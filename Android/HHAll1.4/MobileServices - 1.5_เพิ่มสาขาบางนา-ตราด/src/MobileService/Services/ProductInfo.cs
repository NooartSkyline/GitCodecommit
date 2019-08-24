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
using SAP.Middleware.Connector;

namespace DoHome.MobileService
{
    #region Property

    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public string Uom { get; set; }

        [DataMember]
        public string UomName { get; set; }

    }

    #endregion

    #region Interface

    public partial interface IMobileService
    {
        [OperationContract]
        ProductInfo ProductInfoGet(string branchCode, string productCode, string barcode);

        [OperationContract]
        ProductInfo ProductInfoGetByProductOrBarcode(string branchCode, string productCodeOrBarcode);

    }

    #endregion

    #region Service

    public partial class MobileService : IMobileService
    {
        public ProductInfo ProductInfoGet(string branchCode, string productCode, string uom)
        {
            ProductInfo productInfo = null;
            using (DbManager db = new DbManager(branchCode))
            {
                productInfo = db.SetCommand(GetSql(70),
                       db.Parameter("@Barcode", productCode))
                       .ExecuteObject<ProductInfo>();


                if (productInfo != null && productInfo.Uom != uom)
                {
                    if (!string.IsNullOrEmpty(uom))
                    {
                        productInfo = db.SetCommand(GetSql(65),
                          db.Parameter("@ProductCode", productCode),
                          db.Parameter("@Uom", uom))
                          .ExecuteObject<ProductInfo>();
                    }

                }

                if (productInfo == null)
                {
                    productInfo = db.SetCommand(GetSql(65),
                           db.Parameter("@ProductCode", productCode),
                           db.Parameter("@Uom", uom))
                           .ExecuteObject<ProductInfo>();
                }
                if (productInfo == null)
                {
                    productInfo = db.SetCommand(GetSql(66),
                           db.Parameter("@ProductCode", productCode),
                           db.Parameter("@Uom", uom))
                           .ExecuteObject<ProductInfo>();

                }

            }

            return productInfo;
        }

        public ProductInfo ProductInfoGetByProductOrBarcode(string branchCode, string productCodeOrBarcode)
        {
            return ProductInfoGet(branchCode, productCodeOrBarcode, null);
        }

        private double ProductInfoGetRealtimeStock(string branchCode, string warehouseCode, string productCode, string uom)
        {
            RfcDestination sapRfcDestination = SapHelper.Destination;
            RfcRepository sapRfcRepository = sapRfcDestination.Repository;

            RfcRepository repo = sapRfcRepository;
            string bapiName = "BAPI_MATERIAL_AVAILABILITY";
            IRfcFunction exportBapi = repo.CreateFunction(bapiName);

            exportBapi.SetValue("PLANT", "");
            exportBapi.SetValue("MATERIAL", "");
            exportBapi.SetValue("UNIT", "");
            exportBapi.SetValue("CHECK_RULE", "");
            exportBapi.SetValue("STGE_LOC", "");
            exportBapi.SetValue("BATCH", "");
            exportBapi.SetValue("CUSTOMER", "");
            exportBapi.SetValue("DOC_NUMBER", "");
            exportBapi.SetValue("ITM_NUMBER", "");
            exportBapi.SetValue("WBS_ELEM", "");
            exportBapi.SetValue("STOCK_IND", "");
            exportBapi.SetValue("DEC_FOR_ROUNDING", 0);
            exportBapi.SetValue("DEC_FOR_ROUNDING_X", "");
            exportBapi.SetValue("READ_ATP_LOCK", "");
            exportBapi.SetValue("READ_ATP_LOCK_X", "");

            IRfcStructure articol;
            RfcStructureMetadata am = repo.GetStructureMetadata("BAPIMGVMATNR");
            articol = am.CreateStructure();
            exportBapi.SetValue("MATERIAL_EVG", articol);

            exportBapi.SetValue("MATERIAL", FormatedProductCode(productCode));
            exportBapi.SetValue("PLANT", branchCode);
            exportBapi.SetValue("UNIT", uom);
            exportBapi.SetValue("STGE_LOC", warehouseCode);
            exportBapi.SetValue("CHECK_RULE", "B");
            exportBapi.SetValue("ITM_NUMBER", "000000");

            exportBapi.Invoke(sapRfcDestination);
            IRfcTable detail = exportBapi.GetTable("WMDVEX");


            return detail.RowCount;
        }

    }

    #endregion


}


