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
    public partial class CountStockMainForm : Form
    {

        private void PrepareDropdown()
        {
            ddlCounterBill.ValueMember = "gjahr";
            ddlCounterBill.DisplayMember = "iblnr";
            ZMMInvoiceCnTh[] zMMInvoiceCnThList = ServiceHelper.MobileServices.GetHandHeldCounterMainHoldZMMInvoiceCnThFromSap(GlobalContext.UserCode);
            ddlCounterBill.DataSource = zMMInvoiceCnThList;
        }

        private void BindGrid()
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (ddlCounterBill.SelectedValue == null)
                {
                    GlobalMessageBox.ShowInfomation("กรุณาเลือกเลขที่ใบนับ");
                    return;
                }


                var counterDocumentNo = ddlCounterBill.Text;
                var accountingYear = ddlCounterBill.SelectedValue as string;

                var zddList = ServiceHelper.MobileServices.GetHandHeldCounterMainHoldZDDHandHeldCheckStockFromSap(GlobalContext.BranchCode, counterDocumentNo
                    , accountingYear
                    , GlobalContext.UserCode);

                bindingSource.DataSource = zddList;
                ddlCounterBill.Enabled = false;
                this.btnSearch.Enabled = false;

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

        private void HoldBill()
        {
            if (IsValidateForm)
            {
                if (GlobalMessageBox.ShowQuestion("คุณต้องการพักบิลเอกสารนี้ ใช่หรือไม่") == DialogResult.Yes)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        var counterHolds = (HandHeldCounterMainHold[])bindingSource.DataSource;

                        foreach (var item in counterHolds)
                        {
                            item.Createuser = GlobalContext.UserCode;
                            item.ErfmgSalesSpecified = true;
                            item.ErfmgSkuSpecified = true;
                        }

                        // save data to server.
                        ServiceHelper.MobileServices.AddHandHeldCounterMainHold(GlobalContext.BranchCode, counterHolds);

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

        private void ClearControlBinding()
        {
            ddlCounterBill.Enabled = true;
            this.btnSearch.Enabled = true;
            bindingSource.DataSource = null;
            bindingSource.ResetBindings(false);
        }

        private bool IsValidateForm
        {
            get
            {
                if (ddlCounterBill.SelectedValue == null)
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุเอกสารการตรวจนับสินค้าคงคลัง");
                    return false;
                }
                if (dgProduct.VisibleRowCount <= 0)
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุรายการสินค้า ก่อนบันทึกข้อมูล");
                    return false;
                }

                return true;

            }
        }

        public CountStockMainForm()
        {
            InitializeComponent();
        }

        private void txtProductOrBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindGrid();
            }

        }

        private void CountStockForm_Load(object sender, EventArgs e)
        {
            this.PrepareDropdown();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ClearControlBinding();
        }

        private void btnHoldBill_Click(object sender, EventArgs e)
        {
            this.HoldBill();
        }

        private void dgProduct_Click(object sender, EventArgs e)
        {
            int rowIndex = dgProduct.CurrentRowIndex;
            if (rowIndex >= 0)
            {
                dgProduct.Select(rowIndex);
            }
        }

        private void btnResumeBill_Click(object sender, EventArgs e)
        {
            var bills = ServiceHelper.MobileServices.GetHandHeldCounterMainHoldBillByUser(GlobalContext.BranchCode, GlobalContext.UserCode);
            var oForm = new ChooseFromListForm(bills, "Iblnr", "Docno");
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                ddlCounterBill.Text = oForm.SelectedValue;

                var counterHolds = ServiceHelper.MobileServices.GetHandHeldCounterMainHoldByDocumentNo(GlobalContext.BranchCode, oForm.SelectedText);
                bindingSource.DataSource = counterHolds;
                bindingSource.ResetBindings(false);
                ddlCounterBill.Enabled = false;
                btnSearch.Enabled = false;
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
            int rowIndex = dgProduct.CurrentRowIndex;
            if (rowIndex >= 0)
            {
                var oForm = new CountStockMainQuantityForm();
                oForm.ValueQuantitySales = Utils.DecimalParse(dgProduct[rowIndex, 4].ToString());
                oForm.ValueQuantityStock = Utils.DecimalParse(dgProduct[rowIndex, 6].ToString());
                oForm.ValueUnitSales = dgProduct[rowIndex, 5] as string;
                oForm.ValueUnitStock = dgProduct[rowIndex, 7] as string;
                oForm.ValueProductName = dgProduct[rowIndex, 3] as string;
                if (oForm.ShowDialog() == DialogResult.OK)
                {
                    dgProduct[rowIndex, 4] = oForm.ValueQuantitySales;
                    dgProduct[rowIndex, 6] = oForm.ValueQuantityStock;

                }

                bindingSource.ResetBindings(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidateForm)
            {
                var oForm = new CountStockMainSaveForm();

                if (oForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        var counterHolds = (HandHeldCounterMainHold[])bindingSource.DataSource;

                        foreach (var item in counterHolds)
                        {
                            item.Createuser = GlobalContext.UserCode;
                            item.ErfmgSalesSpecified = true;
                            item.ErfmgSkuSpecified = true;
                        }

                        // save data to server.
                        var documentNo = ServiceHelper.MobileServices.AddHandHeldCounterMainHold(GlobalContext.BranchCode, counterHolds);

                        if (oForm.ValueIsMajor)
                        {
                            var majorCounter1 = oForm.ValueMajorCounter1;
                            var majorCounter2 = oForm.ValueMajorCounter2;

                            ServiceHelper.MobileServices.AddMajorHandHeldCounterMainHoldToSap(GlobalContext.BranchCode, documentNo
                                , majorCounter1
                                , majorCounter2);
                        }
                        else
                        {
                            var officerID1 = oForm.ValueOfficer1;
                            var officerID2 = oForm.ValueOfficer2;
                            var officerID3 = oForm.ValueOfficer3;
                            var officerID4 = oForm.ValueOfficer4;

                            ServiceHelper.MobileServices.AddMinorHandHeldCounterMainHoldToSap(documentNo
                                , officerID1
                                , officerID2
                                , officerID3
                                , officerID4
                                , GlobalContext.WarehouseCode
                                , GlobalContext.BranchCode);
                        }

                        GlobalMessageBox.ShowInfomation("บันทึกข้อมูลเรียบร้อย");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


    }
}