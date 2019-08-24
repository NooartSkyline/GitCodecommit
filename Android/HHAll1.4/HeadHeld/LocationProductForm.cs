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
    public partial class LocationProductForm : Form
    {
        #region Field

        private bool _offlineMode;

        private int _putLevel { get { return Utils.Int32Parse(txtPutLevel.Text); } }

        private int _putQty { get { return Utils.Int32Parse(txtPutQty.Text); } }

        private decimal _maxStock { get { return Utils.DecimalParse(txtMaxStock.Text); } }

        #endregion

        #region Property

        public ProductLocation ProductLocation { get; set; }

        #endregion

        private void BindData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //ddlProductUnit.Items.Clear();
                ddlProductUnit.DataSource = null;
                ddlProductUnit.ValueMember = "Code";
                ddlProductUnit.DisplayMember = "Name";
                txtProductName.Text = null;

                var productBarcode = GetProduct();
                if (productBarcode.Length > 0)
                {
                    txtProductCodeOrBarcode.Text = null;
                    var product = (ProductBarcode)productBarcode.GetValue(0);
                    //ddlProductUnit.Enabled = true;

                    //Begin BEE Edit ตั๊กบอกให้แสดงทุกหน่วย 2012-11-15
                    //if (productBarcode.Length == 1)
                    //{
                    //    List<ProductUnit> productUnit = new List<ProductUnit>();
                    //    productUnit.Add(new ProductUnit { ProductCode = product.ProductCode, Code = product.UnitCode, Name = product.UnitName, IsSelected = false });
                    //    ddlProductUnit.DataSource = productUnit;
                    //}
                    //else
                    //{
                    //    ddlProductUnit.DataSource = ServiceHelper.MobileServices.ProductUnitGetByProductCode(GlobalContext.BranchCode, product.ProductCode);
                    //}

                    ddlProductUnit.DataSource = ServiceHelper.MobileServices.ProductUnitGetByProductCode(GlobalContext.BranchCode, product.ProductCode);
                    //End BEE Edit ตั๊กบอกให้แสดงทุกหน่วย 2012-11-15

                    txtProductName.Text = product.ProductName;
                    txtProductCode.Text = product.ProductCode;
                    //txtPutLevel.Focus();
                    txtMaxStock.Focus();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "พบข้อผิดพลาด");
            }
        }

        private Array GetProduct()
        {

            string productCodeOrBarcode = txtProductCodeOrBarcode.Text.Trim();

            //if (chkIsProductCode.Checked)
            //{
            //    ProductBarcode[] products = new ProductBarcode[1];
            //    var product = ServiceHelper.MobileServices.ProductByProductCode(GlobalContext.BranchCode, productCodeOrBarcode);
            //    if (product != null)
            //        products.SetValue(product, 0);

            //    return products;
            //}
            //else
            //{
            //    return ServiceHelper.MobileServices.ProductBarcodeGetByProductCodeOrBarcode2(productCodeOrBarcode, GlobalContext.BranchCode);
            //}

            return ServiceHelper.MobileServices.ProductBarcodeGetByProductCodeOrBarcode2(productCodeOrBarcode, GlobalContext.BranchCode);


        }

        public LocationProductForm(bool offlineMode)
        {
            InitializeComponent();

            _offlineMode = offlineMode;

            if (_offlineMode)
            {
                ddlProductUnit.Enabled = false;
            }
        }

        public LocationProductForm(ProductLocation productLocation, bool offlineMode)
        {
            InitializeComponent();

            _offlineMode = offlineMode;

            if (_offlineMode)
            {
                ddlProductUnit.Enabled = false;
            }

            if (productLocation != null)
            {
                this.ProductLocation = productLocation;
                this.txtProductCodeOrBarcode.Text = productLocation.ProductBarcode;
                if (!_offlineMode)
                {
                    this.BindData();                    
                    this.ddlProductUnit.SelectedValue = productLocation.ProductUnitCode;
                }
                this.txtPutLevel.Text = productLocation.PutLevel.ToString();
                this.txtPutQty.Text = productLocation.PutQuantity.ToString();
                this.chkRequestPrintLabel.Checked = productLocation.RequestPrintLabel;
                this.txtMaxStock.Text = productLocation.MaxStock.ToString();
            }
        }

        private void LocationProductForm_Load(object sender, EventArgs e)
        {

        }

        private void LocationProductForm_Activated(object sender, EventArgs e)
        {
            this.Location = new Point(
            (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2),
            (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (_offlineMode)
            {
                if (string.IsNullOrEmpty(txtProductCodeOrBarcode.Text))
                {
                    MessageBox.Show("กรุณาระบุรหัส/บาร์โค้ด", "แจ้งเตือน");
                    return;
                }

                this.ProductLocation = new ProductLocation();
                this.ProductLocation.ProductCode = txtProductCodeOrBarcode.Text;
                this.ProductLocation.ProductBarcode = txtProductCodeOrBarcode.Text;
                this.ProductLocation.ProductName = "-";
                this.ProductLocation.ProductUnitName = "-";
                this.ProductLocation.PutLevel = _putLevel;
                this.ProductLocation.PutQuantity = _putQty;
                this.ProductLocation.RequestPrintLabel = chkRequestPrintLabel.Checked;
                this.ProductLocation.MaxStock = _maxStock;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (string.IsNullOrEmpty(txtProductCode.Text))
                {                                                                                                                                                                                                                                                                                                                     
                    MessageBox.Show("กรุณาระบุรหัสสินค้า", "แจ้งเตือน");
                    return;
                }
                this.ProductLocation = new ProductLocation();
                var unitCode = ddlProductUnit.SelectedValue.ToString();
                this.ProductLocation.ProductCode = txtProductCode.Text;

                this.ProductLocation.ProductBarcode = ServiceHelper.MobileServices.BarcodeGetByProductCode(GlobalContext.BranchCode, this.ProductLocation.ProductCode, unitCode);
                this.ProductLocation.PutLevel = this._putLevel;
                this.ProductLocation.PutQuantity = this._putQty;
                this.ProductLocation.ProductUnitCode = unitCode;
                this.ProductLocation.ProductName = txtProductName.Text;
                this.ProductLocation.ProductUnitName = ddlProductUnit.Text;
                this.ProductLocation.RequestPrintLabel = chkRequestPrintLabel.Checked;
                this.ProductLocation.MaxStock = _maxStock;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    this.ProductLocation = null;
        //    this.DialogResult = DialogResult.OK;
        //}

        private void txtProductCodeOrBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtProductCodeOrBarcode.Text;
                if (string.IsNullOrEmpty(barcode))
                    barcode = CeReader.Barcode.Scan();
                txtProductCodeOrBarcode.Text = barcode;

                //var barcode = txtProductCodeOrBarcode.Text;
                barcode = txtProductCodeOrBarcode.Text;
                if (barcode.IndexOf(Convert.ToChar(".")) > -1)
                {
                    // if price no scan.
                    return;
                }
                if (Utils.CheckLocationIsLocation(barcode))
                {
                    // if location no scan
                    return;
                }

                if (!_offlineMode)
                {
                    this.BindData();
                }
                if (!string.IsNullOrEmpty(txtProductCodeOrBarcode.Text))
                {
                    txtPutLevel.Focus();
                    txtPutLevel.SelectAll();
                    //txtMaxStock.Focus();
                }
            }
        }

        private void txtPutLevel_TextChanged(object sender, EventArgs e)
        {
            txtPutQty.Focus();
            txtPutQty.SelectAll();
        }

        private void txtPutQty_TextChanged(object sender, EventArgs e)
        {
            txtMaxStock.Focus();
            txtMaxStock.SelectAll();
        }

        private void txtDeep_TextChanged(object sender, EventArgs e)
        {
            btnSave.Focus();
        }

        private void chkRequestPrintLabel_CheckStateChanged(object sender, EventArgs e)
        {
            btnSave.Focus();
        }

        private void txtMaxStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
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

    }
}