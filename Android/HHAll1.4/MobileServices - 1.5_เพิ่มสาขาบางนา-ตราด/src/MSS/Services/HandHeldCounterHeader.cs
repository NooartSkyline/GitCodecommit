using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;
using System;

namespace DoHome.MobileService
{
    ///<summary>
    ///<para>Date Created: 29/07/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBHANDHELDCOUNTER_HEADER</para>
    ///<para>This object represents the properties of a HandHeldCounterHeader, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("TBHANDHELDCOUNTER_HEADER")]
    public partial class HandHeldCounterHeader
    {
        /// <summary>
        /// Gets the HandHeldCounterHeader identifier
        /// </summary>
        [DataMember]
        [MapField("DOCNO"), PrimaryKey]
        public string Docno { get; set; }
        /// <summary>
        /// Gets the HandHeldCounterHeader identifier
        /// </summary>
        [DataMember]
        [MapField("PRODUCTCODE"), PrimaryKey]
        public string Productcode { get; set; }

        /// <summary>
        /// Gets or sets the DOCDATE
        /// </summary>
        [DataMember]
        [MapField("DOCDATE")]
        public DateTime? Docdate { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCTNAME
        /// </summary>
        [DataMember]
        [MapField("PRODUCTNAME")]
        public string Productname { get; set; }

        /// <summary>
        /// Gets or sets the WAREHOUSE
        /// </summary>
        [DataMember]
        [MapField("WAREHOUSE")]
        public string Warehouse { get; set; }

        /// <summary>
        /// Gets or sets the BRANCHCODE
        /// </summary>
        [DataMember]
        [MapField("BRANCHCODE")]
        public string Branchcode { get; set; }

        /// <summary>
        /// Gets or sets the COUNTQTY
        /// </summary>
        [DataMember]
        [MapField("COUNTQTY")]
        public decimal Countqty { get; set; }

        /// <summary>
        /// Gets or sets the BALANCEQTY
        /// </summary>
        [DataMember]
        [MapField("BALANCEQTY")]
        public decimal Balanceqty { get; set; }

    }

    public partial interface IMobileService
    {



    }


    public partial class MobileService : IMobileService
    {

        //public List<DisplayList> ProductLocationGetDisplayList(string createUser)
        //{
        //    using (DbManager db = new DbManager())
        //    {
        //        return db
        //            .SetCommand(GetSql(1),
        //            db.Parameter("@CreateUser", createUser))
        //            .ExecuteList<DisplayList>();
        //    }
        //}

    }

}