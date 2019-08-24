using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;
using System;
using SubSonic.Repository;
using SubSonic.SqlGeneration.Schema;
using SubSonic.DataProviders;
using System.Data;
using System.Transactions;

namespace DoHome.MobileService
{
    [DataContract]
    public class LabelPrint
    {
        [DataMember]
        [MapField("DocNo")]
        public string DocumentNo { get; set; }

        //[DataMember]
        //[MapField("DocDate")]
        //public DateTime DocumentDate { get; set; }

        //[DataMember]
        //[MapIgnore]
        //public string DocumentDateString { get; set; }

        [DataMember]
        [MapField("LocationCode")]
        public string LocationCode { get; set; }

        [DataMember]
        [MapField("QuantityOfLabel")]
        public int QuantityOfLabel { get; set; }

    }

    [DataContract]
    public class LabelPrintType
    {
        [DataMember]
        [MapField("Code")]
        public string Code { get; set; }

        [DataMember]
        [MapField("Remark")]
        public string Name { get; set; }

        [DataMember]
        [MapField("BranchCode")]
        public string BranchCode { get; set; }

    }
    //get locations
    [DataContract]
    public class LabelPrintTypeLocation
    {
        [DataMember]
        [MapField("BRANCHCODE")]
        public string branchcode { get; set; }

        [DataMember]
        [MapField("PRODUCTCODE")]
        public string productcode { get; set; }

        [DataMember]
        [MapField("WAREHOUSE")]
        public string warehouse { get; set; }

        [DataMember]
        [MapField("UNITCODE")]
        public string unitcode { get; set; }

        [DataMember]
        [MapField("LOCATION")]
        public string location { get; set; }
    }



    [DataContract]
    [TableName("TBPRINTLABEL")]
    [SubSonicTableNameOverride("TBPRINTLABEL")]
    public class LabelPrintProduct
    {
        [MapField("DOCNO"), PrimaryKey]
        [DataMember]
        [SubSonicPrimaryKey]
        public string Docno { get; set; }

        [DataMember]
        public string Branchcode { get; set; }

        [DataMember]
        public DateTime? Docdate { get; set; }

        [DataMember]
        public string Remark { get; set; }

        [DataMember]
        public string Createuser { get; set; }

        [DataMember]
        public DateTime? Createdate { get; set; }

        [DataMember]
        public int Isprint { get; set; }

        [DataMember]
        public string Printlabeltype { get; set; }

        [DataMember]
        [NonUpdatable]
        [SubSonicIgnore]
        public string PrintlabeltypeName { get; set; }

        [DataMember]
        public DateTime? Printlabeldate { get; set; }

        [DataMember]
        public string Computername { get; set; }

        [DataMember]
        public int Printcount { get; set; }

        [DataMember]
        [MapIgnore]
        [SubSonicIgnore]
        public string PrintStatus { get; set; }

    }

    [DataContract]
    [TableName("TBPRINTLABELSUB")]
    [SubSonic.SqlGeneration.Schema.SubSonicTableNameOverride("TBPRINTLABELSUB")]
    public class LabelPrintProductDetail
    {
        /// <summary>
        /// Gets the LocationCheckDepartment identifier
        /// </summary>
        [DataMember]
        [MapField("DOCNO")]
        [SubSonic.SqlGeneration.Schema.SubSonicPrimaryKey]
        public string Docno { get; set; }

        /// <summary>
        /// Gets the LocationCheckDepartment identifier
        /// </summary>
        [DataMember]
        [MapField("ROWORDER")]
        [SubSonic.SqlGeneration.Schema.SubSonicPrimaryKey]
        public string Roworder { get; set; }


        [DataMember]
        [SubSonicIgnore]
        public int DisplayOrder { get; set; }


        /// <summary>
        /// Gets or sets the DOCDATE
        /// </summary>
        [DataMember]
        [MapField("DOCDATE")]
        public DateTime? Docdate { get; set; }

        /// <summary>
        /// Gets or sets the BARCODE
        /// </summary>
        [DataMember]
        [MapField("BARCODE")]
        public string Barcode { get; set; }

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
        /// Gets or sets the LOCATIONCODE
        /// </summary>
        [DataMember]
        [MapField("LOCATIONCODE")]
        public string Locationcode { get; set; }

        /// <summary>
        /// Gets or sets the LOCATIONNAME
        /// </summary>
        [DataMember]
        [MapField("LOCATIONNAME")]
        public string Locationname { get; set; }

