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
    public partial class ProductBlankForm : Form
    {
        private void BindGrid()
        {
            btnSave.Enabled = false;

            if (string.IsNullOrEmpty(txtBarcode.Text.Trim()))
            {
                GlobalMessageBox.ShowInfomation("กรุณาระบุบาร์โค้ดสินค้า ก่อนทำการค้นหา");
                txtBarcode.Focus();
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var barcode = txtBarcode.Text.Trim();
                var productBarcode = ServiceHelper.MobileServices.ProductBarcodeGetByBarcode(barcode, GlobalContext.BranchCode);
                if (productBarcode == null)
                    return;
                else
                {
                    txtProductCode.Text = productBarcode.ProductCode;
                    txtProductName.Text = productBarcode.ProductName;
                    txtUnitCode.Text = productBarcode.UnitCode;
                    txtUnitName.Text = productBarcode.UnitName;
                    List<ProductLocation> productLocations = new List<ProductLocation>();
                    var productLocationResult = ServiceHelper.MobileServices.ProductLocationGetAllByBarcode(barcode, GlobalContext.BranchCode, GlobalContext.WarehouseCode);
                    productLocations.AddRange(productLocationResult);
                    if (productLocationResult != null)
                    {
                        bsLocation.DataSource = productLocations;
                        btnSave.Enabled = true;
                    }

                    this.txtBarcode.Text = null;
                }

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

        private void ClearGrid()
        {
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Text = null;
            this.bsLocation.DataSource = null;
            this.bsLocation.ResetBindings(false);
            this.btnSave.Enabled = false;
            this.txtBarcode.Focus();
        }

        public ProductBlankForm()
        {
            InitializeComponent();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BindGrid();
            }
        }

        private void btnCheckLists_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var displayList = ServiceHelper.MobileServices.ProductLocationGetDisplayList(GlobalContext.BranchCode, GlobalContext.UserCode);
                var oForm = new DisplayListForm(displayList);
                Cursor.Current = Cursors.Default;
                oForm.ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GlobalMessageBox.ShowQuestion("คุณต้องการบันทึกข้อมูล ใช่หรือไม่") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var productLocations = (List<ProductLocation>)bsLocation.DataSource;
                    foreach (var item in productLocations)
                    {
                        item.ProductCode = txtProductCode.Text;
                        item.ProductUnitCode = txtUnitCode.Text;
                        item.ProductName = txtProductName.Text;
                        item.BalanceQuantitySpecified = true;
                    }
                    ServiceHelper.MobileServices.ProductLocationBlankAdd(GlobalContext.BranchCode, productLocations.ToArray());

                    GlobalMessageBox.ShowInfomation("บันทึกข้อมูลเรียบร้อยแล้ว");
                    ClearGrid();
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

        private void ProductBlankForm_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

    }
}