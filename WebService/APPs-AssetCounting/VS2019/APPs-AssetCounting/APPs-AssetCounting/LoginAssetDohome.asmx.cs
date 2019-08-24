using MoreLinq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace APPs_AssetCounting
{
    /// <summary>
    /// Summary description for LoginAssetDohome
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginAssetDohome : System.Web.Services.WebService
    {

        [WebMethod]
        public string LOGIN(string Usernam, string password)
        {

            string Token = "LkMsr28g10jzMT5GWV/gSbyEzkaKagnf";

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

        //public string LOGIN_DOHOMEAPP(string Usernam, string password,  string PolicyCode)
        //{
        //    string Token = "LkMsr28g10jzMT5GWV/gSbyEzkaKagnf";  

        //    WebLogIn.Token token = new WebLogIn.Token();
        //    token.Value = Token;
        //    WebLogIn.Login lg = new WebLogIn.Login();
        //    lg.Username = Usernam;
        //    lg.Password = password;

        //    WebLogIn.AuthenticationSoapClient aut = new WebLogIn.AuthenticationSoapClient();
        //    WebLogIn.ResLogin res = aut.Login(token, lg);

        //    if (res.Authenticated)
        //    {
        //        //เช็คว่าเป็น Cashier หรือไม่
        //        if (res.Policy != null)
        //        {
        //            PolicyCode = res.Policy.PolicyCode.ToString();
        //        }
        //        else
        //        {
        //            PolicyCode = null;
        //        }
        //        return res.Authenticated.ToString();
        //    }
        //    else
        //    {
        //        PolicyCode = "";
        //        return res.Message;
        //    }
        //}

        [WebMethod]
        public string GET_SITE() {
            DBMASTERDataContext dBMASTER = new DBMASTERDataContext();
            List<TBMaster_Site> list_site = new List<TBMaster_Site>();
            Model_Site msite = new Model_Site();

            list_site = (from db_site in dBMASTER.TBMaster_Sites
                         select db_site).ToList();

            msite.TBMaster_Site = list_site;
            return JsonConvert.SerializeObject(msite);
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

    }

}
