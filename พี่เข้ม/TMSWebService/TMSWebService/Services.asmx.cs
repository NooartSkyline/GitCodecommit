using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using SourceCode.Hosting.Client;
using SourceCode.SmartObjects.Client;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Xml;
using System.IO;

namespace TMSWebService
{
    /// <summary>
    /// Summary description for Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Services : System.Web.Services.WebService
    {
        SourceCode.SmartObjects.Client.SmartObjectClientServer serverName = new SmartObjectClientServer();
        SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();
        //
        private struct Config
        {
            /// <summary>
            /// K2 User Login
            /// </summary>
            public string _user;
            /// <summary>
            /// K2 Password
            /// </summary>
            public string _password;
            /// <summary>
            /// Domain
            /// </summary>
            public string _domain;
            /// <summary>
            /// K2 Server
            /// </summary>
            public string _serverName;
            /// <summary>
            /// K2 Securitybel
            /// </summary>
            public string _SecurityLabel;

        }

        private Config Local_Config = new Config();
        private void IsK2Connect()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + @"\Config.xml");
            DataRow drow = ds.Tables[0].Rows[0];
            this.Local_Config._user = drow["K2User"].ToString();
            this.Local_Config._domain = drow["Domain"].ToString();
            this.Local_Config._serverName = drow["K2Server"].ToString(); ;

            string strPwd = drow["K2Password"].ToString();
            if (strPwd != "")
            {
                EnDeCode.ClsEnDeCode dec = new EnDeCode.ClsEnDeCode();
                strPwd = dec.Decrypt(strPwd, "UW");
            }
            this.Local_Config._password = strPwd;
            this.Local_Config._SecurityLabel = drow["SecurityLabel"].ToString();

