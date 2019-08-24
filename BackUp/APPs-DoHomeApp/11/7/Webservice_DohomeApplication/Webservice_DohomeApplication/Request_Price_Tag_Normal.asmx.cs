using Newtonsoft.Json;
using SourceCode.SmartObjects.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Webservice_DohomeApplication
{
    /// <summary>
    /// Summary description for Request_Price_Tag_Normal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Request_Price_Tag_Normal : System.Web.Services.WebService
    {
        public string Connect = System.Configuration.ConfigurationManager.ConnectionStrings["DBMASTERConnectionString"].ConnectionString;
        private SmartObjectClientServer K2_CONNECT_SERVER()
        {
            DataSet ds = new DataSet();
            SmartObjectClientServer serverName = new SmartObjectClientServer();
            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();
            connectionString.Authenticate = true;
            connectionString.Host = System.Configuration.ConfigurationManager.AppSettings["K2Server"];
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = Convert.ToUInt32(System.Configuration.ConfigurationManager.AppSettings["Port"].ToString());
            connectionString.UserID = System.Configuration.ConfigurationManager.AppSettings["K2User"];
            connectionString.WindowsDomain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            connectionString.Password = System.Configuration.ConfigurationManager.AppSettings["K2Password"];
            connectionString.SecurityLabelName = System.Configuration.ConfigurationManager.AppSettings["SecurityLabel"];
            serverName.CreateConnection();
            serverName.Connection.Open(connectionString.ToString());
            return serverName;
        }


        [WebMethod]
        public string Search_TBMaster_Print_Label_Type()
        {
            DataTable dt = new DataTable();
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            string strsql = "SELECT * FROM DBMASTER..TBMaster_Print_Label_Type where LTYPE = '0' or LTYPE = '1'";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "TBMaster_Print_Label_Type", ref cnn);
            //if (ret)
            //{
            //    if (ds.Tables["tbl"].Rows.Count > 0)
            //    {
            //        ds.Tables.Add(dt);
            //    }
            //}
            return ConvertDataSetToJSON(ds);
        }

        [WebMethod]
        public string Search_TBMaster_Print_Label_Type_By_LType(string LTYPE)
        {
            DataTable dt = new DataTable();
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            string strsql = " SELECT * FROM DBMASTER..TBMaster_Print_Label_Type where LTYPE = '" + LTYPE + "'";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "TBMaster_Print_Label_Type", ref cnn);
            //if (ret)
            //{
            //    if (ds.Tables["tbl"].Rows.Count > 0)
            //    {
            //        ds.Tables.Add(dt);
            //    }
            //}
            return ConvertDataSetToJSON(ds);
        }

        [WebMethod]
        public string Search_TBMaster_Print_Label_Reason()
        {
            DataTable dt = new DataTable();
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            string strsql = "SELECT * FROM DBMASTER..TBMaster_Print_Label_Reason";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "TBMaster_Print_Label_Reason", ref cnn);
            //if (ret)
            //{
            //    if (ds.Tables["TBMaster_Print_Label_Reason"].Rows.Count > 0)
            //    {
            //        ds.Tables.Add(dt);
            //    }
            //}
            return ConvertDataSetToJSON(ds);
        }

        [WebMethod]
        public string SearchProductByProductCode(string sProductCode, string sSite, string sUnitCode)
        {
            DataTable dt = new DataTable();
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            DataSet objdds = new DataSet();
            string strsql = "select prd.code as productcode, prd.nameth as productname, pun.unitcode, unt.myname as unitname, pun.unitrate, bar.barcode " +
                            "   , 0.00 as unitprice, '' as location, '' as matkl, {fn curdate()} as pricedate " +
                            "from dbmaster..tbmaster_product prd " +
                            "   inner join dbmaster..TBMaster_Product_Unit pun on prd.code = pun.productcode " +
                            "   left join dbmaster..TBMaster_Unit unt on pun.unitcode = unt.code " +
                            "   left join dbmaster..TBMaster_barcode bar on pun.productcode = bar.productcode and pun.unitcode = bar.unitcode " +
                            "where prd.code = '" + sProductCode + "' and pun.unitcode = '" + sUnitCode + "' " +
                            "order by pun.unitrate ";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
            if (ret)
            {
                dt = ds.Tables["tbl"];
                if (ds.Tables["tbl"].Rows.Count > 0)
                {

                    DataRow drow = ds.Tables["tbl"].Rows[0];
                    DataTable objdt = new DataTable();
                    objdt.Columns.Add("PriceDate", typeof(string));
                    objdt.Columns.Add("ProductCode", typeof(string));
                    objdt.Columns.Add("Barcode", typeof(string));
                    objdt.Columns.Add("ProductName", typeof(string));
                    objdt.Columns.Add("UnitName", typeof(string));
                    objdt.Columns.Add("Location", typeof(string));
                    objdt.Columns.Add("UnitPrice", typeof(double));
                    objdt.Columns.Add("ArticleHierarchy", typeof(string));

                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow row = objdt.NewRow();
                        row["PriceDate"] = Convert.ToDateTime(dr["Pricedate"].ToString()).ToString("dd/MM/yyyy");
                        row["ProductCode"] = dr["productcode"].ToString();
                        row["Barcode"] = dr["barcode"].ToString();
                        row["ProductName"] = dr["productname"].ToString();
                        row["UnitName"] = dr["unitname"].ToString();
                        row["Location"] = ""; // Location
                        row["ArticleHierarchy"] = ""; // ArticleHierarchy

                        DateTime dtPriceDate = DateTime.Today;

                        double dUnitPrice = this.OnGetSalePrice(sSite, sProductCode, sUnitCode, "0000"); // ส่ง sSite
                        row["UnitPrice"] = dUnitPrice;

                        objdt.Rows.Add(row);
                    }
                    objdt.TableName = "TB_Pre_Print_Label";
                    objdds.Tables.Add(objdt);
                }
            }
            return ConvertDataSetToJSON(objdds);
        }

        [WebMethod]
        public string OnSearchByBarcode(string sBarcode, string sSite, string sUnitCode)
        {
            string sResult = "";
            try
            {
                dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
                SqlConnection cnn = devdb.getSqlConncetion;
                DataSet objds = new DataSet();
                string strsql = "select * " +
                                "from dbmaster..tbmaster_barcode bar " +
                                "where barcode = '" + sBarcode + "' and unitcode = '" + sUnitCode + "' ";
                bool ret = devdb.ExecuteCommand(ref objds, strsql, "tbl", ref cnn);
                cnn.Close();
                if (ret)
                {
                    if (objds.Tables["tbl"].Rows.Count > 0)
                    {
                        DataRow dr = objds.Tables["tbl"].Rows[0];
                        string sProductCode = dr["productcode"].ToString();

                        sResult = this.SearchProductByProductCode(sProductCode, sSite, sUnitCode);
                    }
                    else
                    {
                        sResult = "ไม่พบบาร์โค้ดที่ค้นหา";
                    }
                }
            }
            catch (Exception ex)
            {
                sResult = ex.Message.ToString();
            }
            return sResult;
        }

        [WebMethod]
        public string OnSave(string Jsonstring, string sStatus, string sDocNo)
        {
            string sMessage = "";
            string sRunningDocNo = "";

            try
            {
                DataSet ds = new DataSet();
                DataTable dt = this.JsonToTable(Jsonstring);
                DataRow dr = dt.Rows[0];

                if (sStatus == "AddNew" && sDocNo == "")
                {
                    sRunningDocNo = this.RunningNewDocNo(dr["BRANCHCODE"].ToString(), dr["LTYPE"].ToString()); // ส่งรหัสสาขาเข้าไปเพื่อนำไป Get ข้อมูลที่ Field SHORT_NAME (ให้ดูที่ฟังก์ชั่น : getBranchShortName)
                }
                if (sStatus == "Edit" && sDocNo != "")
                {
                    sRunningDocNo = sDocNo;
                }
                dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
                SqlConnection cnn = devdb.getSqlConncetion;
                DataSet objds = new DataSet();
                string strsql = "";

                #region header
                strsql = "select * from dbtrans.dbo.TBTrans_PRE_Print_Label where docno = '" + sRunningDocNo + "' ";
                bool ret = devdb.ExecuteCommand(ref objds, strsql, "hd", ref cnn);
                if (ret)
                {
                    DataRow newrow = objds.Tables["hd"].NewRow();

                    if (objds.Tables["hd"].Rows.Count > 0)
                        newrow = objds.Tables["hd"].Rows[0];
                    newrow["docno"] = sRunningDocNo;
                    newrow["docdate"] = DateTime.Now.Date;
                    newrow["branchcode"] = dr["BRANCHCODE"].ToString();
                    newrow["sitecode"] = dr["SITECODE"].ToString();
                    newrow["sloc"] = dr["SLOC"].ToString();
                    newrow["request_user"] = dr["REQUEST_USER"].ToString();
                    newrow["status"] = "ยังไม่พิมพ์";
                    newrow["label_type"] = dr["LABEL_TYPE"].ToString();
                    newrow["cause_of_request"] = dr["CAUSE_OF_REQUEST"].ToString();
                    // ตรงนี้ให้ใส่เงื่อนไข ให้บันทึกค่าเฉพาะเมื่อมีการสร้างเอกสารครั้งแรกเท่านั้น
                    if (sStatus == "AddNew")
                        newrow["create_user"] = dr["CREATE_USER"].ToString(); ;

                    if (objds.Tables["hd"].Rows.Count <= 0)
                        objds.Tables["hd"].Rows.Add(newrow);
                }
                #endregion

                #region detail
                if (ret)
                {
                    strsql = "select top 0 * from dbtrans.dbo.tbtrans_pre_print_label_sub where docno = '" + sRunningDocNo + "' ";
                    ret = devdb.ExecuteCommand(ref objds, strsql, "dt", ref cnn);
                    if (ret)
                    {
                        int index = 1;
                        foreach (DataRow drow in dt.Rows)
                        {
                            DataRow newrow = objds.Tables["dt"].NewRow();
                            newrow["docno"] = sRunningDocNo;
                            newrow["docdate"] = DateTime.Now.Date;
                            newrow["roworder"] = index;
                            newrow["productcode"] = drow["PRODUCTCODE"];
                            newrow["productname"] = drow["PRODUCTNAME"];
                            newrow["barcode"] = drow["BARCODE"];
                            newrow["unitcode"] = drow["UNITCODE"];
                            newrow["branchcode"] = drow["BRANCHCODE"]; // ตรงนี้ให้นำรหัสสาขามาบันทึก
                            newrow["sitecode"] = drow["SITECODE"];
                            newrow["sloc"] = drow["SLOC"];
                            newrow["location"] = drow["LOCATION"];
                            newrow["unitprice"] = drow["UNITPRICE"];

                            CultureInfo provider = CultureInfo.InvariantCulture;
                            string sPriceDate = Convert.ToDateTime(drow["PRICEDATE"].ToString()).ToString("yyyy-MM-dd");
                            string format = "yyyy-MM-dd";
                            DateTime dResult = DateTime.ParseExact(sPriceDate, format, provider);

                            newrow["pricedate"] = dResult;
                            newrow["matkl"] = "";
                            objds.Tables["dt"].Rows.Add(newrow);
                            index++;
                        }
                    }
                }
                #endregion

                if (ret)
                    ret = devdb.BeginTrans(ref cnn);
                if (ret)
                {
                    strsql = "select * from dbtrans.dbo.tbtrans_pre_print_label where docno = '" + sRunningDocNo + "' ";
                    ret = devdb.ExcuteDataAdapterUpdate(ref objds, "hd", strsql, ref cnn);
                }
                if (ret)
                {
                    strsql = "delete from dbtrans..tbtrans_pre_print_label_sub where docno = '" + sRunningDocNo + "' ";
                    ret = devdb.ExecuteNoneQuery(strsql, ref cnn);
                    if (ret)
                    {
                        strsql = "select * from dbtrans.dbo.tbtrans_pre_print_label_sub where docno = '" + sRunningDocNo + "' ";
                        ret = devdb.ExcuteDataAdapterUpdate(ref objds, "dt", strsql, ref cnn);
                    }
                }
                if (ret)
                    ret = devdb.CommitTrans(ref cnn);
                if (!ret)
                    devdb.RollbackTrans(ref cnn);


                if (ret)
                    sMessage = "Saved successfully." + Environment.NewLine + "Document No. : " + sRunningDocNo;
                if (!ret)
                    sMessage = "Save failed";
            }
            catch (Exception ex)
            {
                sMessage = "Error : " + ex.Message.ToString();
            }
            return sMessage;
        }

        [WebMethod]
        public string OnDelete(string sDocNo)
        {
            string sMessage = "";
            try
            {
                dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
                SqlConnection cnn = devdb.getSqlConncetion;
                DataSet ds = new DataSet();
                string strsql = "";
                bool ret = devdb.BeginTrans(ref cnn);
                if (ret)
                {
                    strsql = "delete from DBTRANS..tbtrans_pre_print_label where DOCNO = '" + sDocNo + "' ";
                    ret = devdb.ExecuteNoneQuery(strsql, ref cnn);
                }
                if (ret)
                {
                    strsql = "delete from dbtrans..tbtrans_pre_print_label_sub where docno = '" + sDocNo + "' ";
                    ret = devdb.ExecuteNoneQuery(strsql, ref cnn);
                }
                if (ret)
                    ret = devdb.CommitTrans(ref cnn);
                if (!ret)
                    ret = devdb.RollbackTrans(ref cnn);
                if (ret)
                {
                    sMessage = "Delete Successfully";
                }
            }
            catch (Exception ex)
            {
                sMessage = "Error : " + ex.Message.ToString();
            }
            return sMessage;
        }

        [WebMethod]
        public string OnSearchByDocNo(string sDocNo)
        {
            DataSet ds = new DataSet();
            try
            {
                dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
                SqlConnection cnn = devdb.getSqlConncetion;
                DataTable dt = new DataTable();
                string strsql = "select tPrint.DOCNO, tPrint.DOCDATE, tPrint.BRANCHCODE, tPrint.SITECODE, tPrint.SLOC, tPrint.CREATE_USER,tuser.myname as 'USERNAME', tPrint.LABEL_TYPE,ltype.MYNAME as 'TYPETAG_NAME', tPrint.CAUSE_OF_REQUEST,"
                                + " tPrint.STATUS, tPrintSub.UNITCODE,unit.MYNAME as 'UNITNAMETH', tPrintSub.UNITPRICE, tPrintSub.PRICEDATE, tPrintSub.ROWORDER, tPrintSub.PRODUCTCODE,"
                                + " tPrintSub.BARCODE, tPrintSub.PRODUCTNAME, tPrintSub.LOCATION, tPrintSub.MATKL "

                                + " from dbtrans..tbtrans_pre_print_label as tPrint "
                                + " inner join dbtrans..tbtrans_pre_print_label_sub as tPrintSub on tPrint.DOCNO = tPrintSub.DOCNO "
                                + " inner join DBMASTER..TBMaster_Print_Label_Type as ltype on tPrint.LABEL_TYPE = ltype.code "
                                + " inner join DBMASTER..TBMaster_Unit as unit on tPrintSub.UNITCODE = unit.code "
                                + " inner join DBMASTER..TBMaster_User as tuser on tPrint.CREATE_USER = tuser.code "
                                + " where tPrint.DOCNO = '" + sDocNo + "' "
                                + " order by roworder";
                bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
                cnn.Close();
                if (ret)
                {
                    if (ds.Tables["tbl"].Rows.Count > 0)
                    {
                        dt.TableName = "tbtrans_pre_print_label_sub";
                        ds.Tables.Add(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ConvertDataSetToJSON(ds);
        }

        [WebMethod]
        public string OnDisplayDocNo(string BRANCHCODE,string SITECODE ,string SLOC, string sDocNo, string sCreateUser, string sStatus)
        {
            DataSet ds = new DataSet();
            try
            {
                dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
                SqlConnection cnn = devdb.getSqlConncetion;
                DataTable dt = new DataTable();
                string strsql = "select top 100 a.* , b.MYNAME from DBTRANS..TBTrans_PRE_Print_Label a "
                              + "left join DBMASTER..TBMaster_User b on a.create_user = b.code "
                              + " where a.BRANCHCODE = '" + BRANCHCODE + "'"
                              + " and a.SITECODE = '" + SITECODE + "'"
                              + " and a.SLOC = '" + SLOC + "'"
                              + " and a.DOCNO like '%" + sDocNo + "'"
                              + " and a.CREATE_USER like '%" + sCreateUser + "'"
                              + " and a.STATUS like '%" + sStatus + "%'";
                bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
                cnn.Close();
                if (ret)
                {
                    if (ds.Tables["tbl"].Rows.Count > 0)
                    {
                        dt.TableName = "TBTrans_PRE_Print_Label";
                        ds.Tables.Add(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ConvertDataSetToJSON(ds);
        }

        [WebMethod]
        public string OnSearchStorageBin(string ProductCode, string BinCode, string SiteCode, string Sloc)
        {
            DataSet ds = new DataSet();
            try
            {
                if (SiteCode != "" && Sloc != "") // SiteCode และ Sloc บังคับให้ระบุ
                {
                    SmartObjectClientServer serverName = K2_CONNECT_SERVER();// Connect K2 Server 
                    SmartObject smartObject = serverName.GetSmartObject("ZHH_GET_BIN_ASSIGNLOC");//ชื่อ SmartOject
                    smartObject.MethodToExecute = "ZHH_GET_BINASSIGNLOC_ZHH_GET_BIN_ASSIGNLOC";
                    //Set parameter
                    if (ProductCode != "")
                        smartObject.ListMethods["ZHH_GET_BINASSIGNLOC_ZHH_GET_BIN_ASSIGNLOC"].InputProperties["p_I_MATNR"].Value = ProductCode;
                    if (BinCode != "")
                        smartObject.ListMethods["ZHH_GET_BINASSIGNLOC_ZHH_GET_BIN_ASSIGNLOC"].InputProperties["p_I_BINCODE"].Value = BinCode;
                    smartObject.ListMethods["ZHH_GET_BINASSIGNLOC_ZHH_GET_BIN_ASSIGNLOC"].InputProperties["p_I_WERKS"].Value = SiteCode;
                    smartObject.ListMethods["ZHH_GET_BINASSIGNLOC_ZHH_GET_BIN_ASSIGNLOC"].InputProperties["p_I_LGORT"].Value = Sloc;
                    DataTable dt = serverName.ExecuteListDataTable(smartObject);

                    dt.Columns.Add("Barcode");
                    dt.Columns.Add("ArticleName");
                    dt.Columns.Add("UnitName");
                    dt.Columns.Add("SalePrice");
                    dt.Columns.Add("PriceDate");
                    foreach (DataRow row in dt.Rows)
                    {
                        //DateTime dtPriceDate = DateTime.Today;
                        
                        row["O_ASSIGNLOC_MATERIAL"] = row["O_ASSIGNLOC_MATERIAL"].ToString().TrimStart('0');
                        row["Barcode"] = this.Read_Barcode(row["O_ASSIGNLOC_MATERIAL"].ToString(), row["O_ASSIGNLOC_UNITOFMEASURE"].ToString());
                        row["ArticleName"] = this.Read_Product_Name(row["O_ASSIGNLOC_MATERIAL"].ToString());
                        row["UnitName"] = this.Read_Unit_Name(row["O_ASSIGNLOC_UNITOFMEASURE"].ToString());
                        row["SalePrice"] = this.OnGetSalePrice(row["O_ASSIGNLOC_WERKS"].ToString(), row["O_ASSIGNLOC_MATERIAL"].ToString(), row["O_ASSIGNLOC_UNITOFMEASURE"].ToString(), "0000");
                        row["PriceDate"] = DateTime.Now.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
                    }


                    ds.Tables.Add(dt);

                    serverName.Connection.Close();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ConvertDataSetToJSON(ds); // Retrun DataSet โดยแปลงข้อมูลทั้งหมดเป้น JSON

        }

        private string Read_Barcode(string sProductCode, string sUnitCode)
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            string strsql = "select *from DBMASTER..TBMaster_Barcode where productcode = '" + sProductCode + "' and unitcode = '" + sUnitCode + "'";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
            cnn.Close();
            if (ret)
            {
                if (ds.Tables["tbl"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["tbl"].Rows[0];
                    sResult = dr["barcode"].ToString();
                }
            }


            return sResult;
        }
        private string Read_Product_Name(string sProductCode)
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            string strsql = "select *from DBMASTER..TBMaster_Product where code = '" + sProductCode + "' ";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
            cnn.Close();
            if (ret)
            {
                DataRow dr = ds.Tables["tbl"].Rows[0];
                sResult = dr["NAMETH"].ToString();
            }

            return sResult;
        }
        private string Read_Unit_Name(string sUnitCode)
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            string strsql = "select *from DBMaster..TBMaster_Unit where code = '" + sUnitCode + "' ";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
            if (ret)
            {
                if (ds.Tables["tbl"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["tbl"].Rows[0];
                    sResult = dr["myname"].ToString();
                }
            }

            return sResult;
        }

        private string RunningNewDocNo(string sBranchCode,string LTYPE)
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            dev.lib.UtilityDataBase dbutil = new dev.lib.UtilityDataBase();
            dbutil.ConnectionString = Connect;
            dbutil.RunningFieldName = "DOCNO";
            string sformat = "yyyyMMdd-####";
            string sShortName = this.getBranchShortName(sBranchCode); // 
            dbutil.RunningGroup = sShortName + LTYPE + "-";
            dbutil.RunningFormat = sformat;
            dbutil.RunningTableName = "dbtrans.dbo.TBTrans_PRE_Print_Label";
            sResult = dbutil.RunningNewDocNo(devdb);
            return sResult;
        }
        private double OnGetSalePrice(string sSiteCode, string ProductCode, string UnitCode, string PaymentCode)
        {
            double sResult = 0;
            DataSet ds = new DataSet();
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            string strsql = "select top 1 saleprice ";
            strsql += "from TBMaster_Sale_Price ";
            strsql += "where sitecode='" + sSiteCode + "' ";
            strsql += "      and productcode='" + ProductCode + "' ";
            strsql += "      and unitcode='" + UnitCode + "' ";
            strsql += "      and paymentcode='" + PaymentCode + "' ";
            strsql += "      and {fn curdate()} between begindate and enddate ";
            strsql += "order by createdate desc";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
            if (ret)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["tbl"].Rows[0];
                    sResult = Convert.ToDouble(dr["saleprice"].ToString());
                }
            }
            return sResult;

        }
        private string getBranchShortName(string sBranchCode)
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet objds = new DataSet();
            string strsql = "select * from dbmaster..tbmaster_branch where old_code = '" + sBranchCode + "' ";
            bool ret = devdb.ExecuteCommand(ref objds, strsql, "tbl", ref cnn);
            cnn.Close();
            if (ret)
            {
                if (objds.Tables["tbl"].Rows.Count > 0)
                {
                    sResult = objds.Tables["tbl"].Rows[0]["short_name"].ToString();
                }
            }
            return sResult;
        }
        public string ConvertDataSetToJSON(DataSet ds)
        {
            string JSONString = string.Empty;
            if (ds != null)
            {
                return JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            else
            {
                return JSONString;
            }
        }
        public DataTable JsonToTable(String JsonString)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(JsonString, typeof(DataTable));
            return dt;
        }
    }
}
