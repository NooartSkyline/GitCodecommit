using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DoHome.HandHeld.Client.DataAccess;

namespace DoHome.HandHeld.Client
{
    public partial class LabelLocationForm : Form
    {
        #region Field

        List<LabelLocation> _labelLocation;



        #endregion

        #region Method

        private void PrepareForm()
        {
            _labelLocation = new List<LabelLocation>();
            tbLocationCode.Focus();
            tbRequestor.Text = string.Format("{0} : {1}", GlobalContext.UserCode, GlobalContext.UserName);
        }

        private void AddLocationCode(string locationCode)
        {
            _labelLocation.Add(new LabelLocation
            {
                Id = _labelLocation.Count + 1,
                LocationCode = locationCode
            });
            this.BindGridview();
        }

        private void BindGridview()
        {
            this.grdLocations.DataSource = _labelLocation;
        }

        #endregion

        public LabelLocationForm()
        {
            InitializeComponent();
        }

        private void RequestLocationLabelSuperForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.PrepareForm();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void btnRequestList_Click(object sender, EventArgs e)
        {
            // open list form.
            new LabelLocationViewForm().ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_labelLocation == null || _labelLocation.Count <= 0)
            {
                GlobalMessageBox.ShowInfomation("ระบุตำแหน่งก่อนทำการบันทึก");
                return;
            }
            if (string.IsNullOrEmpty(cmbPrintType.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกประเภทป้าย");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            var list = new List<PrintLabelLocationDetail>();
            foreach (var item in _labelLocation)
            {
                //RequestLocationLabelSuperManager.Add(item.LocationCode, GlobalContext.UserCode, GlobalContext.WarehouseCode);
                list.Add(new PrintLabelLocationDetail() { LocationCode = item.LocationCode });
            }

            var docno = ServiceHelper.MobileServices.PrintLabelLocationAdd(GlobalContext.BranchCode, GlobalContext.WarehouseCode,
                      GlobalContext.UserCode, cmbPrintType.Text, list.ToArray());

            _labelLocation.Clear();
            grdLocations.DataSource = null;
            Cursor.Current = Cursors.Default;
            GlobalMessageBox.ShowInfomation(string.Format("บันทึกข้อมูล เสร็จเรียบร้อยแล้ว\nเลขที่เอกสารที่ได้คือ\n{0}", docno));
            tbLocationCode.Text = null;
            tbLocationCode.Focus();
        }

        private void grdLocations_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {
            //click on delete column
            if (e.Cell.ColumnIndex == 2)
            {
                if (GlobalMessageBox.ShowQuestion("คุณต้องลบรายการ ใช่หรือไม่") == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(grdLocations.Cells[e.Cell.RowIndex, 0].Text);
                    _labelLocation.RemoveAll(p => p.Id == id);
                    this.BindGridview();
                }
            }
        }

        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new LocationKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                tbLocationCode.Text = oForm.Tag as string;
                tbLocationCode.Focus();
            }
        }

        private void tbLocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string barcode = tbLocationCode.Text;
                if (string.IsNullOrEmpty(barcode))
                    barcode = CeReader.Barcode.Scan();
                tbLocationCode.Text = barcode;

                var locationCode = tbLocationCode.Text.ToUpper().Trim();
                tbLocationCode.Text = locationCode;
                if (locationCode.Length != 10)
                {
                    GlobalMessageBox.ShowInfomation("ระบุตำแหน่งไม่ถูกต้อง กรุณาตรวจสอบอีกครั้ง");
                    return;
                }

                if (Utils.CheckLocationIsLocation(locationCode))
                {
                    AddLocationCode(locationCode);
                    //tbLocationCode.SelectAll();
                    tbLocationCode.Text = "";
                }
            }
        }
    }
}