            connectionString.Authenticate = true;
            connectionString.Host = this.Local_Config._serverName;
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = 5555;
            connectionString.UserID = this.Local_Config._user;
            connectionString.WindowsDomain = this.Local_Config._domain;
            connectionString.Password = this.Local_Config._password;
            connectionString.SecurityLabelName = this.Local_Config._SecurityLabel; //the default label
            serverName.CreateConnection();
            serverName.Connection.Open(connectionString.ToString());
        }

        [WebMethod]
        public string InterfaceDO_into_1Link(string sDoDocNo, string sResend)
        {
            string strReturn = "";
            string strXml = "";

            try
            {
                this.IsK2Connect();

                #region Z1LINK_INTERFACE_DO
                // Get SmartObject 
                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_GETDO");
                smartObject.MethodToExecute = "ZBAPI_TMSGETDO_ZBAPI_TMS_GETDO";
                SetPropertyValue(smartObject.Methods["ZBAPI_TMSGETDO_ZBAPI_TMS_GETDO"].InputProperties["p_P_DO"], sDoDocNo);
                SetPropertyValue(smartObject.Methods["ZBAPI_TMSGETDO_ZBAPI_TMS_GETDO"].InputProperties["p_P_RESEND"], sResend);

                SmartObject returnSmartObject;
                returnSmartObject = serverName.ExecuteScalar(smartObject);
                string strXml_DO_HD = returnSmartObject.Properties["DO_HEADER"].Value;
                string strXml_DO_DT = returnSmartObject.Properties["DO_DETAIL"].Value;
                #endregion
                //---------------------Table : ZBAPI_TMS_GETDO_DO_HEADER-------------------------------
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_GETDO_DO_HEADER");
                smartObject.MethodToExecute = "DeserializeTypedArray";
                SetPropertyValue(smartObject.ListMethods["DeserializeTypedArray"].InputProperties["Serialized_Array__DO_HEADER___"], strXml_DO_HD);
                SmartObjectList SmartObjectListDO_HD = serverName.ExecuteList(smartObject);
                //---------------------Table : ZBAPI_TMS_GETDO_DO_DETAIL-------------------------------
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_GETDO_DO_DETAIL");
                smartObject.MethodToExecute = "DeserializeTypedArray";
                SetPropertyValue(smartObject.ListMethods["DeserializeTypedArray"].InputProperties["Serialized_Array__DO_DETAIL___"], strXml_DO_DT);
                SmartObjectList SmartObjectListDO_DT = serverName.ExecuteList(smartObject);
                //---------------------Loop : SmartObjectListDO----------------------------------------
                if (SmartObjectListDO_HD.SmartObjectsList.Count > 0)
                {
                    strXml = "<CustQData>";
                    foreach (SmartObject smo in SmartObjectListDO_HD.SmartObjectsList)
                    {
                        strXml += "<QItem>";
                        strXml += "<QNo></QNo>";
                        strXml += "<QKey></QKey>";
                        strXml += "<SO>" + smo.Properties["SODOC"].Value + "</SO>";
                        strXml += "<DO>" + smo.Properties["DODOC"].Value + "</DO>";
                        strXml += "<RefDO></RefDO>";

                        strXml += "<JobCode></JobCode>";

                        string dvDate = smo.Properties["DDATE"].Value.Substring(8, 2) + "/" + smo.Properties["DDATE"].Value.Substring(5, 2) + "/" + smo.Properties["DDATE"].Value.Substring(0, 4);
                        strXml += "<DeliveryDate>" + dvDate + "</DeliveryDate>";

                        string dvTime = smo.Properties["DTIME"].Value.Substring(0, 2) + ":" + smo.Properties["DTIME"].Value.Substring(2, 2);
                        strXml += "<DeliveryTime>" + dvTime + "</DeliveryTime>";

                        strXml += "<Site>" + smo.Properties["BRSALES"].Value + "</Site>";
                        strXml += "<ShippingPoint>" + smo.Properties["BRSHIP"].Value + "</ShippingPoint>";
                        strXml += "<SoldToNo>" + this.OnReplaceZero(smo.Properties["CUST"].Value) + "</SoldToNo>"; 
                        strXml += "<SoldToName>" + smo.Properties["CUSTNAME"].Value.Replace("&", "&amp;") + "</SoldToName>"; 
                        strXml += "<ShipToNo>" + this.OnReplaceZero(smo.Properties["RECEIVER"].Value) + "</ShipToNo>"; 
                        strXml += "<JobType></JobType>";  
                        strXml += "<Remark></Remark>"; 
                        strXml += "<ContactName>" + smo.Properties["RECNAME"].Value.Replace("&", "&amp;") + "</ContactName>"; 
                        strXml += "<ShipToTel>" + smo.Properties["TELEPHONE"].Value + "</ShipToTel>";
                        strXml += "<TelHome></TelHome>";  
                        strXml += "<TelOffice></TelOffice>"; 
                        strXml += "<Mobile1></Mobile1>";  
                        strXml += "<Mobile2></Mobile2>";
                        strXml += "<Fax>" + smo.Properties["FAX"].Value + "</Fax>";
                        strXml += "<MoreTeamFlag></MoreTeamFlag>";
                        strXml += "<Worker></Worker>"; 
                        strXml += "<BigLot></BigLot>";
                        strXml += "<CustomerType></CustomerType>";
                        strXml += "<Status>" + smo.Properties["STATUS"].Value + "</Status>";
                        strXml += "<ShiftRound></ShiftRound>";
                        strXml += "<transportationCostsFromCustomers></transportationCostsFromCustomers>"; 
                        strXml += "<transportationCosts></transportationCosts>";
                        strXml += "<typeOfDelivery>" + smo.Properties["VSBED"].Value + "</typeOfDelivery>";
                        strXml += "<Paytment>" + smo.Properties["SHPMNT_INCOME"].Value.ToString() + "</Paytment>";
                        // SO/DO ที่มีการชำระเงินแล้ว  ค่า IS_COD  ใส่ค่าว่าง
                        // ถ้าสถานะการจ่ายเงินเป็นเครดิต 1 วัน  ค่า param IS_COD  ต้องมีค่า   ส่งเป็น  Y  หรือ 1  หรืออะไรมากะได้  ไม่ให้ว่าง
                        strXml += "<IsCod>" + smo.Properties["COD"].Value.ToString() + "</IsCod>"; 
                        strXml += "<Address>";
                        strXml += "<Title>" + smo.Properties["TITLE"].Value + "</Title>";
                        strXml += "<FirstName>" + smo.Properties["FNAME"].Value.Replace("&", "&amp;") + "</FirstName>";
                        strXml += "<LastName>" + smo.Properties["LNAME"].Value + "</LastName>";
                        strXml += "<Village>" + smo.Properties["VILLAGE"].Value + "</Village>"; 
                        strXml += "<Floor>" + smo.Properties["FLOOR"].Value + "</Floor>";
                        strXml += "<Room>" + smo.Properties["ROOM"].Value + "</Room>"; 
                        strXml += "<HouseNumber>" + smo.Properties["HNUMBER"].Value + "</HouseNumber>";
                        strXml += "<Moo>" + smo.Properties["MOO"].Value + "</Moo>";
                        strXml += "<Soi>" + smo.Properties["SOI"].Value + "</Soi>";
                        strXml += "<Road>" + smo.Properties["ROAD"].Value.Replace("&", "&amp;") + "</Road>";
                        strXml += "<SubDistrict>" + smo.Properties["SUBDIST"].Value + "</SubDistrict>";
                        strXml += "<District>" + smo.Properties["DISTRICT"].Value + "</District>";
                        string strProvince = "";
                        if (smo.Properties["PROVINCE"].Value == "กรุงเทพมหานคร" || smo.Properties["PROVINCE"].Value == "กรุงเทพ")
                            strProvince = "กรุงเทพมหานคร";
                        else
                            strProvince = "จ." + smo.Properties["PROVINCE"].Value;
                        strXml += "<Province>" + strProvince + "</Province>";

                        strXml += "<PostCode>" + smo.Properties["POSTCODE"].Value + "</PostCode>";
                        strXml += "<ResidenType></ResidenType>"; 
                        strXml += "<ShipToName>" + smo.Properties["RECNAME"].Value.Replace("&", "&amp;") + "</ShipToName>";
                        strXml += "</Address>";
                        //
                        if (SmartObjectListDO_DT.SmartObjectsList.Count > 0)
                        {
                            foreach (SmartObject smo_article in SmartObjectListDO_DT.SmartObjectsList)
                            {
                                if (smo_article.Properties["DODOC"].Value == smo.Properties["DODOC"].Value)
                                {
                                    strXml += "<Article>";
                                    strXml += "<ItemNo>" + this.OnReplaceZero(smo_article.Properties["SEQ"].Value) + "</ItemNo>";
                                    strXml += "<ArticleNo>" + this.OnReplaceZero(smo_article.Properties["ITEMNO"].Value) + "</ArticleNo>";
                                    strXml += "<Qty>" + smo_article.Properties["QTY"].Value.ToString() + "</Qty>";
                                    strXml += "<Amount>" + smo_article.Properties["AMOUNT"].Value.ToString() + "</Amount>";
                                    strXml += "<UnitCode>" + smo_article.Properties["UOM"].Value + "</UnitCode>";
                                    strXml += "<InstallFlag></InstallFlag>";
                                    strXml += "<ItemText>" + smo_article.Properties["ITEM_DESC"].Value.Replace("&", "&amp;") + "</ItemText>";
                                    strXml += "<volume>" + smo_article.Properties["VOLUME"].Value.ToString() + "</volume>";
                                    strXml += "<dimension>" + smo_article.Properties["WEIGHT"].Value.ToString() + "</dimension>";
                                    strXml += "<ATP></ATP>";
                                    // ตัวแรก เท่ากับ 1 คือ รหัสสินค้าที่ไม่ใช่ค่าบริหาร
                                    if (this.OnReplaceZero(smo_article.Properties["ITEMNO"].Value).Substring(0, 1) == "1")
                                    {
                                        strXml += "<Worker></Worker>";
                                    }
                                    else
                                    {
                                        strXml += "<Worker>" + smo_article.Properties["WORKER"].Value + "</Worker>";
                                    }

                                    strXml += "<JobType>" + smo_article.Properties["JOBTYPE"].Value.ToString() + "</JobType>";
                                    strXml += "</Article>";
                                }
                            }
                        }
                        strXml += "</QItem>";
                    }
                    strXml += "</CustQData>";
                }
                //serverName.Connection.Close();

                if (strXml != "")
                {
                    //Production
                    DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
                    ///
                    //Qas
                    //DO_WebReference_Test.DHMService web = new DO_WebReference_Test.DHMService();

                    strXml = web.OTSReciveQData(strXml);

                    int i1 = strXml.ToUpper().IndexOf("<RESULT>") + 8;
                    int i2 = strXml.ToUpper().IndexOf("</RESULT>");

                    if (i1 >= 0 && i2 >= 0)
                    {
                        strReturn = strXml.Substring(i1, i2 - i1);
                    }
                    else
                    {
                        strReturn = "";
                    }
                }
                //ส่งข้อมูล ShipTo
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_GETDO_DO_HEADER");
                smartObject.MethodToExecute = "DeserializeTypedArray";
                // Set input parameter (Filter)
                SetPropertyValue(smartObject.ListMethods["DeserializeTypedArray"].InputProperties["Serialized_Array__DO_HEADER___"], strXml_DO_HD);
                SmartObjectList SmartObjectListDOBottom = serverName.ExecuteList(smartObject);

                if (strReturn == "Y" && SmartObjectListDOBottom.SmartObjectsList.Count > 0)
                {
                    foreach (SmartObject smo in SmartObjectListDO_HD.SmartObjectsList)
                    {
                        strXml = "<RecvShipTo>";
                        strXml += "<ShiptTo>";

                        strXml += "<SoldToNo>" + smo.Properties["CUST"].Value + "</SoldToNo>"; 
                        strXml += "<ShipToNo>" + smo.Properties["RECEIVER"].Value + "</ShipToNo>"; 
                        strXml += "<ShipToName>" + smo.Properties["RECNAME"].Value.Replace("&", "&amp;") + "</ShipToName>"; 

                        string dvDate = smo.Properties["DDATE"].Value.Substring(8, 2) + "/" + smo.Properties["DDATE"].Value.Substring(5, 2) + "/" + smo.Properties["DDATE"].Value.Substring(0, 4);
                        strXml += "<TransDate>" + dvDate + "</TransDate>";

                        strXml += "<InitialName>" + "" + "</InitialName>"; //NO HANA
                        strXml += "<Title>" + smo.Properties["TITLE"].Value + "</Title>";
                        strXml += "<FirstName>" + smo.Properties["FNAME"].Value.Replace("&", "&amp;") + "</FirstName>";
                        strXml += "<LastName>" + smo.Properties["LNAME"].Value.Replace("&", "&amp;") + "</LastName>";
                        strXml += "<Village>" + smo.Properties["VILLAGE"].Value + "</Village>";
                        strXml += "<Floor>" + smo.Properties["FLOOR"].Value + "</Floor>";
                        strXml += "<Room>" + smo.Properties["ROOM"].Value + "</Room>";
                        strXml += "<HouseNumber>" + smo.Properties["HNUMBER"].Value + "</HouseNumber>";
                        strXml += "<Moo>" + smo.Properties["MOO"].Value + "</Moo>";
                        strXml += "<Soi>" + smo.Properties["SOI"].Value + "</Soi>";
                        strXml += "<Road>" + smo.Properties["ROAD"].Value + "</Road>";
                        strXml += "<SubDistrict>" + smo.Properties["SUBDIST"].Value + "</SubDistrict>";
                        strXml += "<District>" + smo.Properties["DISTRICT"].Value + "</District>";
                        strXml += "<Province>จ." + smo.Properties["PROVINCE"].Value + "</Province>";
                        strXml += "<PostCode>" + smo.Properties["POSTCODE"].Value + "</PostCode>";
                        strXml += "<ResidenType>" + "" + "</ResidenType>";

                        strXml += "</ShiptTo>";
                        strXml += "</RecvShipTo>";

                        if (strXml != "")
                        {
                            //Production
                            DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
                            ///
                            //Qas
                            //DO_WebReference_Test.DHMService web = new DO_WebReference_Test.DHMService();
                            strXml = web.OTSReceiveShipTo(strXml);
                        }
                    }
                }

                if (strReturn.Trim() == "")
                    strReturn = "N";

                serverName.Connection.Close();

                return strReturn;
            }
            catch (Exception ex)
            {
                strReturn = ex.Message;
                return strReturn;
            }
        }  // เช็คแล้ว

        [WebMethod]
        public string InterfacePlanning_to_1Link_XML(string SapId, string Shipping, string Licenseplate,
                                                 string EmployeeId, string EmployeeName, string MOB_NUMBER,
                                                 string StampDate, string StampTime, string DoList)
        {
            string strPlanNo = "";
            string strDistance = "";
            string strReturn = "";
            string strXml = "";
            strXml = "<Planning>";
            strXml += "<SapId>" + SapId + "</SapId>";
            strXml += "<Shipping>" + Shipping + "</Shipping>";
            strXml += "<Licenseplate>" + Licenseplate + "</Licenseplate>";
            strXml += "<EmployeeId>" + this.OnReplaceZero(EmployeeId) + "</EmployeeId>";
            strXml += "<EmployeeName>" + EmployeeName + "</EmployeeName>";
            strXml += "<TelNumber>" + MOB_NUMBER + "</TelNumber>";

            string strStampDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            strXml += "<StampDate>" + strStampDate + "</StampDate>";
            strXml += "<TellNumber>" + MOB_NUMBER + "</TellNumber>";
            ///--------------------------------------------
            strXml += "<DOList>";
            string[] doList = DoList.Split(',');
            foreach (string donom in doList)
            {
                strXml += "<DO>" + donom + "</DO>";
            }
            strXml += "</DOList>";
            ///--------------------------------------------
            strXml += "</Planning>";

            if (strXml != "")
            {
                //Production
                DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
                ///
                //Qas
                //DO_WebReferencePRD_Test.DHMService web = new DO_WebReferencePRD_Test.DHMService();

                strXml = web.OTSPlanning(strXml);

                int i1 = strXml.ToUpper().IndexOf("<ROUTEID>") + 9;
                int i2 = strXml.ToUpper().IndexOf("</ROUTEID>");
                int i3 = strXml.ToUpper().IndexOf("<TOTALDISTANCE>") + 15;
                int i4 = strXml.ToUpper().IndexOf("</TOTALDISTANCE>");

                if (i1 >= 0 && i2 >= 0)
                {
                    strPlanNo = strXml.Substring(i1, i2 - i1).Trim();
                }
                else
                {
                    strPlanNo = "";
                }
                if (i3 >= 0 && i4 >= 0)
                {
                    strDistance = strXml.Substring(i3, i4 - i3).Trim();
                }
                else
                {
                    strDistance = "";
                }
                if (strPlanNo != "")
                {
                    if (strDistance == "")
                        strDistance = "0";

                    strReturn = strPlanNo + "," + strDistance;
                }
                else
                    strReturn = "";
            }
            if (strReturn.Trim() == "")
                strReturn = "N";

            return strReturn;
        }

        //public string GetStatusCheckPlanning(string PlanningNo)
        //{
        //    string strReturn = "";
        //    this.IsConnectK2FormConfigXML();
        //    SmartObject smartObject = new SmartObject();
        //    smartObject = serverName.GetSmartObject("ZTMS_CHECK_PLANNING");
        //    smartObject.MethodToExecute = "ZTMS_CHECKPLANNING_ZTMS_CHECK_PLANNING";
        //    SetPropertyValue(smartObject.Methods["ZTMS_CHECKPLANNING_ZTMS_CHECK_PLANNING"].InputProperties["p_PLANNINGNO"], PlanningNo); // เลขที่ใบจัด
        //    SmartObject returnSmartObject;
        //    returnSmartObject = serverName.ExecuteScalar(smartObject);

        //    strReturn = returnSmartObject.Properties["RESULT"].Value;

        //    return strReturn;
        //}

        [WebMethod]
        public string InterfaceCashinfo_into_1Link(string DocumentNo)  
        {
            string strXml = "";
            string strReturn = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_GETCASH");
                smartObject.MethodToExecute = "ZBAPI_TMSGETCASH_ZBAPI_TMS_GETCASH";
                SetPropertyValue(smartObject.ListMethods["ZBAPI_TMSGETCASH_ZBAPI_TMS_GETCASH"].InputProperties["p_VBELN"], DocumentNo); // เลขที่การจัดส่ง

                #region List Methods จาก Datatable
                //DataTable dt = serverName.ExecuteListDataTable(smartObject);

                //strXml = "<RecvCashInfo>";
                //if (dt.Rows.Count > 0)
                //{
                //    DataRow dr = dt.Rows[0];
                //    strXml += "<PlanId>" + dr["ZCASHINFO_TKNUM"].ToString() + "</PlanId>";
                //    strXml += "<SO>" + dr["ZCASHINFO_ZUONR"].ToString() + "</SO>";
                //    strXml += "<BELNR>" + dr["ZCASHINFO_BELNR"].ToString() + "</BELNR>";
                //    strXml += "<CashId>" + dr["ZCASHINFO_AUGBL"].ToString() + "</CashId>";
                //    // วันที่รับเงิน
                //    //string dvDate = dr["ZCASHINFO_AUGDT"].ToString().Substring(1, 2) + "/" + dr["ZCASHINFO_AUGDT"].ToString().Substring(4, 2) + "/" + dr["ZCASHINFO_AUGDT"].ToString().Substring(0, 4);
                //    string dvDate = Convert.ToDateTime(dr["ZCASHINFO_AUGDT"].ToString()).Date.ToString("dd/MM/yyyy");
                //    strXml += "<CashDate>" + dvDate + "</CashDate>"; // ปี เป็น พ.ศ. หรือ ค.ศ.
                //    ///
                //    strXml += "<DOList>";
                //    foreach (DataRow drow in dt.Rows)
                //    {
                //        strXml += "<DO>" + drow["ZCASHINFO_VBELN"].ToString() + "</DO>";
                //    }
                //    strXml += "</DOList>";
                //    strXml += "</RecvCashInfo>";

                //    if (strXml != "")
                //    {
                //        DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
                //        strXml = web.OTSRecvCashInfo(strXml);

                //    }
                //}
                #endregion
                //
                #region List Methods จาก SmartObjectList
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);

                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    SmartObject smo = SmartObjectList.SmartObjectsList[0];

                    strXml = "<RecvCashInfo>";
                    strXml += "<PlanId>" + smo.Properties["CASHINFO_TKNUM"].Value + "</PlanId>";
                    strXml += "<SO>" + smo.Properties["CASHINFO_ZUONR"].Value + "</SO>";
                    strXml += "<BELNR>" + smo.Properties["CASHINFO_BELNR"].Value + "</BELNR>";
                    strXml += "<CashId>" + smo.Properties["CASHINFO_AUGBL"].Value + "</CashId>";

                    string dvDate = smo.Properties["CASHINFO_AUGDT"].Value.Substring(8, 2) + "/" + smo.Properties["CASHINFO_AUGDT"].Value.Substring(5, 2) + "/" + smo.Properties["CASHINFO_AUGDT"].Value.Substring(0, 4);
                    strXml += "<CashDate>" + dvDate + "</CashDate>";

                    strXml += "<DOList>";
                    foreach (SmartObject smo_dolist in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<DO>" + smo_dolist.Properties["CASHINFO_VBELN"].Value + "</DO>";
                    }
                    strXml += "</DOList>";
                    strXml += "</RecvCashInfo>";

                    serverName.Connection.Close();

                    if (strXml != "")
                    {
                        //Production
                        DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
                        ///
                        //Qas
                        //DO_WebReference_Test.DHMService web = new DO_WebReference_Test.DHMService();
                        strXml = web.OTSRecvCashInfo(strXml);
                    }
                }
                #endregion

                if (strReturn.Trim() == "")
                    strReturn = "N";
                else
                    strReturn = "Y";
                return strReturn;
                //return strXml;
            }
            catch (Exception ex)
            {
                strReturn = ex.Message;
                return strReturn;
            }
        } //Check แล้ว

        //[WebMethod]
        //public string InterfaceDO_Shipto_into_1Link()
        //{
        //    string strReturn = "";
        //    string strXml = "";
        //    try
        //    {
        //        this.IsConnectK2FormConfigXML();
        //        SmartObject smartObject = new SmartObject();
        //        smartObject = serverName.GetSmartObject("ZTMS_GET_SHIPTO");
        //        smartObject.MethodToExecute = "ZTMS_GETSHIPTO_ZTMS_GET_SHIPTO";
        //        SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
        //        if (SmartObjectList.SmartObjectsList.Count > 0)
        //        {
        //            foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
        //            {
        //                strXml = "<RecvShipTo>";
        //                strXml += "<ShiptTo>";

        //                strXml += "<SoldToNo>" + smo.Properties["ZSHIPTO_SOI"].Value + "</SoldToNo>";
        //                strXml += "<ShipToNo>" + smo.Properties["ZSHIPTO_CUSTID"].Value + "</ShipToNo>";
        //                string dvDate = smo.Properties["ZSHIPTO_TRNSD"].Value.Substring(8, 2) + "/" + smo.Properties["ZSHIPTO_TRNSD"].Value.Substring(5, 2) + "/" + smo.Properties["ZSHIPTO_TRNSD"].Value.Substring(0, 4);
        //                strXml += "<TransDate>" + dvDate + "</TransDate>";
        //                strXml += "<InitialName>" + smo.Properties["ZSHIPTO_ININAM"].Value + "</InitialName>";
        //                strXml += "<Title>" + smo.Properties["ZSHIPTO_TITLE"].Value + "</Title>";
        //                strXml += "<FirstName>" + smo.Properties["ZSHIPTO_FNAME"].Value.Replace("&", "&amp;") + "</FirstName>";
        //                strXml += "<LastName>" + smo.Properties["ZSHIPTO_LNAME"].Value.Replace("&", "&amp;") + "</LastName>";
        //                strXml += "<Village>" + smo.Properties["ZSHIPTO_VILLAGE"].Value + "</Village>";
        //                strXml += "<Floor>" + smo.Properties["ZSHIPTO_FLOOR"].Value + "</Floor>";
        //                strXml += "<Room>" + smo.Properties["ZSHIPTO_ROOM"].Value + "</Room>";
        //                strXml += "<HouseNumber>" + smo.Properties["ZSHIPTO_HNUM"].Value + "</HouseNumber>";
        //                strXml += "<Moo>" + smo.Properties["ZSHIPTO_MOO"].Value + "</Moo>";
        //                strXml += "<Soi>" + smo.Properties["ZSHIPTO_SOI"].Value + "</Soi>";
        //                strXml += "<Road>" + smo.Properties["ZSHIPTO_ROAD"].Value + "</Road>";
        //                strXml += "<SubDistrict>" + smo.Properties["ZSHIPTO_SUBDIST"].Value + "</SubDistrict>";
        //                strXml += "<District>" + smo.Properties["ZSHIPTO_DIST"].Value + "</District>";
        //                strXml += "<Province>จ." + smo.Properties["ZSHIPTO_PROV"].Value + "</Province>";
        //                strXml += "<PostCode>" + smo.Properties["ZSHIPTO_POSTC"].Value + "</PostCode>";
        //                strXml += "<Tell>" + smo.Properties["ZSHIPTO_TEL"].Value + "</Tell>";
        //                strXml += "<Parvw>" + smo.Properties["ZSHIPTO_MCR"].Value + "</Parvw>";
        //                strXml += "<ParvwName>" + smo.Properties["ZSHIPTO_MCRNAM"].Value + "</ParvwName>";
        //                strXml += "<PARNR>" + smo.Properties["ZSHIPTO_SCR"].Value + "</PARNR>";
        //                strXml += "<Name>" + smo.Properties["ZSHIPTO_SCRNAM"].Value + "</Name>";

        //                strXml += "</ShiptTo>";
        //                strXml += "</RecvShipTo>";

        //                if (strXml != "")
        //                {
        //                    //Production
        //                    //DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
        //                    ///
        //                    //Qas
        //                    DO_WebReference_Test.DHMService web = new DO_WebReference_Test.DHMService();
        //                    strXml = web.OTSReceiveShipTo(strXml);
        //                }
        //            }
        //        }
        //        if (strReturn.Trim() == "")
        //            strReturn = "N";
        //        else
        //            strReturn = "Y";

        //        serverName.Connection.Close();
        //        return strReturn;
        //        //return strXml;
        //    }
        //    catch (Exception ex)
        //    {
        //        strReturn = ex.Message;
        //        return strReturn;
        //    }
        //}


        [WebMethod]
        public string MasterEmployee(string EmployeeNo)
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();

                smartObject = serverName.GetSmartObject("ZBAPI_TMS_DRIVER");
                smartObject.MethodToExecute = "ZBAPI_TMSDRIVER_ZBAPI_TMS_DRIVER";
                SetPropertyValue(smartObject.ListMethods["ZBAPI_TMSDRIVER_ZBAPI_TMS_DRIVER"].InputProperties["p_EMPNO"], EmployeeNo);

                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvEmployee>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<Employee>";

                        strXml += "<PERNR>" + smo.Properties["DRIVER_PERNR"].Value + "</PERNR>";
                        strXml += "<ANREX>" + smo.Properties["DRIVER_ANREX"].Value + "</ANREX>";
                        strXml += "<VORNA>" + smo.Properties["DRIVER_FNAME"].Value + "</VORNA>";
                        strXml += "<NACHN>" + smo.Properties["DRIVER_LNAME"].Value + "</NACHN>";
                        strXml += "<WERKS>" + smo.Properties["DRIVER_BRANCH"].Value + "</WERKS>";
                        strXml += "<ORGEH>" + smo.Properties["DRIVER_DEP"].Value + "</ORGEH>";
                        strXml += "<PERSG>" + smo.Properties["DRIVER_GROUP"].Value + "</PERSG>";
                        strXml += "<STELL>" + smo.Properties["DRIVER_JKEY"].Value + "</STELL>";

                        strXml += "</Employee>";
                    }
                    strXml += "</RecvEmployee>";
                }

                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } //Check แล้ว

        [WebMethod]
        public string MasterCarType()
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_CARTYPE");
                smartObject.MethodToExecute = "ZBAPI_TMSCARTYPE_ZBAPI_TMS_CARTYPE";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvCarType>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<CarType>";

                        strXml += "<MANDT>" + smo.Properties["CARTYPE_MANDT"].Value + "</MANDT>";
                        strXml += "<VSART>" + smo.Properties["CARTYPE_TKTYPE"].Value + "</VSART>";
                        strXml += "<BEZEI>" + smo.Properties["CARTYPE_DTEXT"].Value + "</BEZEI>"; 
                        strXml += "<ZWEIGHT1>" + smo.Properties["CARTYPE_MAXPU"].Value + "</ZWEIGHT1>"; 
                        strXml += "<MSEHIW1>" + smo.Properties["CARTYPE_MAXU"].Value + "</MSEHIW1>"; 
                        strXml += "<ZWEIGHT2>" + smo.Properties["CARTYPE_MINPU"].Value + "</ZWEIGHT2>"; 
                        strXml += "<MSEHIW2>" + smo.Properties["CARTYPE_MINU"].Value + "</MSEHIW2>";
                        strXml += "<ZVOL1>" + smo.Properties["CARTYPE_MAXVL"].Value + "</ZVOL1>"; 
                        strXml += "<MSEHIV1>" + smo.Properties["CARTYPE_MAXVU"].Value + "</MSEHIV1>"; 
                        strXml += "<ZVOL2>" + smo.Properties["CARTYPE_MINVL"].Value + "</ZVOL2>"; 
                        strXml += "<MSEHIV2>" + smo.Properties["CARTYPE_MINVU"].Value + "</MSEHIV2>"; 
                        strXml += "<ZDIESEL>" + smo.Properties["CARTYPE_DIESEL"].Value + "</ZDIESEL>"; 
                        strXml += "<ZDIESEL_UOM>" + smo.Properties["CARTYPE_DIESELU"].Value + "</ZDIESEL_UOM>";
                        strXml += "<ZLPG>" + smo.Properties["CARTYPE_LPG"].Value + "</ZLPG>";
                        strXml += "<ZLPG_UOM>" + smo.Properties["CARTYPE_LPGU"].Value + "</ZLPG_UOM>";
                        strXml += "<ZNGV>" + smo.Properties["CARTYPE_NGV"].Value + "</ZNGV>";
                        strXml += "<ZNGV_UOM>" + smo.Properties["CARTYPE_NGVU"].Value + "</ZNGV_UOM>";

                        strXml += "</CarType>";
                    }
                    strXml += "</RecvCarType>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // Check แล้ว

        [WebMethod]
        public string MasterFuelType()
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_FUELTYPE");
                smartObject.MethodToExecute = "ZBAPI_TMSFUELTYPE_ZBAPI_TMS_FUELTYPE";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvFuelType>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<FuelType>";

                        //strXml += "<MANDT>" + smo.Properties["ZFUELTYPE_MANDT"].Value + "</MANDT>"; // ตัดออกหรือป่าว
                        strXml += "<TYPE>" + smo.Properties["FUELTYPE_FUTYPE"].Value + "</TYPE>";
                        strXml += "<DESC>" + smo.Properties["FUELTYPE_DTEXT"].Value + "</DESC>";


                        strXml += "</FuelType>";
                    }
                    strXml += "</RecvFuelType>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // Check แล้ว

        [WebMethod]
        public string MasterDriver(string sUpdate, string sLicensePlate)
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_CARMASTER");
                smartObject.MethodToExecute = "ZBAPI_TMSCARMASTER_ZBAPI_TMS_CARMASTER";
                SetPropertyValue(smartObject.ListMethods["ZBAPI_TMSCARMASTER_ZBAPI_TMS_CARMASTER"].InputProperties["p_UPDATE"], sUpdate);
                SetPropertyValue(smartObject.ListMethods["ZBAPI_TMSCARMASTER_ZBAPI_TMS_CARMASTER"].InputProperties["p_P_LCPLATE"], sLicensePlate);

                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvDriver>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<Driver>";

                        strXml += "<BRANCH>" + smo.Properties["CARMASTER_WERKS"].Value + "</BRANCH>";
                        strXml += "<EXIT1>" + smo.Properties["CARMASTER_LCPLATE"].Value + "</EXIT1>";
                        strXml += "<CREDITOR>" + smo.Properties["CARMASTER_SUPP"].Value + "</CREDITOR>";
                        strXml += "<CRNAME>" + smo.Properties["CARMASTER_SUPPNAM"].Value + "</CRNAME>";
                        strXml += "<VSART>" + smo.Properties["CARMASTER_TKTYPE"].Value + "</VSART>";
                        strXml += "<TYPE>" + smo.Properties["CARMASTER_TGRP"].Value + "</TYPE>";
                        strXml += "<CAR_NO>" + smo.Properties["CARMASTER_EQUIP"].Value + "</CAR_NO>";
                        strXml += "<BRAND>" + smo.Properties["CARMASTER_BRAND"].Value + "</BRAND>";
                        strXml += "<COLOR>" + smo.Properties["CARMASTER_COLOR"].Value + "</COLOR>"; 
                        strXml += "<GENERATION>" + smo.Properties["CARMASTER_SERIES"].Value + "</GENERATION>";
                        strXml += "<CHASSIS_NUMBER>" + smo.Properties["CARMASTER_CHASIS"].Value + "</CHASSIS_NUMBER>";
                        strXml += "<ENGINE_NUMBER>" + smo.Properties["CARMASTER_ENGINEN"].Value + "</ENGINE_NUMBER>";
                        strXml += "<PASSPORT_CAR>" + smo.Properties["CARMASTER_CPASSP"].Value + "</PASSPORT_CAR>";
                        strXml += "<EQUIPMENT_NO>" + smo.Properties["CARMASTER_ACCID"].Value + "</EQUIPMENT_NO>";
                        strXml += "<TANDARD_OIL>" + "" + "</TANDARD_OIL>";
                        strXml += "<DRIVER1>" + smo.Properties["CARMASTER_DRV1"].Value + "</DRIVER1>";
                        strXml += "<DVNAME1>" + smo.Properties["CARMASTER_DRVNAME1"].Value + "</DVNAME1>";
                        strXml += "<DRIVER2>" + smo.Properties["CARMASTER_DRV2"].Value + "</DRIVER2>";
                        strXml += "<DVNAME2>" + smo.Properties["CARMASTER_DRVNAME2"].Value + "</DVNAME2>";
                        strXml += "<START_DATE_1>" + smo.Properties["CARMASTER_DRVBEG1"].Value + "</START_DATE_1>";
                        strXml += "<END_DATE_1>" + smo.Properties["CARMASTER_DRVEND1"].Value + "</END_DATE_1>";
                        strXml += "<START_DATE_2>" + smo.Properties["CARMASTER_DRVBEG2"].Value + "</START_DATE_2>";
                        strXml += "<END_DATE_2>" + smo.Properties["CARMASTER_DRVEND2"].Value + "</END_DATE_2>";
                        strXml += "<ZSTATUS>" + smo.Properties["CARMASTER_STID"].Value + "</ZSTATUS>";
                        strXml += "<ZFUEL_TYPE>" + smo.Properties["CARMASTER_FUTYPE"].Value + "</ZFUEL_TYPE>";
                        strXml += "<ZFUEL_TYPE_REAL>" + "" + "</ZFUEL_TYPE_REAL>";
                        strXml += "<ZDRVLICE_1>" + smo.Properties["CARMASTER_DVLC1"].Value + "</ZDRVLICE_1>";
                        strXml += "<ZDRVLICE_2>" + smo.Properties["CARMASTER_DVLC2"].Value + "</ZDRVLICE_2>";
                        strXml += "<ZDRVLICE_TYPE_1>" + smo.Properties["CARMASTER_LCTYPE1"].Value + "</ZDRVLICE_TYPE_1>";
                        strXml += "<ZDRVLICE_TYPE_2>" + smo.Properties["CARMASTER_LCTYPE2"].Value + "</ZDRVLICE_TYPE_2>";
                        strXml += "<TEL_NUMBER_1>" + smo.Properties["CARMASTER_TEL1"].Value + "</TEL_NUMBER_1>";
                        strXml += "<TEL_NUMBER_2>" + smo.Properties["CARMASTER_TEL2"].Value + "</TEL_NUMBER_2>";
                        strXml += "<ZGUARAN_WEIGHT>" + smo.Properties["CARMASTER_WEIGHTGUA"].Value + "</ZGUARAN_WEIGHT>";
                        strXml += "<ZGUARAN_UOM>" + smo.Properties["CARMASTER_WEIGHTGUAUNIT"].Value + "</ZGUARAN_UOM>";
                        strXml += "<INSURANCE_NO>" + smo.Properties["CARMASTER_CINSNUM"].Value + "</INSURANCE_NO>";
                        strXml += "<INSURANCE_NAME>" + smo.Properties["CARMASTER_CINSCOMP"].Value + "</INSURANCE_NAME>";
                        strXml += "<INSURANCE_TYPE>" + smo.Properties["CARMASTER_CINSTYPE"].Value + "</INSURANCE_TYPE>";
                        strXml += "<INSURANCE_BGNDT>" + smo.Properties["CARMASTER_CINSBEG"].Value + "</INSURANCE_BGNDT>";
                        strXml += "<INSURANCE_ENDDT>" + smo.Properties["CARMASTER_CINSEND"].Value + "</INSURANCE_ENDDT>";
                        strXml += "<INSURANCE_CREDIT>" + smo.Properties["CARMASTER_CINSAMT"].Value + "</INSURANCE_CREDIT>";
                        strXml += "<REMARK>" + smo.Properties["CARMASTER_DETAIL"].Value + "</REMARK>";
                        strXml += "<KOSTL>" + smo.Properties["CARMASTER_COSTC"].Value + "</KOSTL>";
                        strXml += "<AUFNR>" + smo.Properties["CARMASTER_AUFNR"].Value + "</AUFNR>";
                        strXml += "<TPLST>" + smo.Properties["CARMASTER_TPLST"].Value + "</TPLST>";
                        strXml += "<GPSFLAG>" + smo.Properties["CARMASTER_GPSFLAG"].Value + "</GPSFLAG>";
                        strXml += "<INFO_001>" + smo.Properties["CARMASTER_FUCAP"].Value + "</INFO_001>";
                        strXml += "<INFO_002>" + smo.Properties["CARMASTER_CWEIGHT"].Value + "</INFO_002>";
                        strXml += "<INFO_003>" + smo.Properties["CARMASTER_MAXPU"].Value + "</INFO_003>";
                        strXml += "<INFO_004>" + smo.Properties["CARMASTER_MINPU"].Value + "</INFO_004>";
                        strXml += "<INFO_005>" + smo.Properties["CARMASTER_MAXVL"].Value + "</INFO_005>";
                        strXml += "<INFO_006>" + smo.Properties["CARMASTER_MINVL"].Value + "</INFO_006>";
                        strXml += "<INFO_007>" + smo.Properties["CARMASTER_ACCID"].Value + "</INFO_007>";
                        strXml += "<INFO_008>" + smo.Properties["CARMASTER_ACCIDTXT"].Value + "</INFO_008>";
                        strXml += "<INFO_009>" + smo.Properties["CARMASTER_GPSNUM"].Value + "</INFO_009>";
                        strXml += "<INFO_010>" + smo.Properties["CARMASTER_CVL"].Value + "</INFO_010>";
                        strXml += "<INFO_011>" + smo.Properties["CARMASTER_DRSYS"].Value + "</INFO_011>";
                        strXml += "<INFO_012>" + smo.Properties["CARMASTER_ENSIZE"].Value + "</INFO_012>";
                        strXml += "<INFO_013>" + smo.Properties["CARMASTER_BRKSYS"].Value + "</INFO_013>";
                        strXml += "<INFO_014>" + smo.Properties["CARMASTER_LFCC"].Value + "</INFO_014>";
                        strXml += "<INFO_015>" + smo.Properties["CARMASTER_LFCCM"].Value + "</INFO_015>";
                        strXml += "<INFO_016>" + smo.Properties["CARMASTER_AGE"].Value + "</INFO_016>";
                        strXml += "<INFO_017>" + smo.Properties["CARMASTER_WHEELS"].Value + "</INFO_017>";
                        strXml += "<INFO_018>" + smo.Properties["CARMASTER_DEALDAT"].Value + "</INFO_018>";
                        strXml += "<INFO_019>" + smo.Properties["CARMASTER_MNTCC"].Value + "</INFO_019>";
                        strXml += "<INFO_020>" + smo.Properties["CARMASTER_SPLIMIT"].Value + "</INFO_020>";
                        strXml += "<INFO_021>" + smo.Properties["CARMASTER_DETAIL1"].Value + "</INFO_021>";
                        strXml += "<INFO_022>" + smo.Properties["CARMASTER_DETAIL2"].Value + "</INFO_022>";
                        strXml += "<INFO_023>" + smo.Properties["CARMASTER_DRVBEG1"].Value + "</INFO_023>";
                        strXml += "<INFO_024>" + smo.Properties["CARMASTER_DRVEND1"].Value + "</INFO_024>";
                        strXml += "<INFO_025>" + smo.Properties["CARMASTER_DRVBEG2"].Value + "</INFO_025>";
                        strXml += "<INFO_026>" + smo.Properties["CARMASTER_DRVEND2"].Value + "</INFO_026>";
                        strXml += "<INFO_027>" + smo.Properties["CARMASTER_INSCOMPTXT"].Value + "</INFO_027>";
                        strXml += "<INFO_028>" + smo.Properties["CARMASTER_PINSNUM"].Value + "</INFO_028>";
                        strXml += "<INFO_029>" + smo.Properties["CARMASTER_PINSAMT"].Value + "</INFO_029>";
                        strXml += "<INFO_030>" + smo.Properties["CARMASTER_PINSBEG"].Value + "</INFO_030>";
                        strXml += "<INFO_031>" + smo.Properties["CARMASTER_PINEND"].Value + "</INFO_031>";
                        strXml += "<INFO_032>" + smo.Properties["CARMASTER_CINSTYPETXT"].Value + "</INFO_032>";
                        strXml += "<WEIGHT_UNIT_CAR>" + smo.Properties["CARMASTER_CWEIGHTU"].Value + "</WEIGHT_UNIT_CAR>";
                        strXml += "<VOLUME_CAR>" + smo.Properties["CARMASTER_VLUNIT"].Value + "</VOLUME_CAR>"; 
                        strXml += "<IMG_PATH>" + smo.Properties["CARMASTER_IMGPATH"].Value + "</IMG_PATH>";
                        strXml += "<EDIT_DATE>" + smo.Properties["CARMASTER_EDITDATE"].Value + "</EDIT_DATE>";
                        strXml += "<EDIT_TIME>" + smo.Properties["CARMASTER_EDITTIME"].Value + "</EDIT_TIME>";

                        strXml += "</Driver>";
                    }
                    strXml += "</RecvDriver>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } //Check แล้ว

        [WebMethod]
        public string MasterTruckGroup()
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_CARGROUP");
                smartObject.MethodToExecute = "ZBAPI_TMSCARGROUP_ZBAPI_TMS_CARGROUP";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvTruckGroup>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<TruckGroup>";

                        strXml += "<ZGRPID>" + smo.Properties["CARGROUP_TGRP"].Value + "</ZGRPID>";
                        strXml += "<ZGRDESC>" + smo.Properties["CARGROUP_DTEXT"].Value + "</ZGRDESC>";

                        strXml += "</TruckGroup>";
                    }
                    strXml += "</RecvTruckGroup>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } //Check แล้ว

        [WebMethod]
        public string MasterWheelDriveSystem() 
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_DRIVINGSYS");
                smartObject.MethodToExecute = "ZBAPI_TMSDRIVINGSYS_ZBAPI_TMS_DRIVINGSYS";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvWheelDriveSystem>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<WheelDriveSystem>";

                        strXml += "<WHEEL>" + smo.Properties["DRIVINGSYS_DRSYS"].Value + "</WHEEL>";
                        strXml += "<WHEET>" + smo.Properties["DRIVINGSYS_DTEXT"].Value + "</WHEET>";

                        strXml += "</WheelDriveSystem>";
                    }
                    strXml += "</RecvWheelDriveSystem>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // Check แล้ว

        [WebMethod]
        public string MasterTruckStatus() //Check แล้ว
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_CARSTATUS");
                smartObject.MethodToExecute = "ZBAPI_TMSCARSTATUS_ZBAPI_TMS_CARSTATUS";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvTruckStatus>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<TruckStatus>";

                        strXml += "<TRUCKS>" + smo.Properties["CARSTATUS_STID"].Value + "</TRUCKS>";
                        strXml += "<TRUCKT>" + smo.Properties["CARSTATUS_DTEXT"].Value + "</TRUCKT>";

                        strXml += "</TruckStatus>";
                    }
                    strXml += "</RecvTruckStatus>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public string MasterInsureType()  //Check แล้ว
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_INSTYPE");
                smartObject.MethodToExecute = "ZBAPI_TMSINSTYPE_ZBAPI_TMS_INSTYPE";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvInsureType>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<InsureType>";

                        strXml += "<INSURE>" + smo.Properties["INSTYPE_INSTYPE"].Value + "</INSURE>";
                        strXml += "<INSURT>" + smo.Properties["INSTYPE_DTEXT"].Value + "</INSURT>";

                        strXml += "</InsureType>";
                    }
                    strXml += "</RecvInsureType>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public string MasterInsurance() //Check แล้ว
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_INSCOMP");
                smartObject.MethodToExecute = "ZBAPI_TMSINSCOMP_ZBAPI_TMS_INSCOMP";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvInsurance>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<Insurance>";

                        strXml += "<COMINS>" + smo.Properties["INSCOMP_INSCOMP"].Value + "</COMINS>";
                        strXml += "<COMINT>" + smo.Properties["INSCOMP_DTEXT"].Value + "</COMINT>";

                        strXml += "</Insurance>";
                    }
                    strXml += "</RecvInsurance>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public string MasterRangeTimeFillFuel() //Check แล้ว
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_REFILL");
                smartObject.MethodToExecute = "ZBAPI_TMSREFILL_ZBAPI_TMS_REFILL";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvTimeFillFuel>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<FuleFillTime>";

                        strXml += "<WERKS>" + smo.Properties["REFILL_BRANCH"].Value + "</WERKS>";
                        strXml += "<TYPE>" + smo.Properties["REFILL_TGRP"].Value + "</TYPE>";
                        // Begin
                        string dvBgTime = smo.Properties["REFILL_STARTTIM"].Value.Substring(0, 2) + ":" + smo.Properties["REFILL_STARTTIM"].Value.Substring(3, 2) + ":" + smo.Properties["REFILL_STARTTIM"].Value.Substring(4, 2);
                        strXml += "<BGNTIMEFUEL>" + dvBgTime + "</BGNTIMEFUEL>";
                        // End
                        string dvEnTime = smo.Properties["REFILL_ENDTIM"].Value.Substring(0, 2) + ":" + smo.Properties["REFILL_ENDTIM"].Value.Substring(3, 2) + ":" + smo.Properties["REFILL_ENDTIM"].Value.Substring(4, 2);
                        strXml += "<ENDTIMEFUEL>" + dvEnTime + "</ENDTIMEFUEL>";
                        strXml += "<TYPNAM>" + smo.Properties["REFILL_TGRPTXT"].Value + "</TYPNAM>";
                        strXml += "</FuleFillTime>";
                    }
                    strXml += "</RecvTimeFillFuel>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public string MasterEquipmentCar() //Check แล้ว
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_ACCESSORY");
                smartObject.MethodToExecute = "ZBAPI_TMSACCESSORY_ZBAPI_TMS_ACCESSORY";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvEquipmentCar>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<EquipmentCar>";

                        strXml += "<EQMCAR>" + smo.Properties["ACCESSORY_ACCID"].Value + "</EQMCAR>";
                        strXml += "<EQMCAT>" + smo.Properties["ACCESSORY_DTEXT"].Value + "</EQMCAT>";

                        strXml += "</EquipmentCar>";
                    }
                    strXml += "</RecvEquipmentCar>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public string MasterDriverlicense() //Check แล้ว
        {
            string strXml = "";

            try
            {
                this.IsK2Connect();

                SmartObject smartObject = new SmartObject();
                smartObject = serverName.GetSmartObject("ZBAPI_TMS_LCTYPE");
                smartObject.MethodToExecute = "ZBAPI_TMSLCTYPE_ZBAPI_TMS_LCTYPE";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);
                if (SmartObjectList.SmartObjectsList.Count > 0)
                {
                    strXml = "<RecvDriverlicense>";
                    foreach (SmartObject smo in SmartObjectList.SmartObjectsList)
                    {
                        strXml += "<Driverlicense>";

                        strXml += "<DRIVLI>" + smo.Properties["LCTYPE_LCTYPE"].Value + "</DRIVLI>";
                        strXml += "<DRIVLT>" + smo.Properties["LCTYPE_DTEXT"].Value + "</DRIVLT>";

                        strXml += "</Driverlicense>";
                    }
                    strXml += "</RecvDriverlicense>";
                }
                serverName.Connection.Close();
                return strXml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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

        private string OnReplaceZero(string getValue)
        {
            try
            {
                string retValue = getValue;
                for (int i = 0; i <= getValue.Length - 1; i++)
                {
                    if (retValue.Substring(0, 1) == "0")
                        retValue = retValue.Substring(1, retValue.Length - 1);
                    else
                        break;
                }

                return retValue;
            }
            catch //(Exception ex)
            {
                return "";
            }
        }

        [WebMethod]
        public string GetDistance(string ShippingID, string ShipToNo, string SubDistrict, string District, string Province, string Type)
        {
            if (ShipToNo == "-")
                ShipToNo = "";
            if (SubDistrict == "-")
                SubDistrict = "";

            string strData = "<ReqCustomDistance><ShippingId>" + ShippingID + "</ShippingId>";
            strData += "<ShipToNo>" + ShipToNo + "</ShipToNo>";
            strData += "<SubDistrict>" + SubDistrict + "</SubDistrict>";
            strData += "<District>" + District + "</District>";
            strData += "<Province>" + Province + "</Province>";
            strData += "<Type>" + Type + "</Type></ReqCustomDistance>";

            //Prodution
            DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
            ///
            //Qas
            //DO_WebReferencePRD_Test.DHMService web = new DO_WebReferencePRD_Test.DHMService();

            strData = web.OTSReqCustomDistance(@strData);

            int i1 = strData.ToUpper().IndexOf("<DISTANCE>") + 10;
            int i2 = strData.ToUpper().IndexOf("</DISTANCE>");

            if (i1 >= 0 && i2 >= 0)
            {
                strData = strData.Substring(i1, i2 - i1);
            }
            else
            {
                strData = "0";
            }

            return strData;
        }

        [WebMethod]
        public string ReqShipToDistance(string ShippingID, string ShipToNo, string SubDistrict, string District, string Province, string Type)
        {
            if (ShipToNo == "-")
                ShipToNo = "";
            if (SubDistrict == "-")
                SubDistrict = "";

            string strData = "<ReqShipToDistance><Shipping>" + ShippingID + "</Shipping>";
            strData += "<ShipToNo>" + ShipToNo + "</ShipToNo>";
            strData += "<SubDistrict>" + SubDistrict + "</SubDistrict>";
            strData += "<District>" + District + "</District>";
            strData += "<Province>" + Province + "</Province>";
            strData += "<Type>" + Type + "</Type></ReqShipToDistance>";

            //production
            DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
            ///
            //Qas
            //DO_WebReferencePRD_Test.DHMService web = new DO_WebReferencePRD_Test.DHMService();

            strData = web.OTSReqShipToDistance(@strData);

            int i1 = strData.ToUpper().IndexOf("<DISTANCE>") + 10;
            int i2 = strData.ToUpper().IndexOf("</DISTANCE>");

            if (i1 >= 0 && i2 >= 0)
            {
                strData = strData.Substring(i1, i2 - i1);
            }
            else
            {
                strData = "0";
            }

            return strData;
        }

        [WebMethod]
        public string Send_DebtInfo_To_1Link(string PlanDocNo, string DebtDocNo, string DebtDate, string PostYear)
        {
            string strData = "<RecvDebtInfo>";
            strData += "<PlanId>" + PlanDocNo + "</PlanId>";
            strData += "<DebtId>" + DebtDocNo + "</DebtId>";
            strData += "<DebtDate>" + DebtDate + "</DebtDate>";
            strData += "<FiscYear>" + PostYear + "</FiscYear>";
            strData += "</RecvDebtInfo>";

            //Production
            DO_WebReferencePRD.DHMService web = new DO_WebReferencePRD.DHMService();
            ///
            //Qas
            //DO_WebReferencePRD_Test.DHMService web = new DO_WebReferencePRD_Test.DHMService();
            strData = web.OTSRecvDebtInfo(@strData);

            int i1 = strData.ToUpper().IndexOf("<RESULT>") + 8;
            int i2 = strData.ToUpper().IndexOf("</RESULT>");

            string strReturn = "";
            if (i1 >= 0 && i2 >= 0)
            {
                strReturn = strData.Substring(i1, i2 - i1);
            }
            else
            {
                strReturn = "";
            }

            return strReturn;
        }
    }
}
