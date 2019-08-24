using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System;
using System.ServiceModel;
using System.Data;
using System.Collections.Generic;
using BLToolkit.Data;


namespace DoHome.MobileService
{
    ///<summary>
    ///<para>Date Created: 01/08/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBHANDHELDCOUNTER_MAIN_HOLDBILL</para>
    ///<para>This object represents the properties of a HandHeldCounterMainHold, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("TBHANDHELDCOUNTER_MAIN_HOLDBILL")]
    public partial class HandHeldCounterMainHold
    {
        /// <summary>
        /// Gets the HandHeldCounterMainHold identifier
        /// </summary>
        [DataMember]
        [MapField("DOCNO"), PrimaryKey]
        public string Docno { get; set; }
        /// <summary>
        /// Gets the HandHeldCounterMainHold identifier
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
        /// Gets or sets the IBLNR
        /// </summary>
        [DataMember]
        [MapField("IBLNR")]
        public string Iblnr { get; set; }

        /// <summary>
        /// Gets or sets the GJAHR
        /// </summary>
        [DataMember]
        [MapField("GJAHR")]
        public string Gjahr { get; set; }

        /// <summary>
        /// Gets or sets the ZEILI
        /// </summary>
        [DataMember]
        [MapField("ZEILI")]
        public string Zeili { get; set; }

        /// <summary>
        /// Gets or sets the MATNR
        /// </summary>
        [DataMember]
        [MapField("MATNR")]
        public string Matnr { get; set; }

        /// <summary>
        /// Gets or sets the EAN11
        /// </summary>
        [DataMember]
        [MapField("EAN11")]
        public string Ean11 { get; set; }

        /// <summary>
        /// Gets or sets the MAKTX
        /// </summary>
        [DataMember]
        [MapField("MAKTX")]
        public string Maktx { get; set; }

        /// <summary>
        /// Gets or sets the SHELF
        /// </summary>
        [DataMember]
        [MapField("SHELF")]
        public string Shelf { get; set; }

        /// <summary>
        /// Gets or sets the BIN_CODE
        /// </summary>
        [DataMember]
        [MapField("BIN_CODE")]
        public string BinCode { get; set; }

        /// <summary>
        /// Gets or sets the ERFMG_SKU
        /// </summary>
        [DataMember]
        [MapField("ERFMG_SKU")]
        public decimal ErfmgSku { get; set; }

        /// <summary>
        /// Gets or sets the ERFME_SKU
        /// </summary>
        [DataMember]
        [MapField("ERFME_SKU")]
        public string ErfmeSku { get; set; }

        /// <summary>
        /// Gets or sets the RATIO
        /// </summary>
        [DataMember]
        [MapField("RATIO")]
        public decimal Ratio { get; set; }

        /// <summary>
        /// Gets or sets the ERFMG_SALES
        /// </summary>
        [DataMember]
        [MapField("ERFMG_SALES")]
        public decimal ErfmgSales { get; set; }

        /// <summary>
        /// Gets or sets the ERFME_SALES
        /// </summary>
        [DataMember]
        [MapField("ERFME_SALES")]
        public string ErfmeSales { get; set; }

        /// <summary>
        /// Gets or sets the CREATEDATE
        /// </summary>
        [DataMember]
        [MapField("CREATEDATE")]
        public DateTime? Createdate { get; set; }

        /// <summary>
        /// Gets or sets the CREATEUSER
        /// </summary>
        [DataMember]
        [MapField("CREATEUSER")]
        public string Createuser { get; set; }

        /// <summary>
        /// Gets or sets the STATUS
        /// </summary>
        [DataMember]
        [MapField("STATUS")]
        public string Status { get; set; }

        [DataMember]
        [MapIgnore]
        public string UnitNameForSale { get; set; }

        [DataMember]
        [MapIgnore]
        public string UnitNameForSKU { get; set; }

        [DataMember]
        [MapIgnore]
        public string ProductCode { get; set; }

    }

    [DataContract]
    public partial class ZMMInvoiceCnTh
    {

        /// <summary>
        /// Gets or sets the iblnr "เอกสารการตรวจนับสินค้าคงคลัง"
        /// </summary>
        [DataMember]
        public string iblnr { get; set; }

