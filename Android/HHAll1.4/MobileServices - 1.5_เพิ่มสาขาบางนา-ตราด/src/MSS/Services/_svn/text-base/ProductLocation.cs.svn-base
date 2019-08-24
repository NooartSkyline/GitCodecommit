using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.Data;
using System.ServiceModel;
using System.Data;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;
using System.Runtime.Serialization;

namespace DoHome.MobileService
{
    [DataContract]
    [TableName("TBHANDHELDLOCATION")]
    [Serializable]
    public partial class ProductLocation
    {
        [DataMember]
        [MapField("DOCNO"), PrimaryKey]
        public string DocumentNo { get; set; }

        [DataMember]
        [MapField("DOCDATE")]
        public DateTime DocumentDate { get; set; }

        [DataMember]
        [MapField("CREATEDATE")]
        public DateTime CreateDate { get; set; }
        [DataMember]
        [MapField("LOCATION")]
        public string LocationCode { get; set; }
        [DataMember]
        [MapField("PRODUCTCODE")]
        public string ProductCode { get; set; }
        [DataMember]
        [MapField("BARCODE")]
        public string ProductBarcode { get; set; }
        [DataMember]
        [MapField("PRODUCTNAME")]
        public string ProductName { get; set; }
        [DataMember]
        [MapField(), NonUpdatable]
        public decimal PutLevel { get; set; }
        [DataMember]
        [MapField(), NonUpdatable]
        public decimal PutQuantity { get; set; }
        [DataMember]
        [MapField("UNITCODE")]
        public string ProductUnitCode { get; set; }
        [DataMember]
        [MapField("UNITNAME")]
        public string ProductUnitName { get; set; }
        [DataMember]
        [MapField("ROWORDER"), PrimaryKey]
        public int DisplayOrder { get; set; }
        [DataMember]
        [MapField(), NonUpdatable]
        public string LocationType { get; set; }
        [DataMember]
        [MapField("WAREHOUSE")]
        public string WarehouseCode { get; set; }
        [DataMember]
        [MapField(), NonUpdatable]
        public string WarehouseName { get; set; }
        [DataMember]
        [MapField(), NonUpdatable]
        public string StatusText { get; set; }
        [DataMember]
        [MapField(), NonUpdatable]
        public double BalanceQuantity { get; set; }
        [DataMember]
        [MapField(), NonUpdatable]
        public string BalanceQuantityText { get; set; }
        [DataMember]
        [MapField("SYS_PRICE")]
        public decimal SalePrice { get; set; }
        [DataMember]
        [MapField("POS_PRICE")]
        public decimal ShopPrice { get; set; }
        [DataMember]
        [MapIgnore]
        public string RandomText { get; set; }
        [DataMember]
        [MapField("REMARK")]
        public string Remark { get; set; }
        [DataMember]
        [MapField("USERID")]
        public string UserID { get; set; }
        [DataMember]
        [MapField("OFFICERID")]
        public string OfficerID { get; set; }
        [DataMember]
        [MapField("RES_LOCATION")]
        public string LocationStatus { get; set; }
        [DataMember]
        [MapField("RES_PRICE")]
        public string PriceStatus { get; set; }


        //public string BalanceQuantityText
        //{
        //    get
        //    {
        //        if (BalanceQuantityDisplayEmptyText)
        //        {
        //            if (BalanceQuantity != 0)
        //                return BalanceQuantity.ToString("N2");
        //            else
        //                return string.Empty;
        //        }
        //        else
        //        {
        //            return BalanceQuantity.ToString("N2");
        //        }
        //    }
        //}

        //public bool BalanceQuantityDisplayEmptyText { get; set; }
    }

    public partial interface IMobileService
    {
        [OperationContract]
        List<ProductLocation> ProductLocationGetByLocation(string branchCode, string locationCode, string warehouseCode);

        [OperationContract]
        bool ProductLocationAdd(string branchCode, string locationCode, string warehouseCode, List<ProductLocation> productLocation);

        [OperationContract]
        void ProductLocationMixAdd(string branchCode, string warehouseCode, string userCode, List<ProductLocation> productLocations);

        [OperationContract]
        void ProductLocationMixItemAdd(string branchCode, string warehouseCode, string userCode, ProductLocation productLocation);

        [OperationContract]
        void ProductLocationMixItemDelete(string branchCode, string warehouseCode, string locationCode, string userCode, int displayOrder, string productCode, string unitCode);

        [OperationContract]
        List<ProductLocation> ProductLocationMixGetByLocation(string branchCode, string warehouseCode, string locationCode, string userCode);

        [OperationContract]
        ProductLocation ProductLocationGetByBarcode(string barcode, string locationCode, string warehouseCode, string branchCode);

        [OperationContract]
        ProductLocation ProductLocationGetByProductCodeOrBarcode(string productCode, string warehouseCode, string branchCode);