        /// <summary>
        /// Gets or sets the SELLPRICE
        /// </summary>
        [DataMember]
        [MapField("SELLPRICE")]
        public decimal Sellprice { get; set; }

        /// <summary>
        /// Gets or sets the PRICEDATE
        /// </summary>
        [DataMember]
        [MapField("PRICEDATE")]
        public DateTime? Pricedate { get; set; }

        /// <summary>
        /// Gets or sets the PRIMARYGROUP
        /// </summary>
        [DataMember]
        [MapField("PRIMARYGROUP")]
        public string Primarygroup { get; set; }

        /// <summary>
        /// Gets or sets the REMARK
        /// </summary>
        [DataMember]
        [MapField("REMARK")]
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the SETPRICE_ROWID
        /// </summary>
        [DataMember]
        [MapField("SETPRICE_ROWID")]
        [SubSonic.SqlGeneration.Schema.SubSonicColumnNameOverride("SETPRICE_ROWID")]
        public string SetpriceRowid { get; set; }

        /// <summary>
        /// Gets or sets the OTH_UNITCODE
        /// </summary>
        [DataMember]
        [MapField("OTH_UNITCODE")]
        [SubSonic.SqlGeneration.Schema.SubSonicColumnNameOverride("OTH_UNITCODE")]
        public string OthUnitcode { get; set; }

        /// <summary>
        /// Gets or sets the OTH_UNITNAME
        /// </summary>
        [DataMember]
        [MapField("OTH_UNITNAME")]
        [SubSonic.SqlGeneration.Schema.SubSonicColumnNameOverride("OTH_UNITNAME")]
        public string OthUnitname { get; set; }

        /// <summary>
        /// Gets or sets the OTH_UNITPRICE
        /// </summary>
        [DataMember]
        [MapField("OTH_UNITPRICE")]
        [SubSonic.SqlGeneration.Schema.SubSonicColumnNameOverride("OTH_UNITPRICE")]
        public decimal OthUnitprice { get; set; }

        /// <summary>
        /// Gets or sets the LASTPRICE
        /// </summary>
        [DataMember]
        [MapField("LASTPRICE")]
        public decimal Lastprice { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCTTYPE
        /// </summary>
        [DataMember]
        [MapField("PRODUCTTYPE")]
        public string Producttype { get; set; }

        /// <summary>
        /// Gets or sets the STDPRICE
        /// </summary>
        [DataMember]
        [MapField("STDPRICE")]
        public decimal Stdprice { get; set; }

        /// <summary>
        /// Gets or sets the PrintLabelTypeCode
        /// </summary>
        [DataMember]
        [MapField("PrintLabelTypeCode")]
        public string PrintLabelTypeCode { get; set; }
    }

    public partial interface IMobileService
    {

        [OperationContract]
        List<LabelPrint> GetLabelPrint(string branchCode, string userCode);

        [OperationContract]
        string LabelPrintProductAdd(string branchCode, string createdBy, string remark, string labelPrintTypeCode);

        [OperationContract]
        string LabelPrintProductAddWithDetail(string branchCode, string createdBy, string remark, string labelType, List<LabelPrintProductDetail> details);

        [OperationContract]
        void LabelPrintProductDelete(string branchCode, string docno);

        [OperationContract]
        List<LabelPrintProduct> LabelPrintProductGet(string branchCode, string docno, DateTime docdate, string createdBy);

        [OperationContract]
        void LabelPrintProductDetailAdd(string branchCode, string docno, List<LabelPrintProductDetail> details);

        [OperationContract]
        void LabelPrintProductDetailDelete(string branchCode, string docno, int rowOrder);

        [OperationContract]
        List<LabelPrintProductDetail> LabelPrintProductDetailGet(string branchCode, string docno);

        [OperationContract]
        List<LabelPrintType> LabelPrintTypeGetByBranch(string branchCode);

        //[OperationContract]
        //List<LabelPrintTypeLocation> LabelPrintTypeLocationDetail(string branchcode,string productcode,string warehouse,string location);
    }


    public partial class MobileService : IMobileService
    {

