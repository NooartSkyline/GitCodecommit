using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using System;
using BLToolkit.Data;

namespace DoHome.MobileService
{
    [DataContract]
    [TableName("OrderedSet")]
    public class OrderedSet
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the order number
        /// </summary>
        [DataMember]
        public string OrderNo { get; set; }


        /// <summary>
        /// Gets or sets the Forklift number
        /// </summary>
        [DataMember]
        public string ForkliftNumber { get; set; }

        /// <summary>
        /// Gets or sets the Driver name
        /// </summary>
        [DataMember]
        public string DriverName { get; set; }

        /// <summary>
        /// Gets or sets the Start time
        /// </summary>
        [DataMember]
        public DateTime StartOn { get; set; }

        /// <summary>
        /// Gets or sets the Finish time
        /// </summary>
        [DataMember]
        public DateTime? FinishOn { get; set; }

        /// <summary>
        /// Gets or sets the Created by
        /// </summary>
        [DataMember]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Branch
        /// </summary>
        [DataMember]
        public string BranchCode { get; set; }

        /// <summary>
        /// Gets or sets the Shippoint
        /// </summary>
        [DataMember]
        public string ShippointCode { get; set; }
    }

    public partial interface IMobileService
    {
        [OperationContract]
        List<OrderedSet> OrderedSetGetAllByPresent(string branchCode, string warehouseCode, bool displayOnlyNotClose);

        [OperationContract]
        OrderedSet OrderedSetGetByOrderNo(string orderNo);

        [OperationContract]
        List<ForkLift> OrderedSetGetForkleftAll(string branchCode, string warehouseCode);

        [OperationContract]
        void OrderedSetAdd(OrderedSet order);

        [OperationContract]
        void OrderedSetUpdate(string orderNo);

        [OperationContract]
        void OrderedSetDelete(int id);

        [OperationContract]
        List<ForkLiftShippoint> OrderedSetGetForkLiftShippointByBranch(string branchCode);
    }


    public partial class MobileService : IMobileService
    {
        public List<OrderedSet> OrderedSetGetAllByPresent(string branchCode, string warehouseCode, bool displayOnlyNotClose)
        {
            using (var db = new DbManager("HandHeldDB"))
            {
                if (displayOnlyNotClose)
                {
                    return db.SetCommand(GetSql(96),
                        db.Parameter("@BranchCode", branchCode),
                        db.Parameter("@WarehouseCode", warehouseCode)).ExecuteList<OrderedSet>();
                }
                else
                {
                    return db.SetCommand(GetSql(95),
                           db.Parameter("@BranchCode", branchCode),
                           db.Parameter("@WarehouseCode", warehouseCode)).ExecuteList<OrderedSet>();
                }
            }
        }

        public OrderedSet OrderedSetGetByOrderNo(string orderNo)
        {
            using (var db = new DbManager("HandHeldDB"))
            {
                return db.SetCommand(GetSql(89), db.Parameter("@OrderNo", orderNo)).ExecuteObject<OrderedSet>();
            }
        }

        public void OrderedSetAdd(OrderedSet order)
        {
            using (var db = new DbManager("HandHeldDB"))
            {
                //if (order.FinishOn.HasValue)
                //{
                    //Add data from client PDA/HandHeld
                    db.SetCommand(GetSql(98),
                        db.Parameter("@OrderNo", order.OrderNo),
                        db.Parameter("@ForkliftNumber", order.ForkliftNumber),
                        db.Parameter("@DriverName", order.DriverName),
                        db.Parameter("@CreatedBy", order.CreatedBy),
                        db.Parameter("@StartOn", order.StartOn),
                        db.Parameter("@FinishOn", order.FinishOn),
                        db.Parameter("@BranchCode", order.BranchCode),
                        db.Parameter("@ShippointCode", order.ShippointCode)).ExecuteNonQuery();
                //}
                //else
                //{
                //    db.SetCommand(GetSql(90),
                //    db.Parameter("@OrderNo", order.OrderNo),
                //    db.Parameter("@ForkliftNumber", order.ForkliftNumber),
                //    db.Parameter("@DriverName", order.DriverName),
                //    db.Parameter("@CreatedBy", order.CreatedBy),
                //    db.Parameter("@BranchCode", order.BranchCode),
                //    db.Parameter("@ShippointCode", order.ShippointCode)).ExecuteNonQuery();
                //}
            }
        }

        public void OrderedSetUpdate(string orderNo)
        {
            using (var db = new DbManager("HandHeldDB"))
            {
                db.SetCommand(GetSql(91),
                db.Parameter("@OrderNo", orderNo)).ExecuteNonQuery();
            }
        }

        public void OrderedSetDelete(int id)
        {
            using (var db = new DbManager("HandHeldDB"))
            {
                db.SetCommand(GetSql(91),
                db.Parameter("@Id", id)).ExecuteNonQuery();
            }
        }

        public List<ForkLift> OrderedSetGetForkleftAll(string branchCode, string warehouseCode)
        {

            using (var db = new DbManager("HandHeldDB"))
            {
                return db.SetCommand(GetSql(93),
                 db.Parameter("@BranchCode", branchCode),
                 db.Parameter("@WarehouseCode", warehouseCode)).ExecuteList<ForkLift>();
            }
        }


        public List<ForkLiftShippoint> OrderedSetGetForkLiftShippointByBranch(string branchCode)
        {
            using (var db = new DbManager("HandHeldDB"))
            {
                var forklifts = db.SetCommand(GetSql(97),
                 db.Parameter("@BranchCode", branchCode)).ExecuteList<ForkLiftShippoint>();

                forklifts.Insert(0, new ForkLiftShippoint() { BranchCode = branchCode, ShippointCode = "0", ShippointName = "-- เลือก --" });
                return forklifts;
            }
        }



    }

}