        [OperationContract]
        ProductLocation ProductLocationGetByProductCode(string productCode, string warehouseCode, string branchCode);

        [OperationContract]
        List<ProductLocation> ProductLocationGetAllByBarcode(string barcode, string branchCode, string warehouseCode);

        [OperationContract]
        void ProductLocationBlankAdd(string branchCode, List<ProductLocation> productLocations);

        [OperationContract]
        string ProductLocationAddHandHeldLocation(string branchCode, List<ProductLocation> products);

        [OperationContract]
        List<ProductLocation> ProductLocationGetHandHeldLocation(string branchCode, string locationCode, string employeeCode);

        [OperationContract]
        bool CheckIsCreateLocationToday(string branchCode, string locationCode, string warehouseCode);

        [OperationContract]
        ProductLocation ProductLocationGetInfomationByBarcode(string barcode, string warehouseCode, string branchCode);
    }

    public partial class MobileService : IMobileService
    {

        //public Location LocationGetByCode(string locationCode)
        //{
        //    using (DbManager db = new DbManager())
        //    {
        //        return db
        //            .SetCommand("SELECT * FROM TBUnit Where Code = @UnitCode;",
        //            db.Parameter("@UnitCode", unitCode))
        //            .ExecuteObject<ProductUnit>();
        //    }
        //}

        public List<ProductLocation> ProductLocationGetByLocation(string branchCode, string locationCode, string warehouseCode)
        {

            using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (var prx = new SAPProxyIII.UWProxy())
                {

                    prx.Connection = sapConnection;

                    var Tables = new SAPProxyIII.ZMM_ASSIGNLOCTable();

                    prx.Zdd_Handheld_Get_Zmm_Assignloc(locationCode, warehouseCode, string.Empty, ref Tables);

                    var locations = (List<SAPProxyIII.ZMM_ASSIGNLOC>)CollectionHelper.ConvertTo<SAPProxyIII.ZMM_ASSIGNLOC>(Tables.ToADODataTable());

                    List<ProductLocation> productLocations = new List<ProductLocation>();
                    var productCode = string.Empty;
                    Product product = null;
                    ProductUnit productUnit = null;
                    foreach (var item in locations)
                    {

                        productCode = SystemProductCodeFormated(item.Material);

                        product = GetProductByCode(branchCode, productCode);
                        productUnit = ProductUnitGetByCode(branchCode, item.Unitofmeasure);
                        productLocations.Add(new ProductLocation
                        {
                            LocationCode = item.Bin_Code,
                            ProductCode = productCode,
                            ProductBarcode = GetProductBarcodeByProductCode(branchCode, productCode, item.Unitofmeasure),
                            ProductName = product.NameTh,
                            ProductUnitCode = item.Unitofmeasure,
                            ProductUnitName = productUnit.Name,
                            PutLevel = item.Putlevel,
                            PutQuantity = item.Putqty,
                            DisplayOrder = Convert.ToInt32(item.Roworder)
                        });
                    }

                    productLocations.Sort(delegate(ProductLocation p1, ProductLocation p2) { return p1.DisplayOrder.CompareTo(p2.DisplayOrder); });

                    return productLocations;

                }
            }

        }

        public bool ProductLocationAdd(string branchCode, string locationCode, string warehouseCode, List<ProductLocation> productLocations)
        {
            bool isSaved = false;

            try
            {
                using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (SAPProxyII.UWProxy prx = new SAPProxyII.UWProxy())
                    {
                        prx.Connection = sapConnection;

                        SAPProxyII.ZMM_ASSIGNLOCTable productLocationTable = new SAPProxyII.ZMM_ASSIGNLOCTable();


                        // clear old data in SAP.
                        prx.Zdd_Handheld_Del_Zmm_Assignloc(locationCode, warehouseCode, ref productLocationTable);

                        foreach (var item in productLocations)
                        {
                            if (string.IsNullOrEmpty(item.ProductCode))
                            {
                                var product = ProductBarcodeGetByProductCodeOrBarcode3(branchCode, item.ProductBarcode);
                                if (product == null)
                                    continue;
                                item.ProductCode = product.ProductCode;
                                item.ProductUnitCode = product.UnitCode;
                            }

                            productLocationTable = new SAPProxyII.ZMM_ASSIGNLOCTable();
                            prx.Zdd_Handheld_Set_Zmm_Assignloc(locationCode,
                                "X",
                                item.LocationType,
                                SapProductCodeFormated(item.ProductCode),
                                item.PutLevel,
                                item.PutQuantity,
                                item.DisplayOrder,
                                warehouseCode,
                                item.ProductUnitCode,
                                ref productLocationTable);
                        }

                        isSaved = true;
                    }
                }
            }
            catch
            {
                isSaved = false;
            }