        /// <summary>
        /// Gets or sets the gjahr "ปีบัญชี"
        /// </summary>
        [DataMember]
        public string gjahr { get; set; }

        /// <summary>
        /// Gets or sets the budat "วันที่ผ่านรายการในเอกสาร"
        /// </summary>
        [DataMember]
        public DateTime budat { get; set; }

        [DataMember]
        public string DisplayText { get; set; }

    }

    //[DataContract]
    //public partial class ZDDHandHeldCheckStock
    //{

    //    /// <summary>
    //    /// Gets or sets the matnr "เลขที่วัสดุ"
    //    /// </summary>
    //    [DataMember]
    //    public string ProductCode { get; set; }

    //    /// <summary>
    //    /// Gets or sets the maktx "คำอธิบายวัสดุ (ข้อความแบบสั้น)"
    //    /// </summary>
    //    [DataMember]
    //    public string ProductName { get; set; }

    //    /// <summary>
    //    /// Gets or sets the bin_code "รหัสตำแหน่งเก็บสินค้า"
    //    /// </summary>
    //    [DataMember]
    //    public string LocationCode { get; set; }

    //    /// <summary>
    //    /// Gets or sets the erfme_sales "หน่วยรายการ (การนับสินค้าคงคลัง)"
    //    /// </summary>
    //    [DataMember]
    //    public string UnitCodeForSale { get; set; }

    //    /// <summary>
    //    /// Gets or sets the erfme_sku "หน่วยรายการ (การนับสินค้าคงคลัง)"
    //    /// </summary>
    //    [DataMember]
    //    public string UnitCodeForSKU { get; set; }

    //    [DataMember]
    //    public string UnitNameForSale { get; set; }

    //    [DataMember]
    //    public string UnitNameForSKU { get; set; }


    //    [DataMember]
    //    public decimal QuantityForSale { get; set; }

    //    [DataMember]
    //    public decimal QuantityForSKU { get; set; }

    //    [DataMember]
    //    public string Barcode { get; set; }

    //}

    public partial interface IMobileService
    {
        [OperationContract]
        string AddHandHeldCounterMainHold(string branchCode, HandHeldCounterMainHold[] handHeldCounterMainHolds);

        [OperationContract]
        void AddMajorHandHeldCounterMainHoldToSap(string branchCode, string documentNo, string officerID1, string officerID2);

        [OperationContract]
        void AddMinorHandHeldCounterMainHoldToSap(string documentNo, string officerID1, string officerID2, string officerID3, string officerID4, string warehouseCode, string branchCode);

        [OperationContract]
        List<ZMMInvoiceCnTh> GetHandHeldCounterMainHoldZMMInvoiceCnThFromSap(string officerID);

        [OperationContract]
        List<HandHeldCounterMainHold> GetHandHeldCounterMainHoldZDDHandHeldCheckStockFromSap(string branchCode,string iblnr, string Gjahr, string officerID);

        [OperationContract]
        List<HandHeldCounterMainHold> GetHandHeldCounterMainHoldByDocumentNo(string branchCode,string documentNo);

        [OperationContract]
        List<HandHeldCounterMainHold> GetHandHeldCounterMainHoldBillByUser(string branchCode,string userCode);

    }


    public partial class MobileService : IMobileService
    {

        #region Private Method

        private bool IsNumeric(object obj)
        {
            try
            {
                double dTemp = Convert.ToDouble(obj);
                return true;
            }
            catch { return false; }
        }

        private string FormatedProductCode(string sapProductCode)
        {
            bool ret = this.IsNumeric(sapProductCode);
            if (ret)
            {
                try
                {
                    sapProductCode = Convert.ToDouble(sapProductCode).ToString("####0");
                }
                catch { }
            }

            return sapProductCode;
        }


        private string GetHandHeldCounterMainHoldDocumentNo(string branchCode)
        {
            var documentNo = string.Empty;

            using (DbManager db = new DbManager(branchCode))
            {
                documentNo = db.SetCommand(GetSql(30)).ExecuteScalar<string>();
            }

            var culture = new System.Globalization.CultureInfo("th-TH");
            int index = 1;
            if (!string.IsNullOrEmpty(documentNo))
                index = Convert.ToInt32(documentNo) + 1;

            documentNo = string.Format("HL{0}-{1:0000}", DateTime.Now.Date.ToString("yyMMdd", culture), index);

            return documentNo;
        }

