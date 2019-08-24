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
    ///<para>Function    : To create a business tier relating to table ForkLiftShippoint</para>
    ///<para>This object represents the properties of a ForkLiftShippoint, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    public partial class ForkLiftShippoint
    {                              

        /// <summary>
        /// Gets or sets the Identity.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the BranchCode
        /// </summary>
        [DataMember]
        public string BranchCode { get; set; }

        /// <summary>
        /// Gets or sets the ShippointCode
        /// </summary>
        [DataMember]
        public string ShippointCode { get; set; }

        /// <summary>
        /// Gets or sets the ShippointName
        /// </summary>
        [DataMember]
        public string ShippointName { get; set; }

    }

    #endregion


}

