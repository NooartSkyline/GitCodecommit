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
using System.Globalization;

namespace Webservice_DohomeApplication
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public SqlConnection conn;
        public SqlCommand command;
        public string Connect = System.Configuration.ConfigurationManager.ConnectionStrings["DBMASTERConnectionString"].ConnectionString;

        //--------------------------------------------------------//เช็คสต๊อกสินค้า ATP------------------------------------------------------------------------------
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
        public string GET_SITE(string EMP_ID)
        {
            DataTable dt = new DataTable();
            DataTable dt_site = new DataTable();
            DataSet ds = new DataSet();
            DBMASTERDataContext db = new DBMASTERDataContext();
            dt = (from tb_u in db.TBMaster_DHApp_Users
                  join tb_s in db.TBMaster_DHApp_Group_Details on tb_u.Group_Code equals tb_s.Group_Code
                  join tb_s_name in db.TBMaster_Sites on tb_s.Site equals tb_s_name.CODE
                  where tb_u.User_Code == EMP_ID
                  group tb_s by new { tb_s.Site, tb_s_name.MYNAME } into d

                  select new { Site = d.Key.Site, SiteName = d.Key.MYNAME }).ToDataTable();
            dt.TableName = "TB_SITE";
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);

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
        public string ZGET_ARTICLE_DH_APP_DOHOME_APPLICATION(String p_I_EAN11, String p_I_LGORT, String p_I_MATNR, String p_I_WERKS)
        {
            dev.lib.Utilities utilities = new Utilities(); //xประกาศ Object เพื่อเอาไว้สำหรับเติม 0

            DataSet dataSet = new DataSet(); //สร้าง DataSet เอาไว้เก็บ DataTable

            if (p_I_EAN11 != "")
            {

                #region Connect K2 
                SmartObjectClientServer serverName = K2_CONNECT_SERVER();// Connect K2 Server 
                SmartObject smartObject0 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_ARTICLE");//ชื่อ SmartOject
                smartObject0.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                //smartObject.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = p_I_MATNR;
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt0 = serverName.ExecuteListDataTable(smartObject0); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt0.Rows.Remove(dt0.Rows[dt0.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt0);// add Datatable ใส่ DataSet

                #region Connect K2               
                SmartObject smartObject1 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_BIN");//ชื่อ SmartOject
                smartObject1.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                //smartObject.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = p_I_MATNR;
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt1 = serverName.ExecuteListDataTable(smartObject1); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt1.Rows.Remove(dt1.Rows[dt1.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt1);// add Datatable ใส่ DataSet

                #region Connect K2  
                //สำหรับ Connect K2 
                SmartObject smartObject2 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_UNIT");//ชื่อ SmartOject
                smartObject2.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute             
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                //smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = p_I_MATNR;
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt2 = serverName.ExecuteListDataTable(smartObject2); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt2.Rows.Remove(dt2.Rows[dt2.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt2);// add Datatable ใส่ DataSet

                #region Connect K2  
                //สำหรับ Connect K2 
                SmartObject smartObject3 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_STOCK");//ชื่อ SmartOject
                smartObject3.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute             
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                //smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = p_I_MATNR;
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt3 = serverName.ExecuteListDataTable(smartObject3); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt3.Rows.Remove(dt3.Rows[dt3.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt3);// add Datatable ใส่ DataSet

                return ConvertDataSetToJSON(dataSet); // Retrun DataSet โดยแปลงข้อมูลทั้งหมดเป้น JSON
            }
            else
            {
                #region Connect K2 
                SmartObjectClientServer serverName = K2_CONNECT_SERVER();// Connect K2 Server 
                SmartObject smartObject0 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_ARTICLE");//ชื่อ SmartOject
                smartObject0.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute
                //smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = utilities.AddZero(p_I_MATNR, 18);
                smartObject0.ListMethods["ZGET_ARTICLE_DH_APP_E_ARTICLE_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt0 = serverName.ExecuteListDataTable(smartObject0); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt0.Rows.Remove(dt0.Rows[dt0.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt0);// add Datatable ใส่ DataSet

                #region Connect K2 
                SmartObject smartObject1 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_BIN");//ชื่อ SmartOject
                smartObject1.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute
                //smartObject1.ListMethods["ZGET_ARTICLE_DHAPP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = utilities.AddZero(p_I_MATNR, 18);
                smartObject1.ListMethods["ZGET_ARTICLE_DH_APP_E_BIN_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt = serverName.ExecuteListDataTable(smartObject1); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt);// add Datatable ใส่ DataSet

                #region Connect K2  
                //สำหรับ Connect K2 
                SmartObject smartObject2 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_UNIT");//ชื่อ SmartOject
                smartObject2.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute           
                //smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = utilities.AddZero(p_I_MATNR, 18);
                smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_UNIT_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt2 = serverName.ExecuteListDataTable(smartObject2); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt2.Rows.Remove(dt2.Rows[dt2.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt2);// add Datatable ใส่ DataSet

                #region Connect K2  
                //สำหรับ Connect K2 
                SmartObject smartObject3 = serverName.GetSmartObject("ZGET_ARTICLE_DH_APP_STOCK");//ชื่อ SmartOject
                smartObject3.MethodToExecute = "ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP";//ชื่อ Method ที่ใช้สำหรับ Excute
                #endregion Connect K2

                //ข้อมูลที่ส่งเข้าไปใน BAPI เพื่อใช้ สำหรับ Excute           
                //smartObject2.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_EAN11"].Value = p_I_EAN11;
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LANGU"].Value = "EN";
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_LGORT"].Value = p_I_LGORT;
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_MATNR"].Value = utilities.AddZero(p_I_MATNR, 18);
                smartObject3.ListMethods["ZGET_ARTICLE_DH_APP_E_STOCK_ZGET_ARTICLE_DH_APP"].InputProperties["p_I_WERKS"].Value = p_I_WERKS;

                DataTable dt3 = serverName.ExecuteListDataTable(smartObject3); // สร้าง DataTable มารับ ข้อมูลที่ Execute SmartObject
                //dt3.Rows.Remove(dt3.Rows[dt3.Rows.Count - 1]);//ตัด Rows ที่ซ้ำออก
                dataSet.Tables.Add(dt3);// add Datatable ใส่ DataSet

                return ConvertDataSetToJSON(dataSet); // Retrun DataSet โดยแปลงข้อมูลทั้งหมดเป้น JSON
            }
        }

        //--------------------------------------------------------//ตรวจสอบป้ายราคา------------------------------------------------------------------------------

        [WebMethod]
        public string GETTBMaster_Sale_Price(string PRODUCTCODE, string BARCODE, string SITECODE, string UNITCODE)
        {
            DataSet dataSet = new DataSet();
            if (!PRODUCTCODE.Equals("") && PRODUCTCODE != null && BARCODE.Equals("") || BARCODE == null)//Article
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Connect;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "select top 1 pd.CODE, bc.BARCODE, pd.NAMETH, sp.SALEPRICE, sp.UNITCODE ,sp.CREATEDATE "
                                    + " from DBMASTER..TBMaster_Sale_Price sp"
                                    + " left join DBMASTER..TBMaster_Product pd  on sp.PRODUCTCODE = pd.CODE"
                                    + " left join DBMASTER..TBMaster_Barcode bc on sp.PRODUCTCODE = bc.PRODUCTCODE and sp.UNITCODE = bc.UNITCODE"
                                    + " where sp.PRODUCTCODE = '" + PRODUCTCODE + "' and sp.SITECODE = '" + SITECODE + "' and sp.UNITCODE = '" + UNITCODE + "' and GETDATE() between sp.BEGINDATE and sp.ENDDATE"
                                    + " order by sp.CREATEDATE DESC";

                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                data.TableName = "TBMaster_Sale_Price";
                dataSet.Tables.Add(data);
            }
            if (!BARCODE.Equals("") && BARCODE != null && PRODUCTCODE.Equals("") || PRODUCTCODE == null)//Barcode
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Connect;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "select top 1 pd.CODE, bc.BARCODE, pd.NAMETH, sp.SALEPRICE,sp.UNITCODE ,sp.CREATEDATE"
                                    + " from DBMASTER..TBMaster_Sale_Price sp"
                                    + " left join DBMASTER..TBMaster_Product pd on sp.PRODUCTCODE = pd.CODE"
                                    + " left join DBMASTER..TBMaster_Barcode bc on sp.PRODUCTCODE = bc.PRODUCTCODE  and sp.UNITCODE = bc.UNITCODE"
                                    + " where bc.BARCODE = '" + BARCODE + "' and sp.SITECODE = '" + SITECODE + "' and GETDATE() between sp.BEGINDATE and sp.ENDDATE"
                                    + " order by sp.CREATEDATE DESC";

                DataTable data1 = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data1);
                data1.TableName = "TBMaster_Sale_Price";
                dataSet.Tables.Add(data1);

            }



            return ConvertDataSetToJSON(dataSet);
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
        public string INSERTJSONSTRING(string Jsonstring)
        {
            DataTable data = new DataTable();
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "TBTrans_Check_Price_Tag";
                dt = JsonToTable(Jsonstring);

                RunningNewDocNo(dt.Rows[0]["SITE"].ToString());


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Connect;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT TOP 1 DOCNO  FROM DBTRANS..TBTrans_Gen_Docno_Check_Price_Tag order by DOCNO desc";


                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                data.TableName = "TBTrans_Gen_Docno";



                if (dt.Rows.Count > 0 && data.Rows.Count > 0)
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


                                String query = "INSERT INTO DBTRANS..TBTrans_Check_Price_Tag (DOCNO,BRANCH,SITE,SLOC,DATEEDIT,DATECREATE,PRODUCTCODE,BARCODE,PRODUCTNAME,UNITCODE,UNITNAME,"
                                             + "PRICETAG,PRICESYSTEM,STATUSTAG,EMPLOYEECODE,EMPLOYEENAME,CHECKTAGCODE,CHECKTAGNAME) "
                                             + " VALUES (@DOCNO,@BRANCH,@SITE,@SLOC,@DATEEDIT,@DATECREATE,@PRODUCTCODE,@BARCODE,@PRODUCTNAME"
                                             + " ,@UNITCODE,@UNITNAME,@PRICETAG,@PRICESYSTEM,@STATUSTAG,@EMPLOYEECODE,@EMPLOYEENAME,@CHECKTAGCODE,@CHECKTAGNAME)";

                                command = new SqlCommand(query, conn,tran);

                                command.Parameters.Add("@DOCNO", data.Rows[0]["DOCNO"].ToString());
                                command.Parameters.Add("@BRANCH", dt.Rows[i]["BRANCH"].ToString());
                                command.Parameters.Add("@SITE", dt.Rows[i]["SITE"].ToString());
                                command.Parameters.Add("@SLOC", dt.Rows[i]["SLOC"].ToString());
                                command.Parameters.Add("@DATEEDIT", DateTime.Now);
                                //command.Parameters.Add("@DATEEDIT", "2561-10-03");
                                command.Parameters.Add("@DATECREATE", DateTime.Now);
                                //command.Parameters.Add("@DATECREATE", "2561-10-03 12:12:12");
                                command.Parameters.Add("@PRODUCTCODE", dt.Rows[i]["PRODUCTCODE"].ToString());
                                command.Parameters.Add("@BARCODE", dt.Rows[i]["BARCODE"].ToString());
                                command.Parameters.Add("@PRODUCTNAME", dt.Rows[i]["PRODUCTNAME"].ToString());
                                command.Parameters.Add("@UNITCODE", dt.Rows[i]["UNITCODE"].ToString());
                                command.Parameters.Add("@UNITNAME", dt.Rows[i]["UNITNAME"].ToString());
                                command.Parameters.Add("@PRICETAG", dt.Rows[i]["PRICETAG"].ToString());
                                command.Parameters.Add("@PRICESYSTEM", dt.Rows[i]["PRICESYSTEM"].ToString());
                                command.Parameters.Add("@STATUSTAG", dt.Rows[i]["STATUSTAG"].ToString());
                                command.Parameters.Add("@EMPLOYEECODE", dt.Rows[i]["EMPLOYEECODE"].ToString());
                                command.Parameters.Add("@EMPLOYEENAME", dt.Rows[i]["EMPLOYEENAME"].ToString());
                                command.Parameters.Add("@CHECKTAGCODE", dt.Rows[i]["CHECKTAGCODE"].ToString());
                                command.Parameters.Add("@CHECKTAGNAME", dt.Rows[i]["CHECKTAGNAME"].ToString());

                                command.ExecuteNonQuery();                              
                            }
                            tran.Commit();
                            conn.Close();
                        }

                        catch(Exception ex)
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
            return data.Rows[0]["DOCNO"].ToString();
        }

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
            dbutil.RunningTableName = "dbtrans.dbo.TBTrans_Gen_Docno_Check_Price_Tag";
            sResult = dbutil.RunningNewDocNo(devdb);
            string sql_update = "INSERT INTO dbtrans.dbo.TBTrans_Gen_Docno_Check_Price_Tag (DOCNO) VALUES ('" + sResult + "')";
            devdb.ExecuteNoneQuery(sql_update, ref Conn1);
            return sResult;
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


        //--------------------------------------------------------//ตรวจสอบป้ายราคา------------------------------------------------------------------------------

        private SmartObjectClientServer K2_CONNECT_SERVER()
        {
            #region Connect K2 
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
            #endregion Connect K2
            return serverName;
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
