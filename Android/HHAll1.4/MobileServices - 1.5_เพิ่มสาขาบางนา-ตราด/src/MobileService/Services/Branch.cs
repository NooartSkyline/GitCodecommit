using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using System;

namespace DoHome.MobileService
{
    [DataContract]
    public class Branch
    {

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        [DataMember]
        [MapValue("Code")]
        public string Code { get; set; }


        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [DataMember]
        [MapValue("Name")]
        public string Name { get; set; }

    }

    public partial interface IMobileService
    {
        [OperationContract]
        List<Branch> BranchGetAll();
    }


    public partial class MobileService : IMobileService
    {
        public List<Branch> BranchGetAll()
        {
            var branchs = new List<Branch>();
            branchs.Add(new Branch { Code = "1100", Name = "สาขาอุบลราชธานี" });
            branchs.Add(new Branch { Code = "1200", Name = "สาขาโคราช" });
            branchs.Add(new Branch { Code = "1300", Name = "สาขารังสิต คลอง 7" });
            branchs.Add(new Branch { Code = "1400", Name = "สาขาขอนแก่น" });
			branchs.Add(new Branch { Code = "1500", Name = "สาขาอุดรธานี" });
            branchs.Add(new Branch { Code = "1700", Name = "สาขาพระราม 2" });
            branchs.Add(new Branch { Code = "M030", Name = "สาขาบางบัวทอง" });
            branchs.Add(new Branch { Code = "N010", Name = "สาขาเชียงใหม่" });
            branchs.Add(new Branch { Code = "E010", Name = "สาขาบางนา-ตราด" });
            return branchs;
        }
    }

}