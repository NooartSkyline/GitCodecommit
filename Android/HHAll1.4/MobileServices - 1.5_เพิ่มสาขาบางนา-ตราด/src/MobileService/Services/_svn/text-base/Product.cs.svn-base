using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using BLToolkit.Data;

namespace DoHome.MobileService
{
    [DataContract]
    [TableName("TBPRODUCT")]
    public partial class Product
    {
        /// <summary>
        /// Gets the Product identifier
        /// </summary>
        [DataMember]
        [MapField("CODE")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the NAMETH
        /// </summary>
        [DataMember]
        [MapField("NAMETH")]
        public string NameTh { get; set; }

        /// <summary>
        /// Gets or sets the NAMEEN
        /// </summary>
        [DataMember]
        [MapField("NAMEEN")]
        public string NameEn { get; set; }

        /// <summary>
        /// Gets or sets the NAMESEARCH
        /// </summary>
        [DataMember]
        [MapField("NAMESEARCH")]
        public string NameSearch { get; set; }

        /// <summary>
        /// Gets or sets the TAXTYPE
        /// </summary>
        [DataMember]
        [MapField("TAXTYPE")]
        public short TaxType { get; set; }

        /// <summary>
        /// Gets or sets the STATUS
        /// </summary>
        [DataMember]
        [MapField("STATUS")]
        public short Status { get; set; }

        /// <summary>
        /// Gets or sets the STOCKUNIT
        /// </summary>
        [DataMember]
        [MapField("STOCKUNIT")]
        public string StockUnit { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCTTYPE
        /// </summary>
        [DataMember]
        [MapField("PRODUCTTYPE")]
        public string ProductType { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCTBRAND
        /// </summary>
        [DataMember]
        [MapField("PRODUCTBRAND")]
        public string ProductBrand { get; set; }

        /// <summary>
        /// Gets or sets the MATERIALTYPE
        /// </summary>
        [DataMember]
        [MapField("MATERIALTYPE")]
        public short MaterialType { get; set; }

        /// <summary>
        /// Gets or sets the MAINCODE
        /// </summary>
        [DataMember]
        [MapField("MAINCODE")]
        public string MainCode { get; set; }

        /// <summary>
        /// Gets or sets the CNFLAG
        /// </summary>
        [DataMember]
        [MapField("CNFLAG")]
        public short Cnflag { get; set; }

        /// <summary>
        /// Gets or sets the SHOWPRICEFLAG
        /// </summary>
        [DataMember]
        [MapField("SHOWPRICEFLAG")]
        public short ShowPriceflag { get; set; }

        /// <summary>
        /// Gets or sets the CRCHARGEFLAG
        /// </summary>
        [DataMember]
        [MapField("CRCHARGEFLAG")]
        public short CrChargeflag { get; set; }

        /// <summary>
        /// Gets or sets the OLDCODE
        /// </summary>
        [DataMember]
        [MapField("OLDCODE")]
        public string OldCode { get; set; }

        /// <summary>
        /// Gets or sets the MTPOS
        /// </summary>
        [DataMember]
        [MapField("MTPOS")]
        public string MtPos { get; set; }

    }

    public partial interface IMobileService
    {
        [OperationContract]
        string GetProductBarcodeByProductCode(string branchCode,string productCode, string unitCode);

        [OperationContract]
        Product GetProductByCode(string branchCode,string productCode);

        [OperationContract]
        Product GetProductByBarCode(string branchCode,string barcode);

        [OperationContract]
        string GetProductCode(string branchCode,string productCodeOrBarcode);
      

    }

    public partial class MobileService : IMobileService
    {
        public Product GetProductByCode(string branchCode,string productCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand("SELECT * FROM TBProduct Where Code = @ProductCode;",
                    db.Parameter("@ProductCode", productCode))
                    .ExecuteObject<Product>();
            }
        }

        public Product GetProductByBarCode(string branchCode,string barcode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand("SELECT * FROM TBProduct Where Code = (SELECT Distinct ProductCode FROM TBBarcode Where Barcode = @Barcode );",
                    db.Parameter("@Barcode", barcode))
                    .ExecuteObject<Product>();
            }
        }

        public string GetProductCode(string branchCode,string productCodeOrBarcode)
        {

            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(16),
                    db.Parameter("@ProductOrBarcode", productCodeOrBarcode))
                    .ExecuteScalar<string>();
            }
        }
        
    }

}

