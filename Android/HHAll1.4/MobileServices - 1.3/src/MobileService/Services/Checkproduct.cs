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
    #region Property

    [DataContract]
    [TableName("TBCUSTOMER")]
    public partial class Checkproduct
    {
        ///// <summary>
        ///// Gets the HandHeldCheckProduct identifier
        ///// </summary>
        //[DataMember]
        //[MapField("DOCNO"), PrimaryKey]
        //public string docno { get; set; }

        ///// <summary>
        ///// Gets or sets the LOCATION
        ///// </summary>
        //[DataMember]
        //[MapField("PRODUCTCODE")]
        //public string productCode { get; set; }

        ///// <summary>
        ///// Gets or sets the DOCDATE
        ///// </summary>
        //[DataMember]
        //[MapField("PRODUCTNAME")]
        //public DateTime? productName { get; set; }

        ///// <summary>
        ///// Gets or sets the USERID
        ///// </summary>
        //[DataMember]
        //[MapField("UNITNAME")]
        //public string unitname { get; set; }

        ///// <summary>
        ///// Gets or sets the OFFICERID
        ///// </summary>
        //[DataMember]
        //[MapField("DOCDATE")]
        //public string docdate { get; set; }

     //   [DataMember]
    //    [MapField("CUSTOMERID")]
    //    public string customerid { get; set; }

        [DataMember]
        [MapField("NAMETH")]
        public string customerName { get; set; } 

    }

    #endregion

    public partial interface IMobileService
    {
        [OperationContract]
        void AddCheckProduct(string productCode, string productName, string unitName);

        //[OperationContract]
        //string CheckCustomer(string customerid);
    }

    public partial class MobileService : IMobileService
    {

        public void AddCheckProduct(string productCode, string productName, string unitname)
        {
            using (DbManager db = new DbManager())
            {
                db.SetCommand(GetSql(100), db.Parameter("@productCode", productCode), db.Parameter("@productName", productName), db.Parameter("@unitname", unitname)).ExecuteScalar<decimal>();
            }
        }

        //public string CheckCustomer(string customerid)
        //{
        //    try
        //    {
        //        using (DbManager db = new DbManager())
        //        {
        //            return db.SetCommand(GetSql(101), db.Parameter("@customerid", customerid)).ExecuteScalar().ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //        return null;
        //    }

        //}
    }

}
