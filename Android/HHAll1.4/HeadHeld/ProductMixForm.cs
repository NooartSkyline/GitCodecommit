using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using DoHome.HandHeld.Client.DataAccess;

namespace DoHome.HandHeld.Client
{
    public partial class ProductMixForm : Form
    {
        public bool OfflineMode { get { return chkOffline.Checked; } }

        private void BindLocationData()
        {
            var locationCode = txtLocationCode.Text.ToUpper();
            if (locationCode.IndexOf(Convert.ToChar(".")) > -1)
            {
                txtLocationCode.Text = null;
                txtLocationCode.Focus();
                return;
            }
            else if (Utils.CheckIsDigitOnly(locationCode))
            {
                txtLocationCode.Text = null;
                txtLocationCode.Focus();
                return;
            }

            try
            {
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
                        return;
                    }
                    txtLocationCode.Text = location.Code;
                }
                else { txtLocationCode.Text = locationCode; }

                //chkOffline.Enabled = false;
                txtLocationCode.Enabled = false;
                txtBarcode.Enabled = true;
                txtEmployeeCode.Enabled = true;
                btnSearchUser.Enabled = true;
                txtBarcode.Focus();
            }
            catch (Exception ex) { GlobalMessageBox.ShowError(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void BindGrid()
        {
            var barcode = txtBarcode.Text;

            if (string.IsNullOrEmpty(barcode))
            {
                GlobalMessageBox.ShowInfomation("กรุณาระบุบาร์โค้ดสินค้า ก่อนทำการค้นหา");
                txtBarcode.Focus();
                return;
            }
            else if (barcode.IndexOf(Convert.ToChar(".")) > -1)
            {
                // if price no scan.
                txtBarcode.Text = null;
                return;
            }
            else if (Utils.CheckLocationIsLocation(barcode))
            {  
                // if location no scan.
                txtBarcode.Text = null;
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (bsProductLocation.DataSource == null)
                    bsProductLocation.DataSource = new List<ProductLocation>();

                ProductLocation productLocation = null;
                if (!OfflineMode)
                {
                    var isWarehouse = GlobalContext.UseInPlaces == UseInPlaces.WAREHOUSE ? true : false;
                    productLocation = ServiceHelper.MobileServices.ProductLocationGetByBarcode(txtBarcode.Text.Trim(), txtLocationCode.Text, GlobalContext.WarehouseCode, GlobalContext.BranchCode, isWarehouse);
                }
                else
                {
                    productLocation = new ProductLocation();
                    productLocation.ProductBarcode = txtBarcode.Text.Trim();
                    productLocation.StatusText = "Offline";
                }
                if (productLocation != null)
                {

                    var productLocations = (List<ProductLocation>)bsProductLocation.DataSource;
                    if (productLocations.Find(p => p.ProductBarcode == productLocation.ProductBarcode) != null)
                    {
                        GlobalMessageBox.ShowInfomation("มีสินค้านี้อยู่ในรายการแล้ว");
                    }
                    else
                    {
                        ((List<ProductLocation>)bsProductLocation.DataSource).Add(productLocation);
                        bsProductLocation.ResetBindings(false);
                    }

                    this.btnSave.Enabled = true;
                }

                this.txtBarcode.Text = null;
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex.Message);
            }
            finally { Cursor.Current = Cursors.Default; }
        }

        public ProductMixForm()
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

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text;
                if (string.IsNullOrEmpty(barcode))
                    barcode = CeReader.Barcode.Scan();
                txtBarcode.Text = barcode;
                this.BindGrid();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtLocationCode.Text = null;

            this.txtLocationCode.Enabled = true;
            this.chkOffline.Enabled = true;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Text = null;
            this.txtEmployeeCode.Enabled = false;
            this.txtEmployeeCode.Text = null;
            this.txtEmployeeName.Text = null;
            this.btnSearchUser.Enabled = false;
            this.bsProductLocation.DataSource = null;
            this.bsProductLocation.ResetBindings(false);
            this.btnSave.Enabled = false;

            this.txtLocationCode.Focus();
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
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกพนักงานประจำล็อก ก่อนทำการบันทึก");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var productLocations = (List<ProductLocation>)bsProductLocation.DataSource;
                foreach (var item in productLocations)
                {
                    item.OfficerID = txtEmployeeCode.Text.Trim();
                }

                if (OfflineMode)
                {
                    using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                    {
                        con.Open();

                        using (SqlCeCommand com = new SqlCeCommand())
                        {
                            com.Connection = con;
                            IDbTransaction trans = con.BeginTransaction(IsolationLevel.Serializable);
                            try
                            {
                                var locationCode = txtLocationCode.Text.Trim();
                                com.CommandText = SqlHelper.GetSql(30);
                                com.Parameters.AddWithValue("@LocationCode", locationCode);
                                com.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);
                                com.ExecuteNonQuery();


                                com.CommandText = SqlHelper.GetSql(31);
                                var displayOrder = 0;
                                foreach (var item in productLocations)
                                {
                                    com.Parameters.Clear();
                                    com.Parameters.AddWithValue("@LocationCode", locationCode);
                                    com.Parameters.AddWithValue("@BranchCode", GlobalContext.BranchCode);
                                    com.Parameters.AddWithValue("@WarehouseCode", GlobalContext.WarehouseCode);
                                    com.Parameters.AddWithValue("@DisplayOrder", displayOrder);
                                    com.Parameters.AddWithValue("@Barcode", item.ProductBarcode);
                                    com.Parameters.AddWithValue("@OfficerId", item.OfficerID);
                                    com.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);
                                    com.ExecuteNonQuery();

                                    displayOrder++;
                                }
                                trans.Commit();
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    ServiceHelper.MobileServices.ProductLocationMixAdd(GlobalContext.BranchCode,
                       GlobalContext.WarehouseCode,
                       GlobalContext.UserCode,
                       productLocations.ToArray());
                }
                //GlobalMessageBox.ShowInfomation("บันทึกข้อมูลเรียบร้อยแล้ว");
                btnClear_Click(sender, e);
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

        private void gvProduct_CustomizeCell(object sender, Resco.Controls.SmartGrid.CustomizeCellEventArgs e)
        {
            if (!e.Cell.Header)
            {
                if (e.Cell.ColumnIndex == 0)
                {
                    if ((e.Cell.Data as string) == "ไม่พบ")
                        e.Cell.Style = this.gvProduct.Styles["styleRed"];
                    else
                        e.Cell.Style = this.gvProduct.Styles["styleBlack"];
                }
            }
        }

        private void chkOffline_CheckStateChanged(object sender, EventArgs e)
        {
            txtLocationCode.Focus();
        }

        private void ProductMixForm_Load(object sender, EventArgs e)
        {
            //chkOffline.Checked = true;
        }

        private void btnOffLineView_Click(object sender, EventArgs e)
        {
            var oForm = new ProductMixedOfflineForm();
            oForm.ShowDialog();
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
                txtBarcode.Text = oForm.Tag as string;
                txtBarcode.Focus();
            }
        }


    }
}