using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using BLToolkit.Data;
using System.Data;

namespace DoHome.MobileService
{

    #region Property

    ///<summary>
    ///<para>Date Created: 05/10/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBSALEPRICE</para>
    ///<para>This object represents the properties of a ProductPrice, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("TBSALEPRICE")]
    public partial class ProductPrice
    {
        /// <summary>
        /// Gets the ProductPrice identifier
        /// </summary>
        [DataMember]
        [MapField("BRANCHCODE"), PrimaryKey]
        public string Branchcode { get; set; }
        /// <summary>
        /// Gets the ProductPrice identifier
        /// </summary>
        [DataMember]
        [MapField("BEGINDATE"), PrimaryKey]
        public DateTime? Begindate { get; set; }
        /// <summary>
        /// Gets the ProductPrice identifier
        /// </summary>
        [DataMember]
        [MapField("ENDDATE"), PrimaryKey]
        public DateTime? Enddate { get; set; }
        /// <summary>
        /// Gets the ProductPrice identifier
        /// </summary>
        [DataMember]
        [MapField("PRODUCTCODE"), PrimaryKey]
        public string Productcode { get; set; }
        /// <summary>
        /// Gets the ProductPrice identifier
        /// </summary>
        [DataMember]
        [MapField("UNITCODE"), PrimaryKey]
        public string Unitcode { get; set; }

        /// <summary>
        /// Gets or sets the PAYMENTCODE
        /// </summary>
        [DataMember]
        [MapField("PAYMENTCODE")]
        public string Paymentcode { get; set; }

        /// <summary>
        /// Gets or sets the SALEPRICE
        /// </summary>
        [DataMember]
        [MapField("SALEPRICE")]
        public decimal Saleprice { get; set; }

        /// <summary>
        /// Gets or sets the SALEPRICENV
        /// </summary>
        [DataMember]
        [MapField("SALEPRICENV")]
        public decimal Salepricenv { get; set; }

        /// <summary>
        /// Gets or sets the CREATEDATE
        /// </summary>
        [DataMember]
        [MapField("CREATEDATE")]
        public DateTime? Createdate { get; set; }

        /// <summary>
        /// Gets or sets the STDPRICE
        /// </summary>
        [DataMember]
        [MapField("STDPRICE")]
        public decimal Stdprice { get; set; }

    }
    [DataContract]
    public partial class ProductPriceUnit
    {   [DataMember]
        public string UnitCode { get; set; }
           [DataMember]
        public string UnitName { get; set; }
    }
    #endregion

    public partial interface IMobileService
    {
        [OperationContract]
        ProductPrice ProductPriceGetCurrentPrice(string branchCode, string productCode, string unitCode);
        [OperationContract]
        List<ProductPrice> ProductPriceGetAllPrice(string branchCode, string productCode, string unitCode);
        [OperationContract]
        ProductPriceUnit ProductPriceGetUnitOther(string branchCode, string productCode, string unitCode);
    }

    public partial class MobileService : IMobileService
    {

        public ProductPrice ProductPriceGetCurrentPrice(string branchCode, string productCode, string unitCode)
        {
            using (var db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(47),
                db.Parameter("@BranchCode", branchCode),
                db.Parameter("@ProductCode", productCode),
                db.Parameter("@UnitCode", unitCode))
                .ExecuteObject<ProductPrice>();
            }
        }
        public ProductPriceUnit ProductPriceGetUnitOther(string branchCode, string productCode, string unitCode)
        {
            using (var db = new DbManager(branchCode))
            {
               var x = db.SetCommand(GetSql(105),                
                db.Parameter("@ProductCode", productCode),
                db.Parameter("@UnitCode", unitCode))
                .ExecuteObject<ProductPriceUnit>();
               return x;
            }
        }
        public List<ProductPrice> ProductPriceGetAllPrice(string branchCode, string productCode, string unitCode)
        {
            using (var db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(48),
                db.Parameter("@BranchCode", branchCode),
                db.Parameter("@ProductCode", productCode),
                db.Parameter("@UnitCode", unitCode))
                .ExecuteList<ProductPrice>();
            }
        }

    }
}