using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System;

namespace DoHome.MobileService
{
    [DataContract]
    public class ProductSaleDetail
    {
        /// <summary>
        /// Gets or sets the SaleRate
        /// </summary>
        [DataMember]
        [MapValue("SaleRate")]
        public decimal SaleRate { get; set; }

        /// <summary>
        /// Gets or sets the SaleQuantity
        /// </summary>
        [DataMember]
        [MapValue("SaleQuantity")]
        public decimal SaleQuantity { get; set; }

        /// <summary>
        /// Gets or sets the SaleProductType
        /// </summary>
        [DataMember]
        [MapValue("SaleProductType")]
        public string SaleProductType { get; set; }

        /// <summary>
        /// Gets or sets the SaleProfit
        /// </summary>
        [DataMember]
        [MapValue("SaleProfit")]
        public string SaleProfit { get; set; }

        /// <summary>
        /// Gets or sets the SalePerDay
        /// </summary>
        [DataMember]
        [MapValue("SalePerDay")]
        public decimal SalePerDay { get; set; }

        /// <summary>
        /// Gets or sets the ProductCode
        /// </summary>
        [DataMember]
        [MapValue("ProductCode")]
        public string ProductCode { get; set; }

    }

    public partial interface IMobileService
    {
        [OperationContract]
        ProductSaleDetail ProductSaleDetailGetByProductCode(string productCode, string branchCode, bool isShowProfit);
    }


    public partial class MobileService : IMobileService
    {

        public ProductSaleDetail ProductSaleDetailGetByProductCode(string productCode, string branchCode, bool isShowProfit)
        {
            //log.Debug("ProductSaleDetailGetByProductCode start " + DateTime.Now);

            ProductSaleDetail productSaleDetail;
            try
            {
                using (SAP.Connector.SAPConnection sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {

                    using (SAPProxyII.UWProxy prx = new SAPProxyII.UWProxy())
                    {
                        prx.Connection = sapConnection;

                        string saleProductType = string.Empty;
                        decimal salePerDay = 0;
                        decimal saleAmount = 0;
                        decimal saleBackOffice = 0;
                        decimal SalePos = 0;
                        decimal saleQuantity = 0;
                        decimal saleRate = 0;

                        var sapProductCode = SapProductCodeFormated(productCode);
                        prx.Zdd_Export_Pos_Saleinfo(sapProductCode,
                            branchCode,
                            out saleProductType,
                            out salePerDay,
                            out saleAmount,
                            out saleBackOffice,
                            out SalePos,
                            out saleQuantity,
                            out saleRate);

                        productSaleDetail = new ProductSaleDetail();
                        productSaleDetail.SaleProductType = saleProductType;
                        productSaleDetail.SalePerDay = salePerDay;
                        //productSaleDetail.SaleProfit
                        productSaleDetail.SaleQuantity = saleQuantity;
                        productSaleDetail.SaleRate = saleRate;

                        if (isShowProfit)
                        {
                            //prepare Sale Profit
                            var stockUnit = GetProductStockUnit(branchCode, productCode);
                            var productPrice = GetProductPrice(productCode, stockUnit, branchCode);
                            decimal stockCost = 0;
                            decimal profit = 0;

                            SAPProxyII.EKETTable eket = new SAPProxyII.EKETTable();
                            SAPProxyII.EKKOTable ekko = new SAPProxyII.EKKOTable();
                            SAPProxyII.EKPOTable ekpo = new SAPProxyII.EKPOTable();
                            prx.Zdd_Export_Po_Not_Rec(sapProductCode, branchCode, out stockCost, ref eket, ref ekko, ref ekpo);
                            eket = null;
                            ekko = null;
                            ekpo = null;

                            //คำนวนกำไรที่ได้ของหน่วยย่อยสุด
                            if (productPrice != 0)
                                profit = 100 * (productPrice - stockCost) / productPrice;

                            if (profit >= 10)
                                productSaleDetail.SaleProfit = "++";
                            else if (profit < 0)
                                productSaleDetail.SaleProfit = "-";
                            else
                                productSaleDetail.SaleProfit = "+";
                        }
                        else
                            productSaleDetail.SaleProfit = "*******";

                    }

                }
            }
            catch
            {
                productSaleDetail = null;
            }

            //log.Debug("ProductSaleDetailGetByProductCode end " + DateTime.Now);

            return productSaleDetail;
        }

    }

}