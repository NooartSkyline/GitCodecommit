using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;

namespace DoHome.MobileService
{
    #region Property

    ///<summary>
    ///<para>Date Created: 31/07/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBHANDHELDCOUNTER_CHECKPRODUCT</para>
    ///<para>This object represents the properties of a HandHeldCheckProduct, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("TBHANDHELDCOUNTER_CHECKPRODUCT")]
    public partial class HandHeldCheckProduct
    {
        /// <summary>
        /// Gets the HandHeldCheckProduct identifier
        /// </summary>
        [DataMember]
        [MapField("DOCNO"), PrimaryKey]
        public string Docno { get; set; }

        /// <summary>
        /// Gets or sets the LOCATION
        /// </summary>
        [DataMember]
        [MapField("LOCATION")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the DOCDATE
        /// </summary>
        [DataMember]
        [MapField("DOCDATE")]
        public DateTime? Docdate { get; set; }

        /// <summary>
        /// Gets or sets the USERID
        /// </summary>
        [DataMember]
        [MapField("USERID")]
        public string Userid { get; set; }

        /// <summary>
        /// Gets or sets the OFFICERID
        /// </summary>
        [DataMember]
        [MapField("OFFICERID")]
        public string Officerid { get; set; }

        /// <summary>
        /// Gets or sets the CHKAREANO
        /// </summary>
        [DataMember]
        [MapField("CHKAREANO")]
        public string Chkareano { get; set; }

    }

    #endregion

    public partial interface IMobileService
    {

        [OperationContract]
        void AddHandHeldCheckProduct(string userCode, string userName, string employeeID, string locationCode, string warehouseCode, string branchCode, List<LocationDescription> locationDescriptions, List<ProductBarcode> products, string remark);

    }

    public partial class MobileService : IMobileService
    {

        private string GetHandHeldCheckProductDocumentNo(string branchCode)
        {
            var documentNo = string.Empty;

            using (DbManager db = new DbManager(branchCode))
            {
                documentNo = db.SetCommand(GetSql(29)).ExecuteScalar<string>();
            }

            var culture = new System.Globalization.CultureInfo("th-TH");
            int index = 1;
            if (!string.IsNullOrEmpty(documentNo))
                index = Convert.ToInt32(documentNo) + 1;

            documentNo = string.Format("CK{0}-{1:0000}", DateTime.Now.Date.ToString("yyMMdd", culture), index);

            return documentNo;
        }

        private string PrepareHandHeldCheckProductDocumentNo(string documentNo)
        {
            var documentNoTemp = documentNo.Split(Convert.ToChar("-"));
            return string.Format("{0}-{1:0000}", documentNoTemp[0], Convert.ToInt32(documentNoTemp[1]) + 1);

        }

