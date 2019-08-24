﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataGridCustomColumns;
using DoHome.HandHeld.Client.DataAccess;

namespace DoHome.HandHeld.Client
{
    public partial class LocationCheckForm2 : Form
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
                var locationCode = txtLocationCode.Text.Trim().ToUpper();
                if (Utils.CheckIsDigitOnly(locationCode))
                {
                    txtLocationCode.Text = null;
                    txtLocationCode.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                if (!OfflineMode)
                {
                    var EndPoint = GlobalContext.ServerEndpointAddress;
                    var ServiceUrl = GlobalContext.remoteAddress;
                    var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
                    cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
                    var location = cnn.LocationGetByCode(locationCode, GlobalContext.WarehouseCode);
                    if (location == null)
                    {
                        GlobalMessageBox.ShowInfomation("ไม่พบตำแหน่งจัดเก็บสินค้านี้ ในระบบ");
                        txtLocationCode.Text = null;
                        txtLocationCode.Focus();
                        return;
                    }

                    if (!CheckIsCreateLocationToday())
                        return;
                }

                txtLocationCode.Text = locationCode;
                txtLocationCode.Enabled = false;
                btnSearchUser.Enabled = true;
                smartGridDesc.Enabled = true;
                btnSave.Enabled = true;
                txtEmployeeCode.Enabled = true;
                chkCheckAll.Enabled = true;
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex.Message);
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void BindLocationAgenda()
        {
            this.bsAgenda.DataSource = LocationCheckManager.LocationCheckAgendaGetAllActive(); ;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtEmployeeCode.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกพนักงานประจำล็อก ก่อนทำการบันทึก");
                txtEmployeeCode.Focus();
                return false;
            }

            return true;
        }

        private void Add()
        {
            if (this.ValidateForm())
            {
                try
                {

                    if (OfflineMode)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var agenda = (List<LocationCheckPeriodAgenda>)bsAgenda.DataSource;
                        LocationCheckManager.Add(txtLocationCode.Text.Trim()
                            , txtEmployeeCode.Text.Trim()
                            , agenda);
                    }
                    else
                    {
                        var locationCheck = new LocationCheck();
                        locationCheck.Location = txtLocationCode.Text.Trim();
                        locationCheck.OfficerCode = txtEmployeeCode.Text.Trim();
                        locationCheck.CheckerCode = GlobalContext.UserCode;
                        locationCheck.WarehouseCode = GlobalContext.WarehouseCode;
                        locationCheck.PeriodId = LocationCheckManager.GetCurrentPeriodId();
                        locationCheck.PeriodIdSpecified = true;

                        var locationCheckDetail = new List<LocationCheckDetail>();
                        var agenda = (List<LocationCheckPeriodAgenda>)bsAgenda.DataSource;
                        foreach (var item in agenda)
                        {
                            locationCheckDetail.Add(new LocationCheckDetail
                            {
                                PeriodAgendaId = item.AgendaTemplateId,
                                PeriodAgendaIdSpecified = true,
                                AgendaValue = item.CheckedValue,
                                IsChecked = item.Checked,
                                IsCheckedSpecified = true,

                            });
                        }

                        ServiceHelper.MobileServices.LocationCheckAdd(GlobalContext.BranchCode, locationCheck, locationCheckDetail.ToArray());
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    var message = "เกิดข้อผิดพลาดในการบันทึกข้อมูล ดังนี้ \n" + ex.Message;
                    GlobalMessageBox.ShowError(message);
                }

                //clear controls
                this.ClearBindingControl();
            }

        }

        private void ClearBindingControl()
        {
            this.txtLocationCode.Text = null;
            this.txtLocationCode.Enabled = true;
            this.txtEmployeeCode.Text = null;
            txtEmployeeCode.Enabled = false;
            this.txtEmployeeName.Text = null;
            this.btnSearchUser.Enabled = false;
            this.btnSave.Enabled = false;
            this.chkCheckAll.Checked = false;

            var agenda = (List<LocationCheckPeriodAgenda>)bsAgenda.DataSource;
            foreach (var item in agenda)
            {
                item.Checked = false;
                if (item.IsValue)
                    item.CheckedValue = "0";
                else
                    item.CheckedValue = "";
            }
            bsAgenda.ResetBindings(false);
            smartGridDesc.Enabled = false;

            this.txtLocationCode.Focus();
        }

        private bool CheckIsCreateLocationToday()
        {

            var locationCode = txtLocationCode.Text.Trim();
            bool checkIsCreateLocationToday = false;
            checkIsCreateLocationToday =ServiceHelper.MobileServices.CheckIsCreateLocationToday(GlobalContext.BranchCode, locationCode
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

        public LocationCheckForm2()
        {
            InitializeComponent();
        }

        private void txtLocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtLocationCode.Text;
                if (string.IsNullOrEmpty(barcode))
                    barcode = CeReader.Barcode.Scan();
                txtLocationCode.Text = barcode;
                BindLocationData();
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
                var displayList = ServiceHelper.MobileServices.DisplayListGetByLocationCheck(GlobalContext.BranchCode, GlobalContext.UserCode);
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
            try
            {
                Add();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void ProductCheckPriceForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                txtLocationCode.Focus();
                this.BindLocationAgenda();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                throw ex;
            }
        }

        private void smartGridDesc_CheckBoxEdit(object sender, Resco.Controls.SmartGrid.CheckBoxEditEventArgs e)
        {

            var cell = this.smartGridDesc.SelectedCell;
            if (smartGridDesc.Cells[cell.RowIndex, 3].Style.Name == "Number")
            {
                if (e.OldState == false)
                {

                    var cellPoint = smartGridDesc.Cells[cell.RowIndex, 3].Data;
                    var oForm = new InputNumberForm();
                    oForm.SelectedValue = cellPoint as string;
                    if (oForm.ShowDialog() == DialogResult.OK)
                    {
                        if (string.IsNullOrEmpty(oForm.SelectedValue))
                            oForm.SelectedValue = "0";
                        smartGridDesc.Cells[cell.RowIndex, 3].Data = oForm.SelectedValue;
                        smartGridDesc.Cells[cell.RowIndex, 1].Data = true;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    smartGridDesc.Cells[cell.RowIndex, 3].Data = 0;
                    smartGridDesc.Cells[cell.RowIndex, 1].Data = false;
                }
            }

            smartGridDesc.UpdateLayout();
        }

        private void smartGridDesc_CustomizeCell(object sender, Resco.Controls.SmartGrid.CustomizeCellEventArgs e)
        {
            try
            {
                var cell = e.Cell;
                if (cell.ColumnIndex == 3)
                {
                    if (cell.Text != "")
                        cell.Style = this.smartGridDesc.Styles["Number"];
                }
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
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

        private void txtEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchUser_Click(sender, e);
        }

        private void btnOfflineToSap_Click(object sender, EventArgs e)
        {
            try
            {
                new LocationCheckOfflineForm().ShowDialog();

            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void chkOffline_CheckStateChanged(object sender, EventArgs e)
        {
            txtLocationCode.Focus();
        }

        private void chkCheckAll_CheckStateChanged(object sender, EventArgs e)
        {
            foreach (Resco.Controls.SmartGrid.Row item in smartGridDesc.Rows)
                ((LocationCheckPeriodAgenda)item.Data).Checked = chkCheckAll.Checked;
            
            // rebind
            bsAgenda.ResetBindings(false);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new LocationKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtLocationCode.Text = oForm.Tag as string;
            }
        }


    }
}