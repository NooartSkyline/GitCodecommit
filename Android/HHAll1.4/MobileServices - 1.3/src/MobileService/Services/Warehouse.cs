using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;

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
    [TableName("TBWAREHOUSE")]
    public partial class Warehouse
    {
        /// <summary>
        /// Gets the Warehouse identifier
        /// </summary>
        [DataMember]
        [MapField("BRANCHCODE")]
        public string BranchCode { get; set; }
        /// <summary>
        /// Gets the Warehouse identifier
        /// </summary>
        [DataMember]
        [MapField("CODE")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the MYNAME
        /// </summary>
        [DataMember]
        [MapField("MYNAME")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the STATUS
        /// </summary>
        [DataMember]
        [MapField("STATUS")]
        public short Status { get; set; }

    }

    #endregion

    public partial interface IMobileService
    {


        [OperationContract]
        Warehouse WareHouseGetSingle(string warehouseCode, string branchCode);

        [OperationContract]
        List<Warehouse> WareHouseGetAllByBranch(string branchCode);

        [OperationContract]
        List<Warehouse> WareHouseGetAll(string branchCode);
    }


    public partial class MobileService : IMobileService
    {

        public List<Warehouse> WareHouseGetAllByBranch(string branchCode)
        {
            //List<Warehouse> warehouses;   
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand("SELECT * FROM TBWareHouse WHERE [Status] = 1 And BranchCode = @BranchCode;",
                    db.Parameter("@BranchCode", branchCode))
                    .ExecuteList<Warehouse>();
            }


            //foreach (var item in warehouses)
            //{
            //    if (item.Code == "1205")
            //        item.Name = "คลัง H";
            //    if (item.Code == "1305")
            //        item.Name = "คลัง H";
            //    if (item.Code == "1405")
            //        item.Name = "คลัง H";
            //}

            //return warehouses;
        }

        public Warehouse WareHouseGetSingle(string warehouseCode, string branchCode)
        {
            Warehouse warehouse = null;
            using (DbManager db = new DbManager(branchCode))
            {
                warehouse = db
                    .SetCommand(GetSql(5),
                        db.Parameter("@Code", warehouseCode),
                        db.Parameter("@BranchCode", branchCode))
                    .ExecuteObject<Warehouse>();
            }           
            return warehouse;
        }

        public List<Warehouse> WareHouseGetAll(string branchCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                SqlQuery<Warehouse> query = new SqlQuery<Warehouse>();

                return query.SelectAll(db);

            }
        }
    }
}

