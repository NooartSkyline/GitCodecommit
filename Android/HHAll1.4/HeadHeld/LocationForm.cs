using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client
{
    public partial class LocationForm : Form
    {
        #region Field

        private int _currentRowIndex = 0;

        #endregion

        #region Method

        private void GridSelected()
        {
            if (dgLocation.VisibleRowCount > 0)
                dgLocation.Select(_currentRowIndex);
        }

        #endregion

        public bool OfflineMode
        {
            get
            {
                return chkOffline.Checked;

            }
        }

        private void BindData()
        {
            if (OfflineMode)
            {
                txtLocationCodeScan.Text = txtLocationCodeScan.Text.ToUpper().Trim();
                txtLocationCodeScan.ReadOnly = true;
                btnAdd.Enabled = true;
                btnInsert.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnSave.Enabled = true;
                chkOffline.Enabled = false;
            }
            else
            {
            var EndPoint = GlobalContext.ServerEndpointAddress;
            var ServiceUrl = GlobalContext.remoteAddress;
            try
            {
                //เรียกแบบ ธรรมดาจะสามารถแก้ไข CFF ERROR ได้
                var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
                cnn.Url  = ServiceUrl.Replace("localhost", EndPoint);
                var location = cnn.LocationGetByCode(txtLocationCodeScan.Text.Trim().ToUpper(), GlobalContext.WarehouseCode);
                //var location = ServiceHelper.MobileServices.LocationGetByCode(txtLocationCodeScan.Text.Trim().ToUpper(), GlobalContext.WarehouseCode);
                txtLocationCodeScan.Text = null;
                if (location != null)
                {
                    txtLocationCodeScan.Text = location.Code;
                    txtLocationCodeScan.ReadOnly = true;
                    btnAdd.Enabled = true;
                    btnInsert.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDeleteAll.Enabled = true;
                    btnSave.Enabled = true;
                    chkOffline.Enabled = true;
                    List<ProductLocation> productLocations = new List<ProductLocation>();
                   // var productLocationResult = cnn.ProductLocationGetByLocation(GlobalContext.BranchCode, txtLocationCodeScan.Text, GlobalContext.WarehouseCode);
                    var productLocationResult = ServiceHelper.MobileServices.ProductLocationGetByLocation(GlobalContext.BranchCode, txtLocationCodeScan.Text, GlobalContext.WarehouseCode);
                    if (productLocationResult.Length >= 0)
                    {
                        productLocations.AddRange(productLocationResult);
                        //foreach (var item in productLocationResult)
                        //{
                        //    productLocations.Add(new ProductLocation
                        //                {
                        //                   BalanceQuantity = item.BalanceQuantity ,
                        //                   BalanceQuantitySpecified = item.BalanceQuantitySpecified,
                        //                    BalanceQuantityText = item.BalanceQuantityText,
                        //                     CreateDate = item.CreateDate,
                        //                      CreateDateSpecified = item.CreateDateSpecified,
                        //                       DisplayOrder = item.DisplayOrder,
                        //                        DisplayOrderSpecified = item.DisplayOrderSpecified,
                        //                         DocumentDate = item.DocumentDate,
                        //                          DocumentDateSpecified = item.DocumentDateSpecified,
                        //                           DocumentNo = item.DocumentNo,
                        //                            LocationCode = item.LocationCode,
                        //                             LocationStatus = item.LocationStatus,
                        //                              LocationType = item.LocationType,
                        //                               MaxStock = item.MaxStock,
                        //                                MaxStockSpecified = item.MaxStockSpecified,
                        //                                 OfficerID = item.OfficerID,
                        //                                  PriceStatus = item.PriceStatus,
                        //                                   ProductBarcode = item.ProductBarcode,
                        //                                    ProductCode = item.ProductCode,
                        //                                     ProductName = item.ProductName,
                        //                                      ProductUnitCode = item.ProductUnitCode,
                        //                                       ProductUnitName = item.ProductUnitName,
                        //                                        PutDeep = item.PutDeep,
                        //                                         PutDeepSpecified = item.PutDeepSpecified,
                        //                                          PutLevel = item.PutLevel,
                        //                                           PutLevelSpecified = item.PutLevelSpecified,
                        //                                            PutQuantity = item.PutQuantity,
                        //                                             PutQuantitySpecified = item.PutQuantitySpecified,
                        //                                              RandomText = item.RandomText,
                        //                                               Remark = item.Remark,
                        //                                                RequestPrintLabel = item.RequestPrintLabel,
                        //                                                 RequestPrintLabelSpecified = item.RequestPrintLabelSpecified,
                        //                                                  SalePrice = item.SalePrice,
                        //                                                   SalePriceSpecified = item.SalePriceSpecified,
                        //                                                    ShopPrice = item.ShopPrice,
                        //                                                     ShopPriceSpecified = item.ShopPriceSpecified,
                        //                                                      StatusText = item.StatusText,
                        //                                                       UserID = item.UserID,
                        //                                                        WarehouseCode = item.WarehouseCode,
                        //                                                         WarehouseName = item.WarehouseName
                        //                }
                        //               );
                        //}
                        bsLocation.DataSource = productLocations;
                        _currentRowIndex = 0;
                        GridSelected();
                    }
                }
                else 
                {
                    MessageBox.Show("ไม่พบตำแหน่งนี้ในระบบ");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
            }
        }

        private void PrepareSave()
        {
            bsLocation.ResumeBinding();
            var productLocations = (List<ProductLocation>)bsLocation.DataSource;
            var remark = cmbLabelType.Text;
            int displayOrder = 1;
            foreach (var item in productLocations)
            {
                item.LocationCode = txtLocationCodeScan.Text;
                item.LocationType = Utils.GetLocationTypeByLocationCode(item.LocationCode);
                item.WarehouseCode = GlobalContext.WarehouseCode;
                item.DisplayOrderSpecified = true;
                item.PutQuantitySpecified = true;
                item.PutLevelSpecified = true;
                item.Remark = remark;
                item.MaxStockSpecified = true;
                item.RequestPrintLabelSpecified = true;
                item.UserID = GlobalContext.UserCode;
                item.DisplayOrder = displayOrder;
                displayOrder++;
            }

            //this.Reindex();
        }

        private void Reindex()
        {

            var productLocations = (List<ProductLocation>)bsLocation.DataSource;
            int displayOrder = 1;
            foreach (var item in productLocations)
            {
                item.DisplayOrder = displayOrder;
                displayOrder++;
            }

        }

        private void AddOnLineMode()
        {
            var productLocations = (List<ProductLocation>)bsLocation.DataSource;
            if (productLocations.Exists(p => p.RequestPrintLabel) && cmbLabelType.SelectedIndex == 0)
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกประเภทป้าย\nก่อนบันทึกข้อมูล");
                return;
            }

            if (GlobalMessageBox.ShowQuestion("คุณต้องการบันทึกข้อมูล ใช่หรือไม่") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.PrepareSave();
                    string result = string.Empty;

                    productLocations = (List<ProductLocation>)bsLocation.DataSource;

                    result = ServiceHelper.MobileServices.ProductLocationAdd(GlobalContext.BranchCode, txtLocationCodeScan.Text.Trim()
                        , GlobalContext.WarehouseCode
                        , productLocations.ToArray());
                    if (!"ERROR".Equals(result))
                    {
                        string message = string.Empty;
                        if (result.Contains("PL"))
                        {
                            message = "บันทึกข้อมูลเรียบร้อย\nเลขที่เอกสารพิมพ์ป้ายที่ได้\n" + result;
                        }
                        else
                            message = "บันทึกข้อมูลเรียบร้อย";

                        GlobalMessageBox.ShowInfomation(message);
                        // call btnClear button
                        btnClear_Click(null, null);
                    }
                    else
                    {
                        GlobalMessageBox.ShowError("บันทึกข้อมูลไม่สำเร็จ กรุณาติดต่อผู้ดูแล");
                    }
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
        }

        private void AddOffLineMode()
        {
            var productLocations = (List<ProductLocation>)bsLocation.DataSource;
            if (productLocations.Exists(p => p.RequestPrintLabel) && cmbLabelType.SelectedIndex == 0)
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกประเภทป้าย\nก่อนบันทึกข้อมูล");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.PrepareSave();
                productLocations = (List<ProductLocation>)bsLocation.DataSource;
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();


                    using (SqlCeCommand cmd = new SqlCeCommand())
                    {
                        cmd.Connection = con;
                        IDbTransaction trans = con.BeginTransaction(IsolationLevel.Serializable);
                        try
                        {
                            var locationCode = txtLocationCodeScan.Text.Trim();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = SqlHelper.GetSql(48);
                            cmd.Parameters.AddWithValue("@LocationCode", locationCode);
                            cmd.Parameters.AddWithValue("@UserCode", GlobalContext.UserCode);
                            cmd.ExecuteScalar();
                            cmd.Parameters.Clear();

                            //get the last insert id
                            cmd.CommandText = "SELECT @@IDENTITY";
                            int id = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd.CommandText = SqlHelper.GetSql(49);
                            var displayOrder = 1;
                            foreach (var item in productLocations)
                            {
                                //com.Parameters.AddWithValue("@LocationCode", locationCode);
                                cmd.Parameters.AddWithValue("@LocationId", id);
                                cmd.Parameters.AddWithValue("@ProductCode", item.ProductCode);
                                cmd.Parameters.AddWithValue("@PutLevel", item.PutLevel);
                                cmd.Parameters.AddWithValue("@PutQty", item.PutQuantity);
                                cmd.Parameters.AddWithValue("@DisplayOrder", displayOrder);
                                //com.Parameters.AddWithValue("@UserCode", GlobalContext.UserCode);
                                cmd.Parameters.AddWithValue("@RequestPrintLabel", item.RequestPrintLabel);
                                cmd.Parameters.AddWithValue("@MaxStock", item.MaxStock);
                                if (item.Remark.Contains("เลือก"))
                                    item.Remark = string.Empty;
                                cmd.Parameters.AddWithValue("@PrintLabelType", item.Remark);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
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

                //GlobalMessageBox.ShowInfomation("บันทึกข้อมูลผูกตำแหน่งเรียบร้อย\n[Offline Mode] ");
                // call btnClear button
                btnClear_Click(null, null);

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

        public LocationForm()
        {
            InitializeComponent();
        }

        private void btnLevelAdd_Click(object sender, EventArgs e)
        {
            var oForm = new LocationProductForm(this.OfflineMode);
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                if (oForm.ProductLocation == null)
                    return;

                if (bsLocation.DataSource == null)
                    bsLocation.DataSource = new List<ProductLocation>();

                var location = oForm.ProductLocation;
                var locations = (List<ProductLocation>)bsLocation.DataSource;

                var productLocation = locations.Find(p => p.ProductCode == location.ProductCode);
                if (productLocation != null)// update
                {
                    if (GlobalMessageBox.ShowQuestion("มีสินค้านี้อยู่ในตำแหน่งแล้ว\nคุณต้องการแก้ไขสินค้านี้ ใช่หรือไม่ ?") == DialogResult.Yes)
                    {
                        productLocation.ProductBarcode = oForm.ProductLocation.ProductBarcode;
                        productLocation.ProductCode = oForm.ProductLocation.ProductCode;
                        productLocation.PutLevel = oForm.ProductLocation.PutLevel;
                        productLocation.ProductName = oForm.ProductLocation.ProductName;
                        productLocation.PutQuantity = oForm.ProductLocation.PutQuantity;
                        productLocation.ProductUnitCode = oForm.ProductLocation.ProductUnitCode;
                        productLocation.ProductUnitName = oForm.ProductLocation.ProductUnitName;
                        productLocation.RequestPrintLabel = oForm.ProductLocation.RequestPrintLabel;
                        productLocation.RequestPrintLabelSpecified = true;
                        productLocation.MaxStock = oForm.ProductLocation.MaxStock;
                        productLocation.MaxStockSpecified = true;

                        bsLocation.ResetBindings(false);
                        btnAdd.Focus();
                        return;
                    }
                    else
                        return;
                }
                else // add
                {
                    locations.Add(location);
                    bsLocation.ResetBindings(false);

                    this.Reindex();
                    btnLevelAdd_Click(sender, e);
                }


            }

            _currentRowIndex = dgLocation.VisibleRowCount - 1;
            GridSelected();
        }

        private bool CheckOddNumber(int number)
        {
            if ((number % 2) == 0)
                return false;
            else
                return true;
        }

        private void txtLocationCodeScan_KeyDown(object sender, KeyEventArgs e)
        {
            _currentRowIndex = 0;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    string barcode = txtLocationCodeScan.Text.ToUpper();
                    if (string.IsNullOrEmpty(barcode))
                        barcode = CeReader.Barcode.Scan();
                    txtLocationCodeScan.Text = barcode;

                    var locationCode = txtLocationCodeScan.Text;
                    if (locationCode.IndexOf(Convert.ToChar(".")) > -1)
                    {
                        // if price no scan.
                        Cursor.Current = Cursors.Default;
                        txtLocationCodeScan.Text = null;
                        txtLocationCodeScan.Focus();
                        return;
                    }
                    else if (Utils.CheckIsDigitOnly(locationCode))
                    {
                        // if barcode no scan.
                        Cursor.Current = Cursors.Default;
                        txtLocationCodeScan.Text = null;
                        txtLocationCodeScan.Focus();
                        return;
                    }
                    this.BindData();
                    Cursor.Current = Cursors.Default;
                    if (OfflineMode)
                    {
                        btnLevelAdd_Click(sender, e);
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbLabelType.SelectedIndex = 0;
            txtLocationCodeScan.ReadOnly = false;
            txtLocationCodeScan.Text = null;
            txtLocationCodeScan.Focus();
            btnAdd.Enabled = false;
            btnInsert.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnSave.Enabled = false;
            this.chkOffline.Enabled = true;
            //this.chkOffline.Checked = true;
            bsLocation.DataSource = null;
            bsLocation.ResetBindings(false);
            _currentRowIndex = 0;
        }

        private void LocationForm_Load(object sender, EventArgs e)
        {
            this.txtLocationCodeScan.Focus();
            this.cmbLabelType.SelectedIndex = 0;
        }

        private void mnuItemUp_Click(object sender, EventArgs e)
        {
            //var button = this._currentButtonLocation;

            //var currentIndex = panel2.Controls.GetChildIndex(button);
            //if (currentIndex > 0)
            //{
            //    var upIndex = currentIndex - 1;
            //    var currentButton = (Button)panel2.Controls[currentIndex];
            //    var currentProductLocation = currentButton.Tag;
            //    var upButton = (Button)panel2.Controls[upIndex];
            //    var upProductLocation = upButton.Tag;

            //    currentButton.Tag = upProductLocation;
            //    upButton.Tag = currentProductLocation;

            //    currentButton.Text = string.Format("({0}){1}+{2}", ((ProductLocation)currentButton.Tag).ProductLevel, ((ProductLocation)currentButton.Tag).ProductBarcode, ((ProductLocation)currentButton.Tag).ProductPin);
            //    upButton.Text = string.Format("({0}){1}+{2}", ((ProductLocation)upButton.Tag).ProductLevel, ((ProductLocation)upButton.Tag).ProductBarcode, ((ProductLocation)upButton.Tag).ProductPin);

            //    panel2.Refresh();
            //}
        }

        private void mnuItemDown_Click(object sender, EventArgs e)
        {
            //var button = this._currentButtonLocation;

            //var index = panel2.Controls.GetChildIndex(button);
            //if (index < (panel2.Controls.Count - 1))
            //{
            //    panel2.Controls.SetChildIndex(button, index - 1);
            //    panel2.Refresh();
            //}
        }

        private void mnuItemEdit_Click(object sender, EventArgs e)
        {
            //var button = this._currentButtonLocation;


            //var oForm = new LocationProductForm((ProductLocation)button.Tag);
            //if (oForm.ShowDialog() == DialogResult.OK)
            //{
            //    if (oForm.ProductLocation != null)
            //    {
            //        var productLocation = oForm.ProductLocation;
            //        button.Tag = productLocation;
            //        button.Text = string.Format("({0}){1}+{2}", ((ProductLocation)button.Tag).ProductLevel, ((ProductLocation)button.Tag).ProductBarcode, ((ProductLocation)button.Tag).ProductPin);

            //    }
            //    else
            //    {
            //        var index = panel2.Controls.GetChildIndex(button);
            //        panel2.Controls.RemoveAt(index);
            //    }
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgLocation.VisibleRowCount > 0)
            {
                var productCode = GetCurrentProductCode();
                var displayOrder = GetCurrentRowIndex();
                var locations = (List<ProductLocation>)bsLocation.DataSource;
                var localtion = locations.Find(p => p.ProductCode == productCode && p.DisplayOrder == displayOrder);
                //var location = localtion;
                var oForm = new LocationProductForm(localtion, OfflineMode);
                if (oForm.ShowDialog() == DialogResult.OK)
                {
                    if (oForm.ProductLocation != null)
                    {
                        //localtion = locations.Find(p => p.ProductBarcode == barcode);

                        //localtion = oForm.ProductLocation
                        localtion.ProductBarcode = oForm.ProductLocation.ProductBarcode;
                        localtion.ProductCode = oForm.ProductLocation.ProductCode;
                        localtion.PutLevel = oForm.ProductLocation.PutLevel;
                        localtion.ProductName = oForm.ProductLocation.ProductName;
                        localtion.PutQuantity = oForm.ProductLocation.PutQuantity;
                        localtion.ProductUnitCode = oForm.ProductLocation.ProductUnitCode;
                        localtion.ProductUnitName = oForm.ProductLocation.ProductUnitName;
                        localtion.RequestPrintLabel = oForm.ProductLocation.RequestPrintLabel;
                        localtion.RequestPrintLabelSpecified = true;
                        localtion.MaxStock = oForm.ProductLocation.MaxStock;
                        localtion.MaxStockSpecified = true;

                        bsLocation.ResetBindings(false);
                    }

                }

                GridSelected();
            }
        }

        private string GetCurrentProductCode()
        {
            var barcode = dgLocation[_currentRowIndex, 1] as string;
            return barcode;
        }

        private int GetCurrentRowIndex()
        {
            return Convert.ToInt32(dgLocation[dgLocation.CurrentCell.RowNumber, 0]);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgLocation.VisibleRowCount > 0)
            {
                var productCode = GetCurrentProductCode();
                var wranningMessage = string.Format("คุณต้องการลบสินค้า {0} ใช่หรือไม่", productCode);
                if (MessageBox.Show(wranningMessage, "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    var rowIndex = this.GetCurrentRowIndex();
                    var locations = (List<ProductLocation>)bsLocation.DataSource;
                    locations.RemoveAll(p => p.DisplayOrder == rowIndex);
                    bsLocation.ResetBindings(false);

                    this.Reindex();
                }
                _currentRowIndex = 0;
                GridSelected();
            }
        }

        private void ddlWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLocationCodeScan.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //var rowIndex = dgLocation.CurrentCell.RowNumber;
            var locations = (List<ProductLocation>)bsLocation.DataSource;
            //var displayOrder = locations.Find(p => p.ProductCode == this.GetCurrentProductCode()).DisplayOrder;
            var displayOrder = _currentRowIndex;
            var oForm = new LocationProductForm(this.OfflineMode);
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                if (bsLocation.DataSource == null)
                    bsLocation.DataSource = new List<ProductLocation>();

                var location = oForm.ProductLocation;
                if (location == null)
                    return;

                var productLocation = locations.Find(p => p.ProductBarcode == location.ProductBarcode);
                if (productLocation != null)
                {
                    if (GlobalMessageBox.ShowQuestion("มีสินค้านี้อยู่ในตำแหน่งแล้ว\nคุณต้องการแก้ไขสินค้านี้ ใช่หรือไม่ ?") == DialogResult.Yes)
                    {
                        productLocation.ProductBarcode = oForm.ProductLocation.ProductBarcode;
                        productLocation.ProductCode = oForm.ProductLocation.ProductCode;
                        productLocation.PutLevel = oForm.ProductLocation.PutLevel;
                        productLocation.ProductName = oForm.ProductLocation.ProductName;
                        productLocation.PutQuantity = oForm.ProductLocation.PutQuantity;
                        productLocation.ProductUnitCode = oForm.ProductLocation.ProductUnitCode;
                        productLocation.ProductUnitName = oForm.ProductLocation.ProductUnitName;
                        productLocation.RequestPrintLabel = oForm.ProductLocation.RequestPrintLabel;
                        productLocation.RequestPrintLabelSpecified = true;
                        productLocation.MaxStock = oForm.ProductLocation.MaxStock;
                        productLocation.MaxStockSpecified = true;
                        bsLocation.ResetBindings(false);
                        return;
                    }
                    else
                        return;
                }

                if (displayOrder == 0)
                    locations.Insert(0, location);
                else
                    locations.Insert(displayOrder, location);
                //locations.Insert(displayOrder - 1, location);

                bsLocation.ResetBindings(false);

                this.Reindex();

                _currentRowIndex = displayOrder;
                GridSelected();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OfflineMode)
            {
                AddOffLineMode();
            }
            else
            {
                AddOnLineMode();
            }
        }

        private void LocationForm_Closing(object sender, CancelEventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (GlobalMessageBox.ShowQuestion("คุณยังไม่ทำการบันทึกข้อมูล\nคุณต้องการบันทึกข้อมูล ใช่หรือไม่") == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var wranningMessage = string.Format("คุณต้องการลบสินค้าทั้งหมด ใช่หรือไม่");
            if (MessageBox.Show(wranningMessage, "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dgLocation.VisibleRowCount > 0)
                {
                    var locations = (List<ProductLocation>)bsLocation.DataSource;
                    locations.Clear();
                    bsLocation.ResetBindings(false);
                }
            }
        }

        private void chkOffline_CheckStateChanged(object sender, EventArgs e)
        {
            this.txtLocationCodeScan.Focus();
        }

        private void btnOffLineView_Click(object sender, EventArgs e)
        {
            new LocationOfflineModeForm().ShowDialog();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new LocationKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtLocationCodeScan.Text = oForm.Tag as string;
                //txtLocationCodeScan_KeyDown(sender, new KeyEventArgs(Keys.Enter));
            }
        }

        private void btnLabelPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                new LocationLabelPrintForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void dgLocation_CurrentCellChanged(object sender, EventArgs e)
        {
            _currentRowIndex = dgLocation.CurrentRowIndex;
            GridSelected();
        }


    }
}