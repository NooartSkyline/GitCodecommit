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
    public partial class OrderedSetForm : Form
    {
        #region Method

        private void PrepareDropdownShippoint()
        {
            cmbShippoint.DisplayMember = "ShippointName";
            cmbShippoint.ValueMember = "ShippointCode";
            cmbShippoint.DataSource = ServiceHelper.MobileServices.OrderedSetGetForkLiftShippointByBranch(GlobalContext.BranchCode);
            GlobalContext.ShippointCode = cmbShippoint.SelectedValue as string;
        }

        private void BindGridview()
        {
            bindingSourceForklift.DataSource = ServiceHelper.MobileServices.OrderedSetGetForkleftAll(GlobalContext.BranchCode, GlobalContext.ShippointCode).ToList<ForkLift>();
            bindingSourceForklift.ResetBindings(false);
        }

        #endregion

        public OrderedSetForm()
        {
            InitializeComponent();
        }

        private void tbSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var barcode = tbOrderNo.Text.Trim();
                    if (string.IsNullOrEmpty(barcode))
                        barcode = CeReader.Barcode.Scan();

                    if (string.IsNullOrEmpty(barcode))
                    {
                        GlobalMessageBox.ShowWarnning("กรุณาระบุเลขที่เอกสาร");
                        return;
                    }
                    else
                    {
                        if (barcode.Length > 10)
                            barcode = barcode.Substring(0, 10);

                        tbOrderNo.Text = barcode;
                        var order = ServiceHelper.MobileServices.OrderedSetGetByOrderNo(barcode);
                        if (order != null)
                        {
                            Cursor.Current = Cursors.Default;
                            new OrderedInfoForm(order).ShowDialog();
                            btnNew_Click(null, null);
                            return;
                        }

                        tbOrderNo.Text = barcode;
                        tbOrderNo.ReadOnly = true;
                        tbOrderNo.BackColor = Color.FromArgb(255, 255, 192);
                        btnSave.Enabled = true;
                        grdForkLift.Enabled = true;
                    }
                }
                catch (Exception ex)
                { GlobalMessageBox.ShowError(ex.Message); }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            tbOrderNo.ReadOnly = false;
            tbOrderNo.BackColor = Color.FromArgb(255, 255, 255);
            tbOrderNo.Text = "";
            tbOrderNo.Focus();
            grdForkLift.Enabled = false;
        }

        private void OrderedSetForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PrepareDropdownShippoint();
                //BindGridview();
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

        private void grdForkLift_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {
            try
            {
                var forklifts = (List<ForkLift>)bindingSourceForklift.DataSource;
                foreach (var item in forklifts)
                {
                    item.IsSelected = false;
                }

                var forklift = forklifts.Find(p => p.ForkliftNumber == grdForkLift.Cells[e.Cell.RowIndex, 1].Text);
                if (forklift != null)
                {
                    forklift.IsSelected = true;
                }

                bindingSourceForklift.ResetBindings(false);
            }
            catch (Exception ex)
            { GlobalMessageBox.ShowError(ex); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var forklifts = (List<ForkLift>)bindingSourceForklift.DataSource;

                var forklift = forklifts.Find(p => p.IsSelected);
                if (forklift != null)
                {
                    forklift.IsSelected = true;

                    var orderedSet = new OrderedSet();
                    orderedSet.OrderNo = tbOrderNo.Text.Trim();
                    orderedSet.ForkliftNumber = forklift.ForkliftNumber;
                    orderedSet.DriverName = forklift.DriverName;
                    orderedSet.CreatedBy = string.Format("{0}:{1}", GlobalContext.UserCode, GlobalContext.UserName);
                    orderedSet.BranchCode = GlobalContext.BranchCode;
                    orderedSet.ShippointCode = GlobalContext.ShippointCode;
                    ServiceHelper.MobileServices.OrderedSetAdd(orderedSet);
                    Cursor.Current = Cursors.Default;
                    GlobalMessageBox.ShowInfomation("บันทึกการจ่ายใบจัด เรียบร้อย");
                    foreach (var item in forklifts)
                    {
                        item.IsSelected = false;
                    }
                    bindingSourceForklift.ResetBindings(false);
                    btnSave.Enabled = false;
                    btnNew_Click(null, null);
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    GlobalMessageBox.ShowWarnning("กรุณาเลือกรถ เพื่อใช้กับใบจัดนี้");
                }
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //}
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                var oForm = new OrderedSetCloseForm();
                oForm.ShowDialog();
                btnNew_Click(null, null);
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var oForm = new OrderedSetListForm();
            oForm.ShowDialog();
            tbOrderNo.Focus();
        }

        private void cmbShippoint_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GlobalContext.ShippointCode = cmbShippoint.SelectedValue as string;
                BindGridview();
                tbOrderNo.Focus();
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