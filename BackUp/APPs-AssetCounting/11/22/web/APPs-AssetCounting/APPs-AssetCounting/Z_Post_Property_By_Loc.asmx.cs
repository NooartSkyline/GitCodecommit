using Newtonsoft.Json;
using SourceCode.SmartObjects.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace APPs_AssetCounting
{
    /// <summary>
    /// Summary description for Z_Post_Property_By_Loc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Z_Post_Property_By_Loc : System.Web.Services.WebService
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
        public DataTable JsonToTable(String JsonString)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(JsonString, typeof(DataTable));
            
            return dt;
        }
        public DataSet JsonToDataSet(String JsonString)
        {
         //   DataSet ds = (DataSet)JsonConvert.DeserializeObject(JsonString, typeof(DataSet));
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(JsonString);
            return ds;
        }


        //[WebMethod]
        //public string ZDD_HH_SET_ZMM_ASSIGNLOC_MULTI(string Jsonstring)
        //{
        //    string strXml = "";
        //    string sMessage = "";
        //    try
        //    {
          //      DataTable dt = this.JsonToTable(Jsonstring);
        //        strXml = "<connect>";
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            strXml += "<I_ARTICLE_ASSIGNLOC>";
        //            //
        //            strXml += "<IN_MATNR>" + dr["O_ASSIGNLOC_MATERIAL"].ToString() + "</IN_MATNR>";
        //            strXml += "<IN_UNITOFMEASURE>" + dr["O_ASSIGNLOC_UNITOFMEASURE"].ToString() + "</IN_UNITOFMEASURE>";
        //            strXml += "<IN_BIN_CODE>" + dr["O_ASSIGNLOC_BIN_CODE"].ToString() + "</IN_BIN_CODE>";
        //            strXml += "<IN_LOCTYPE>" + dr["O_ASSIGNLOC_LOCTYPE"].ToString() + "</IN_LOCTYPE>";
        //            strXml += "<IN_SITE>" + dr["O_ASSIGNLOC_WERKS"].ToString() + "</IN_SITE>";
        //            strXml += "<IN_STORAGE_LOC>" + dr["O_ASSIGNLOC_STORAGE_LOC"].ToString() + "</IN_STORAGE_LOC>";
        //            strXml += "<IN_DEFAULT_BIN>" + (dt.Columns.Contains("O_ASSIGNLOC_DEFAULT_BIN") ? dr["O_ASSIGNLOC_DEFAULT_BIN"].ToString() : "") + "</IN_DEFAULT_BIN>";
        //            //
        //            if (dr["O_ASSIGNLOC_ROWORDER"].ToString() == "")
        //                strXml += "<IN_ROWORDER>" + "0" + "</IN_ROWORDER>";
        //            else
        //                strXml += "<IN_ROWORDER>" + dr["O_ASSIGNLOC_ROWORDER"].ToString() + "</IN_ROWORDER>";
        //            //
        //            if (dr["O_ASSIGNLOC_PUTQTY"].ToString() == "")
        //                strXml += "<IN_PUTQTY>" + "0" + "</IN_PUTQTY>";
        //            else
        //                strXml += "<IN_PUTQTY>" + dr["O_ASSIGNLOC_PUTQTY"].ToString() + "</IN_PUTQTY>";
        //            //
        //            if (dr["O_ASSIGNLOC_PUTLEVEL"].ToString() == "")
        //                strXml += "<IN_PUTLEVEL>" + "0" + "</IN_PUTLEVEL>";
        //            else
        //                strXml += "<IN_PUTLEVEL>" + dr["O_ASSIGNLOC_PUTLEVEL"].ToString() + "</IN_PUTLEVEL>";
        //            //
        //            if (dr["O_ASSIGNLOC_MAXSTOCK"].ToString() == "")
        //                strXml += "<IN_MAXSTOCK>" + "0" + "</IN_MAXSTOCK>";
        //            else
        //                strXml += "<IN_MAXSTOCK>" + dr["O_ASSIGNLOC_MAXSTOCK"].ToString() + "</IN_MAXSTOCK>";
        //            //
        //            strXml += "</I_ARTICLE_ASSIGNLOC>";
        //        }
        //        strXml += "</connect>";

        //        SmartObjectClientServer serverName = K2_CONNECT_SERVER();// Connect K2 Server 
        //        SmartObject smartObject = serverName.GetSmartObject("ZDD_HH_SET_ZMM_ASSIGNLOC_MULTI_I_ARTICLE_ASSIGNLOC");
        //        smartObject.MethodToExecute = "ZDD_HH_SET_ZMM_ASSIGNLOC_MULTII_ARTICLE_ASSIGNLOC_ZDD_HH_SET_ZMM_ASSIGNLOC_MULTI";
        //        SetPropertyValue(smartObject.ListMethods["ZDD_HH_SET_ZMM_ASSIGNLOC_MULTII_ARTICLE_ASSIGNLOC_ZDD_HH_SET_ZMM_ASSIGNLOC_MULTI"].InputProperties["p_P_BUKRS"], );
        //        SetPropertyValue(smartObject.ListMethods["ZDD_HH_SET_ZMM_ASSIGNLOC_MULTII_ARTICLE_ASSIGNLOC_ZDD_HH_SET_ZMM_ASSIGNLOC_MULTI"].InputProperties["p_P_GJAHR"], );
        //        SetPropertyValue(smartObject.ListMethods["ZDD_HH_SET_ZMM_ASSIGNLOC_MULTII_ARTICLE_ASSIGNLOC_ZDD_HH_SET_ZMM_ASSIGNLOC_MULTI"].InputProperties["p_P_WERKS"], );
        //        SetPropertyValue(smartObject.ListMethods["ZDD_HH_SET_ZMM_ASSIGNLOC_MULTII_ARTICLE_ASSIGNLOC_ZDD_HH_SET_ZMM_ASSIGNLOC_MULTI"].InputProperties["I_TABLE"], strXml); // รับ XML


        //        DataTable dt_result = serverName.ExecuteListDataTable(smartObject);
        //        serverName.Connection.Close();

        //        //loop check each article have been set to SAP
        //        bool check = false;
        //        dev.lib.Utilities devlib = new dev.lib.Utilities();
        //        List<string> list = new List<string>();

        //        foreach (DataRow row in dt.Rows)
        //        {
        //            foreach (DataRow result in dt_result.Rows)
        //            {
        //                if (devlib.RemoveZero(result["TBL_LOCATION_MATERIAL"].ToString()).Equals(row["O_ASSIGNLOC_MATERIAL"].ToString()) &&
        //                    result["TBL_LOCATION_BIN_CODE"].ToString().Equals(row["O_ASSIGNLOC_BIN_CODE"].ToString()) &&
        //                    result["TBL_LOCATION_UNITOFMEASURE"].ToString().Equals(row["O_ASSIGNLOC_UNITOFMEASURE"].ToString()) &&
        //                    result["TBL_LOCATION_WERKS"].ToString().Equals(row["O_ASSIGNLOC_WERKS"].ToString()) &&
        //                    result["TBL_LOCATION_STORAGE_LOC"].ToString().Equals(row["O_ASSIGNLOC_STORAGE_LOC"].ToString()))
        //                {
        //                    check = true;
        //                    break;
        //                }

        //            }
        //            if (!check)
        //            {
        //                list.Add(row["O_ASSIGNLOC_MATERIAL"].ToString());
        //            }

        //        }

        //        if (check)
        //        {
        //            sMessage = "S";
        //        }
        //        else
        //        {
        //            sMessage = "Article : ";
        //            foreach (var i in list)
        //            {
        //                sMessage += i + ", ";
        //            }
        //            sMessage = " doesn't set by SAP! Please try again.";

        //        }
        //        return sMessage;


        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }

        //}

        [WebMethod] 
        public string Z_POST_PROPERTY_BY_LOC(string Jsonstring)
        {
            SmartObjectClientServer serverName = new SmartObjectClientServer();
            DataSet ds = this.JsonToDataSet(Jsonstring);
            string sMessage = "";
            try
            {
                string sRetrun = Z_POST_PROPERTY_BY_LOC_I_TABLE(ds.Tables["DT"]);

                serverName = K2_CONNECT_SERVER();// Connect K2 Server 

                SmartObject smartObject = serverName.GetSmartObject("Z_POST_PROPERTY_BY_LOC");
                smartObject.MethodToExecute = "Z_POST_PROPERTYBY_LOC_Z_POST_PROPERTY_BY_LOC";
                // Assign Input properties
                SetPropertyValue(smartObject.ListMethods["Z_POST_PROPERTYBY_LOC_Z_POST_PROPERTY_BY_LOC"].InputProperties["p_P_BUKRS"], ds.Tables["HD"].Rows[0]["p_P_BUKRS"].ToString());
                SetPropertyValue(smartObject.ListMethods["Z_POST_PROPERTYBY_LOC_Z_POST_PROPERTY_BY_LOC"].InputProperties["p_P_GJAHR"], ds.Tables["HD"].Rows[0]["p_P_GJAHR"].ToString());
                SetPropertyValue(smartObject.ListMethods["Z_POST_PROPERTYBY_LOC_Z_POST_PROPERTY_BY_LOC"].InputProperties["p_P_WERKS"], ds.Tables["HD"].Rows[0]["p_P_WERKS"].ToString());
                SetPropertyValue(smartObject.ListMethods["Z_POST_PROPERTYBY_LOC_Z_POST_PROPERTY_BY_LOC"].InputProperties["I_TABLE"], sRetrun);

                DataTable dt_retrun = serverName.ExecuteListDataTable(smartObject);
                sMessage = dt_retrun.Rows[0]["O_TABLE_DOCNO"].ToString();

                //SmartObject returnSmartObject;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                serverName.Connection.Close();
            }

            return sMessage;


        }

        public string Z_POST_PROPERTY_BY_LOC_I_TABLE(DataTable dt)
        {
            SmartObjectClientServer serverName = new SmartObjectClientServer();
            string str_serialize = "";

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    serverName = K2_CONNECT_SERVER();// Connect K2 Server 
                    SmartObject smartObject = serverName.GetSmartObject("Z_POST_PROPERTY_BY_LOC_I_TABLE");
                    smartObject.MethodToExecute = "SerializeAddItemToArray";
                    // Assign Input properties
                    SetPropertyValue(smartObject.Methods["SerializeAddItemToArray"].InputProperties["Serialized_Array__I_TABLE___"], str_serialize);
                    SetPropertyValue(smartObject.Methods["SerializeAddItemToArray"].InputProperties["BUKRS"], row["BUKRS"].ToString());
                    SetPropertyValue(smartObject.Methods["SerializeAddItemToArray"].InputProperties["ANLN1"], row["ANLN1"].ToString());


                    SmartObject returnSmartObject;

                    // Execute SmartObject
                    using (serverName.Connection)
                    {
                        returnSmartObject = serverName.ExecuteScalar(smartObject);
                        str_serialize = returnSmartObject.Properties["Serialized_Array__I_TABLE___"].Value;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    serverName.Connection.Close();
            //}
            
           
           
            return str_serialize;
        }
    }
    
}
