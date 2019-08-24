using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using dev.lib;
using System.Data;
using SourceCode.SmartObjects.Client;
using Newtonsoft.Json;
using MoreLinq;
using System.Data.SqlClient;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace DohomeAppWebService
{

    public class Service : System.Web.Services.WebService
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

        #region Create By : Naruenart Matsombut

        #region 10/10/2018
        // ค้นหาสินค้าตาม ARTICLECODE (10/10/2018)
        [WebMethod]
        public string GETARTICLE_BY_ARTICLECODE(string ARTICLECODE, string UNITCODE)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "select top 100 tProduct.code as ArticleCode, tProduct.nameth as ArticleName, tBarcode.UNITCODE, tUnit.myname as UNITNAME, tBarcode.Barcode"
                                + " from TBMaster_Product as tProduct inner join "
                                + " TBMaster_Barcode as tBarcode on tProduct.code = tBarcode.productcode inner join"
                                + " TBMaster_Unit as tUnit on tBarcode.UnitCode = tUnit.code"
                                + " where tProduct.code = '" + ARTICLECODE + "' and tBarcode.UNITCODE = '" + UNITCODE + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dt.TableName = "TBMaster_Product";
            ds.Tables.Add(dt);

            return ConvertDataSetToJSON(ds);
        }
        // ค้นหาสินค้าตาม BARCODE (10/10/2018)
        [WebMethod]
        public string GETARTICLE_BY_BARCODE(string BARCODE, string UNITCODE)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "select top 100 tProduct.code as ArticleCode, tProduct.nameth as ArticleName, tBarcode.UNITCODE, tUnit.myname as UNITNAME, tBarcode.Barcode"
                                + " from TBMaster_Product as tProduct inner join "
                                + " TBMaster_Barcode as tBarcode on tProduct.code = tBarcode.productcode inner join"
                                + " TBMaster_Unit as tUnit on tBarcode.UnitCode = tUnit.code"
                                + " where tBarcode.Barcode = '" + BARCODE + "' and tBarcode.UNITCODE = '" + UNITCODE + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dt.TableName = "TBMaster_Product";
            ds.Tables.Add(dt);

            return ConvertDataSetToJSON(ds);
        }
        // บันทึกข้อมูลตรวจสอบสินค้าปน (10/10/2018)
        [WebMethod]
        public string InsertToTBTrans_Check_Position_Product_Contaminated(string Jsonstring)
        {
            DataTable objdt = new DataTable();
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "TBTrans_Gen_Docno_Check_Position_Product_Contaminated";
                dt = this.JsonToTable(Jsonstring);
                this.RunningNewDocNo(dt.Rows[0]["SITE"].ToString());

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Connect;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT TOP 1 DOCNO  FROM DBTRANS..TBTrans_Gen_Docno_Check_Position_Product_Contaminated order by DOCNO desc";
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(objdt);
                objdt.TableName = "TBTrans_Gen_Docno";
                if (dt.Rows.Count > 0 && objdt.Rows.Count > 0)
                {
                    conn = new SqlConnection();
                    conn.ConnectionString = Connect;
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                String query = "INSERT INTO DBTRANS..TBTrans_Check_Position_Product_Contaminated"
                                             + "(DOCNO,"
                                             + "BRANCH,"
                                             + "SITE,"
                                             + "SLOC,"
                                             + "BINCODE,"
                                             + "BARCODE,"
                                             + "PRODUCTCODE,"
                                             + "PRODUCTNAME,"
                                             + "UNITCODE,"
                                             + "UNITNAME,"
                                             + "STATUS,"
                                             //+ "DATECREATE,"
                                             + "EMPLOYEECODE,"
                                             + "EMPLOYEENAME,"
                                             + "CHECKTAGCODE,"
                                             + "CHECKTAGNAME)"

                                             // Value
                                             + " VALUES (@DOCNO,"
                                             + "@BRANCH,"
                                             + "@SITE,"
                                             + "@SLOC,"
                                             + "@BINCODE,"
                                             + "@BARCODE,"
                                             + "@PRODUCTCODE,"
                                             + "@PRODUCTNAME,"
                                             + "@UNITCODE,"
                                             + "@UNITNAME,"
                                             + "@STATUS,"
                                             //+ "@DATECREATE,"
                                             + "@EMPLOYEECODE,"
                                             + "@EMPLOYEENAME,"
                                             + "@CHECKTAGCODE,"
                                             + "@CHECKTAGNAME)";
                                command = new SqlCommand(query, conn, tran);

                                #region Parameters.Add (โค้ดเก่าไม่ใช้)
                                //command.Parameters.Add("@DOCNO", objdt.Rows[0]["DOCNO"].ToString());
                                //command.Parameters.Add("@BRANCH", dt.Rows[i]["BRANCH"].ToString());
                                //command.Parameters.Add("@SITE", dt.Rows[i]["SITE"].ToString());
                                //command.Parameters.Add("@SLOC", dt.Rows[i]["SLOC"].ToString());
                                //command.Parameters.Add("@BINCODE", dt.Rows[i]["BINCODE"].ToString());
                                //command.Parameters.Add("@BARCODE", dt.Rows[i]["BARCODE"].ToString());
                                //command.Parameters.Add("@PRODUCTCODE", dt.Rows[i]["PRODUCTCODE"].ToString());
                                //command.Parameters.Add("@PRODUCTNAME", dt.Rows[i]["PRODUCTNAME"].ToString());
                                //command.Parameters.Add("@UNITCODE", dt.Rows[i]["UNITCODE"].ToString());
                                //command.Parameters.Add("@UNITNAME", dt.Rows[i]["UNITNAME"].ToString());
                                //command.Parameters.Add("@STATUSTAG", dt.Rows[i]["STATUSTAG"].ToString());
                                //command.Parameters.Add("@DATECREATE", dt.Rows[i]["DATECREATE"].ToString());
                                //command.Parameters.Add("@EMPLOYEECODE", dt.Rows[i]["EMPLOYEECODE"].ToString());
                                //command.Parameters.Add("@EMPLOYEENAME", dt.Rows[i]["EMPLOYEENAME"].ToString());
                                //command.Parameters.Add("@CHECKTAGCODE", dt.Rows[i]["CHECKTAGCODE"].ToString());
                                //command.Parameters.Add("@CHECKTAGNAME", dt.Rows[i]["CHECKTAGNAME"].ToString()); 
                                #endregion

                                // Parameters.AddWithValue
                                command.Parameters.AddWithValue("@DOCNO", objdt.Rows[0]["DOCNO"].ToString());
                                command.Parameters.AddWithValue("@BRANCH", dt.Rows[i]["BRANCH"].ToString());
                                command.Parameters.AddWithValue("@SITE", dt.Rows[i]["SITE"].ToString());
                                command.Parameters.AddWithValue("@SLOC", dt.Rows[i]["SLOC"].ToString());
                                command.Parameters.AddWithValue("@BINCODE", dt.Rows[i]["BINCODE"].ToString());
                                command.Parameters.AddWithValue("@BARCODE", dt.Rows[i]["BARCODE"].ToString());
                                command.Parameters.AddWithValue("@PRODUCTCODE", dt.Rows[i]["PRODUCTCODE"].ToString());
                                command.Parameters.AddWithValue("@PRODUCTNAME", dt.Rows[i]["PRODUCTNAME"].ToString());
                                command.Parameters.AddWithValue("@UNITCODE", dt.Rows[i]["UNITCODE"].ToString());
                                command.Parameters.AddWithValue("@UNITNAME", dt.Rows[i]["UNITNAME"].ToString());
                                command.Parameters.AddWithValue("@STATUS", dt.Rows[i]["STATUS"].ToString());
                                //command.Parameters.AddWithValue("@DATECREATE", dt.Rows[i]["DATECREATE"].ToString());
                                command.Parameters.AddWithValue("@EMPLOYEECODE", dt.Rows[i]["EMPLOYEECODE"].ToString());
                                command.Parameters.AddWithValue("@EMPLOYEENAME", dt.Rows[i]["EMPLOYEENAME"].ToString());
                                command.Parameters.AddWithValue("@CHECKTAGCODE", dt.Rows[i]["CHECKTAGCODE"].ToString());
                                command.Parameters.AddWithValue("@CHECKTAGNAME", dt.Rows[i]["CHECKTAGNAME"].ToString());
                                command.ExecuteNonQuery();
                            }
                            tran.Commit();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            conn.Close();
                            return ex.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return objdt.Rows[0]["DOCNO"].ToString();
        }
        // Get Storage Bin หรือ Bin Code (K2 Connect) (10/10/2018)
        // BAPI : ZHH_GET_BIN_ASSIGNLOC
        [WebMethod]
        public string GetStorageBinFromSAP(string ProductCode, string BinCode, string SiteCode, string Sloc)
        {
            DataSet ds = new DataSet();
            if (SiteCode != "" && Sloc != "")
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

                dt.Columns.Add("Article_Name");

                foreach (DataRow row in dt.Rows)
                {
                    row["O_ASSIGNLOC_MATERIAL"] = row["O_ASSIGNLOC_MATERIAL"].ToString().TrimStart('0');
                    dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
                    SqlConnection cnn = devdb.getSqlConncetion;
                    DataSet objds = new DataSet();
                    string strsql = "select top 1 * " +
                                    "from dbmaster..tbmaster_product " +
                                    "where code = '" + row["O_ASSIGNLOC_MATERIAL"].ToString() + "'";
                    bool ret = devdb.ExecuteCommand(ref objds, strsql, "tbl", ref cnn);
                    cnn.Close();
                    if (ret)
                    {
                        if (objds.Tables["tbl"].Rows.Count > 0)
                        {
                            DataRow dr = objds.Tables["tbl"].Rows[0];
                            row["Article_Name"] = dr["NAMETH"].ToString();
                        }
                        else
                        {
                            row["Article_Name"] = "";
                        }
                    }
                }

                ds.Tables.Add(dt);

                serverName.Connection.Close();
            }
            return ConvertDataSetToJSON(ds); // Retrun DataSet โดยแปลงข้อมูลทั้งหมดเป้น JSON
        }
        // Get local Bin Code (10/10/2018)
        [WebMethod]
        public string GetBinCode_From_TBTrans_Check_Position_Product_Contaminated(string BranchCode, string Site, string Sloc, string BinCode, string EmpCode)
        {
            dev.lib.Utilities util = new dev.lib.Utilities();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            string sDate = util.ConvertDateToString(DateTime.Now.Date);
            command.CommandText = "select DOCNO, DATECREATE, BRANCH, SITE, SLOC, BINCODE, EMPLOYEECODE from DBTRANS..TBTrans_Check_Position_Product_Contaminated"
                                + " where DATECREATE = '" + sDate + "'"
                                + " and BRANCH = '" + BranchCode + "'"
                                + " and site = '" + Site + "'"
                                + " and sloc = '" + Sloc + "'"
                                + " and bincode like '%" + BinCode + "%' "
                                + " and EMPLOYEECODE = '" + EmpCode + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dt.TableName = "TB_Contaminated";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }
        // Get local Bin Code And Product Detail (10/10/2018)
        [WebMethod]
        public string GetBinCode_Detail_From_TBTrans_Check_Position_Product_Contaminated(string BranchCode, string Site, string Sloc, string BinCode, string EmpCode)
        {
            dev.lib.Utilities util = new dev.lib.Utilities();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            string sDate = util.ConvertDateToString(DateTime.Now.Date);
            command.CommandText = "select DOCNO, DATECREATE, BRANCH, SITE, SLOC, BINCODE, EMPLOYEECODE, PRODUCTCODE, BARCODE, PRODUCTNAME, UNITCODE, UNITNAME, STATUS from DBTRANS..TBTrans_Check_Position_Product_Contaminated"
                                + " where DATECREATE = '" + sDate + "'"
                                + " and BRANCH = '" + BranchCode + "'"
                                + " and site = '" + Site + "'"
                                + " and sloc = '" + Sloc + "'"
                                + " and bincode like '%" + BinCode + "%' "
                                + " and EMPLOYEECODE = '" + EmpCode + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dt.TableName = "TB_Contaminated";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }
        #endregion

        #region 11/10/2018

        // บันทึกข้อมูลตรวจสอบตำแหน่งสินค้า (11/10/2018)
        [WebMethod]
        public string InsertToTBTrans_Check_Product_Location(string Jsonstring)
        {
            DataTable objdt = new DataTable();
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "TBTrans_Gen_Docno_Check_Product_Location";
                dt = this.JsonToTable(Jsonstring);
                this.PreRunningNewDocNoCheckProductlocation(dt.Rows[0]["SITE"].ToString());

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Connect;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT TOP 1 DOCNO  FROM DBTRANS..TBTrans_Gen_Docno_Check_Product_Location order by DOCNO desc";
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(objdt);
                objdt.TableName = "TBTrans_Gen_Docno";
                if (dt.Rows.Count > 0 && objdt.Rows.Count > 0)
                {
                    conn = new SqlConnection();
                    conn.ConnectionString = Connect;
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                String query = "INSERT INTO DBTRANS..TBTrans_Check_Product_Location"
                                             + "(DOCNO,"
                                             + "BRANCH,"
                                             + "SITE,"
                                             + "SLOC,"
                                             + "BINCODE,"
                                             + "BARCODE,"
                                             + "PRODUCTCODE,"
                                             + "PRODUCTNAME,"
                                             + "UNITCODE,"
                                             + "UNITNAME,"
                                             + "STATUS,"
                                             //+ "DATECREATE,"
                                             + "REMARKS,"
                                             + "EMPLOYEECODE,"
                                             + "EMPLOYEENAME,"
                                             + "CARETAKERSCODE,"
                                             + "CARETAKERSNAME)"

                                             // Value
                                             + " VALUES (@DOCNO,"
                                             + "@BRANCH,"
                                             + "@SITE,"
                                             + "@SLOC,"
                                             + "@BINCODE,"
                                             + "@BARCODE,"
                                             + "@PRODUCTCODE,"
                                             + "@PRODUCTNAME,"
                                             + "@UNITCODE,"
                                             + "@UNITNAME,"
                                             + "@STATUS,"
                                             //+ "@DATECREATE,"
                                             + "@REMARKS,"
                                             + "@EMPLOYEECODE,"
                                             + "@EMPLOYEENAME,"
                                             + "@CARETAKERSCODE,"
                                             + "@CARETAKERSNAME)";
                                command = new SqlCommand(query, conn, tran);
                                // Parameters.AddWithValue
                                command.Parameters.AddWithValue("@DOCNO", objdt.Rows[0]["DOCNO"].ToString());
                                command.Parameters.AddWithValue("@BRANCH", dt.Rows[i]["BRANCH"].ToString());
                                command.Parameters.AddWithValue("@SITE", dt.Rows[i]["SITE"].ToString());
                                command.Parameters.AddWithValue("@SLOC", dt.Rows[i]["SLOC"].ToString());
                                command.Parameters.AddWithValue("@BINCODE", dt.Rows[i]["BINCODE"].ToString());
                                command.Parameters.AddWithValue("@BARCODE", dt.Rows[i]["BARCODE"].ToString());
                                command.Parameters.AddWithValue("@PRODUCTCODE", dt.Rows[i]["PRODUCTCODE"].ToString());
                                command.Parameters.AddWithValue("@PRODUCTNAME", dt.Rows[i]["PRODUCTNAME"].ToString());
                                command.Parameters.AddWithValue("@UNITCODE", dt.Rows[i]["UNITCODE"].ToString());
                                command.Parameters.AddWithValue("@UNITNAME", dt.Rows[i]["UNITNAME"].ToString());
                                command.Parameters.AddWithValue("@STATUS", dt.Rows[i]["STATUS"].ToString());
                                //command.Parameters.AddWithValue("@DATECREATE", dt.Rows[i]["DATECREATE"].ToString());
                                command.Parameters.AddWithValue("@REMARKS", dt.Rows[i]["REMARKS"].ToString());
                                command.Parameters.AddWithValue("@EMPLOYEECODE", dt.Rows[i]["EMPLOYEECODE"].ToString());
                                command.Parameters.AddWithValue("@EMPLOYEENAME", dt.Rows[i]["EMPLOYEENAME"].ToString());
                                command.Parameters.AddWithValue("@CARETAKERSCODE", dt.Rows[i]["CARETAKERSCODE"].ToString());
                                command.Parameters.AddWithValue("@CARETAKERSNAME", dt.Rows[i]["CARETAKERSNAME"].ToString());
                                command.ExecuteNonQuery();
                            }
                            tran.Commit();
                            //
                            // Start Insert Reason
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["REASONCODE"].ToString() != "") // ให้เปลี่ยนชื่อ Field REASONCODE เป็นชื่อ Field ที่ถูกส่งเข้ามา
                                {
                                    string strsql = "INSERT INTO DBTRANS..TBTrans_Check_Product_Location_LossReason"
                                                                             + "(DOCNO,"
                                                                             + "REASONCODE,"
                                                                             + "REASONNAME)"
                                                                             // Value
                                                                             + " VALUES (@DOCNO,"
                                                                             + "@REASONCODE,"
                                                                             + "@REASONNAME)";
                                    command = new SqlCommand(strsql, conn, tran);
                                    // Parameters.AddWithValue
                                    command.Parameters.AddWithValue("@DOCNO", objdt.Rows[0]["DOCNO"].ToString());
                                    command.Parameters.AddWithValue("@REASONCODE", dt.Rows[i]["REASONCODE"].ToString());
                                    command.Parameters.AddWithValue("@REASONNAME", dt.Rows[i]["REASONNAME"].ToString());
                                    command.ExecuteNonQuery();
                                }
                            }
                            tran.Commit();
                        //--------------- End ------------------------
                        conn.Close();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            conn.Close();
                            return ex.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return objdt.Rows[0]["DOCNO"].ToString();
        }

        // Get local Bin Code (11/10/2018)
        [WebMethod]
        public string GetBinCode_From_TBTrans_Check_Product_Location(string BranchCode, string Site, string Sloc, string BinCode, DateTime Date, string EmpCode)
        {
            dev.lib.Utilities util = new dev.lib.Utilities();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            string sDate = util.ConvertDateToString(Date);
            command.CommandText = "select DATECREATE, BRANCH, SITE, SLOC, BINCODE, EMPLOYEECODE from DBTRANS..TBTrans_Check_Product_Location"
                                + " where DATECREATE = '" + sDate + "'"
                                + " and BRANCH = '" + BranchCode + "'"
                                + " and site = '" + Site + "'"
                                + " and sloc = '" + Sloc + "'"
                                + " and bincode like '%" + BinCode + "%' "
                                + " and EMPLOYEECODE = '" + EmpCode + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dt.TableName = "TB_Product_Location";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }

        [WebMethod]
        public string GetLocation_Reason()
        {
            DataTable dt = new DataTable();
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            SqlConnection cnn = devdb.getSqlConncetion;
            DataSet ds = new DataSet();
            string strsql = "select ID, REASONDESCRIPTION from DBTRANS..TBTrans_Check_Product_Location_Reason";
            bool ret = devdb.ExecuteCommand(ref ds, strsql, "tbl", ref cnn);
            if (ret)
            {
                if (ds.Tables["tbl"].Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
            }
            return ConvertDataSetToJSON(ds);
        }
        // Get local Bin Code And Reason Detail (10/10/2018)
        [WebMethod]
        public string GetBinCode_Detail_From_TBTrans_Check_Product_Location(string BranchCode, string Site, string Sloc, string BinCode, DateTime Date, string EmpCode)
        {
            dev.lib.Utilities util = new dev.lib.Utilities();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            string sDate = util.ConvertDateToString(Date);
            command.CommandText = "select A.DATECREATE, A.BRANCH, A.SITE,"
                                + " A.SLOC, A.BINCODE, A.EMPLOYEECODE,"
                                + " A.PRODUCTCODE, A.BARCODE, A.PRODUCTNAME,"
                                + " A.UNITCODE, A.UNITNAME, B.ID AS REASONCODE, B.REASONDESCRIPTION AS REASONNAME, A.STATUS"

                                + " from DBTRANS..TBTrans_Check_Product_Location as A inner join"
                                + " DBTRANS..TBTrans_Check_Product_Location_Reason as B on A.REASONCODE = B.ID"
                                + " where DATECREATE = '" + sDate + "'"
                                + " and BRANCH = '" + BranchCode + "'"
                                + " and site = '" + Site + "'"
                                + " and sloc = '" + Sloc + "'"
                                + " and bincode like '%" + BinCode + "%' "
                                + " and EMPLOYEECODE = '" + EmpCode + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            dt.TableName = "TB_Product_Location";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }

        public string PreRunningNewDocNoCheckProductlocation(string SITE)
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            dev.lib.UtilityDataBase dbutil = new dev.lib.UtilityDataBase();
            SqlConnection Conn1 = devdb.getSqlConncetion;
            dbutil.ConnectionString = Connect;
            dbutil.RunningFieldName = "DOCNO";
            //string sformat = "yyyyMMdd-####";
            string sformat = "-yyMMdd####";
            string Leftsite = LeftString(SITE, 2);
            string sShortName = Leftsite + "LP";
            dbutil.RunningGroup = sShortName;
            dbutil.RunningFormat = sformat;
            dbutil.RunningTableName = "dbtrans.dbo.TBTrans_Gen_Docno_Check_Product_Location";
            sResult = dbutil.RunningNewDocNo(devdb);
            string sql_update = "INSERT INTO dbtrans.dbo.TBTrans_Gen_Docno_Check_Product_Location (DOCNO) VALUES ('" + sResult + "')";
            devdb.ExecuteNoneQuery(sql_update, ref Conn1);
            return sResult;
        }

        #endregion


        #endregion

        public string RunningNewDocNo(string SITE)
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(Connect);
            dev.lib.UtilityDataBase dbutil = new dev.lib.UtilityDataBase();
            SqlConnection Conn1 = devdb.getSqlConncetion;
            dbutil.ConnectionString = Connect;
            dbutil.RunningFieldName = "DOCNO";
            //string sformat = "yyyyMMdd-####";
            string sformat = "-yyMMdd####";
            string Leftsite = LeftString(SITE, 2);
            string sShortName = Leftsite + "LP";
            dbutil.RunningGroup = sShortName;
            dbutil.RunningFormat = sformat;
            dbutil.RunningTableName = "dbtrans.dbo.TBTrans_Gen_Docno_Check_Position_Product_Contaminated";
            sResult = dbutil.RunningNewDocNo(devdb);
            string sql_update = "INSERT INTO dbtrans.dbo.TBTrans_Gen_Docno_Check_Position_Product_Contaminated (DOCNO) VALUES ('" + sResult + "')";
            devdb.ExecuteNoneQuery(sql_update, ref Conn1);
            return sResult;
        }

        [WebMethod]
        public string LOGIN_DOHOMEAPP(string Usernam, string password)
        {

            string Token = "cOqyOKGB1UitBX1gdoo0SLgoPfh7jAQS";

            WebLogIn.Token token = new WebLogIn.Token();
            token.Value = Token;
            WebLogIn.Login lg = new WebLogIn.Login();
            lg.Username = Usernam;
            lg.Password = password;

            WebLogIn.AuthenticationSoapClient aut = new WebLogIn.AuthenticationSoapClient();

            WebLogIn.ResLogin res = aut.Login(token, lg);
            if (res.Authenticated)
            {
                //เช็คว่าเป็น Cashier หรือไม่
                return res.Authenticated.ToString();
            }
            else
            {
                return res.Message;
            }
        }
        [WebMethod]
        public string GET_USER_DETAIL(string EMP_ID)
        {
            DataSet ds = new DataSet();
            DBMASTERDataContext db = new DBMASTERDataContext();
            DataTable dt = new DataTable();
            dt.Columns.Add("EMP_ID", typeof(string));
            dt.Columns.Add("EMP_NAME", typeof(string));
            dt.Columns.Add("EMP_JOBKEY_CODE", typeof(string));
            dt.Columns.Add("EMP_JOBKEY_NAME", typeof(string));
            dt.Columns.Add("Server", typeof(string));
            dt.Columns.Add("Client", typeof(string));
            DataTable dt_user = (from tb_user in db.TBMaster_Users
                                 join tb_job in db.TBMaster_User_Job_Keys on tb_user.JOBKEY equals tb_job.CODE
                                 into tb_position
                                 from tb_posi in tb_position.DefaultIfEmpty()
                                 where tb_user.CODE.Equals(EMP_ID)
                                 select new { EMP_IDs = tb_user.CODE, EMP_FNAME = tb_user.MYNAME, EMP_JOBKEY_CODE = tb_posi.CODE, EMP_JOBKEY_NAME = tb_posi.MYNAME }).ToDataTable();

            DataTable user_g = (from tb_us in db.TBMaster_DHApp_Users
                                join tb_detail in db.TBMaster_DHApp_Group_Details on tb_us.Group_Code equals tb_detail.Group_Code
                                join tb_branch in db.TBMaster_Branches on tb_detail.Branch equals tb_branch.CODE
                                where tb_us.User_Code.Equals(EMP_ID)
                                group tb_detail by new { tb_detail.Branch, tb_branch.MYNAME } into d
                                select new { BRANCH_CODE = d.Key.Branch, BRANCH_NAME = d.Key.MYNAME }).ToDataTable();

            user_g.TableName = "TB_Branch";
            ds.Tables.Add(user_g);
            DataRow drow = dt.NewRow();
            drow["EMP_ID"] = dt_user.Rows[0]["EMP_IDs"].ToString();
            drow["EMP_NAME"] = dt_user.Rows[0]["EMP_FNAME"].ToString();
            drow["EMP_JOBKEY_CODE"] = dt_user.Rows[0]["EMP_JOBKEY_CODE"].ToString();
            drow["EMP_JOBKEY_NAME"] = dt_user.Rows[0]["EMP_JOBKEY_NAME"].ToString();
            string server = System.Configuration.ConfigurationManager.AppSettings["K2Server"].ToString() ?? "";
            drow["Server"] = server;
            if (server.Equals("192.168.0.159"))
            {
                drow["Client"] = "DEV";
            }
            else if (server.Equals("192.168.0.157"))
            {
                drow["Client"] = "QAS";
            }
            else
            {
                drow["Client"] = "";
            }
            dt.Rows.Add(drow);
            dt.TableName = "TB_EMP";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }
        [WebMethod]
        public string GET_SITE(string sEmpID)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DBMASTERDataContext db = new DBMASTERDataContext();
            dt = (from tb_u in db.TBMaster_DHApp_Users
                  join tb_s in db.TBMaster_DHApp_Group_Details on tb_u.Group_Code equals tb_s.Group_Code
                  join tb_s_name in db.TBMaster_Sites on tb_s.Site equals tb_s_name.CODE
                  where tb_u.User_Code == sEmpID
                  group tb_s by new { tb_s.Site, tb_s_name.MYNAME } into d

                  select new { Site = d.Key.Site, SiteName = d.Key.MYNAME }).ToDataTable();
            dt.TableName = "TB_SITE";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);

        }
        [WebMethod]
        public string GET_Sloc(string EMP_ID, string Site)
        {
            DataTable dt = new DataTable();
            DataTable dt_site = new DataTable();
            DataSet ds = new DataSet();
            DBMASTERDataContext db = new DBMASTERDataContext();
            dt = (from tb_u in db.TBMaster_DHApp_Users
                  join tb_s in db.TBMaster_DHApp_Group_Details on tb_u.Group_Code equals tb_s.Group_Code
                  join tb_sl_name in db.TBMaster_Slocs on new { Sloc = tb_s.Sloc, Site = tb_s.Site } equals new { Sloc = tb_sl_name.SLOC, Site = tb_sl_name.SITECODE }
                  where tb_u.User_Code.Equals(EMP_ID) && tb_s.Site.Equals(Site)
                  select new { tb_s.Sloc, SlocName = tb_sl_name.SLOC_NAME }).ToDataTable();
            dt.TableName = "TB_Sloc";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }
        [WebMethod]
        public string GETUNIT_BY_ARTICLE(string PRODUCTCODE)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT PRODUCTCODE ,UNITCODE,b.MYNAME  FROM DBMASTER..TBMaster_Product_Unit a left join DBMASTER..TBMaster_Unit b on a.UNITCODE = b.CODE where a.PRODUCTCODE = '" + PRODUCTCODE + "'";

            DataSet dataSet = new DataSet();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            data.TableName = "TBMaster_Unit";
            dataSet.Tables.Add(data);

            return ConvertDataSetToJSON(dataSet);
        }
        [WebMethod]
        public string GETUNIT_BY_BARCODE(string BARCODE)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Connect;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT PRODUCTCODE,BARCODE ,UNITCODE,b.MYNAME  FROM DBMASTER..TBMaster_Barcode a "
                                + " left join DBMASTER..TBMaster_Unit b on a.UNITCODE = b.CODE"
                                + " where a.STATUS = 1 and BARCODE = '" + BARCODE + "'";

            DataSet dataSet = new DataSet();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            data.TableName = "GETUNIT_BY_BARCODE";
            dataSet.Tables.Add(data);

            return ConvertDataSetToJSON(dataSet);
        }
        [WebMethod]
        public bool USER_CHECKING(string EMP_ID)
        {
            DBMASTERDataContext db = new DBMASTERDataContext();
            List<TBMaster_DHApp_User> dt2 = (from tb_u in db.TBMaster_DHApp_Users
                                             where tb_u.User_Code == EMP_ID
                                             select tb_u).ToList();
            if (dt2.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public static string LeftString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }
        public DataTable JsonToTable(String JsonString)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(JsonString, typeof(DataTable));
            return dt;
        }

    }
}
