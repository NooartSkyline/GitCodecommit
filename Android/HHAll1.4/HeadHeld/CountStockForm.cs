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
    public partial class CountStockForm : Form
    {
        private int _currentRowIndex;

        private void PrepareEmployeeDropdown()
        {
            //ddlEmployee.ValueMember = "Code";
            //ddlEmployee.DisplayMember = "Name";
            ////var employee = ServiceHelper.MobileServices.GetUserByBranch(GlobalContext.BranchCode);
            ////var employee = new User { Code = GlobalContext.UserCode, Name = GlobalContext.UserName };
            //var employee = new List<User>();
            //employee.Add(new User { Code = GlobalContext.UserCode, Name = GlobalContext.UserName });
            //ddlEmployee.DataSource = employee;
        }

        private void BindGrid()
        {
            //lblMessage.Visible = false;
            string messageAlert = string.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<HandHeldCounterHold> prouductBarcode = null;
                if (bindingSource.DataSource == null)
                    bindingSource.DataSource = new List<HandHeldCounterHold>();

                prouductBarcode = (List<HandHeldCounterHold>)bindingSource.DataSource;
                var productCodeOrBarcode = txtScan.Text.Trim();

                //MessageBox.Show("MobileServices.GetProductCode");

                var productCode = ServiceHelper.MobileServices.GetProductCode(GlobalContext.BranchCode, productCodeOrBarcode);
                //MessageBox.Show(productCode);
                if (prouductBarcode.FindAll(p => p.Productcode == productCode).Count > 0)
                {
                    GlobalMessageBox.ShowInfomation("มีสินค้าอยู่ในรายการตรวจสอบนี้แล้ว");

                    //clear barcode textbox
                    this.txtScan.Text = string.Empty;
                    this.txtScan.Focus();

                    return;
                }

                //MessageBox.Show("call HandHeldCounterHoldGetByProductCode");
                var products = ServiceHelper.MobileServices.HandHeldCounterHoldGetByProductCode(productCode
                    , GlobalContext.UserCode
                    , GlobalContext.UserCode//ddlEmployee.SelectedValue as string
                    , GlobalContext.WarehouseCode
                    , GlobalContext.BranchCode
                    , out messageAlert);

                //MessageBox.Show(products.Length.ToString ());

                //test.
                //ServiceHelper.MobileServices.HandHeldCounterHoldGetByProductCode2(productCode
                //   , GlobalContext.UserCode
                //   , ddlEmployee.SelectedValue as string
                //   , GlobalContext.WarehouseCode
                //   , GlobalContext.BranchCode);

                if (products != null)
                {
                    foreach (var item in products)
                    {
                        prouductBarcode.Add(item);
                    }

                    bindingSource.DataSource = prouductBarcode;
                    bindingSource.ResetBindings(false);
                }
                else
                {
                    if (string.IsNullOrEmpty(messageAlert))
                        GlobalMessageBox.ShowInfomation("ไม่พบรหัสสินค้า/บาร์โค้ดที่ระบุ");
                    else
                        GlobalMessageBox.ShowInfomation(messageAlert);
                }

                //clear barcode textbox
                this.txtScan.Text = string.Empty;
                this.txtScan.Focus();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                GlobalMessageBox.ShowError(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void ClearControlBinding()
        {
            txtScan.Text = string.Empty;
            bindingSource.DataSource = new List<HandHeldCounterHold>();
            bindingSource.ResetBindings(false);
        }


        private bool IsValidateForm
        {
            get
            {
                //if (ddlEmployee.SelectedValue == null)
                //{
                //    GlobalMessageBox.ShowInfomation("กรุณาระบุเจ้าหน้าที่ ก่อนบันทึกข้อมูล");
                //    return false;
                //}
                if (grdProduct.Rows.Count <= 0)
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุรายการสินค้า ก่อนบันทึกข้อมูล");
                    return false;
                }

                return true;
            }
        }

        public CountStockForm()
        {
            InitializeComponent();
        }


        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                BindGrid();
            }

        }

        private void CountStockForm_Load(object sender, EventArgs e)
        {
            this.PrepareEmployeeDropdown();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ClearControlBinding();
        }

        private void btnHoldBill_Click(object sender, EventArgs e)
        {
           if (IsValidateForm)
            {
                //string ShopRemark = oForm.Remark;
                var oForm = new EnterRemark();
                
                if (oForm.ShowDialog() == DialogResult.OK)
                {
                    // ShopRemark = oForm.Remark;
                }   
                    if (GlobalMessageBox.ShowQuestion("คุณต้องการพักบิลเอกสารนี้ ใช่หรือไม่") == DialogResult.Yes)
                    {

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            grdProduct.EndEdit();
                            List<HandHeldCounterHold> products = (List<HandHeldCounterHold>)bindingSource.DataSource;

                            foreach (var item in products)
                            {
                                item.Warehouse = GlobalContext.WarehouseCode;
                                item.Branchcode = GlobalContext.BranchCode;
                                item.QuantitySpecified = true;
                                item.Officerid = GlobalContext.UserCode;//ddlEmployee.SelectedValue as string;
                                item.Createuser = GlobalContext.UserCode;
                            }

                            // save data to server.
                            ServiceHelper.MobileServices.AddHandHeldCounterHold(GlobalContext.BranchCode, products.ToArray());

                            GlobalMessageBox.ShowInfomation("พักบิลเรียบร้อยแล้ว");

                            this.ClearControlBinding();
                        }
                        catch (Exception ex)
                        {
                            GlobalMessageBox.ShowError(ex);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }

               
            }
        }

        private void dgProduct_Click(object sender, EventArgs e)
        {
            //_currentRowIndex = dgProduct.CurrentRowIndex;
            //if (_currentRowIndex > -1)
            //{
            //    dgProduct.Select(_currentRowIndex);
            //}
        }

        private void btnResumeBill_Click(object sender, EventArgs e)
        {
            var oform = new CountStockFormResumeBillForm();
            if (oform.ShowDialog() == DialogResult.OK)
            {
                List<HandHeldCounterHold> prouductBarcode = new List<HandHeldCounterHold>();

                var products = ServiceHelper.MobileServices.GetHandHeldCounterHoldByDocumentNo(GlobalContext.BranchCode, oform.SelectedValue);

                if (products != null)
                {
                    foreach (var item in products)
                    {
                        prouductBarcode.Add(item);
                    }

                    bindingSource.DataSource = prouductBarcode;
                    bindingSource.ResetBindings(false);
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var displayList = ServiceHelper.MobileServices.DisplayListGetByCountStock(GlobalContext.BranchCode, GlobalContext.UserCode);
                var oForm = new DisplayListForm(displayList);
                Cursor.Current = Cursors.Default;
                oForm.ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex.Message);
            }
        }

        private void dgProduct_DoubleClick(object sender, EventArgs e)
        {
            //var uniqeID = dgProduct[_currentRowIndex, 0] as string;
            //var prouductBarcode = (List<HandHeldCounterHold>)bindingSource.DataSource;
            //var product = prouductBarcode.Find(p => p.UniqueID == uniqeID);
            //if (product != null)
            //{
            //    var oForm = new CountStockQuantityForm(product.Productcode
            //        , product.Productname
            //        , product.Unitcode);

            //    oForm.ValueQuantity = product.Quantity;
            //    oForm.ValueUnitCode = product.Unitcode;

            //    if (oForm.ShowDialog() == DialogResult.OK)
            //    {


            //        product.Quantity = oForm.ValueQuantity;
            //        product.QuantitySpecified = true;
            //        product.Unitcode = oForm.ValueUnitCode;
            //        product.Unitname = oForm.ValueUnitName;

            //        //กรณีเปลี่ยนหน่วยนับ ต้องเปลี่ยนทั้งหมด
            //        foreach (var item in prouductBarcode.FindAll(p => p.Productcode == product.Productcode))
            //        {
            //            item.Unitcode = oForm.ValueUnitCode;
            //            item.Unitname = oForm.ValueUnitName;
            //        }

            //        bindingSource.DataSource = prouductBarcode;
            //        bindingSource.ResetBindings(false);
            //    }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidateForm)
            {
                if (GlobalMessageBox.ShowQuestion("คุณต้องการบันทึกเอกสารนี้ ใช่หรือไม่") == DialogResult.Yes)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        grdProduct.EndEdit();
                        List<HandHeldCounterHold> products = (List<HandHeldCounterHold>)bindingSource.DataSource;

                        foreach (var item in products)
                        {
                            item.Warehouse = GlobalContext.WarehouseCode;
                            item.Branchcode = GlobalContext.BranchCode;
                            item.QuantitySpecified = true;
                            item.Officerid = GlobalContext.UserCode;//ddlEmployee.SelectedValue as string;
                            item.Createuser = GlobalContext.UserCode;

                        }

                        string messageStatus = string.Empty;
                        // save data to server.
                        var documentNo = ServiceHelper.MobileServices.AddHandHeldCounterHold(GlobalContext.BranchCode, products.ToArray());
                        var message = ServiceHelper.MobileServices.AddHandHeldCounter(GlobalContext.BranchCode, documentNo, false, out messageStatus);

                        //lblMessage.Text = messageStatus;
                        //lblMessage.Visible = true;
                        if (message.IndexOf("true") > -1)
                        {
                            GlobalMessageBox.ShowInfomation(message);
                        }
                        else if (message.IndexOf("false") > -1)
                        {
                            if (GlobalMessageBox.ShowQuestion(message) == DialogResult.Yes)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                message = ServiceHelper.MobileServices.AddHandHeldCounter(GlobalContext.BranchCode, documentNo, true, out messageStatus);
                                GlobalMessageBox.ShowInfomation(message);
                            }
                            else
                            {
                                this.ClearControlBinding();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        GlobalMessageBox.ShowError(ex);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //var oForm = new ChooseFromListForm((Array)ddlEmployee.DataSource, "Code", "Name");
            //if (oForm.ShowDialog() == DialogResult.OK)
            //{
            //    this.ddlEmployee.SelectedValue = oForm.SelectedValue;
            //}
            //txtProductOrBarcode.Focus();
        }

        private void CountStockForm_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void grdLocations_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {

        }

        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new NumericKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtScan.Text = oForm.Tag as string;
                txtScan.Focus();
            }
        }

    }
}