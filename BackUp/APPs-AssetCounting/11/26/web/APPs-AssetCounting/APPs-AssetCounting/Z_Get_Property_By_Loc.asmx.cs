using dev.lib;
using Newtonsoft.Json;
using SourceCode.SmartObjects.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace APPs_AssetCounting
{
    /// <summary>
    /// Summary description for Z_Get_Property_By_Loc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Z_Get_Property_By_Loc : System.Web.Services.WebService
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
        public string Z_GET_LOCATION(string BRANCH, string WERKS)
        {
            dev.lib.Utilities utilities = new Utilities();
            DataSet ds = new DataSet();
            try
            {
                if (BRANCH != "" && WERKS != "") // SiteCode และ Sloc บังคับให้ระบุ
                {
                    SmartObjectClientServer serverName = K2_CONNECT_SERVER();// Connect K2 Server 
                    SmartObject smartObject = serverName.GetSmartObject("Z_GET_PROPERTY_BY_LOC");//ชื่อ SmartOject
                    smartObject.MethodToExecute = "Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC";
                    //Set parameter

                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_ANLN1"].Value = "X";    //utilities.AddZero(ANLN1, 12);
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_BUKRS"].Value = BRANCH;
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_GJAHR"].Value = DateTime.Now.Year.ToString();
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_LANGU"].Value = "EN";
                    //smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_STORT"].Value = STORT;
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_WERKS"].Value = WERKS;
                    DataTable dt = serverName.ExecuteListDataTable(smartObject);

                    DataTable dt_new = new DataTable();
                    dt_new.TableName = "Z_GET_PROPERTY_BY_LOC";

                    dt_new.Columns.Add("O_TABLE_STORT", typeof(string));
                    dt_new.Columns.Add("O_TABLE_STORT_TXT", typeof(string));

                    //DataTable dt_Duplicate = RemoveDuplicateRows(dt, "O_TABLE_STORT");

                    if (dt.Rows.Count > 0)
                    {
                        dt = dt.AsEnumerable()
                            .GroupBy(r => new { O_TABLE_STORT = r["O_TABLE_STORT"], O_TABLE_STORT_TXT = r["O_TABLE_STORT_TXT"] })
                            .Select(g => g.OrderBy(r => r["O_TABLE_STORT"]).First())
                            .CopyToDataTable();

                        foreach (DataRow dr_1 in dt.Rows)
                        {
                            DataRow dr_2 = dt_new.NewRow();

                            dr_2["O_TABLE_STORT"] = dr_1["O_TABLE_STORT"].ToString();
                            dr_2["O_TABLE_STORT_TXT"] = dr_1["O_TABLE_STORT_TXT"];

                            dt_new.Rows.Add(dr_2);
                        }
                        ds.Tables.Add(dt_new);

                       
                    }
                    else {
                        dt.TableName = "Z_GET_PROPERTY_BY_LOC";
                        ds.Tables.Add(dt);
                    }
                    serverName.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ConvertDataSetToJSON(ds); // Retrun DataSet โดยแปลงข้อมูลทั้งหมดเป้น JSON

        }
        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        [WebMethod]
        public string Z_GET_PROPERTY_BY_LOC(string BRANCH, string WERKS, string STORT)
        {
            dev.lib.Utilities utilities = new Utilities();
            DataSet ds = new DataSet();
            try
            {
                if (BRANCH != "" && WERKS != "") // SiteCode และ Sloc บังคับให้ระบุ
                {
                    SmartObjectClientServer serverName = K2_CONNECT_SERVER();// Connect K2 Server 
                    SmartObject smartObject = serverName.GetSmartObject("Z_GET_PROPERTY_BY_LOC");//ชื่อ SmartOject
                    smartObject.MethodToExecute = "Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC";
                    //Set parameter

                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_ANLN1"].Value = "X";    //utilities.AddZero(ANLN1, 12);
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_BUKRS"].Value = BRANCH;
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_GJAHR"].Value = DateTime.Now.Year.ToString();
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_LANGU"].Value = "EN";
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_STORT"].Value = STORT;
                    smartObject.ListMethods["Z_GET_PROPERTYBY_LOC_Z_GET_PROPERTY_BY_LOC"].InputProperties["p_P_WERKS"].Value = WERKS;
                    DataTable dt = serverName.ExecuteListDataTable(smartObject);
                    dt.TableName = "Z_GET_PROPERTY_BY_LOC";

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

        private static void SetPropertyValue(SmartProperty smartProperty, object value)
        {
            if (value == null)
            {
                smartProperty.ValueBehaviour = ValueBehaviour.Unchanged;
                smartProperty.Value = null;
            }
            else if (value == DBNull.Value)
            {
                smartProperty.ValueBehaviour = ValueBehaviour.Clear;
                smartProperty.Value = null;
            }
            else if (value.ToString() == string.Empty)
            {
                smartProperty.ValueBehaviour = ValueBehaviour.Empty;
                smartProperty.Value = string.Empty;
            }
            else
            {
                smartProperty.ValueBehaviour = ValueBehaviour.None;
                smartProperty.Value = value.ToString();
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
    }
}

       