using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;
using System.Text;
using DoHome.MobileService.Services;
using EnDeCode;

namespace DoHome.MobileService
{
    #region Property

    [DataContract]
    [TableName("ProductInLocation")]
    public class ProductInLocation
    {
        [DataMember]
        [PrimaryKey, NonUpdatable]
        public int Id { get; set; }

        [DataMember]
        [MapField("ProductCode")]
        public string ProductCode { get; set; }

        [DataMember]
        [MapField("Uom")]
        public string Uom { get; set; }

        [DataMember]
        public string UomName { get; set; }

        [DataMember]
        [MapField("LocationCode")]
        public string LocationCode { get; set; }

        [DataMember]
        [MapField("WarehouseCode")]
        public string WarehouseCode { get; set; }

        [DataMember]
        [MapField("MaxStock")]
        public string MaxStock { get; set; }

        [DataMember]
        [MapField("PutLevel")]
        public string PutLevel { get; set; }

        [DataMember]
        [MapField("PutQuantity")]
        public string PutQuantity { get; set; }

        [DataMember]
        [MapField("DisplayOrder")]
        public string DisplayOrder { get; set; }

        [DataMember]
        [MapField("UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }

        [DataMember]
        [MapIgnore]
        public double StockQuantity { get; set; }

    }

    #endregion

    #region Interface

    public partial interface IMobileService
    {
        [OperationContract]
        List<ProductInLocation> ProductInLocationGetByProductCode(string branchCode, string productCode, string warehouseCode);

        [OperationContract]
        string ProductInLocationGetWarehouseCode(string locationCode);

    }

    #endregion

    #region Service

    public partial class MobileService : IMobileService
    {
        private void ProductInLocationUpdate(List<ProductInLocation> productInLocation)
        {
            if (productInLocation == null || productInLocation.Count <= 0)
                return;

            using (DbManager db = new DbManager("HandHeldDB"))
            {
                db.BeginTransaction();

                db.SetCommand(GetSql(63),
                db.Parameter("@LocationCode", productInLocation[0].LocationCode),
                db.Parameter("@WarehouseCode", productInLocation[0].WarehouseCode))
                .ExecuteNonQuery();

                db.SetCommand(GetSql(64)).ExecuteForEach<ProductInLocation>(productInLocation);

                db.CommitTransaction();
            }
        }

        private List<ProductInLocation> ProductInLocationGet(string locationCode, string warehouseCode)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db.SetCommand(GetSql(62),
                       db.Parameter("@LocationCode", locationCode),
                       db.Parameter("@WarehouseCode", warehouseCode))
                       .ExecuteList<ProductInLocation>();
            }
        }

        private List<ProductInLocation> ProductInLocationGet(string locationCode, string warehouseCode, string productCode)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db.SetCommand(GetSql(68),
                       db.Parameter("@LocationCode", locationCode),
                       db.Parameter("@WarehouseCode", warehouseCode),
                       db.Parameter("@ProductCode", productCode))
                       .ExecuteList<ProductInLocation>();
            }
        }

        private List<ProductInLocation> ProductInLocationGet(string locationCode, string warehouseCode, string productCode, string uom)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db.SetCommand(GetSql(69),
                       db.Parameter("@LocationCode", locationCode),
                       db.Parameter("@WarehouseCode", warehouseCode),
                       db.Parameter("@ProductCode", productCode),
                       db.Parameter("@Uom", uom))
                       .ExecuteList<ProductInLocation>();
            }
        }

        private void ProductInLocationDelete(string locationCode, string warehouseCode)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                db.SetCommand(GetSql(71),
                db.Parameter("@LocationCode", locationCode),
                db.Parameter("@WarehouseCode", warehouseCode))
                .ExecuteNonQuery();
            }
        }

        public List<ProductInLocation> ProductInLocationGetByProductCode(string branchCode, string productCode, string warehouseCode)
        {
            List<ProductInLocation> locations;
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                locations = db.SetCommand(GetSql(72),
                db.Parameter("@ProductCode", productCode),
                db.Parameter("@WarehouseCode", warehouseCode))
                .ExecuteList<ProductInLocation>();
            }

            if (locations != null)
            {
                foreach (var item in locations)
                {
                    item.StockQuantity = SAPGetBalanceQuantity(productCode, warehouseCode, item.Uom, branchCode);
                }

            }
            //string location = string.Empty;
            //foreach (var item in locations)
            //    location += item.LocationCode + ",";
            //if (!string.IsNullOrEmpty(location))
            //    location.Substring(0, location.Length - 1);

            return locations;
        }

        public string ProductInLocationGetWarehouseCode(string locationCode)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db.SetCommand(GetSql(75),
                db.Parameter("@LocationCode", locationCode))
                .ExecuteScalar<string>();
            }

        }

    }

    #endregion


}


