using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;
using System;
using SAP.Connector;
using System.Linq;

namespace DoHome.MobileService
{
    ///<summary>
    ///<para>Date Created: 29/07/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBHANDHELDCOUNTER</para>
    ///<para>This object represents the properties of a HandHeldCounter, and is used to represent a single instance</para>
    ///</summary>   
    [DataContract]
    [TableName("TBHANDHELDCOUNTER")]
    public partial class HandHeldCounter
    {
        /// <summary>
        /// Gets the HandHeldCounter identifier
        /// </summary>
        [DataMember]
        [MapField("DOCNO"), PrimaryKey]
        public string Docno { get; set; }
        /// <summary>
        /// Gets the HandHeldCounter identifier
        /// </summary>
        [DataMember]
        [MapField("ROWORDER"), PrimaryKey]
        public int Roworder { get; set; }

        /// <summary>
        /// Gets or sets the DOCDATE
        /// </summary>
        [DataMember]
        [MapField("DOCDATE")]
        public DateTime? Docdate { get; set; }

        /// <summary>
        /// Gets or sets the BRANCHCODE
        /// </summary>
        [DataMember]
        [MapField("BRANCHCODE")]
        public string Branchcode { get; set; }

        /// <summary>
        /// Gets or sets the WAREHOUSE
        /// </summary>
        [DataMember]
        [MapField("WAREHOUSE")]
        public string Warehouse { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCTCODE
        /// </summary>
        [DataMember]
        [MapField("PRODUCTCODE")]
        public string Productcode { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCTNAME
        /// </summary>
        [DataMember]
        [MapField("PRODUCTNAME")]
        public string Productname { get; set; }

        /// <summary>
        /// Gets or sets the UNITCODE
        /// </summary>
        [DataMember]
        [MapField("UNITCODE")]
        public string Unitcode { get; set; }

        /// <summary>
        /// Gets or sets the UNITNAME
        /// </summary>
        [DataMember]
        [MapField("UNITNAME")]
        public string Unitname { get; set; }

        /// <summary>
        /// Gets or sets the UNITRATE
        /// </summary>
        [DataMember]
        [MapField("UNITRATE")]
        public decimal Unitrate { get; set; }

        /// <summary>
        /// Gets or sets the LOCATION
        /// </summary>
        [DataMember]
        [MapField("LOCATION")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the QUANTITY
        /// </summary>
        [DataMember]
        [MapField("QUANTITY")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the BALANCEQTY
        /// </summary>
        [DataMember]
        [MapField("BALANCEQTY")]
        public decimal Balanceqty { get; set; }

        /// <summary>
        /// Gets or sets the SAPDOCNO
        /// </summary>
        [DataMember]
        [MapField("SAPDOCNO")]
        public string Sapdocno { get; set; }

        /// <summary>
        /// Gets or sets the OFFICERID
        /// </summary>
        [DataMember]
        [MapField("OFFICERID")]
        public string Officerid { get; set; }

        /// <summary>
        /// Gets or sets the CREATEUSER
        /// </summary>
        [DataMember]
        [MapField("CREATEUSER")]
        public string Createuser { get; set; }

        /// <summary>
        /// Gets or sets the ISTRUE
        /// </summary>
        [DataMember]
        [MapField("ISTRUE")]
        public string Istrue { get; set; }

    }

    public partial interface IMobileService
    {

        [OperationContract]
        string AddHandHeldCounter(string branchCode, string documentNo, out string messageStatus);

    }

    public partial class MobileService : IMobileService
    {
        #region Private Method

        private string HandHeldCounterGetDocumentNo(string branchCode)
        {
            var documentNo = string.Empty;

            using (DbManager db = new DbManager(branchCode))
            {
                documentNo = db.SetCommand(GetSql(26)).ExecuteScalar<string>();
            }

            var culture = new System.Globalization.CultureInfo("th-TH");
            int index = 1;
            if (!string.IsNullOrEmpty(documentNo))
                index = Convert.ToInt32(documentNo) + 1;

            documentNo = string.Format("CT{0}-{1:0000}", DateTime.Now.Date.ToString("yyMMdd", culture), index);

            return documentNo;
        }

        private string SapAddHandHeldCounter(string branchCode, List<HandHeldCounterHold> productStocks, out string e_zcountqi, out string e_iblnr)
        {

            HandHeldCounterHold productStock = productStocks[0];
            string _iblnr = string.Empty;
            string _zcountqi = string.Empty;
            string alertMessage = string.Empty;


            List<string> productCodeList = null;
            using (DbManager db = new DbManager(branchCode))
            {
                productCodeList = db.SetCommand(GetSql(22), db.Parameter("@DocumentNo", productStock.Docno)).ExecuteScalarList<string>();
            }

            string branchShort = "01";
            switch (productStock.Branchcode)
            {
                case "1100":
                    branchShort = "01";
                    break;
                case "1200":
                    branchShort = "02";
                    break;
                case "1300":
                    branchShort = "04";
                    break;
                default:
                    branchShort = "03";     //ASM
                    break;
            }

            using (var sapConnection = new SAPConnection(GlobalContext.SapDestination))
            {

                using (var prx = new SAPProxyIII.UWProxy())
                {
                    prx.Connection = sapConnection;

                    SAPProxyIII.BAPIRET2Table ret2 = new SAPProxyIII.BAPIRET2Table();
                    SAPProxyIII.WSELMATNRTable tbCor = new SAPProxyIII.WSELMATNRTable();
                    SAPProxyIII.WSELMATNRTable tbIncor = new SAPProxyIII.WSELMATNRTable();
                    SAPProxyIII.ZCOUNT_ITEMTable tbCorCount = new SAPProxyIII.ZCOUNT_ITEMTable();
                    SAPProxyIII.ZCOUNT_ITEMTable tbIncorCount = new SAPProxyIII.ZCOUNT_ITEMTable();
                    SAPProxyIII.ZCOUNT_ITEM itcount = new SAPProxyIII.ZCOUNT_ITEM();


                    decimal sumBalanceQuantity = 0;
                    decimal sumQuantity = 0;
                    string sapProductCode = string.Empty;
                    List<HandHeldCounterHold> holds = null;

                    //var sums = productStocks
                    //            .GroupBy(x => new { x.Productcode })
                    //            .Select(group => group.Sum(x => x.Balanceqty));

                    foreach (var productCode in productCodeList)
                    {
                        holds = productStocks.FindAll(p => p.Productcode == productCode.ToString());

                        if (holds != null)
                        {
                            foreach (var item in holds)
                            {
                                sumBalanceQuantity += item.Balanceqty;
                                sumQuantity += item.Quantity;
                            }

                            sapProductCode = SapProductCodeFormated(productCode.ToString());

                            SAPProxyIII.WSELMATNR it = new SAPProxyIII.WSELMATNR();
                            it.Sign = "I";
                            it.Option = "EQ";
                            it.Low = sapProductCode;

                            tbCor.Add(it);
                            SAPProxyIII.ZCOUNT_ITEM zCountITem = null;
                            foreach (var item in holds)
                            {
                                zCountITem = new SAPProxyIII.ZCOUNT_ITEM();
                                itcount.Bin_Code = item.Location;
                                itcount.Erfmg1 = item.Quantity;
                                itcount.Meins1 = item.Unitcode;
                                itcount.Matnr = sapProductCode;

                                if (sumQuantity == sumBalanceQuantity)
                                    tbCorCount.Add(zCountITem);
                                else
                                    tbIncorCount.Add(zCountITem);

                            }

                            sumBalanceQuantity = 0;
                            sumQuantity = 0;
                        }
                    }

                    //ตรง
                    if (tbCor.Count > 0)
                        prx.Zmm_Inv_Cre_Count_Doc(branchShort, productStock.Createuser, productStock.Warehouse, "X", productStock.Officerid, "X", out _iblnr, out _zcountqi, ref tbCorCount, ref tbCor, ref ret2);
                    if (ret2.Count > 0)
                        alertMessage = string.Format("{0} - {1}", "นับตรง", ret2[0].Message);
                    //ไม่ตรง
                    if (tbIncor.Count > 0)
                        prx.Zmm_Inv_Cre_Count_Doc(branchShort, productStock.Createuser, productStock.Warehouse, "", productStock.Officerid, "X", out _iblnr, out _zcountqi, ref tbIncorCount, ref tbIncor, ref ret2);
                    if (ret2.Count > 0)
                        alertMessage = string.Format("{0} - {1}", "นับไม่ตรง", ret2[0].Message);

                }
            }


            e_zcountqi = _zcountqi;
            e_iblnr = _iblnr;

            return alertMessage;
        }

        #endregion

        public string AddHandHeldCounter(string branchCode, string documentNo, out string messageStatus)
        {
            var productStocks = GetHandHeldCounterHoldByDocumentNo(branchCode, documentNo);
            string e_zcountqi;
            string sapDocumentNo;
            string messageAlert;

            messageStatus = SapAddHandHeldCounter(branchCode, productStocks, out e_zcountqi, out sapDocumentNo);

            var handHeldCounterDocumentNo = HandHeldCounterGetDocumentNo(branchCode);
            if (!string.IsNullOrEmpty(sapDocumentNo))
            {
                using (DbManager db = new DbManager(branchCode))
                {
                    try
                    {
                        db.BeginTransaction();

                        foreach (var item in productStocks)
                        {
                            db.SetCommand(GetSql(23),
                            db.Parameter("@DOCNO", handHeldCounterDocumentNo),
                            db.Parameter("@ROWORDER", item.Roworder),
                            db.Parameter("@DOCDATE", item.Docdate),
                            db.Parameter("@BRANCHCODE", item.Branchcode),
                            db.Parameter("@WAREHOUSE", item.Warehouse),
                            db.Parameter("@PRODUCTCODE", item.Productcode),
                            db.Parameter("@PRODUCTNAME", item.Productname),
                            db.Parameter("@UNITCODE", item.Unitcode),
                            db.Parameter("@UNITNAME", item.Unitname),
                            db.Parameter("@UNITRATE", item.Unitrate),
                            db.Parameter("@LOCATION", item.Location),
                            db.Parameter("@QUANTITY", item.Quantity),
                            db.Parameter("@BALANCEQTY", item.Balanceqty),
                            db.Parameter("@SAPDOCNO", sapDocumentNo),
                            db.Parameter("@OFFICERID", item.Officerid),
                            db.Parameter("@CREATEUSER", item.Createuser),
                            db.Parameter("@ISTRUE", ""))
                            .ExecuteNonQuery();
                        }

                        //อัพเดทสถานะ กรณีที่ได้ทำการบันทึกขอมูลเข้าระบบ SAP แล้ว
                        db.SetCommand(GetSql(24), db.Parameter("@DocumentNo", documentNo)).ExecuteNonQuery();

                        //logic เดิมจาก P'tommy เพิ่มข้อมูลสรุปไปยังตาราง TBHANDHELDCOUNTER_HEADER
                        db.SetCommand(GetSql(25), db.Parameter("@DocumentNo", documentNo)).ExecuteNonQuery();

                        db.CommitTransaction();

                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        throw ex;
                    }

                }

                var countText = "เลขที่ใบนับ";
                if (string.IsNullOrEmpty(e_zcountqi))
                    countText = "เลขที่ใบขอนับ";

                messageAlert = string.Format("บันทึกข้อมูลเรียร้อย\n {2} : {0}\n เลขที่ใบตรวจ : {1}\n คุณต้องการนับสต็อคใหม่ ใช่หรือไม่", sapDocumentNo, e_zcountqi, countText);

                return messageAlert;
            }
            else
            {
                messageAlert = messageStatus;

                return messageAlert;

            }



        }

    }

}