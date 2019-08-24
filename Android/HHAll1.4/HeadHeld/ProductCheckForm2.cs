using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoHome.HandHeld.Client
{
    public partial class ProductCheckForm2 : Form
    {
        private void CleareData()
        {
            gvProductInfo.DataSource = null;
            gvProductInfo.Rows.Clear();
            bsProductOutOfStock.DataSource = null;
            bsProductOutOfStock.ResetBindings(false);
            txtProductCode.Text = null;
            txtProductName.Text = null;
            txtGroupingofmaterials.Text = null;
        }

        private void BindData()
        {
            gvProductInfo.DataSource = null;
            bsProductOutOfStock.DataSource = null;
            bsProductOutOfStock.ResetBindings(false);
            txtProductCode.Text = null;
            txtProductName.Text = null;
            txtGroupingofmaterials.Text = null;

            string productCodeOrBarcode = txtProductCodeOrBarcode.Text.Trim();
            var EndPoint = GlobalContext.ServerEndpointAddress;
            var ServiceUrl = GlobalContext.remoteAddress;
            var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
            cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
            var productBarcodes = cnn.ProductBarcodeGetByProductCodeOrBarcode1(productCodeOrBarcode, GlobalContext.WarehouseCode, GlobalContext.BranchCode, GlobalContext.IsShowPrice, GlobalContext.IsShowPrice);
            if (productBarcodes != null && productBarcodes.Length > 0)
            {
                txtGroupingofmaterials.Text = cnn.SapDepartmentTextGetByProductCode(GlobalContext.BranchCode, productCodeOrBarcode);
                var productBarcode =  productBarcodes.First();
                txtProductCode.Text = productBarcode.ProductCode;
                txtProductName.Text = productBarcode.ProductName;
                this.BindGridViewProductOutOfStock(productBarcode.ProductCode);
            }

            //binding datasource on gridview.
            gvProductInfo.DataSource = productBarcodes;
            txtProductCodeOrBarcode.Text = null;
        }

        private void BindGridViewProductOutOfStock(string productCode)
        {
            List<ProductLocation> productLocations = new List<ProductLocation>();
            var EndPoint = GlobalContext.ServerEndpointAddress;
            var ServiceUrl = GlobalContext.remoteAddress;
            var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
            cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
            var productLocationResult = cnn.ProductLocationGetAllByProductCode(productCode, GlobalContext.BranchCode, GlobalContext.WarehouseCode);

            foreach (var item in productLocationResult)
            {
                ProductLocation pro = new ProductLocation();
                pro.BalanceQuantity = item.BalanceQuantity;
                pro.BalanceQuantitySpecified = item.BalanceQuantitySpecified;
                pro.BalanceQuantityText = item.BalanceQuantityText;
                pro.CreateDate = item.CreateDate;
                pro.CreateDateSpecified = item.CreateDateSpecified;
                pro.DisplayOrder = item.DisplayOrder;
                pro.DisplayOrderSpecified = item.DisplayOrderSpecified;
                pro.DocumentDate = item.DocumentDate;
                pro.DocumentDateSpecified = item.DocumentDateSpecified;
                pro.DocumentNo = item.DocumentNo;
                pro.LocationCode = item.LocationCode;
                pro.LocationStatus = item.LocationStatus;
                pro.LocationType = item.LocationType;
                pro.MaxStock = item.MaxStock;
                pro.MaxStockSpecified = item.MaxStockSpecified;
                pro.OfficerID = item.OfficerID;
                pro.PriceStatus = item.PriceStatus;
                pro.ProductBarcode = item.ProductBarcode;
                pro.ProductCode = item.ProductCode;
                pro.ProductName = item.ProductName;
                pro.ProductUnitCode = item.ProductUnitCode;
                pro.ProductUnitName = item.ProductUnitName;
                pro.PutDeep = item.PutDeep;
                pro.PutDeepSpecified = item.PutDeepSpecified;
                pro.PutLevel = item.PutLevel;
                pro.PutLevelSpecified = item.PutLevelSpecified;
                pro.PutQuantity = item.PutQuantity;
                pro.PutQuantitySpecified = item.PutQuantitySpecified;
                pro.RandomText = item.RandomText;
                pro.Remark = item.Remark;
                pro.RequestPrintLabel = item.RequestPrintLabel;
                pro.RequestPrintLabelSpecified = item.RequestPrintLabelSpecified;
                pro.SalePrice = item.SalePrice;
                pro.SalePriceSpecified = item.SalePriceSpecified;
                pro.ShopPrice = item.ShopPrice;
                pro.ShopPriceSpecified = item.ShopPriceSpecified;
                pro.StatusText = item.StatusText;
                pro.UserID = item.UserID;
                pro.WarehouseCode = item.WarehouseCode;
                pro.WarehouseName = item.WarehouseName;
                productLocations.Add(pro);
            }
          
            if (productLocationResult != null)
            {
                bsProductOutOfStock.DataSource = productLocations;
                btnSaveProductOutOfStock.Enabled = true;
            }
        }

        public ProductCheckForm2()
        {
            InitializeComponent();
        }

        private void ProductCheckForm_Load(object sender, EventArgs e)
        {

            this.txtProductCodeOrBarcode.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CleareData();
            // validate control.
            if (string.IsNullOrEmpty(txtProductCodeOrBarcode.Text))
            {
                MessageBox.Show("กรุณาระบุ รหัสสินค้า หรือ บาร์โค๊ด ก่อนค้นหาข้อมูล", "เกิดข้อผิดพลาด");
                return;
            }
            if (txtProductCodeOrBarcode.Text.IndexOf(Convert.ToChar(".")) > -1)
            {
                txtProductCodeOrBarcode.Text = null;
                txtProductCodeOrBarcode.Focus();
                return;
            }
            // set focus on textbox barcode.
            this.txtProductCodeOrBarcode.Focus();

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.BindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "พบข้อผิดพลาด");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtProductCodeOrBarcode.Text;
                if (string.IsNullOrEmpty(barcode))
                    barcode = CeReader.Barcode.Scan();
                txtProductCodeOrBarcode.Text = barcode;
                btnSearch_Click(sender, e);
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string productCode = txtProductCode.Text;
            //    string productName = txtProductName.Text;
            //    if (!string.IsNullOrEmpty(productCode))
            //    {
            //        var oForm = new ProductOrderRequest(productCode, productName);
            //        oForm.ShowDialog();
            //    }
            //    else
            //        throw new Exception("กรุณาระบุสินค้าก่อน ทำการขอซื้อ");

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "พบข้อผิดพลาด");
            //}
        }

        private void BindTitle()
        {
            this.Text = GlobalContext.ApplicationTitle("ตรวจสอบสินค้า");
        }

        private void btnSaveProductOutOfStock_Click(object sender, EventArgs e)
        {
            if (GlobalMessageBox.ShowQuestion("คุณต้องการบันทึกใช่หรือไม่") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var productLocations = (List<ProductLocation>)bsProductOutOfStock.DataSource;
                    foreach (var item in productLocations)
                    {
                        item.ProductCode = txtProductCode.Text;
                        //item.ProductUnitCode = txtUnitCode.Text;
                        item.ProductName = txtProductName.Text;
                        item.BalanceQuantitySpecified = true;
                    }
                    ServiceHelper.MobileServices.ProductLocationBlankAdd(GlobalContext.BranchCode, productLocations.ToArray());

                    GlobalMessageBox.ShowInfomation("บันทึกข้อมูลเรียบร้อยแล้ว");
                }
                catch (Exception ex)
                {
                    GlobalMessageBox.ShowError(ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new NumericKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtProductCodeOrBarcode.Text = oForm.Tag as string;
                txtProductCodeOrBarcode.Focus();
            }
        }

        private void btnSalesInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาระบุสินค้าก่อนดูข้อมูล");
                return;
            }

            var oForm = new SalesInfoForm(txtProductCode.Text, txtProductName.Text, txtGroupingofmaterials.Text);
            oForm.ShowDialog();
        }

        private void btnPurchaseInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาระบุสินค้าก่อนดูข้อมูล");
                return;
            }

            var oForm = new PurchaseInfoForm(txtProductCode.Text, txtProductName.Text, txtGroupingofmaterials.Text);
            oForm.ShowDialog();
        }

    }
}