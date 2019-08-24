using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;

namespace DoHome.MobileService
{
    [DataContract]
    public class DisplayList
    {

        /// <summary>
        /// Gets or sets the DocDate
        /// </summary>
        [DataMember]
        [MapField("DocDate"), NonUpdatable]
        public string DocumentDate { get; set; }


        /// <summary>
        /// Gets or sets the DataQuantity
        /// </summary>
        [DataMember]
        [MapField("DataQuantity"), NonUpdatable]
        public string DataQuantity { get; set; }

    }

    public partial interface IMobileService
    {

        [OperationContract]
        List<DisplayList> ProductLocationGetDisplayList(string branchCode,string userCode);

        [OperationContract]
        List<DisplayList> DisplayListGetBySearchPrice(string branchCode, string userID);

        [OperationContract]
        List<DisplayList> DisplayListGetByCountStock(string branchCode, string createUser);

        [OperationContract]
        List<DisplayList> DisplayListGetByLocationCheck(string branchCode, string createUser);

    }


    public partial class MobileService : IMobileService
    {

        public List<DisplayList> ProductLocationGetDisplayList(string branchCode,string createUser)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(1),
                    db.Parameter("@CreateUser", createUser))
                    .ExecuteList<DisplayList>();
            }
        }

        public List<DisplayList> DisplayListGetBySearchPrice(string branchCode, string userID)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(12),
                    db.Parameter("@UserID", userID))
                    .ExecuteList<DisplayList>();
            }
        }

        public List<DisplayList> DisplayListGetByCountStock(string branchCode,string createUser)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand(GetSql(21),
                    db.Parameter("@CreateUser", createUser))
                    .ExecuteList<DisplayList>();
            }
        }

        public List<DisplayList> DisplayListGetByLocationCheck(string branchCode,string createUser)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db
                    .SetCommand(GetSql(35),
                    db.Parameter("@CreateUser", createUser))
                    .ExecuteList<DisplayList>();
            }
        }

    }

}