        #endregion

        public List<ZMMInvoiceCnTh> GetHandHeldCounterMainHoldZMMInvoiceCnThFromSap(string officerID)
        {

            using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (var prx = new SAPProxyIII.UWProxy())
                {
                    prx.Connection = sapConnection;
                    SAPProxyIII.PERNR pernr = new SAPProxyIII.PERNR();
                    SAPProxyIII.ZMM_INV_CNTH_UWTable tables = new SAPProxyIII.ZMM_INV_CNTH_UWTable();
                    pernr.Pernr = officerID;
                    prx.Zdd_Handheld_Checkdoc(pernr, ref tables);

                    var ZMMInvoiceCnThList = new List<ZMMInvoiceCnTh>();
                    foreach (SAPProxyIII.ZMM_INV_CNTH_UW item in tables)
                    {
                        var zmm = new ZMMInvoiceCnTh();
                        zmm.iblnr = item.Iblnr;
                        zmm.gjahr = item.Gjahr;
                        zmm.budat = DateTime.ParseExact(item.Budat, "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                        zmm.DisplayText = string.Format("{0} : {1} : {2:dd.MM.yyyy}", zmm.iblnr, zmm.gjahr, zmm.budat);
                        ZMMInvoiceCnThList.Add(zmm);
                    }


                    return ZMMInvoiceCnThList;
                }
            }
        }

        public List<HandHeldCounterMainHold> GetHandHeldCounterMainHoldZDDHandHeldCheckStockFromSap(string branchCode, string iblnr, string Gjahr, string officerID)
        {
            using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (var prx = new SAPProxyIII.UWProxy())
                {
                    prx.Connection = sapConnection;
                    SAPProxyIII.PERNR pernr = new SAPProxyIII.PERNR();
                    SAPProxyIII.ZDD_HH_CHKSTOCKTable tables = new SAPProxyIII.ZDD_HH_CHKSTOCKTable();
                    pernr.Pernr = officerID;
                    prx.Zdd_Handheld_Checkstock(Gjahr, iblnr, string.Empty, string.Empty, string.Empty, ref tables);

                    var zDDHandHeldCheckStockList = new List<HandHeldCounterMainHold>();
                    foreach (SAPProxyIII.ZDD_HH_CHKSTOCK item in tables)
                    {
                        var zdd = new HandHeldCounterMainHold();
                        zdd.Matnr = item.Matnr;
                        zdd.ProductCode = FormatedProductCode(item.Matnr);
                        zdd.Maktx = item.Maktx;
                        zdd.BinCode = item.Bin_Code;
                        zdd.ErfmeSales = item.Erfme_Sales;
                        zdd.UnitNameForSale = GetUnitByCode(branchCode, item.Erfme_Sales);
                        zdd.ErfmeSku = item.Erfme_Sku;
                        zdd.UnitNameForSKU = GetUnitByCode(branchCode, item.Erfme_Sku);
                        zdd.Iblnr = item.Iblnr;
                        zdd.Gjahr = item.Gjahr;
                        zdd.Zeili = item.Zeili;
                        zdd.Ean11 = item.Ean11;
                        zdd.Shelf = zdd.Shelf;
                        zdd.ErfmgSku = item.Erfmg_Sku;
                        zdd.Ratio = item.Ratio;
                        zdd.ErfmgSales = item.Erfmg_Sales;

                        zDDHandHeldCheckStockList.Add(zdd);
                    }

                    return zDDHandHeldCheckStockList;

                }
            }

        }