            return isSaved;
        }

        public ProductLocation ProductLocationGetByBarcode(string barcode, string locationCode, string warehouseCode, string branchCode)
        {
            var product = ProductBarcodeGetByProductCodeOrBarcode3(branchCode, barcode);
            if (product == null)
                return null;

            ProductLocation productLocation = new ProductLocation();

            using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (SAPProxyII.UWProxy prx = new SAPProxyII.UWProxy())
                {
                    prx.Connection = sapConnection;

                    SAPProxyII.ZMM_ASSIGNLOCTable tables = new SAPProxyII.ZMM_ASSIGNLOCTable();
                    prx.Zdd_Handheld_Set_Zmm_Assignloc(locationCode, "", "", "", 0, 0, 0, "", "", ref tables);
                    DataTable locationTable = tables.ToADODataTable();

                    string productCode = SapProductCodeFormated(product.ProductCode);

                    var condition = new StringBuilder();
                    condition.AppendFormat(" STORAGE_LOC='{0}'", warehouseCode);
                    condition.AppendFormat(" AND BIN_CODE='{0}'", locationCode);
                    condition.AppendFormat(" AND MATERIAL='{0}'", productCode);
                    condition.AppendFormat(" AND UNITOFMEASURE='{0}'", product.UnitCode);

                    var rows = locationTable.Select(condition.ToString());
                    if (rows.Length > 0)
                        productLocation.StatusText = "พบ";
                    else
                        productLocation.StatusText = "ไม่พบ";
                }
            }

            productLocation.LocationCode = locationCode;
            productLocation.ProductCode = product.ProductCode;
            productLocation.ProductName = product.ProductName;
            productLocation.ProductBarcode = product.Barcode;
            productLocation.ProductUnitCode = product.UnitCode;
            productLocation.ProductUnitName = product.UnitName;

            return productLocation;
        }

        //public List<DisplayList> ProductLocationGetDisplayList(string createUser)
        //{
        //    using (DbManager db = new DbManager())
        //    {
        //        return db
        //            .SetCommand(GetSql(1),
        //            db.Parameter("@CreateUser", createUser))
        //            .ExecuteList<DisplayList>();
        //    }
        //}

        public void ProductLocationMixAdd(string branchCode, string warehouseCode, string userCode, List<ProductLocation> productLocations)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                try
                {
                    int displayOrder = db.SetCommand(GetSql(3),
                        db.Parameter("@LocationCode", productLocations[0].LocationCode),
                        db.Parameter("@CreatedBy", userCode)).ExecuteScalar<int>();
                    db.BeginTransaction();
                    string sql = GetSql(2);
                    string departmentCode;
                    string departmentName;
                    foreach (var item in productLocations)
                    {
                        departmentCode = null;
                        departmentName = null;
                        var department = SapDepartmentGetByLocationCode(branchCode, warehouseCode, item.LocationCode);
                        if (department != null && department.Count > 0)
                        {
                            departmentCode = department[0].DepartmentCode;
                            departmentName = department[0].DepartmentName;
                        }

                        db.SetCommand(sql,
                        db.Parameter("@BRANCHCODE", branchCode),
                        db.Parameter("@WAREHOUSE", warehouseCode),
                        db.Parameter("@LOCATION", item.LocationCode),
                        db.Parameter("@ROWORDER", displayOrder),
                        db.Parameter("@PRODUCTCODE", item.ProductCode),
                        db.Parameter("@PRODUCTNAME", item.ProductName),
                        db.Parameter("@UNITCODE", item.ProductUnitCode),
                        db.Parameter("@BARCODE", item.ProductBarcode),
                        db.Parameter("@DOCDATE", DateTime.Today),
                        db.Parameter("@STATUS", item.StatusText == "พบ" ? "FOUND" : "NOT FOUND"),
                        db.Parameter("@OFFICERID", item.OfficerID),
                        db.Parameter("@CREATEUSER", userCode),
                        db.Parameter("@DepartmentCode", departmentCode),
                        db.Parameter("@DepartmentName", departmentName))
                        .ExecuteNonQuery();

                        displayOrder++;
                    }

                    db.CommitTransaction();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public void ProductLocationMixItemAdd(string branchCode, string warehouseCode, string userCode, ProductLocation productLocation)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                try
                {
                    int displayOrder = db.SetCommand(GetSql(3)).ExecuteScalar<int>();
                    db.BeginTransaction();

                    db.SetCommand(GetSql(2),
                    db.Parameter("@BRANCHCODE", branchCode),
                    db.Parameter("@WAREHOUSE", warehouseCode),
                    db.Parameter("@LOCATION", productLocation.LocationCode),
                    db.Parameter("@ROWORDER", displayOrder),
                    db.Parameter("@PRODUCTCODE", productLocation.ProductCode),
                    db.Parameter("@PRODUCTNAME", productLocation.ProductName),
                    db.Parameter("@UNITCODE", productLocation.ProductUnitCode),
                    db.Parameter("@BARCODE", productLocation.ProductBarcode),
                    db.Parameter("@DOCDATE", DateTime.Today),
                    db.Parameter("@STATUS", productLocation.StatusText == "พบ" ? "FOUND" : "NOT FOUND"),
                    db.Parameter("@OFFICERID", null),
                    db.Parameter("@CREATEUSER", userCode))
                    .ExecuteNonQuery();

                    db.CommitTransaction();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public void ProductLocationMixItemDelete(string branchCode, string warehouseCode, string locationCode, string userCode, int displayOrder, string productCode, string unitCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                //db.BeginTransaction();

                db.SetCommand(GetSql(37),
                   db.Parameter("@BranchCode", branchCode),
                   db.Parameter("@WarehouseCode", warehouseCode),
                   db.Parameter("@LocationCode", locationCode),
                   db.Parameter("@ProductCode", productCode),
                   db.Parameter("@UnitCode", unitCode),
                   db.Parameter("@UserCode", userCode),
                   db.Parameter("@RowOrder", displayOrder))
                   .ExecuteNonQuery();

                displayOrder = 0;
                var productLocations = ProductLocationMixGetByLocation(branchCode, warehouseCode, locationCode, userCode);
                db.BeginTransaction();
                foreach (var item in productLocations)
                {
                    db.SetCommand(GetSql(38),
                    db.Parameter("@RowOrder", displayOrder),
                    db.Parameter("@BranchCode", branchCode),
                    db.Parameter("@WarehouseCode", item.WarehouseCode),
                    db.Parameter("@LocationCode", item.LocationCode),
                    db.Parameter("@ProductCode", item.ProductCode),
                    db.Parameter("@UnitCode", item.ProductUnitCode),
                    db.Parameter("@UserCode", userCode))
                    .ExecuteNonQuery();

                    displayOrder++;
                }

                db.CommitTransaction();
            }
        }

        public List<ProductLocation> ProductLocationMixGetByLocation(string branchCode, string warehouseCode, string locationCode, string userCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(36),
                    db.Parameter("@BranchCode", branchCode),
                    db.Parameter("@WarehouseCode", warehouseCode),
                    db.Parameter("@LocationCode", locationCode),
                    db.Parameter("@UserCode", userCode))
                    .ExecuteList<ProductLocation>();
            }
        }

        public List<ProductLocation> ProductLocationGetAllByBarcode(string barcode, string branchCode, string warehouseCode)
        {
            List<ProductLocation> productLocations = new List<ProductLocation>();

            using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (SAPProxyII.UWProxy prx = new SAPProxyII.UWProxy())
                {
                    prx.Connection = sapConnection;
                    var productBarcode = ProductBarcodeGetByBarcode(barcode, branchCode);
                    var sapProductCode = SapProductCodeFormated(productBarcode.ProductCode);

                    SAPProxyII.MARDTable Tables = new SAPProxyII.MARDTable();
                    prx.Zdd_Handheld_Get_Mard(sapProductCode, ref Tables);
                    string branchCodePrefix = branchCode.Substring(0, 2);
                    double balanceQuantity1 = 0;
                    double balanceQuantity2 = 0;
                    List<Location> locations = null;
                    int index = 0;
                    // old logic by P' Tommy
                    foreach (SAPProxyII.MARD tbl in Tables)
                    {
                        if (tbl.Werks.Substring(2, 2) != "99" && tbl.Werks.Substring(0, 2) == branchCodePrefix)
                        {
                            var productLocation = new ProductLocation();
                            productLocation.ProductUnitCode = productBarcode.UnitCode;
                            productLocation.ProductUnitName = productBarcode.UnitName;
                            productLocation.WarehouseCode = tbl.Lgort;
                            productLocation.WarehouseName = WareHouseGetSingle(tbl.Lgort, branchCode).Name;
                            balanceQuantity1 = SAPGetBalanceQuantity(productBarcode.ProductCode, tbl.Lgort, productBarcode.UnitCode, branchCodePrefix + "00");
                            balanceQuantity2 = SAPGetBalanceQuantity(productBarcode.ProductCode, tbl.Lgort, productBarcode.UnitCode, branchCodePrefix + "99");

                            //productLocation.LocationCode = location.Code;
                            productLocation.BalanceQuantity = (balanceQuantity1 + balanceQuantity2);
                            productLocation.BalanceQuantityText = productLocation.BalanceQuantity.ToString("N2");
                            productLocations.Add(productLocation);

                            locations = SAPGetLocation(productBarcode.ProductCode, productBarcode.UnitCode, tbl.Lgort);
                            index = 0;
                            foreach (var location in locations)
                            {

                                //productLocation = productLocations.Find(p => p.WarehouseCode == location.Code);

                                if (index == 0)
                                {
                                    productLocation.LocationCode = location.Code;
                                    //balanceQuantity1 = SAPGetBalanceQuantity(productBarcode.ProductCode, location.Code, productBarcode.UnitCode, branchCodePrefix + "00");
                                    //balanceQuantity2 = SAPGetBalanceQuantity(productBarcode.ProductCode, location.Code, productBarcode.UnitCode, branchCodePrefix + "99");
                                    //productLocation.BalanceQuantity = (balanceQuantity1 + balanceQuantity2);
                                }
                                else
                                {
                                    productLocation = new ProductLocation();
                                    productLocation.BalanceQuantityText = string.Empty;
                                    //productLocation.WarehouseCode = tbl.Lgort;
                                    //productLocation.WarehouseName = WareHouseGetSingle(tbl.Lgort, branchCode).Name;
                                    productLocation.LocationCode = location.Code;
                                    //balanceQuantity1 = SAPGetBalanceQuantity(productBarcode.ProductCode, location.Code, productBarcode.UnitCode, branchCodePrefix + "00");
                                    //balanceQuantity2 = SAPGetBalanceQuantity(productBarcode.ProductCode, location.Code, productBarcode.UnitCode, branchCodePrefix + "99");
                                    //productLocation.BalanceQuantity = (balanceQuantity1 + balanceQuantity2);
                                    productLocations.Add(productLocation);
                                }
                                //if (index == 0)
                                //{
                                //    productLocation = productLocations.Find(p => p.WarehouseCode == location.Code);
                                //}
                                //else {
                                //    productLocation = new ProductLocation();
                                //    productLocation.WarehouseCode = tbl.Lgort;
                                //    productLocation.WarehouseName = WareHouseGetSingle(tbl.Lgort, branchCode).Name;
                                //    balanceQuantity1 = SAPGetBalanceQuantity(productBarcode.ProductCode, location.Code, productBarcode.UnitCode, branchCodePrefix + "00");
                                //    balanceQuantity2 = SAPGetBalanceQuantity(productBarcode.ProductCode, location.Code, productBarcode.UnitCode, branchCodePrefix + "99");

                                //    productLocation.LocationCode = location.Code;
                                //    productLocation.BalanceQuantity = (balanceQuantity1 + balanceQuantity2);
                                //    productLocations.Add(productLocation);
                                //}

                                index++;
                            }

                        }
                    }

                }
            }

            //var productBarcode = ProductBarcodeGetByBarcode(barcode);
            //List<ProductLocation> productLocations = new List<ProductLocation>();
            //var productLocation = new ProductLocation();
            //productLocation.LocationCode = SAPGetLocation(productBarcode.ProductCode, productBarcode.UnitCode, warehouseCode, branchCode);
            //productLocation.BalanceQuantity = SAPGetBalanceQuantity(productBarcode.ProductCode, warehouseCode, productBarcode.UnitCode, branchCode);
            //productLocation.ProductUnitCode = productBarcode.UnitCode;
            //productLocation.ProductUnitName = productBarcode.UnitName;
            //productLocations.Add(productLocation);

            return productLocations;

        }

        public void ProductLocationBlankAdd(string branchCode, List<ProductLocation> productLocations)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                try
                {
                    db.BeginTransaction();

                    string unitCode = null; ;

                    foreach (var item in productLocations)
                    {
                        if (!string.IsNullOrEmpty(item.ProductUnitCode))
                        {
                            unitCode = item.ProductUnitCode;
                            break;
                        }
                    }

                    if (unitCode == null)
                        throw new Exception("ProductUnitCode Is Null");

                    // delete old
                    db.SetCommand(GetSql(7),
                    db.Parameter("@DOCDATE", DateTime.Today),
                    db.Parameter("@PRODUCTCODE", productLocations[0].ProductCode),
                    db.Parameter("@UNITCODE", unitCode)).ExecuteNonQuery();

                    int displayOrder = 0;
                    foreach (var item in productLocations)
                    {
                        db.SetCommand(GetSql(8),
                        db.Parameter("@DOCDATE", DateTime.Today),
                        db.Parameter("@PRODUCTCODE", item.ProductCode),
                        db.Parameter("@ROWORDER", displayOrder),
                        db.Parameter("@UNITCODE", unitCode),//item.ProductUnitCode),
                        db.Parameter("@PRODUCTNAME", item.ProductName),
                        db.Parameter("@WAREHOUSE", item.WarehouseCode),
                        db.Parameter("@QTY", item.BalanceQuantity),
                        db.Parameter("@LOCATION", item.LocationCode))
                        .ExecuteNonQuery();

                        displayOrder++;
                    }

                    db.CommitTransaction();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public ProductLocation ProductLocationGetByProductCodeOrBarcode(string productCodeOrBarcode, string warehouseCode, string branchCode)
        {
            ProductLocation product = null;
            product = ProductLocationGetInfomationByBarcode(productCodeOrBarcode, warehouseCode, branchCode);
            if (product == null)
                product = ProductLocationGetByProductCode(productCodeOrBarcode, warehouseCode, branchCode);

            return product;
        }

        public ProductLocation ProductLocationGetByProductCode(string productCode, string warehouseCode, string branchCode)
        {
            ProductLocation product = null;
            using (DbManager db = new DbManager(branchCode))
            {
                try
                {
                    product = db.SetCommand(GetSql(11), db.Parameter("@ProductCode", productCode)).ExecuteObject<ProductLocation>();
                    if (product != null)
                    {
                        product.SalePrice = GetProductPrice(product.ProductCode, product.ProductUnitCode, branchCode);
                        product.LocationCode = SAPGetLocation(product.ProductCode, product.ProductUnitCode, warehouseCode, branchCode);
                        product.RandomText = "********";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return product;
            }
        }

        public ProductLocation ProductLocationGetInfomationByBarcode(string barcode, string warehouseCode, string branchCode)
        {
            ProductLocation product = null;
            using (DbManager db = new DbManager(branchCode))
            {
                try
                {
                    product = db.SetCommand(GetSql(15), db.Parameter("@Barcode", barcode)).ExecuteObject<ProductLocation>();
                    if (product != null)
                    {
                        product.SalePrice = GetProductPrice(product.ProductCode, product.ProductUnitCode, branchCode);
                        product.LocationCode = SAPGetLocation(product.ProductCode, product.ProductUnitCode, warehouseCode, branchCode);
                        product.RandomText = "********";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return product;
            }
        }

        private string ProductLocationHandHeldLocationGetDocumentNo(string branchCode)
        {
            var documentNo = string.Empty;

            using (DbManager db = new DbManager(branchCode))
            {
                documentNo = db.SetCommand(GetSql(13)).ExecuteScalar<string>();
            }

            var culture = new System.Globalization.CultureInfo("th-TH");
            int index = 1;
            if (!string.IsNullOrEmpty(documentNo))
                index = Convert.ToInt32(documentNo) + 1;

            documentNo = string.Format("CK{0}-{1:0000}", DateTime.Now.Date.ToString("yyMMdd", culture), index);

            return documentNo;
        }

        public string ProductLocationAddHandHeldLocation(string branchCode, List<ProductLocation> products)
        {
            var documentNo = string.Empty;
            if (string.IsNullOrEmpty(products[0].DocumentNo))
                documentNo = ProductLocationHandHeldLocationGetDocumentNo(branchCode);
            else
                documentNo = products[0].DocumentNo;

            var createdDate = DateTime.Now;
            var createdDateFormat = createdDate.ToString("yyyy.MM.dd", new System.Globalization.CultureInfo("en-US"));
            var createdTimeFormat = createdDate.ToString("HH:mm:ss");
            int displayOrder = 0;
            var isContains = false;

            SAPProxyII.ZHANDHELD_LOCTable locationTable = new SAPProxyII.ZHANDHELD_LOCTable();

            using (DbManager db = new DbManager(branchCode))
            {
                try
                {
                    SqlQuery<ProductLocation> productQuery = new SqlQuery<ProductLocation>(db);
                    db.BeginTransaction();

                    //Clear old data for location and employee.
                    db.SetCommand(GetSql(40)
                       , db.Parameter("@DocumentNo", documentNo))
                      .ExecuteNonQuery();

                    foreach (var item in products)
                    {
                        // modify for offline mode.
                        if (string.IsNullOrEmpty(item.ProductCode))
                        {
                            var product = ProductBarcodeGetByProductCodeOrBarcode3(branchCode, item.ProductBarcode);
                            if (product == null)//if not exists skip to next row.
                                continue;

                            item.SalePrice = GetProductPrice(product.ProductCode, product.UnitCode, branchCode);
                            item.ProductCode = product.ProductCode;
                            item.ProductName = product.ProductName;
                            item.ProductUnitCode = product.UnitCode;
                            item.ProductUnitName = product.UnitName;
                        }

                        if (item.SalePrice != item.ShopPrice)
                            item.PriceStatus = "ราคาไม่ตรง";
                        else
                            item.PriceStatus = "ราคาถูกต้อง";

                        isContains = SapLocationGetIsContains(item.ProductCode, item.ProductUnitCode, item.LocationCode, item.WarehouseCode, out displayOrder);
                        if (!isContains)
                        {
                            item.LocationStatus = "ไม่พบสินค้าในตำแหน่งนี้";
                        }
                        else
                        {
                            if (displayOrder == item.DisplayOrder)
                                item.LocationStatus = "ตำแหน่งถูกต้อง";
                            else
                                item.LocationStatus = "ลำดับไม่ตรง";
                        }

                        item.DocumentNo = documentNo;
                        item.DocumentDate = createdDate.Date;
                        item.CreateDate = createdDate;
                        item.Remark = string.Concat(item.PriceStatus, ",", item.LocationStatus);
                        var locationItem = new SAPProxyII.ZHANDHELD_LOC();
                        locationItem.Docno = documentNo;
                        //string sDocDate = DateTime.Today.Year.ToString() + DateTime.Today.ToString(".MM.dd");
                        //string sTime = DateTime.Now.ToString("HH:mm:ss");
                        locationItem.Docdate = createdDateFormat;
                        locationItem.Createdate = createdDateFormat;
                        locationItem.Createtime = createdTimeFormat;
                        locationItem.Roworder = item.DisplayOrder;
                        locationItem.Productcode = item.ProductCode;// SapProductCodeFormated(item.ProductCode);
                        locationItem.Productname = item.ProductName;
                        locationItem.Warehouse = item.WarehouseCode;
                        locationItem.Location = item.LocationCode;
                        locationItem.Unitcode = item.ProductUnitCode;
                        locationItem.Unitname = item.ProductUnitName;
                        locationItem.Barcode = item.ProductBarcode;
                        locationItem.Sys_Price = item.SalePrice;
                        locationItem.Pos_Price = item.ShopPrice;
                        locationItem.Remark = item.Remark;
                        locationItem.Userid = item.UserID;
                        locationItem.Officerid = item.OfficerID;
                        locationItem.Res_Location = item.LocationStatus;
                        locationItem.Res_Price = item.PriceStatus;

                        locationTable.Add(locationItem);

                        productQuery.Insert(item);

                        displayOrder = 0;
                    }

                    //commit transaction to SQL Server.
                    db.CommitTransaction();

                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    throw ex;
                }

                using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (var prx = new SAPProxyII.UWProxy())
                    {
                        prx.Connection = sapConnection;
                        prx.Zdd_Export_Tbhandheldlocation(ref locationTable);
                    }
                }
            }

            return documentNo;
        }


        //public void ProductLocationAddHandHeldLocationTransferToSql(string locationCode,string employeeCode,List<ProductLocation> products)
        //{
        //    var documentNo = ProductLocationHandHeldLocationGetDocumentNo();
        //    var createdDate = DateTime.Now;
        //    int putQuantity = 0;
        //    var isContains = false;

        //    SAPProxyII.ZHANDHELD_LOCTable locationTable = new SAPProxyII.ZHANDHELD_LOCTable();

        //    using (DbManager db = new DbManager())
        //    {
        //        try
        //        {
        //            SqlQuery<ProductLocation> productQuery = new SqlQuery<ProductLocation>(db);
        //            db.BeginTransaction();

        //            // Clear old data for location and employee.
        //            db.SetCommand(GetSql(40)
        //               , db.Parameter("@LocationCode", locationCode)
        //               , db.Parameter("@EmployeeCode", employeeCode))
        //              .ExecuteNonQuery();

        //            foreach (var item in products)
        //            {
        //                if (item.SalePrice != item.ShopPrice)
        //                    item.PriceStatus = "ราคาไม่ตรง";
        //                else
        //                    item.PriceStatus = "ราคาถูกต้อง";

        //                isContains = SapLocationGetIsContains(item.ProductCode, item.ProductUnitCode, item.LocationCode, item.WarehouseCode, out putQuantity);
        //                if (!isContains)
        //                {
        //                    item.LocationStatus = "ไม่พบสินค้าในตำแหน่งนี้";
        //                }
        //                else
        //                {
        //                    if (putQuantity == item.DisplayOrder)
        //                        item.LocationStatus = "ตำแหน่งถูกต้อง";
        //                    else
        //                        item.LocationStatus = "ลำดับไม่ตรง";
        //                }

        //                item.DocumentNo = documentNo;
        //                item.DocumentDate = createdDate.Date;
        //                item.CreateDate = createdDate;

        //                var locationItem = new SAPProxyII.ZHANDHELD_LOC();
        //                locationItem.Docno = documentNo;
        //                //string sDocDate = DateTime.Today.Year.ToString() + DateTime.Today.ToString(".MM.dd");
        //                //string sTime = DateTime.Now.ToString("HH:mm:ss");
        //                locationItem.Docdate = createdDate.ToString("yyyy.MM.dd");
        //                locationItem.Createdate = createdDate.ToString("yyyy.MM.dd");
        //                locationItem.Createtime = createdDate.ToString("HH:mm:ss");
        //                locationItem.Roworder = item.DisplayOrder;
        //                locationItem.Productcode = item.ProductCode;
        //                locationItem.Productname = item.ProductName;
        //                locationItem.Warehouse = item.WarehouseCode;
        //                locationItem.Location = item.LocationCode;
        //                locationItem.Unitcode = item.ProductUnitCode;
        //                locationItem.Unitname = item.ProductUnitName;
        //                locationItem.Barcode = item.ProductBarcode;
        //                locationItem.Sys_Price = item.SalePrice;
        //                locationItem.Pos_Price = item.ShopPrice;
        //                locationItem.Remark = item.Remark;
        //                locationItem.Userid = item.UserID;
        //                locationItem.Officerid = item.OfficerID;
        //                locationItem.Res_Location = item.LocationStatus;
        //                locationItem.Res_Price = item.PriceStatus;

        //                locationTable.Add(locationItem);

        //                productQuery.Insert(item);
        //            }

        //            //commit transaction to SQL Server.
        //            db.CommitTransaction();
        //        }
        //        catch (Exception ex)
        //        {
        //            db.RollbackTransaction();
        //            throw ex;
        //        }
        //    }
        //}

        //public void ProductLocationAddHandHeldLocationTransferToSap(string locationCode, string employeeCode)
        //{
        //    SAPProxyII.ZHANDHELD_LOCTable locationTable = new SAPProxyII.ZHANDHELD_LOCTable();

        //    using (DbManager db = new DbManager())
        //    {
        //        try
        //        {
        //            var products = db.SetCommand(GetSql(39)
        //                 , db.Parameter("@LocationCode", locationCode)
        //                 , db.Parameter("@EmployeeCode", employeeCode))
        //                .ExecuteList<ProductLocation>();

        //            foreach (var item in products)
        //            {

        //                var locationItem = new SAPProxyII.ZHANDHELD_LOC();
        //                locationItem.Docno = item.DocumentNo;
        //                locationItem.Docdate = item.CreateDate.ToString("yyyy.MM.dd");
        //                locationItem.Createdate = item.CreateDate.ToString("yyyy.MM.dd");
        //                locationItem.Createtime = item.CreateDate.ToString("HH:mm:ss");
        //                locationItem.Roworder = item.DisplayOrder;
        //                locationItem.Productcode = item.ProductCode;
        //                locationItem.Productname = item.ProductName;
        //                locationItem.Warehouse = item.WarehouseCode;
        //                locationItem.Location = item.LocationCode;
        //                locationItem.Unitcode = item.ProductUnitCode;
        //                locationItem.Unitname = item.ProductUnitName;
        //                locationItem.Barcode = item.ProductBarcode;
        //                locationItem.Sys_Price = item.SalePrice;
        //                locationItem.Pos_Price = item.ShopPrice;
        //                locationItem.Remark = item.Remark;
        //                locationItem.Userid = item.UserID;
        //                locationItem.Officerid = item.OfficerID;
        //                locationItem.Res_Location = item.LocationStatus;
        //                locationItem.Res_Price = item.PriceStatus;

        //                locationTable.Add(locationItem);

        //            }

        //            using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
        //            {
        //                using (var prx = new SAPProxyII.UWProxy())
        //                {
        //                    prx.Connection = sapConnection;

        //                    prx.Zdd_Export_Tbhandheldlocation(ref locationTable);
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            db.RollbackTransaction();
        //            throw ex;
        //        }
        //    }
        //}

        public List<ProductLocation> ProductLocationGetHandHeldLocation(string branchCode, string locationCode, string employeeCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(39)
                        , db.Parameter("@LocationCode", locationCode)
                        , db.Parameter("@EmployeeCode", employeeCode))
                       .ExecuteList<ProductLocation>();
            }
        }

        private bool SapLocationGetIsContains(string productCode, string unitCode, string locationCode, string warehouseCode, out int displayOrder)
        {
            bool isContain = false;
            displayOrder = 0;
            using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (SAPProxyII.UWProxy prx = new SAPProxyII.UWProxy())
                {
                    prx.Connection = sapConnection;

                    SAPProxyII.ZMM_ASSIGNLOCTable tables = new SAPProxyII.ZMM_ASSIGNLOCTable();
                    prx.Zdd_Handheld_Set_Zmm_Assignloc(locationCode, "", "", "", 0, 0, 0, "", "", ref tables);
                    DataTable locationTable = tables.ToADODataTable();


                    string sapProductCode = SapProductCodeFormated(productCode);

                    var condition = new StringBuilder();
                    condition.AppendFormat(" STORAGE_LOC='{0}'", warehouseCode);
                    condition.AppendFormat(" AND BIN_CODE='{0}'", locationCode);
                    condition.AppendFormat(" AND MATERIAL='{0}'", sapProductCode);
                    condition.AppendFormat(" AND UNITOFMEASURE='{0}'", unitCode);

                    var rows = locationTable.Select(condition.ToString());
                    if (rows.Length > 0)
                    {
                        isContain = true;
                        displayOrder = Convert.ToInt32(rows[0]["ROWORDER"]);
                    }
                    else
                        isContain = false;


                }
            }


            return isContain;
        }

        public bool CheckIsCreateLocationToday(string branchCode, string locationCode, string warehouseCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(14), db.Parameter("@LocationCode", locationCode), db.Parameter("@WarehouseCode", warehouseCode)).ExecuteScalar<bool>();
            }
        }


    }
}
