using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLToolkit.Data;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DoHome.MobileService
{

    public partial class MobileService : IMobileService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Constants

        private const string LOCATION_ALL_KEY = "DoHome.Location.all-{0}";

        #endregion
        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;
        public MobileService()
        {
            this._cacheManager = new StaticCache();
        }
        private string GetSql(int queryID)
        {
            Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream("DoHome.MobileService.sql.xml");

            XmlDocument doc = new XmlDocument();

            doc.Load(stream);

            XmlNode node = doc.SelectSingleNode(string.Format("/sql/query[@id={0}]", queryID));

            return node != null ? node.InnerText : null;

        }
        private string SystemProductCodeFormated(string productCode)
        {
            int intResult = 0;
            if (int.TryParse(productCode, out intResult))
                return string.Format("{0:00000000}", intResult);
            else
                return productCode;
        }
        private string SapProductCodeFormated(string productCode)
        {
            int intResult = 0;
            if (int.TryParse(productCode, out intResult))
                return string.Format("{0:000000000000000000}", intResult);
            else
                return productCode;
        }
        private string GetProductStockUnit(string branchCode, string productCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand("SELECT StockUnit FROM TBProduct WHERE Code = @ProductCode",
                        db.Parameter("@ProductCode", productCode))
                    .ExecuteScalar<string>();
            }
        }
        private decimal GetProductPrice(string productCode, string unitCode, string branchCode)
        {
            //System.Text.StringBuilder sql = new System.Text.StringBuilder();
            //sql.Append("SELECT TOP 1 SalePrice FROM TBSalePrice ");
            //sql.Append("WHERE ProductCode = @ProductCode ");
            //sql.Append("AND UnitCode = @UnitCode ");
            //sql.Append("AND BranchCode = @BranchCode ");
            //sql.Append("AND GetDate() BETWEEN BeginDate AND EndDate ");
            //sql.Append("ORDER BY CreateDate DESC; ");

            //using (DbManager db = new DbManager(branchCode))
            //{
            //    return db
            //        .SetCommand(sql.ToString(),
            //        db.Parameter("@ProductCode", productCode),
            //        db.Parameter("@UnitCode", unitCode),
            //        db.Parameter("@BranchCode", branchCode))
            //        .ExecuteScalar<decimal>();
            //}

            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(67),
                    db.Parameter("@ProductCode", productCode),
                    db.Parameter("@Uom", unitCode),
                    db.Parameter("@BranchCode", branchCode))
                    .ExecuteScalar<decimal>();
            }
        }
        private double SAPGetBalanceQuantity(string productCode, string warehouseCode, string unitCode, string branchCode)
        {
            using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (SAPProxy.UWProxy prx = new SAPProxy.UWProxy())
                {
                    prx.Connection = sapConnection;
                    double dQty = 0.00;
                    SAPProxy.BAPIRETURN Return = new SAPProxy.BAPIRETURN();
                    SAPProxy.BAPIMGVMATNR Material_Evg = new SAPProxy.BAPIMGVMATNR();
                    SAPProxy.BAPIWMDVETable tbWmdVex = new SAPProxy.BAPIWMDVETable();
                    SAPProxy.BAPIWMDVSTable tbWmdVsx = new SAPProxy.BAPIWMDVSTable();
                    productCode = SapProductCodeFormated(productCode);
                    var checkRule = "B";
                    var itemNumber = "000000";
                    var batch = "";
                    var customer = "";
                    var docNumber = "";
                    string readAtpLockX = "";
                    var wbsElement = "";
                    var stockIndex = "";
                    string dialogFlag = "";
                    var endLeadTime = "";
                    var decForRoundingX = "";
                    var readAtpLock = "";
                    decimal dlAv_Qty_Plt = 0;
                    short decForRounding = 0;
                    prx.Bapi_Material_Availability(batch, checkRule, customer, decForRounding
                                                    , decForRoundingX, docNumber, itemNumber
                                                    , productCode, Material_Evg, branchCode, readAtpLock
                                                    , readAtpLockX, warehouseCode, stockIndex, unitCode
                                                    , wbsElement, out dlAv_Qty_Plt, out dialogFlag
                                                    , out endLeadTime, out Return, ref tbWmdVex, ref tbWmdVsx);

                    foreach (SAPProxy.BAPIWMDVE item in tbWmdVex)
                    {
                        dQty = Convert.ToDouble(item.Com_Qty);
                    }

                    return dQty;
                }
            }
        }
        private string SAPGetLocation(string productCode, string unitCode, string wareHouseCode, string branchCode)
        {
            string location = string.Empty;
            using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (SAPProxy.UWProxy prx = new SAPProxy.UWProxy())
                {
                    productCode = SapProductCodeFormated(productCode);

                    prx.Connection = sapConnection;

                    SAPProxy.ZSTRC_MATERIAL_MASTER strc = new SAPProxy.ZSTRC_MATERIAL_MASTER();
                    SAPProxy.MEANTable MeanTB = new SAPProxy.MEANTable();
                    SAPProxy.MARDTable MardTB = new SAPProxy.MARDTable();
                    SAPProxy.MARATable MaraTB = new SAPProxy.MARATable();
                    SAPProxy.MARMTable MarmTB = new SAPProxy.MARMTable();
                    SAPProxy.ZMM_ASSIGNLOCTable TB_MMLOCATION = new SAPProxy.ZMM_ASSIGNLOCTable();
                    SAPProxy.MLGTTable TB_WHLOCATION = new SAPProxy.MLGTTable();

                    var ProductCode = productCode;
                    var ProductMain = productCode;
                    SAPProxy.MARATable MaraTB2 = new SAPProxy.MARATable();
                    prx.Zdd_Get_Material_Master(ProductCode, out strc, ref MeanTB, ref TB_MMLOCATION, ref MardTB, ref MaraTB2, ref MarmTB, ref TB_WHLOCATION);

                    foreach (SAPProxy.ZMM_ASSIGNLOC item in TB_MMLOCATION)
                    {
                        string sWH = "11";
                        if (branchCode == "1200")
                            sWH = "12";
                        if (item.Unitofmeasure == unitCode && item.Storage_Loc == wareHouseCode)
                        {
                            location = item.Bin_Code;
                            break;
                        }
                        else if (item.Unitofmeasure == unitCode && item.Storage_Loc.Substring(0, 2) == sWH)
                        {
                            location = item.Bin_Code;
                            break;
                        }
                    }

                    foreach (SAPProxy.MLGT item in TB_WHLOCATION)
                    {
                        location = item.Lgpla;
                        break;
                    }



                }
            }

            return location;
        }
        private List<Location> SAPGetLocation(string productCode, string unitCode, string wareHouseCode)
        {
            List<Location> locations = new List<Location>();
            using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (SAPProxy.UWProxy prx = new SAPProxy.UWProxy())
                {
                    var sapProductCode = SapProductCodeFormated(productCode);

                    prx.Connection = sapConnection;

                    SAPProxy.ZSTRC_MATERIAL_MASTER strc = new SAPProxy.ZSTRC_MATERIAL_MASTER();
                    SAPProxy.MEANTable MeanTB = new SAPProxy.MEANTable();
                    SAPProxy.MARDTable MardTB = new SAPProxy.MARDTable();
                    SAPProxy.MARATable MaraTB = new SAPProxy.MARATable();
                    SAPProxy.MARMTable MarmTB = new SAPProxy.MARMTable();
                    SAPProxy.ZMM_ASSIGNLOCTable TB_MMLOCATION = new SAPProxy.ZMM_ASSIGNLOCTable();
                    SAPProxy.MLGTTable TB_WHLOCATION = new SAPProxy.MLGTTable();

                    var ProductCode = productCode;
                    var ProductMain = productCode;
                    SAPProxy.MARATable MaraTB2 = new SAPProxy.MARATable();
                    prx.Zdd_Get_Material_Master(sapProductCode, out strc, ref MeanTB, ref TB_MMLOCATION, ref MardTB, ref MaraTB2, ref MarmTB, ref TB_WHLOCATION);

                    DataTable dt = TB_MMLOCATION.ToADODataTable();
                    string condition = string.Format("Storage_Loc='{0}' AND Unitofmeasure='{1}'", wareHouseCode, unitCode); 
                    DataRow[] rows = dt.Select(condition);
                    foreach (DataRow row in rows)
                    {
                        Location location = new Location();
                        location.Code = row["bin_code"] as string;
                        locations.Add(location);
                    }
                }
            }

            return locations;
        }
        private List<Location> SAPGetLocationAllUnit(string productCode, string unitCode, string wareHouseCode)
        {
            List<Location> locations = new List<Location>();
            using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (SAPProxy.UWProxy prx = new SAPProxy.UWProxy())
                {
                    var sapProductCode = SapProductCodeFormated(productCode);

                    prx.Connection = sapConnection;

                    SAPProxy.ZSTRC_MATERIAL_MASTER strc = new SAPProxy.ZSTRC_MATERIAL_MASTER();
                    SAPProxy.MEANTable MeanTB = new SAPProxy.MEANTable();
                    SAPProxy.MARDTable MardTB = new SAPProxy.MARDTable();
                    SAPProxy.MARATable MaraTB = new SAPProxy.MARATable();
                    SAPProxy.MARMTable MarmTB = new SAPProxy.MARMTable();
                    SAPProxy.ZMM_ASSIGNLOCTable TB_MMLOCATION = new SAPProxy.ZMM_ASSIGNLOCTable();
                    SAPProxy.MLGTTable TB_WHLOCATION = new SAPProxy.MLGTTable();

                    var ProductCode = productCode;
                    var ProductMain = productCode;
                    SAPProxy.MARATable MaraTB2 = new SAPProxy.MARATable();
                    prx.Zdd_Get_Material_Master(sapProductCode, out strc, ref MeanTB, ref TB_MMLOCATION, ref MardTB, ref MaraTB2, ref MarmTB, ref TB_WHLOCATION);

                    DataTable dt = TB_MMLOCATION.ToADODataTable();
                    //เอาหน่วยออก พี่เอ็มแจ้งให้แสดงทุกหน่วยของสินค้า 2012-11-09
                    //string condition = string.Format("Storage_Loc='{0}' AND Unitofmeasure='{1}'", wareHouseCode, unitCode); 
                    string condition = string.Format("Storage_Loc='{0}'", wareHouseCode);
                    DataRow[] rows = dt.Select(condition);
                    foreach (DataRow row in rows)
                    {
                        Location location = new Location();
                        location.Code = row["bin_code"] as string;
                        locations.Add(location);
                    }
                }
            }

            return locations;
        }
        public string ApplicationTitle(string formTitle, string branchCode, string wareHouseName)
        {
            switch (branchCode)
            {
                case "1100":
                    branchCode = "UB";
                    break;
                case "1200":
                    branchCode = "KR";
                    break;
                case "1300":
                    branchCode = "RS";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(wareHouseName))
                wareHouseName = wareHouseName.Insert(0, "-");

            return string.Format("{3}-{0}-{1}{2}", System.Configuration.ConfigurationManager.AppSettings["SapClient"], branchCode, wareHouseName, formTitle);
        }
        public string ApplicationSAPClient()
        {
            return GlobalContext.SapDestination.Client.ToString();
        }
        public string ApplicationSAPServer()
        {
            return GlobalContext.SapDestination.AppServerHost;
        }
        public string AccountingYear()
        {
            return GlobalContext.AccountingYear;
        }
        public DateTime GetServerTime()
        {
            return DateTime.Now;
        }
        public String GetServerTimeString()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
        }     
    }
}