        public string AddHandHeldCounterMainHold(string branchCode,HandHeldCounterMainHold[] handHeldCounterMainHolds)
        {
            using (var db = new DbManager(branchCode))
            {
                try
                {
                    string documentNo = string.Empty;
                    var hold = handHeldCounterMainHolds[0];
                    if (string.IsNullOrEmpty(hold.Docno))
                        documentNo = GetHandHeldCounterMainHoldDocumentNo(branchCode);
                    else
                        documentNo = hold.Docno;

                    DateTime currentDate = DateTime.Now;

                    SqlQuery<HandHeldCounterMainHold> query = new SqlQuery<HandHeldCounterMainHold>(db);

                    db.BeginTransaction();

                    db.SetCommand(GetSql(34), db.Parameter("@DocumentNo", documentNo)).ExecuteNonQuery();

                    int displayOrder = 0;
                    foreach (var item in handHeldCounterMainHolds)
                    {
                        item.Docno = documentNo;
                        item.Docdate = currentDate.Date;
                        item.Roworder = displayOrder;
                        item.Createdate = currentDate;
                        item.Status = "";
                        query.Insert(item);

                        displayOrder++;
                    }

                    db.CommitTransaction();

                    return documentNo;
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    throw ex;
                }
            }



        }

        public void AddMajorHandHeldCounterMainHoldToSap(string branchCode,string documentNo, string officerID1, string officerID2)
        {

            var counterHolds = GetHandHeldCounterMainHoldByDocumentNo(branchCode,documentNo);
            string accountingYear = string.Empty;
            string officerID = string.Empty;
            SAPProxyIII.ZDD_HH_CHKSTOCKTable tables = new SAPProxyIII.ZDD_HH_CHKSTOCKTable();

            using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (var prx = new SAPProxyIII.UWProxy())
                {
                    prx.Connection = sapConnection;

                    foreach (var item in counterHolds)
                    {
                        var zdd = new SAPProxyIII.ZDD_HH_CHKSTOCK();
                        zdd.Iblnr = item.Iblnr;
                        zdd.Gjahr = item.Gjahr;
                        zdd.Zeili = item.Zeili;
                        zdd.Matnr = item.Matnr;
                        zdd.Ean11 = item.Ean11;
                        zdd.Maktx = item.Maktx;
                        zdd.Shelf = item.Shelf;
                        zdd.Bin_Code = item.BinCode;
                        zdd.Erfmg_Sku = item.ErfmgSku;
                        zdd.Erfme_Sku = item.ErfmeSku;
                        zdd.Ratio = item.Ratio;
                        zdd.Erfmg_Sales = item.ErfmgSales;
                        zdd.Erfme_Sales = item.ErfmeSales;

                        accountingYear = item.Gjahr;
                        officerID = item.Createuser;

                        tables.Add(zdd);
                    }

                    try
                    {
                        prx.Zdd_Handheld_Checkstock(accountingYear, documentNo, "X", officerID1, officerID1, ref tables);

                        using (var db = new DbManager(branchCode))
                        {
                            db.SetCommand(GetSql(33), db.Parameter("@DocumentNo", documentNo)).ExecuteNonQuery();
                        }

                        prx.CommitWork();
                    }
                    catch (Exception ex)
                    {
                        prx.RollbackWork();
                        throw ex;
                    }


                }

            }

        }

        public void AddMinorHandHeldCounterMainHoldToSap(string documentNo, string officerID1, string officerID2, string officerID3, string officerID4, string warehouseCode, string branchCode)
        {

            var counterHolds = GetHandHeldCounterMainHoldByDocumentNo(branchCode,documentNo);
            string accountingYear = string.Empty;
            string officerID = string.Empty;
            SAPProxyIII.ZDD_HH_CHKSTOCKTable tables = new SAPProxyIII.ZDD_HH_CHKSTOCKTable();
            SAPProxyIII.BAPIRET2Table returns = new SAPProxyIII.BAPIRET2Table();

            using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            {
                using (var prx = new SAPProxyIII.UWProxy())
                {
                    prx.Connection = sapConnection;

                    foreach (var item in counterHolds)
                    {
                        var zdd = new SAPProxyIII.ZDD_HH_CHKSTOCK();
                        zdd.Iblnr = item.Iblnr;
                        zdd.Gjahr = item.Gjahr;
                        zdd.Zeili = item.Zeili;
                        zdd.Matnr = item.Matnr;
                        zdd.Ean11 = item.Ean11;
                        zdd.Maktx = item.Maktx;
                        zdd.Shelf = item.Shelf;
                        zdd.Bin_Code = item.BinCode;
                        zdd.Erfmg_Sku = item.ErfmgSku;
                        zdd.Erfme_Sku = item.ErfmeSku;
                        zdd.Ratio = item.Ratio;
                        zdd.Erfmg_Sales = item.ErfmgSales;
                        zdd.Erfme_Sales = item.ErfmeSales;

                        accountingYear = item.Gjahr;
                        officerID = item.Createuser;

                        tables.Add(zdd);
                    }

                    try
                    {
                        string documentOut = string.Empty;

                        prx.Zdd_Handheld_Checkstock02(branchCode
                            , "X"
                            , accountingYear
                            , documentNo
                            , warehouseCode
                            , "X"
                            , officerID1
                            , officerID2
                            , officerID3
                            , officerID4
                            , out documentOut
                            , ref tables
                            , ref returns);

                        using (var db = new DbManager(branchCode))
                        {
                            db.SetCommand(GetSql(33), db.Parameter("@DocumentNo", documentNo)).ExecuteNonQuery();
                        }

                        prx.CommitWork();
                    }
                    catch (Exception ex)
                    {
                        prx.RollbackWork();
                        throw ex;
                    }


                }

            }

        }

        public List<HandHeldCounterMainHold> GetHandHeldCounterMainHoldByDocumentNo(string branchCode, string documentNo)
        {
            using (var db = new DbManager(branchCode))
            {
                List<HandHeldCounterMainHold> counterHolds = null;

                counterHolds = db.SetCommand(GetSql(31), db.Parameter("@DocumentNo", documentNo)).ExecuteList<HandHeldCounterMainHold>();

                foreach (var item in counterHolds)
                {
                    item.ProductCode = FormatedProductCode(item.Matnr);
                    item.UnitNameForSale = GetUnitByCode(branchCode, item.ErfmeSales);
                    item.UnitNameForSKU = GetUnitByCode(branchCode, item.ErfmeSku);
                }

                return counterHolds;
            }

        }

        public List<HandHeldCounterMainHold> GetHandHeldCounterMainHoldBillByUser(string branchCode,string userCode)
        {
            using (var db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(32), db.Parameter("@UserCode", userCode)).ExecuteList<HandHeldCounterMainHold>();

            }

        }

        //public List<ZDDHandHeldCheckStock> GetHandHeldCounterMainHoldZDDHandHeldCheckStockFromSap(string iblnr, string Gjahr, string officerID)
        //{

        //    using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
        //    {
        //        using (var prx = new SAPProxyIII.UWProxy())
        //        {
        //            prx.Connection = sapConnection;
        //            SAPProxyIII.PERNR pernr = new SAPProxyIII.PERNR();
        //            SAPProxyIII.ZDD_HH_CHKSTOCKTable tables = new SAPProxyIII.ZDD_HH_CHKSTOCKTable();
        //            pernr.Pernr = officerID;
        //            prx.Zdd_Handheld_Checkstock(Gjahr, iblnr, "", officerID, ref tables);

        //            var zDDHandHeldCheckStockList = new List<ZDDHandHeldCheckStock>();
        //            foreach (SAPProxyIII.ZDD_HH_CHKSTOCK item in tables)
        //            {
        //                var zdd = new ZDDHandHeldCheckStock();
        //                zdd.ProductCode = FormatedProductCode(item.Matnr);
        //                var product = ProductBarcodeGetByProductCode(zdd.ProductCode, item.Erfme_Sku);
        //                if (product != null)
        //                {
        //                    zdd.Barcode = product.Barcode;
        //                }
        //                zdd.ProductName = item.Maktx;
        //                zdd.LocationCode = item.Bin_Code;
        //                zdd.UnitCodeForSale = item.Erfme_Sales;
        //                zdd.UnitNameForSale = GetUnitByCode(zdd.UnitCodeForSale);
        //                zdd.UnitCodeForSKU = item.Erfme_Sku;
        //                zdd.UnitNameForSKU = GetUnitByCode(zdd.UnitCodeForSKU);
        //                zDDHandHeldCheckStockList.Add(zdd);
        //            }

        //            return zDDHandHeldCheckStockList;

        //        }
        //    }

        //}



    }

}