using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using BLToolkit.Data;
using System.Collections.Generic;

namespace DoHome.MobileService
{
    [DataContract]
    public class MasterProduct
    {
        /// <summary>
        /// Gets the Product ProductCode
        /// </summary>
        [DataMember]
        [MapField("ProductCode")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductBarcode
        /// </summary>
        [DataMember]
        [MapField("ProductBarcode")]
        public string ProductBarcode { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        [DataMember]
        [MapField("ProductName")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ProductUnitCode
        /// </summary>
        [DataMember]
        [MapField("ProductUnitCode")]
        public string ProductUnitCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductPrice
        /// </summary>
        [DataMember]
        [MapField("ProductPrice")]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the BranchCode
        /// </summary>
        [DataMember]
        [MapField("BranchCode")]
        public string BranchCode { get; set; }


    }

    public partial interface IMobileService
    {
        [OperationContract]
        List<MasterProduct> MasterProductGetByBranch(string branchCode);

    }

    public partial class MobileService : IMobileService
    {
        public List<MasterProduct> MasterProductGetByBranch(string branchCode)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db
                    .SetCommand(GetSql(46),
                    db.Parameter("@BranchCode", branchCode))
                    .ExecuteList<MasterProduct>();
            }
        }

    }

}