        public List<LabelPrint> GetLabelPrint(string branchCode, string userCode)
        {
            try
            {
                using (DbManager db = new DbManager(branchCode))
                {
                    var labelPrint = db.SetCommand(GetSql(55),
                                     db.Parameter("@UserCode", userCode))
                                     .ExecuteList<LabelPrint>();
                    return labelPrint;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return null;
        }

        public string LabelPrintProductAdd(string branchCode, string createdBy, string remark, string labelPrintTypeCode)
        {
            string docno = string.Empty;

            using (DbManager db = new DbManager(branchCode))
            {
                docno = db.SetCommand(GetSql(79)).ExecuteScalar<string>();
            }

            var culture = new System.Globalization.CultureInfo("th-TH");
            int index = 1;
            if (!string.IsNullOrEmpty(docno))
                index = Convert.ToInt32(docno) + 1;

            docno = string.Format("PR{0}-{1:0000}", DateTime.Now.Date.ToString("yyMMdd", culture), index);

            using (var db = new DbManager(branchCode))
            {
                SqlQuery<LabelPrintProduct> query = new SqlQuery<LabelPrintProduct>();
                var item = new LabelPrintProduct();
                item.Branchcode = branchCode;
                item.Createuser = createdBy;
                item.Createdate = DateTime.Now;
                item.Computername = "Intranet";
                item.Docno = docno;
                item.Docdate = DateTime.Now.Date;
                item.Remark = remark;
                item.Printlabeltype = labelPrintTypeCode;
               

                query.Insert(db, item);

            }


            return docno;
        }

        public string LabelPrintProductAddWithDetail(string branchCode, string createdBy, string remark, string labelType, List<LabelPrintProductDetail> details)
        {
            string docno = string.Empty;

            using (DbManager db = new DbManager(branchCode))
            {
                docno = db.SetCommand(GetSql(79)).ExecuteScalar<string>();
            }

            var culture = new System.Globalization.CultureInfo("th-TH");
            int index = 1;
            if (!string.IsNullOrEmpty(docno))
                index = Convert.ToInt32(docno) + 1;

            docno = string.Format("PR{0}-{1:0000}", DateTime.Now.Date.ToString("yyMMdd", culture), index);

            var master = new LabelPrintProduct();
            master.Branchcode = branchCode;
            master.Createuser = createdBy;
            master.Createdate = DateTime.Now;
            master.Computername = "PDA";
            master.Docno = docno;
            master.Docdate = DateTime.Now.Date;
            master.Remark = remark;
            master.Printlabeltype = labelType;

            //var labelPrintProduct = repo.Single<LabelPrintProduct>(docno);

            var displayOrder = 0;
            ProductPrice productPrice = null;
            foreach (var item in details)
            {
                item.Docno = docno;
                item.Docdate = DateTime.Now.Date;
                item.Roworder = displayOrder.ToString();
                //item.PrintLabelTypeCode = labelPrintProduct.Printlabeltype;

                productPrice = ProductPriceGetCurrentPrice(branchCode, item.Productcode, item.Unitcode);
                if (productPrice != null)
                {
                    item.Sellprice = productPrice.Saleprice;
                    item.Pricedate = productPrice.Begindate;
                    //item.OthUnitprice = item.Sellprice;
                    item.OthUnitprice = 0;
                    item.OthUnitcode = "";
                    item.OthUnitname = "";
                    var UnitOther = ProductPriceGetUnitOther(branchCode,item.Productcode, item.Unitcode);
                    if (UnitOther != null) 
                    {
                        item.OthUnitcode = UnitOther.UnitCode;
                        item.OthUnitname = UnitOther.UnitName;
                        var OthPrice = ProductPriceGetCurrentPrice(branchCode, item.Productcode, item.OthUnitcode);
                        if (OthPrice != null)
                            item.OthUnitprice = OthPrice.Saleprice;
                        else
                        {
                            item.OthUnitprice = 0;
                            item.OthUnitcode = "";
                            item.OthUnitname = "";
                        }
                    }
                }

                displayOrder++;
            }
            var provider = ProviderFactory.GetProvider(branchCode);
            var repo = new SimpleRepository(provider);
            using (System.Transactions.TransactionScope ts = new TransactionScope())
            {
                using (SharedDbConnectionScope scs = new SharedDbConnectionScope(provider))
                {
                    repo.Add<LabelPrintProduct>(master);
                    repo.AddMany<LabelPrintProductDetail>(details);
                    ts.Complete();
                }
            }
            return docno;
        }

        public void LabelPrintProductDelete(string branchCode, string docno)
        {
            using (var db = new DbManager(branchCode))
            {
                //delete master and details.
                db.SetCommand(GetSql(84), db.Parameter("@Docno", docno)).ExecuteNonQuery();
            }
        }

        public List<LabelPrintProduct> LabelPrintProductGet(string branchCode, string docno, DateTime docdate, string createdBy)
        {
            docdate = DateTime.Now;
            using (var db = new DbManager(branchCode))
            {
                var result = db.SetCommand(GetSql(80),
                        db.Parameter("@Docno", "%" + docno + "%"),
                        db.Parameter("@Docdate", docdate),
                        db.Parameter("@CreatedBy", createdBy)).ExecuteList<LabelPrintProduct>();


                foreach (var item in result)
                {
                    if (item.Printlabeldate.HasValue)
                        item.PrintStatus = "พิมพ์แล้ว";
                    else
                        item.PrintStatus = "ยังไม่พิมพ์";
                }
                return result;
            }

        }

        public void LabelPrintProductDetailAdd(string branchCode, string docno, List<LabelPrintProductDetail> details)
        {

            var provider = ProviderFactory.GetProvider(branchCode, "System.Data.SqlClient");
            var repo = new SimpleRepository(provider);

            var labelPrintProduct = repo.Single<LabelPrintProduct>(docno);

            var displayOrder = 0;
            string productCodeOrBarcode = "";
            ProductBarcode product = null;
            ProductPrice productPrice = null;
            foreach (var item in details)
            {
                item.Docno = docno;
                item.Docdate = DateTime.Now.Date;
                item.Roworder = displayOrder.ToString();
                item.PrintLabelTypeCode = labelPrintProduct.Printlabeltype;
                if (!string.IsNullOrEmpty(item.Barcode))
                    productCodeOrBarcode = item.Barcode;
                else
                    productCodeOrBarcode = item.Productcode;

                product = ProductBarcodeGetByProductCodeOrBarcode3(branchCode, productCodeOrBarcode);
                if (product != null)
                {
                    item.Productcode = product.ProductCode;
                    item.Productname = product.ProductName;
                    item.Barcode = product.Barcode;
                    item.Unitcode = product.UnitCode;
                    item.Unitname = product.UnitName;
                    item.OthUnitcode = item.Unitcode;
                    item.OthUnitname = item.Unitname;
                    productPrice = ProductPriceGetCurrentPrice(branchCode, item.Productcode, item.Unitcode);
                    if (productPrice != null)
                    {
                        item.Sellprice = productPrice.Saleprice;
                        item.Pricedate = productPrice.Begindate;
                        item.OthUnitprice = item.Sellprice;
                    }
                }

                displayOrder++;
            }

            using (System.Transactions.TransactionScope ts = new TransactionScope())
            {
                using (SharedDbConnectionScope scs = new SharedDbConnectionScope(provider))
                {
                    repo.DeleteMany<LabelPrintProductDetail>(p => p.Docno == docno);
                    repo.AddMany<LabelPrintProductDetail>(details);
                    ts.Complete();
                }
            }
        }

        public void LabelPrintProductDetailDelete(string branchCode, string docno, int rowOrder)
        {
            using (var db = new DbManager(branchCode))
            {
                db.SetCommand(GetSql(81),
                     db.Parameter("@Docno", docno),
                     db.Parameter("@Roworder", rowOrder)).ExecuteNonQuery();
            }
        }

        public List<LabelPrintProductDetail> LabelPrintProductDetailGet(string branchCode, string docno)
        {
            using (var db = new DbManager(branchCode))
            {
                var result = db.SetCommand(GetSql(82),
                     db.Parameter("@Docno", docno)).ExecuteList<LabelPrintProductDetail>();

                foreach (var item in result)
                {
                    item.DisplayOrder = Convert.ToInt32(item.Roworder) + 1;
                }
                result.Sort(delegate(LabelPrintProductDetail p1, LabelPrintProductDetail p2) { return p1.DisplayOrder.CompareTo(p2.DisplayOrder); });
                return result;
            }
        }

        public List<LabelPrintType> LabelPrintTypeGetByBranch(string branchCode)
        {
            using (var db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(83),
                     db.Parameter("@BranchCode", branchCode)).ExecuteList<LabelPrintType>();
            }
        }
        //List<LabelPrintTypeLocation> LabelPrintLocationDetail(string branchcode, string productcode, string warehouse, string unitcode, string location);
        public List<LabelPrintTypeLocation> LabelPrintLocationDetail(string branchcode, string productcode, string warehouse, string unitcode, string location)
        {
            using (var db = new DbManager(branchcode))
            {
                return db.SetCommand(GetSql(102),
                     db.Parameter("@branchCode", branchcode),
                     db.Parameter("@productcode", productcode),
                     db.Parameter("@warehouse", warehouse),
                     db.Parameter("@unitcode", unitcode),
                     db.Parameter("@location", location)).ExecuteList<LabelPrintTypeLocation>();
            }
        }
    }

}