        private void AddHandHeldCheckProductToSAP(string userCode, string userName, string employeeID, string locationCode, string warehouseCode, string branchCode, List<LocationDescription> locationDescriptions, List<ProductBarcode> products, string remark)
        {

            using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (var prx = new SAPProxyIII.UWProxy())
                {
                    prx.Connection = sapConnection;


                    SAPProxyIII.ZDD_HH_CHECKAREATable zdd_hh_checkarea = new SAPProxyIII.ZDD_HH_CHECKAREATable();
                    SAPProxyIII.ZDD_HH_CHECKAREA area = new SAPProxyIII.ZDD_HH_CHECKAREA();

                    foreach (var item in locationDescriptions)
                    {
                        #region เก็บข้อมูลลง Internal Table
                        area.Bin_Code = locationCode;
                        switch (item.ID + 1)
                        {
                            case 1:
                                area.F01 = " ";
                                if (item.Checked)
                                    area.F01 = "X";
                                break;
                            case 2:
                                area.F02 = " ";
                                if (item.Checked)
                                    area.F02 = "X";
                                break;
                            case 3:
                                area.F03 = " ";
                                if (item.Checked)
                                    area.F03 = "X";
                                break;
                            case 4:
                                area.F04 = " ";
                                if (item.Checked)
                                    area.F04 = "X";
                                break;
                            case 5:
                                area.F05 = " ";
                                if (item.Checked)
                                    area.F05 = "X";
                                break;
                            case 6:
                                area.F06 = " ";
                                if (item.Checked)
                                    area.F06 = "X";
                                break;
                            case 7:
                                area.F07 = " ";
                                if (item.Checked)
                                    area.F07 = "X";
                                break;
                            case 8:
                                area.F08 = " ";
                                if (item.Checked)
                                    area.F08 = "X";
                                break;
                            case 9:
                                area.F09 = " ";
                                if (item.Checked)
                                    area.F09 = "X";
                                break;
                            case 10:
                                area.F10 = 0;
                                if (item.Checked)
                                {
                                    short areaF10 = 0;
                                    Int16.TryParse(item.BlankNumber, out areaF10);
                                    area.F10 = areaF10;
                                }
                                break;
                            case 11:
                                area.F11 = " ";
                                if (item.Checked)
                                    area.F11 = "X";
                                break;
                            case 12:
                                area.F12 = " ";
                                if (item.Checked)
                                    area.F12 = "X";
                                break;
                            case 13:
                                area.F13 = " ";
                                if (item.Checked)
                                    area.F13 = "X";
                                break;
                            case 14:
                                area.F14 = " ";
                                if (item.Checked)
                                    area.F14 = "X";
                                break;
                            case 15:
                                area.F15 = " ";
                                if (item.Checked)
                                    area.F15 = "X";
                                break;
                            case 16:
                                area.F16 = " ";
                                if (item.Checked)
                                    area.F16 = "X";
                                break;
                            case 17:
                                area.F17 = " ";
                                if (item.Checked)
                                    area.F17 = "X";
                                break;
                            case 18:
                                area.F18 = " ";
                                if (item.Checked)
                                    area.F18 = "X";
                                break;
                            case 19:
                                area.F19 = " ";
                                if (item.Checked)
                                    area.F19 = "X";
                                break;
                            case 20:
                                area.Expoint = 0;
                                if (item.Checked)
                                {
                                    short areaExpoint = 0;
                                    Int16.TryParse(item.BlankNumber, out areaExpoint);
                                    area.Expoint = areaExpoint;

                                }
                                break;
                            default:
                                break;
                        }
                        #endregion
                    }

                    area.Remark = remark;
                    area.Lgort = warehouseCode;
                    area.Werks = branchCode;

                    using (DbManager db = new DbManager(branchCode))
                    {
                        db.Command.CommandTimeout = 200;
                        var sql = GetSql(28);
                        var documentNo = this.GetHandHeldCheckProductDocumentNo(branchCode);
                        try
                        {

                            db.BeginTransaction();

                            foreach (var item in products)
                            {
                                area.Matnr = item.ProductCode;
                                area.Meins = item.UnitCode;
                                zdd_hh_checkarea.Add(area);
                                prx.Zdd_Handheld_Checkarea(userName, employeeID, ref zdd_hh_checkarea);
                                if (zdd_hh_checkarea.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(zdd_hh_checkarea[0].Chkareano))
                                    {
                                        db.SetCommand(sql,
                                        db.Parameter("@DOCNO", documentNo),
                                        db.Parameter("@LOCATION", locationCode),
                                        db.Parameter("@DOCDATE", DateTime.Now.Date),
                                        db.Parameter("@USERID", userCode),
                                        db.Parameter("@OFFICERID", employeeID),
                                        db.Parameter("@CHKAREANO", zdd_hh_checkarea[0].Chkareano))
                                        .ExecuteNonQuery();

                                        documentNo = PrepareHandHeldCheckProductDocumentNo(documentNo);
                                    }
                                }
                            }

                            prx.CommitWork();
                            db.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            prx.RollbackWork();
                            db.RollbackTransaction();
                            throw ex;
                        }
                    }


                }
            }

        }

        public void AddHandHeldCheckProduct(string userCode, string userName, string employeeID, string locationCode, string warehouseCode, string branchCode, List<LocationDescription> locationDescriptions, List<ProductBarcode> products, string remark)
        {
            AddHandHeldCheckProductToSAP(userCode, userName, employeeID, locationCode, warehouseCode, branchCode, locationDescriptions, products, remark);
        }
    }
}

