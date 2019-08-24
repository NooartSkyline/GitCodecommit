using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;
using SAP.Middleware.Connector;

namespace DoHome.MobileService
{
    #region Property

    ///<summary>
    ///<para>Date Created: 05/07/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBWAREHOUSE</para>
    ///<para>This object represents the properties of a Warehouse, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    //[TableName("TBWAREHOUSE")]
    public partial class ForkLift
    {
        /// <summary>
        /// Gets or sets the BranchCode
        /// </summary>
        [DataMember]
        //[MapField("BRANCHCODE")]
        public string BranchCode { get; set; }

        /// <summary>
        /// Gets or sets the WarehouseCode
        /// </summary>
        [DataMember]
        public string WarehouseCode { get; set; }

        /// <summary>
        /// Gets or sets the Driver
        /// </summary>
        [DataMember]
        [MapField("EmployeeCode")]
        public string DriverCode { get; set; }

        /// <summary>
        /// Gets or sets the Driver
        /// </summary>
        [DataMember]
        [MapField("EmployeeName")]
        public string DriverName { get; set; }

        /// <summary>
        /// Gets or sets the CarNumber
        /// </summary>
        [DataMember]
        public string ForkliftNumber { get; set; }

        /// <summary>
        /// Gets or sets the Is Selected
        /// </summary>
        [DataMember]
        [MapIgnore]
        public bool IsSelected { get; set; }
    }

    #endregion


}

