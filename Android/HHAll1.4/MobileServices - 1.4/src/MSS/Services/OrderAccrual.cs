using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Text;
using BLToolkit.Data;


namespace DoHome.MobileService
{
    [DataContract]
    public class OrderAccrual
    {
        /// <summary>
        /// Gets or sets the OrderNo
        /// </summary>
        [DataMember]
        [MapValue("OrderNo")]
        public string OrderNo { get; set; }

        /// <summary>
        /// Gets or sets the OrderDate
        /// </summary>
        [DataMember]
        [MapValue("OrderDate")]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the AppointDate
        /// </summary>
        [DataMember]
        [MapValue("AppointDate")]
        public DateTime? AppointDate { get; set; }

        /// <summary>
        /// Gets or sets the EmployeeNo
        /// </summary>
        [DataMember]
        [MapValue("EmployeeNo")]
        public string EmployeeNo { get; set; }

        
    }

    public partial interface IMobileService
    {
        [OperationContract]
        List<OrderAccrual> OrderAccrualGetByProductCode(string productCode, string branchCode);

        [OperationContract]
        void OrderAccrualAdd(string productCode, string productName, string unitcode, double quantity, string branchCode, string createdUserCode, string createdUserName);

    }


    public partial class MobileService : IMobileService
    {
        public List<OrderAccrual> OrderAccrualGetByProductCode(string productCode, string branchCode)
        {
            List<OrderAccrual> orderAccrual = new List<OrderAccrual>();
            try
            {
                using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {

                    using (SAPProxyII.UWProxy prx = new SAPProxyII.UWProxy())
                    {
                        prx.Connection = sapConnection;


                        var sapProductCode = SapProductCodeFormated(productCode);


                        //prepare Sale Profit
                        var stockUnit = GetProductStockUnit(branchCode, productCode);
                        var productPrice = GetProductPrice(productCode, stockUnit, branchCode);
                        decimal stockCost = 0;

                        SAPProxyII.EKETTable eket = new SAPProxyII.EKETTable();
                        SAPProxyII.EKKOTable ekko = new SAPProxyII.EKKOTable();
                        SAPProxyII.EKPOTable ekpo = new SAPProxyII.EKPOTable();
                        prx.Zdd_Export_Po_Not_Rec(sapProductCode, branchCode, out stockCost, ref eket, ref ekko, ref ekpo);

                        foreach (SAPProxyII.EKPO po in ekpo)
                        {
                            DateTime? appointDate = null;
                            DateTime? orderDate = null;

                            string sAppointDate = "", sPoDocNo = "", sPoDocDate = "", sUser = "";
                            //วันที่นัดรับ
                            foreach (SAPProxyII.EKET ek in eket)
                            {
                                if (ek.Ebeln == po.Ebeln && ek.Ebelp == po.Ebelp)
                                {
                                    // appointDate = DateTime.Parse(ek.Eindt, new System.Globalization.CultureInfo("en-US"));
                                    appointDate = DateTime.ParseExact(ek.Eindt, "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
                                    //sAppointDate = ek.Eindt.Substring(6, 2) + "/" + ek.Eindt.Substring(4, 2) + "/" + ek.Eindt.Substring(0, 4);
                                    //sAppointDate = Convert.ToDateTime(sAppointDate).ToString("dd/MM/yyyy");
                                }
                            }
                            //เลขที่ใบสั่งซื้อ - วันที่สั่งซื้อ
                            sPoDocNo = po.Ebeln;
                            orderDate = DateTime.ParseExact(po.Aedat, "yyyyMMdd", new System.Globalization.CultureInfo("en-US"));

                            //พนักงานจัดซื้อ
                            foreach (SAPProxyII.EKKO ko in ekko)
                            {
                                if (ko.Ebeln == po.Ebeln)
                                    sUser = ko.Ernam;
                            }

                            orderAccrual.Add(new OrderAccrual { OrderNo = sPoDocNo, OrderDate = orderDate, AppointDate = appointDate, EmployeeNo = sUser });
                            ////เช็คว่ามีใบสั่งซื้อเลขที่ๆเลือกไว้แล้วหรือยัง
                            //bool IsHased = false;
                            //foreach (ListViewItem olt in this.lvwPoNotRec.Items)
                            //{
                            //    SAPProxyII.EKKO opo = (SAPProxyII.EKKO)olt.Tag;
                            //    if (sPoDocNo == opo.Ebeln)
                            //    {
                            //        IsHased = true;
                            //        break;
                            //    }
                            //}
                            //if (!IsHased)
                            //{
                            //    ListViewItem item = new ListViewItem(sAppointDate);
                            //    item.SubItems.Add(sPoDocNo);
                            //    item.SubItems.Add(sPoDocDate);
                            //    item.SubItems.Add(sUser);
                            //    item.Tag = po;
                            //    this.lvwPoNotRec.Items.Add(item);
                            //}
                        }



                    }

                }
            }
            catch
            {
                orderAccrual = null;
            }

            return orderAccrual;
        }

        public void OrderAccrualAdd(string productCode, string productName, string unitCode, double quantity, string branchCode, string createdUserCode, string createdUserName)
        {
            var sql = new StringBuilder();
            sql.Append("INSERT INTO TBHANDHELD_PO ");
            sql.Append("(BranchCode,ProductCode,ProductName,UnitCode,Barcode,Quantity,CreateUserCode,CreateUserName) ");
            sql.Append("VALUES ");
            sql.Append("(@BranchCode,@ProductCode,@ProductName,@UnitCode,@Barcode,@Quantity,@CreateUserCode,@CreateUserName);");

            using (DbManager db = new DbManager(branchCode))
            {
                var barcode = BarcodeGetByProductCode(branchCode, productCode, unitCode);
                db.SetCommand(sql.ToString(),
                db.Parameter("@BranchCode", branchCode),
                db.Parameter("@ProductCode", productCode),
                db.Parameter("@ProductName", productName),
                db.Parameter("@UnitCode", unitCode),
                db.Parameter("@Barcode", barcode),
                db.Parameter("@Quantity", quantity),
                db.Parameter("@CreateUserCode", createdUserCode),
                db.Parameter("@CreateUserName", createdUserName))
                .ExecuteNonQuery();
            }
        }

    }

}