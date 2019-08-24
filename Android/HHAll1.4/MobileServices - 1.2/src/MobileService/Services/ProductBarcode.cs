using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;
using System.Text;
using System;
using System.Data;
using System.Linq;

namespace DoHome.MobileService
{

    public class  UnitBarcode 
    {
        public string UnitCode { get; set; }
        public string BarCode { get; set; }
    }
    [DataContract]
    [TableName("TBBARCODE")]
    public partial class ProductBarcode
    {
        /// <summary>
        /// Gets the Barcode identifier
        /// </summary>
        [DataMember]
        [MapField("BARCODE")]
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCTCODE
        /// </summary>
        [DataMember]
        [MapField("PRODUCTCODE")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the UNITCODE
        /// </summary>
        [DataMember]
        [MapField("UNITCODE")]
        public string UnitCode { get; set; }

        /// <summary>
        /// Gets or sets the STATUS
        /// </summary>
        [DataMember]
        [MapField("STATUS")]
        public short Status { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        [DataMember]
        [MapValue("ProductName")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the UnitName
        /// </summary>
        [DataMember]
        [MapValue("UnitName")]
        public string UnitName { get; set; }

        /// <summary>
        /// Gets or sets the UnitRate
        /// </summary>
        [DataMember]
        [MapValue("UnitRate")]
        public decimal UnitRate { get; set; }

        /// <summary>
        /// Gets or sets the StockQuantity
        /// </summary>
        [DataMember]
        [MapValue("StockQuantity")]
        public double StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the ProductPrice
        /// </summary>
        [DataMember]
        [MapValue("ProductPrice")]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the ProductPriceText
        /// </summary>
        [DataMember]
        public string ProductPriceText { get; set; }

        /// <summary>
        /// Gets or sets the StoreLocation
        /// </summary>
        [DataMember]
        [MapValue("StoreLocation")]
        public string StoreLocation { get; set; }

        [DataMember]
        [MapIgnore]
        public decimal Quantity { get; set; }

        [DataMember]
        [MapIgnore]
        public decimal BinCode { get; set; } // ตำแหน่ง

        [DataMember]
        [MapIgnore]
        public string LOGGR { get; set; }

        [DataMember]
        [MapIgnore]
        public string PositionCode { get; set; } // ตำแหน่งปริ้นป้าย Much
        
    }

    [DataContract]
    public partial class ProductPosition 
    {
        [DataMember]
        public string PositionCode { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public string UnitCode { get; set; }

    }    
    public partial interface IMobileService
    {
        [OperationContract]
        List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode1(string productCodeOrBarcode, string warehouseCode, string branchCode, bool isShowPrice);

        [OperationContract]
        List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode2(string productCodeOrBarcode, string branchCode);

        [OperationContract]
        ProductBarcode ProductBarcodeGetByProductCodeOrBarcode3(string branchCode, string productCodeOrBarcode);

        [OperationContract]
        List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode4(string branchCode, string productCodeOrBarcode);

        [OperationContract]
        ProductBarcode ProductBarcodeGetByProductCode(string branchCode, string productCode, string unitCode);

        [OperationContract]
        ProductBarcode ProductByProductCode(string branchCode, string productCode);

        [OperationContract]
        string BarcodeGetByProductCode(string branchCode, string productCode, string unitCode);

        [OperationContract]
        ProductBarcode ProductBarcodeGetByBarcode(string barcode, string branchCode);

        [OperationContract]
        List<ProductPosition> GetProductPosition(string sProductCode, string sWarehouse);

        [OperationContract]
        List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode5(string branchCode, string productCodeOrBarcode, string warehouseCode);

    }


    public partial class MobileService : IMobileService
    {
        public ProductBarcode ProductBarcodeGetByProductCode(string branchCode, string productCode, string unitCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                   .SetCommand("SELECT * FROM TBBarcode WHERE ProductCode = @ProductCode AND UnitCode = @ProductUnitCode",
                       db.Parameter("@ProductCode", productCode),
                        db.Parameter("@ProductUnitCode", unitCode))
                   .ExecuteObject<ProductBarcode>();
            }
        }

        public ProductBarcode ProductByProductCode(string branchCode, string productCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                var sql = @"    
                        SELECT  Code ProductCode,ISNULL(Barcode,'') Barcode,ISNULL(UnitCode,StockUnit) UnitCode,
                        (SELECT TOP 1 MyName FROM TBUnit WHERE Code = ISNULL(UnitCode,StockUnit)) UnitName,NameTh ProductName
                        FROM    TBProduct p LEFT JOIN TBBarcode b
		                        ON p.Code = b.ProductCode
                        WHERE	p.Code =@ProductCode AND b.[Status] = 1 AND p.[Status] = 1 AND Barcode NOT LIKE '0%'";
                return db
                   .SetCommand(sql,
                       db.Parameter("@ProductCode", productCode))
                   .ExecuteObject<ProductBarcode>();
            }
        }

        public string BarcodeGetByProductCode(string branchCode, string productCode, string unitCode)
        {
            var product = ProductInfoGet(branchCode, productCode, unitCode);
            if (productCode != null)
                return product.Barcode;
            else
                return string.Empty;
            //using (DbManager db = new DbManager(branchCode))
            //{
            //    return db
            //       .SetCommand("SELECT Barcode FROM TBBarcode WHERE ProductCode = @ProductCode AND UnitCode = @ProductUnitCode",
            //           db.Parameter("@ProductCode", productCode),
            //            db.Parameter("@ProductUnitCode", unitCode))
            //       .ExecuteScalar<string>();
            //}
        }

        public List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode1(string productCodeOrBarcode, string warehouseCode, string branchCode, bool isShowPrice)
        {

            List<ProductBarcode> productBarcode = null;
            try
            {
                using (DbManager db = new DbManager(branchCode))
                {
                    productBarcode = new List<ProductBarcode>();

                    productBarcode = db.SetCommand(GetSql(61),
                                  db.Parameter("@ProductCode", productCodeOrBarcode))
                                  .ExecuteList<ProductBarcode>();
                    //if (productBarcode == null || productBarcode.Count == 0)
                    //{
                    //    productBarcode = db.SetCommand(GetSql(59),
                    //                     db.Parameter("@ProductCode", productCodeOrBarcode))
                    //                     .ExecuteList<ProductBarcode>();
                    //}

                    if (productBarcode != null)
                    {
                        foreach (var item in productBarcode)
                        {
                            if (isShowPrice)
                            {
                               item.ProductPrice = GetProductPrice(item.ProductCode, item.UnitCode, branchCode);
                               item.ProductPriceText = item.ProductPrice.ToString("N2");
                               item.StockQuantity = SAPGetBalanceQuantity(item.ProductCode, warehouseCode, item.UnitCode, branchCode);

                            }
                            else
                            {
                                item.ProductPriceText = "*******";
                                item.StockQuantity = 999999;
                               
                            }

                          
                             item.StoreLocation = SAPGetLocation(item.ProductCode, item.UnitCode, warehouseCode, branchCode);
                            //item.StoreLocation = ProductInLocationGetByProductCode(item.ProductCode, warehouseCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return productBarcode;
        }

        public List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode2(string productCodeOrBarcode, string branchCode)
        {

            using (DbManager db = new DbManager(branchCode))
            {
                var productBarcode = new List<ProductBarcode>();
                StringBuilder sql = new StringBuilder();
                //sql.Append("IF(EXISTS(SELECT Barcode FROM TBBarcode WHERE Barcode = @ProductCode)) ");
                //sql.Append("BEGIN SELECT @ProductCode = ProductCode FROM TBBarcode WHERE Barcode = @ProductCode END ");
                //sql.Append("SELECT  b.ProductCode ");
                //sql.Append(",(SELECT NameTh FROM TBProduct WHERE Code = b.ProductCode) ProductName ");
                //sql.Append(",b.Barcode ");
                //sql.Append(",pu.UnitCode ");
                //sql.Append(",(SELECT MyName FROM TBUnit WHERE Code = b.UnitCode) UnitName ");
                //sql.Append(",pu.UnitRate ");
                //sql.Append("FROM    TBBarcode b INNER JOIN TBProductUnit pu ");
                //sql.Append("ON b.ProductCode = pu.ProductCode ");
                //sql.Append("AND b.UnitCode = pu.UnitCode ");
                //sql.Append("WHERE	b.ProductCode = @ProductCode ");
                //sql.Append("AND b.[Status] = 1 ");

                sql.Append("IF(EXISTS(SELECT Barcode FROM TBBarcode WHERE Barcode = @ProductCode)) ");
                sql.Append("BEGIN ");
                sql.Append("SELECT  b.ProductCode ");
                sql.Append(",(SELECT NameTh FROM TBProduct WHERE Code = b.ProductCode) ProductName ");
                sql.Append(",b.Barcode ");
                sql.Append(",pu.UnitCode ");
                sql.Append(",(SELECT MyName FROM TBUnit WHERE Code = b.UnitCode) UnitName ");
                sql.Append(",pu.UnitRate ");
                sql.Append("FROM    TBBarcode b INNER JOIN TBProductUnit pu ");
                sql.Append("ON b.ProductCode = pu.ProductCode ");
                sql.Append("AND b.UnitCode = pu.UnitCode ");
                sql.Append("WHERE	b.Barcode = @ProductCode ");
                sql.Append("AND b.[Status] = 1 ");
                sql.Append("END ");
                sql.Append("ELSE ");
                sql.Append("BEGIN ");
                sql.Append("SELECT  b.ProductCode ");
                sql.Append(",(SELECT NameTh FROM TBProduct WHERE Code = b.ProductCode) ProductName ");
                sql.Append(",b.Barcode ");
                sql.Append(",pu.UnitCode ");
                sql.Append(",(SELECT MyName FROM TBUnit WHERE Code = b.UnitCode) UnitName ");
                sql.Append(",pu.UnitRate ");
                sql.Append("FROM    TBBarcode b INNER JOIN TBProductUnit pu ");
                sql.Append("ON b.ProductCode = pu.ProductCode ");
                sql.Append("AND b.UnitCode = pu.UnitCode ");
                sql.Append("WHERE	b.ProductCode = @ProductCode ");
                sql.Append("AND b.[Status] = 1 ");
                sql.Append("END ");


                productBarcode = db
                    .SetCommand(sql.ToString(),
                        db.Parameter("@ProductCode", productCodeOrBarcode))
                    .ExecuteList<ProductBarcode>();

                if (productBarcode == null || productBarcode.Count == 0)
                {
                    productBarcode = db.SetCommand(GetSql(59),
                                     db.Parameter("@ProductCode", productCodeOrBarcode))
                                     .ExecuteList<ProductBarcode>();
                }

                if (productBarcode != null)
                {
                    foreach (var item in productBarcode)
                    {
                        item.ProductPrice = GetProductPrice(item.ProductCode, item.UnitCode, branchCode);
                        item.ProductPriceText = item.ProductPrice.ToString("N2");
                    }
                }

                return productBarcode;
            }

        }

        public ProductBarcode ProductBarcodeGetByProductCodeOrBarcode3(string branchCode, string productCodeOrBarcode)
        {
            using (DbManager db = new DbManager(branchCode))
            {

                var product = db
                     .SetCommand(GetSql(27),
                         db.Parameter("@ProductCode", productCodeOrBarcode))
                     .ExecuteObject<ProductBarcode>();

                if (product != null)
                {
                    var price = ProductPriceGetCurrentPrice(branchCode, product.ProductCode, product.UnitCode);
                    if (price != null)
                    {
                        product.ProductPrice = price.Saleprice;
                        product.ProductPriceText = price.Saleprice.ToString("N2");
                    }
                }
                return product;
            }
        }

        public List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode4(string branchCode, string productCodeOrBarcode)
        {
            var product = new List<ProductBarcode>();
            
            using (DbManager db = new DbManager(branchCode))
            {
                product = db
                     .SetCommand(GetSql(99),
                         db.Parameter("@Barcode", productCodeOrBarcode))
                     .ExecuteList<ProductBarcode>();

                if (product != null)
                {
                    foreach (var item in product)
                    {
                        var price = ProductPriceGetCurrentPrice(branchCode, item.ProductCode, item.UnitCode);
                        if (price != null)
                        {
                            item.ProductPrice = price.Saleprice;
                            item.ProductPriceText = price.Saleprice.ToString("N2"); 
                        }                        
                    }
                }
                return product;
            }
        }

        public string GetProductBarcodeByProductCode(string branchCode, string productCode, string unitCode)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db
                    .SetCommand("SELECT Barcode FROM TBBarcode WHERE status = 1 and barcode not like '0%' and ProductCode = @ProductCode AND UnitCode = @UnitCode;",
                    db.Parameter("@ProductCode", productCode),
                    db.Parameter("@UnitCode", unitCode))
                    .ExecuteScalar<string>();
            }
        }

        public ProductBarcode ProductBarcodeGetByBarcode(string barcode, string branchCode)
        {
            ProductBarcode productBarcode = null;
            using (DbManager db = new DbManager(branchCode))
            {
                productBarcode = db
                    .SetCommand(GetSql(4),
                        db.Parameter("@Barcode", barcode))
                    .ExecuteObject<ProductBarcode>();

                if (productBarcode != null)
                {
                    productBarcode.ProductPrice = GetProductPrice(productBarcode.ProductCode, productBarcode.UnitCode, branchCode);
                    productBarcode.ProductPriceText = productBarcode.ProductPrice.ToString("N2");
                }
            }

            return productBarcode;
        }

        private string GetProductCodeByCodeOrBarcode(string branchCode, string productCodeOrBarcode)
        {
            using (DbManager db = new DbManager(branchCode))
            {

                return db.SetCommand(GetSql(54),
                       db.Parameter("@ProductOrBarcode", productCodeOrBarcode))
                       .ExecuteScalar<string>();
            }
        }
       
        public List<ProductBarcode> ProductBarcodeGetByProductCodeOrBarcode5(string branchCode, string productCodeOrBarcode,string warehouseCode)
        {
            var product = new List<ProductBarcode>();
            var tmpproduct = new List<ProductBarcode>();
            using (DbManager db = new DbManager(branchCode))
            {
                product = db
                     .SetCommand(GetSql(104),
                         db.Parameter("@Barcode", productCodeOrBarcode),
                         db.Parameter("@Branchcode", branchCode),
                         db.Parameter("@Warehousecode", warehouseCode)
                         )
                     .ExecuteList<ProductBarcode>();

                if (product != null)
                {

                    var Result = product.Where(x => x.Barcode == productCodeOrBarcode && x.ProductCode != productCodeOrBarcode).Take(1).ToList();
                    if (Result.Count>0)
                    {
                        product = product.Where(x => x.UnitCode != Result.First().UnitCode).ToList();
                        product.Add(Result.First());
                    }
                    
                    //List<UnitBarcode> barcode = new List<UnitBarcode>();
                    //var results = (product.GroupBy(p => p.UnitCode, (key, g) => new { Unit = key, Products = g.ToList() })).ToList();
                    //foreach (var item in results)
                    //{
                    //    if (item.Products.Count>1)
                    //    {
                    //        foreach (var itemin in item.Products)
                    //        {
                    //            if (itemin.Barcode == productCodeOrBarcode)
                    //            {
                    //                barcode.Add(new UnitBarcode { BarCode = itemin.Barcode, UnitCode = itemin.UnitCode });
                    //            }
                    //        }
                    //        if (barcode.Count> 1)
                    //        {
                    //            //product = from o in product where o.Barcode != productCodeOrBarcode  select o;
                    //        } 
                    //    }
                    //}
                    //tmpproduct.Clear();
                    SAPProxyII.UWProxy prx = new SAPProxyII.UWProxy();
                    SAP.Connector.SAPConnection cnnSAP = new SAP.Connector.SAPConnection(GlobalContext.SapDestination);
                    cnnSAP.Open();
                    prx.Connection = cnnSAP;
                    SAPProxyII.MARCTable marcs = new SAPProxyII.MARCTable();
                    SAPProxyII.TLOGTTable tlogts = new SAPProxyII.TLOGTTable();
                    SAPProxyII.WERKS werks = new SAPProxyII.WERKS();
                    werks.Werks = branchCode;
                    foreach (var item in product)
                    {
                        var price = ProductPriceGetCurrentPrice(branchCode, item.ProductCode, item.UnitCode);
                        if (price != null)
                        {
                            item.ProductPrice = price.Saleprice;
                            item.ProductPriceText = price.Saleprice.ToString("N2");
                        }
                        var Li = product.Where(x => x.ProductCode == item.ProductCode && x.LOGGR != null).ToList();
                        if (Li.Count == 0)
                        {
                            try
                            {

                                prx.Zdd_Export_Pos_Marc(AddZero(item.ProductCode,18), werks, ref marcs, ref tlogts);
                                foreach (SAPProxyII.TLOGT itemin in tlogts)
                                {
                                    item.LOGGR = itemin.Loggr + "-" + itemin.Ltext;
                                    break;
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            item.LOGGR = Li.First().LOGGR;
                        }
                        try
                        {
                           var Position = GetProductPosition(item.ProductCode, warehouseCode, item.UnitCode);
                           var i = 0;
                           foreach (var items in Position)
                           {
                               if (i == 0)
                               {
                                   item.PositionCode = items.PositionCode;
                               }
                               else
                               {
                                   var TmpItem = new ProductBarcode()
                                   {
                                       Barcode =   item.Barcode ,
                                       BinCode = item.BinCode,
                                       LOGGR = item.LOGGR,
                                       PositionCode = item.PositionCode,
                                       ProductCode = item.ProductCode,
                                       ProductName = item.ProductName,
                                       ProductPrice = item.ProductPrice,
                                       ProductPriceText = item.ProductPriceText,
                                       Quantity = item.Quantity,
                                       Status = item.Status,
                                       StockQuantity = item.StockQuantity,
                                       StoreLocation = item.StoreLocation,
                                       UnitCode = item.UnitCode,
                                       UnitName = item.UnitName,
                                       UnitRate = item.UnitRate
                                   };
                                   TmpItem.PositionCode = items.PositionCode;
                                   tmpproduct.Add(TmpItem);
                               }
                               i += 1;
                           }
                            //if (Position != null) 
                           //{
                           //    item.PositionCode = Position.PositionCode;
                           //}
                        }
                        catch (Exception)
                        {
                            
                           
                        }
                    }
                }
                foreach (var item in tmpproduct)
                {
                    product.Add(item);
                }
                return product;
            }
        }
        private string AddZero(string source, int iLen)
        {
            bool ret = this.IsNumeric(source);
            if (ret)
            {
                string sZero = "";
                for (int i = source.Length; i <= iLen - 1; i++)
                    sZero += "0";
                source = sZero + source;
            }
            return source;
        }
        public List<ProductPosition> GetProductPosition(string sProductCode, string sWarehouse)
        {
            var ProdReturn = new List<ProductPosition>();
            try
            {
                using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (var prx = new SAPProxyIII.UWProxy())
                    {
                        prx.Connection = sapConnection;
                        SAPProxyIII.ZMM_ASSIGNLOCTable tables = new SAPProxyIII.ZMM_ASSIGNLOCTable();
                        prx.Zdd_Handheld_Get_Zmm_Assignloc("", sWarehouse, sProductCode, ref tables);
                        DataTable dt = tables.ToADODataTable();
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item["LOCTYPE"].ToString().ToUpper() != "T")
                            ProdReturn.Add(new ProductPosition { PositionCode = item["BIN_CODE"].ToString(), ProductCode = item["MATERIAL"].ToString(), UnitCode = item["UNITOFMEASURE"].ToString() });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return ProdReturn;
        }
        public List<ProductPosition> GetProductPosition(string sProductCode, string sWarehouse,string sUnitCode)
        {
            List<ProductPosition> ProdReturn = new  List<ProductPosition>();
            try
            {
                using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (var prx = new SAPProxyAssignloc.SAPProxyAssignloc())
                    {
                        prx.Connection = sapConnection;
                        SAPProxyAssignloc.ZMM_ASSIGNLOCTable tables = new SAPProxyAssignloc.ZMM_ASSIGNLOCTable();
                        prx.Zhh_Get_Bin_Assignloc("",sWarehouse,sProductCode,ref tables);
                        DataTable dt = tables.ToADODataTable();
                        DataRow[] drNormal = dt.Select("Storage_Loc='" + sWarehouse + "' and unitofmeasure = '" + sUnitCode + "' ");
                        foreach (DataRow item in drNormal)
                        {
                            if (item["LOCTYPE"].ToString().ToUpper() != "T") 
                            {
                                var Idd = new ProductPosition();
                                Idd.PositionCode = item["BIN_CODE"].ToString();
                                Idd.ProductCode = item["MATERIAL"].ToString();
                                Idd.UnitCode = item["UNITOFMEASURE"].ToString();
                                ProdReturn.Add(Idd);
                            }
                               // ProdReturn.Add(new ProductPosition { PositionCode = item["BIN_CODE"].ToString(), ProductCode = item["MATERIAL"].ToString(), UnitCode = item["UNITOFMEASURE"].ToString() });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return ProdReturn;
        }
    }
}

