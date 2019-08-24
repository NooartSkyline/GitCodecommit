﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Resco.Controls.SmartGrid;
using DoHome.HandHeld.Client.DataAccess;

namespace DoHome.HandHeld.Client
{
    public partial class ProductCheckPriceForm : Form
    {
        public bool OfflineMode
        {
            get
            {
                return chkOffline.Checked;

            }
        }

        private void BindLocationData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var locationCode = txtLocationCode.Text.Trim().ToUpper();
                if (!OfflineMode)
                {
                    var EndPoint = GlobalContext.ServerEndpointAddress;
                    var ServiceUrl = GlobalContext.remoteAddress;
                    var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
                    cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
                    var location = cnn.LocationGetByCode(locationCode, GlobalContext.WarehouseCode);
                    //var location = ServiceHelper.MobileServices.LocationGetByCode(locationCode, GlobalContext.WarehouseCode);
                    ////var isExists = LocationManager.CheckExistsLocation(locationCode);
                    if (location == null)
                    {
                        Cursor.Current = Cursors.Default;
                        GlobalMessageBox.ShowInfomation("ไม่พบตำแหน่งจัดเก็บสินค้านี้ ในระบบ");
                        return;
                    }

                    if (!CheckIsCreateLocationToday())
                        return;
                }
                this.txtLocationCode.Text = locationCode;
                this.txtLocationCode.Enabled = false;
                this.txtProductCode.Enabled = true;
                this.txtEmployeeCode.Enabled = true;
                this.btnSearchUser.Enabled = true;
                this.txtProductCode.Focus();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                GlobalMessageBox.ShowError(ex.Message);
            }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void BindGrid()
        {

            if (string.IsNullOrEmpty(txtProductCode.Text.Trim()))
            {
                GlobalMessageBox.ShowInfomation("กรุณาระบุบาร์โค้ดสินค้า ก่อนทำการค้นหา");
                // GlobalMessageBox.ShowInfomation("กรุณาระบุรหัสสินค้า ก่อนทำการค้นหา");
                txtProductCode.Focus();
                return;
            }

            try
            {

                Cursor.Current = Cursors.WaitCursor;
                if (bsProductLocation.DataSource == null)
                    bsProductLocation.DataSource = new List<ProductLocation>();

                ProductLocation product = null;
                var barcode = txtProductCode.Text.Trim();
                if (OfflineMode)
                {
                    product = new ProductLocation();
                    product.ProductCode = string.Empty;
                    product.ProductBarcode = barcode;
                    product.SalePrice = 0;
                }
                else
                {
                    product = ServiceHelper.MobileServices.ProductLocationGetByProductCodeOrBarcode(barcode, GlobalContext.WarehouseCode, GlobalContext.BranchCode);
                }
                if (product != null)
                {
                    product.ShopPrice = 0;
                    Cursor.Current = Cursors.Default;

                    //กรณีที่ใช้ในคลังหรือตรวจตำแหน่ง Top ไม่ต้องให้แสดงราคา และหน้าจอสำหรับป้อนราคา
                    if (GlobalContext.UseInPlaces == UseInPlaces.WAREHOUSE || Utils.CheckLocationIsTopLevel(txtLocationCode.Text))
                    {
                        dgvProducts.Columns["columnSalePrice"].Width = 0;
                        dgvProducts.Columns["columnSalePrice"].AutoSizeColumnMode = AutoSizeColumnMode.None;
                        dgvProducts.Columns["columnShopPrice"].Width = 0;
                        dgvProducts.Columns["columnShopPrice"].AutoSizeColumnMode = AutoSizeColumnMode.None;
                    }
                    else
                    {
                        var oForm = new EnterPriceForm();
                        oForm.ProductCode = product.ProductCode;
                        if (oForm.ShowDialog() == DialogResult.OK)
                        {
                            product.ShopPrice = oForm.Price;
                            if (!OfflineMode)
                            {
                                product.ProductUnitCode = oForm.UnitCode;
                                product.ProductUnitName = oForm.UnitName;
                                var productPrice = ServiceHelper.MobileServices.ProductPriceGetCurrentPrice(GlobalContext.BranchCode, product.ProductCode, product.ProductUnitCode);
                                product.SalePrice = productPrice.Saleprice;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    product.DisplayOrder = ((List<ProductLocation>)bsProductLocation.DataSource).Count + 1;
                    ((List<ProductLocation>)bsProductLocation.DataSource).Add(product);
                    bsProductLocation.ResetBindings(false);
                    this.btnSave.Enabled = true;
                }

                this.txtProductCode.Text = null;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                GlobalMessageBox.ShowError(ex.Message);
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกพนักงานประจำล็อก ก่อนทำการบันทึก");
                return false;
            }
            if (this.dtChangePrice.Value == null)
            {
                GlobalMessageBox.ShowInfomation("กรุณาวันที่ป้ายปรับ ก่อนทำการบันทึก");
                return false;

            }

            return true;
        }

        private void Add()
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var products = (List<ProductLocation>)bsProductLocation.DataSource;
                var warehouseCode = GlobalContext.WarehouseCode;
                var userID = GlobalContext.UserCode;
                var employeeCode = txtEmployeeCode.Text.Trim();
                int displayOrder = 0;
                foreach (var item in products)
                {
                    item.SalePriceSpecified = true;
                    item.ShopPriceSpecified = true;
                    item.DisplayOrder = displayOrder;
                    item.DisplayOrderSpecified = true;
                    item.CreateDateSpecified = true;
                    item.OfficerID = employeeCode;
                    item.WarehouseCode = warehouseCode;
                    item.UserID = userID;
                    item.LocationCode = txtLocationCode.Text;
                    item.DocumentDate = this.dtChangePrice.Value;
                    displayOrder++;
                }
                if (OfflineMode)
                    LocationCheckProductManager.Add(products);
                else
                    ServiceHelper.MobileServices.ProductLocationAddHandHeldLocation(GlobalContext.BranchCode, products.ToArray());

                //clear controls
                this.ClearBindingControl();

                //GlobalMessageBox.ShowInfomation("บันทึกข้อมูลเรียบร้อย");
            }
            catch (Exception ex)
            {
                var message = "เกิดข้อผิดพลาดในการบันทึกข้อมูล ดังนี้ \n" + ex.Message;
                GlobalMessageBox.ShowError(message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        private void ClearBindingControl()
        {
            this.txtLocationCode.Text = null;

            this.txtLocationCode.Enabled = true;
            this.txtProductCode.Enabled = false;
            this.txtProductCode.Text = null;
            this.txtEmployeeCode.Text = null;
            this.txtEmployeeName.Text = null;
            this.btnSearchUser.Enabled = false;
            this.bsProductLocation.DataSource = null;
            this.bsProductLocation.ResetBindings(false);
            this.btnSave.Enabled = false;
            //this.chkOffline.Checked = true;// set offline mode to default.
            this.txtLocationCode.Focus();

            if (this.ChkLabel.Checked)
            {
                this.txtLocationCode.Enabled = false;
                this.txtProductCode.Enabled = true;
                this.txtEmployeeCode.Enabled = true;
                this.btnSearchUser.Enabled = true;
                this.txtProductCode.Focus();
            }
        }

        private bool CheckIsCreateLocationToday()
        {

            var locationCode = txtLocationCode.Text.Trim();
            bool checkIsCreateLocationToday = false;
            checkIsCreateLocationToday = ServiceHelper.MobileServices.CheckIsCreateLocationToday(GlobalContext.BranchCode, locationCode
                 , GlobalContext.WarehouseCode);

            if (checkIsCreateLocationToday)
            {
                if (GlobalMessageBox.ShowQuestion("ตำแหน่ง " + locationCode + " เคยทำแล้วในวันนี้ ต้องการทำซ้ำอีกครั้งหรือไม่?") == DialogResult.Yes)
                    return true;
                else
                    return false;
            }

            return true;
        }

        public ProductCheckPriceForm()
        {
            InitializeComponent();
        }

        private void txtLocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var locationCode = txtLocationCode.Text;
                if (locationCode.IndexOf(Convert.ToChar(".")) > -1)
                {
                    // if price no scan.
                    txtLocationCode.Text = null;
                    txtLocationCode.Focus();
                    //GlobalMessageBox.ShowInfomation("คุณระบุตำแหน่งไม่ถูกต้อง");
                    return;
                }
                else if (Utils.CheckIsDigitOnly(locationCode))
                {
                    // if barcode no scan.
                    txtLocationCode.Text = null;
                    txtLocationCode.Focus();
                    return;
                }

                BindLocationData();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var barcode = txtProductCode.Text;
                if (barcode.IndexOf(Convert.ToChar(".")) > -1)
                {
                    // if price no scan.
                    return;
                }
                else if (Utils.CheckLocationIsLocation(barcode))
                {  // if price no scan.                    
                    return;
                }

                this.BindGrid();
                txtProductCode.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearBindingControl();
        }

        private void btnCheckLists_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var displayList = ServiceHelper.MobileServices.DisplayListGetBySearchPrice(GlobalContext.BranchCode, GlobalContext.UserCode);
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
            if (this.ValidateForm())
            {
                Add();
            }
        }

        private void ProductCheckPriceForm_Load(object sender, EventArgs e)
        {
            try
            {
                //chkOffline.Checked = true;
                dtChangePrice.Value = DateTime.Today;
                txtLocationCode.Focus();
                //Cursor.Current = Cursors.WaitCursor;
                // initialize dropdown controls.
                //this.PrepareEmployeeDropdown();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }

        }

        private void btnRandomCheck_Click(object sender, EventArgs e)
        {
            //if (_currentRowIndex > -1)
            //{
            //    if (dgProduct.IsSelected(_currentRowIndex))
            //    {
            //        var displayOrder = Convert.ToInt32(dgProduct[_currentRowIndex, 0]);
            //        var products = (List<ProductLocation>)bsProductLocation.DataSource;
            //        var product = products.SingleOrDefault(p => p.DisplayOrder == displayOrder);
            //        if (product != null)
            //        {
            //            var oform = new ProductRandomCheckForm(product);
            //            oform.ShowDialog();
            //        }
            //    }
            //}
        }

        private void dgProduct_Click(object sender, EventArgs e)
        {
            //_currentRowIndex = dgProduct.CurrentRowIndex;
            //if (_currentRowIndex > -1)
            //    dgProduct.Select(_currentRowIndex);
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
          /*  if (dgvProducts.Rows.Count > 0)
            {
                var rowIndex = dgvProducts.ActiveRowIndex;
                if (rowIndex >= 0)
                {
                    var displayOrder = Convert.ToInt32(dgvProducts.Cells[rowIndex, 0].Text);
                    var products = (List<ProductLocation>)bsProductLocation.DataSource;
                    var product = products.SingleOrDefault(p => p.DisplayOrder == displayOrder);
                    if (product != null)
                    {
                        var oform = new ProductRandomCheckForm(product);
                        oform.ShowDialog();
                    }
                }
            }*/
        }

        private void dgvProducts_CustomizeCell(object sender, CustomizeCellEventArgs e)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                if (!e.Cell.Header)
                {
                    if (e.Cell.ColumnIndex == 1)
                    {
                        var data = (ProductLocation)e.Cell.Row.Data;
                        if (data.ShopPrice != data.SalePrice)
                            e.Cell.Style = this.dgvProducts.Styles["styleRed"];
                    }
                }
            }
        }

        private void chkOffline_CheckStateChanged(object sender, EventArgs e)
        {
            txtLocationCode.Focus();
        }

        private void btnOffLineView_Click(object sender, EventArgs e)
        {
            new ProductCheckPriceOfflineForm().ShowDialog();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            var user = UserManager.GetByCode(txtEmployeeCode.Text.Trim());
            if (user != null)
            {
                txtEmployeeCode.Text = user.Code;
                txtEmployeeName.Text = user.Name;
            }
            else
            {
                txtEmployeeCode.Text = string.Empty;
                txtEmployeeName.Text = string.Empty;
            }

            // set cursor to save button
            btnSave.Focus();
        }


        private void txtLocationCode_TextChanged(object sender, EventArgs e)
        {
            //txtLocationCode.Text = txtLocationCode.Text.ToUpper();
        }

        private void txtEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new LocationKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtLocationCode.Text = oForm.Tag as string;
            }
        }

        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new NumericKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtProductCode.Text = oForm.Tag as string;
                txtProductCode.Focus();
            }
        }

        private void ChkLabel_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.ChkLabel.Checked)
            {
                this.txtLocationCode.Enabled = false;
                this.txtProductCode.Enabled = true;
                this.txtEmployeeCode.Enabled = true;
                this.btnSearchUser.Enabled = true;
                this.txtProductCode.Focus();
            }
            else
            {
                this.txtLocationCode.Enabled = true;
                this.txtProductCode.Enabled = false;
                this.txtEmployeeCode.Enabled = false;
                this.btnSearchUser.Enabled = false;
                this.txtLocationCode.Focus();
            }
            Cursor.Current = Cursors.Default;
        }

        private void dgvProducts_Click(object sender, EventArgs e)
        {

        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_ParentChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScanProductCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvProducts_Click_1(object sender, EventArgs e)
        {

        }


    }
}