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
    public partial class LabelPriceForm : Form
    {
        #region Field

        private List<LabelPrintProductDetailLocal> _labelPrice;

        #endregion

        #region Method

        private void PrepareForm()
        {
            _labelPrice = new List<LabelPrintProductDetailLocal>();
            tbBarcode.Focus();
            tbRequestor.Text = string.Format("{0} : {1}", GlobalContext.UserCode, GlobalContext.UserName);

            // prepare dropdown labletype

            var labelType = ServiceHelper.MobileServices.LabelPrintTypeGetByBranch(GlobalContext.BranchCode);
            cmbPrintType.DataSource = labelType;
            try
            {
                cmbPrintType.SelectedValue = "17";
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        private void AddLocationCode(string productOrBarcode)
        {
/* Begin BEE Edit เปลี่ยนให้แสดงทุกหน่วยสินค้า ตามที่ Loss แจ้ง 2012-11-14
            var product = ServiceHelper.MobileServices.ProductBarcodeGetByProductCodeOrBarcode3(GlobalContext.BranchCode, productOrBarcode);

            if (product != null)
            {
                var labelPrice = new LabelPrintProductDetail();
                labelPrice.Productcode = product.ProductCode;
                labelPrice.Productname = product.ProductName;
                labelPrice.Barcode = product.Barcode;
                labelPrice.Unitcode = product.UnitCode;
                labelPrice.Unitname = product.UnitName;
                labelPrice.OthUnitcode = labelPrice.Unitcode;
                labelPrice.OthUnitname = labelPrice.Unitname;
                labelPrice.PrintLabelTypeCode = cmbPrintType.SelectedValue.ToString();
                //var productPrice = ServiceHelper.MobileServices.ProductPriceGetCurrentPrice(GlobalContext.BranchCode, labelPrice.Productcode, labelPrice.Unitcode);
                //if (productPrice != null)
                //{
                //    labelPrice.Sellprice = productPrice.Saleprice;
                //    labelPrice.Pricedate = productPrice.Begindate;
                //    labelPrice.OthUnitprice = labelPrice.Sellprice;
                //}

                labelPrice.Sellprice = product.ProductPrice;
                labelPrice.OthUnitprice = labelPrice.Sellprice;

                labelPrice.DisplayOrder = _labelPrice.Count + 1;
                labelPrice.DisplayOrderSpecified = true;
                _labelPrice.Add(labelPrice);

                this.BindGridview();
            }
 End BEE Edit เปลี่ยนให้แสดงทุกหน่วยสินค้า ตามที่ Loss แจ้ง 2012-11-14 */

            //_labelPrice = new List<LabelPrintProductDetail>();
            var EndPoint = GlobalContext.ServerEndpointAddress;
            var ServiceUrl = GlobalContext.remoteAddress;
            var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
                cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
               var product = (cnn.ProductBarcodeGetByProductCodeOrBarcode5(GlobalContext.BranchCode, productOrBarcode, GlobalContext.WarehouseCode));
                
                   if (product != null)
                   {
                       if (product.Count() > 0)
                       {
                           var frm = new SelectUnitPrice(product, chkPosition.Checked, productOrBarcode);
                           frm.ShowDialog();
                           if (frm.IsUse)
                           {
                               product = frm._ProductRT;
                           }
                           else 
                           {
                               return;
                           }
                           if (chkPosition.Checked) 
                           {
                               var frms = new SelectProductPosition(product);
                               frms.ShowDialog();
                               if (frms.IsUse)
                               {
                                   product = frms._ProductRT;
                               }
                               else 
                               {
                                   return;
                               } 
                           }
                           for (int I = 0; I < _labelPrice.Count; I++)
                           {
                               _labelPrice[I].DisplayOrder = I + 1;
                           }
                           foreach (var item in product)
                           {
                               var labelPrice = new LabelPrintProductDetailLocal();
                               labelPrice.Productcode = item.ProductCode;
                               labelPrice.Productname = item.ProductName;
                               labelPrice.Barcode = item.Barcode;
                               labelPrice.Unitcode = item.UnitCode;
                               labelPrice.Unitname = item.UnitName;
                               labelPrice.OthUnitcode = labelPrice.Unitcode;
                               labelPrice.OthUnitname = labelPrice.Unitname;
                               labelPrice.PrintLabelTypeCode = cmbPrintType.SelectedValue.ToString();
                               labelPrice.Sellprice = item.ProductPrice;
                               labelPrice.OthUnitprice = labelPrice.Sellprice;
                               labelPrice.Locationcode = "";
                               labelPrice.DisplayOrder = _labelPrice.Count + 1;
                               labelPrice.DisplayOrderSpecified = true;
                               labelPrice.ProductLoggr = item.LOGGR;
                               labelPrice.ProductPosition = item.PositionCode;
                               _labelPrice.Add(labelPrice);
                           }
                           this.BindGridview();
                       }
                       else 
                       {
                           MessageBox.Show("ไม่พบข้อมูลสินค้า", "คำเตือน");
                       }
                   }
                   else 
                   {
                       MessageBox.Show("ไม่พบข้อมูลสินค้า", "คำเตื่อน");
                   }
        }
        private void BindGridview()
        {
            this.grdLocations.DataSource = _labelPrice;
        }

        #endregion

        public LabelPriceForm()
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
            new LabelPriceViewForm().ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_labelPrice.Count <= 0)
            {
                GlobalMessageBox.ShowInfomation("ระบุสินค้าก่อนทำการบันทึก");
                return;
            }
            if (string.IsNullOrEmpty(cmbPrintType.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกประเภทป้าย");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            //var list = new List<LabelPrintProductDetail>();
            //foreach (var item in _labelPrice)
            //{

            //    var labelPrice = new LabelPrintProductDetail();
            //    labelPrice.Productcode = product.ProductCode;
            //    labelPrice.Productname = product.ProductName;
            //    labelPrice.Barcode = product.Barcode;
            //    labelPrice.Unitcode = product.UnitCode;
            //    labelPrice.Unitname = product.UnitName;
            //    labelPrice.OthUnitcode = labelPrice.Unitcode;
            //    labelPrice.OthUnitname = labelPrice.Unitname;
            //    labelPrice.PrintLabelTypeCode = cmbPrintType.Text;
            //    var productPrice = MobileServiceHelper.MobileService.ProductPriceGetCurrentPrice(LabelPriceSession.Current.BranchCode, labelPrice.Productcode, labelPrice.Unitcode);
            //    if (productPrice != null)
            //    {
            //        labelPrice.Sellprice = productPrice.Saleprice;
            //        labelPrice.Pricedate = productPrice.Begindate;
            //        labelPrice.OthUnitprice = labelPrice.Sellprice;
            //    }
            //    labelPrice.DisplayOrder = LabelPriceSession.Current.LabelPrintProductDetails.Count + 1;
            //    LabelPriceSession.Current.LabelPrintProductDetails.Add(labelPrice);

            //    list.Add(new LabelPrintProductDetail() { LocationCode = item.LocationCode });
            //}
            try
            {
                var _labelPriceL = new List<LabelPrintProductDetail>();
                foreach (var item in _labelPrice)
                {
                    var labelPrice = new LabelPrintProductDetail();
                    labelPrice.Productcode = item.Productcode;
                    labelPrice.Productname = item.Productname;
                    labelPrice.Barcode = item.Barcode;
                    labelPrice.Unitcode = item.Unitcode;
                    labelPrice.Unitname = item.Unitname;
                    labelPrice.OthUnitcode = labelPrice.Unitcode;
                    labelPrice.OthUnitname = labelPrice.Unitname;
                    labelPrice.PrintLabelTypeCode = cmbPrintType.SelectedValue.ToString();
                    var productPrice = ServiceHelper.MobileServices.ProductPriceGetCurrentPrice(GlobalContext.BranchCode, labelPrice.Productcode, labelPrice.Unitcode);
                    if (productPrice != null)
                    {
                        labelPrice.Sellprice = productPrice.Saleprice;
                        labelPrice.Pricedate = productPrice.Begindate;
                        var productOtherPrice = ServiceHelper.MobileServices.ProductPriceGetCurrentPrice(GlobalContext.BranchCode, labelPrice.Productcode, labelPrice.OthUnitcode);
                        if (productOtherPrice != null)
                        {
                            labelPrice.OthUnitprice = productOtherPrice.Saleprice;
                        }                        
                    }
                    labelPrice.Sellprice = item.Sellprice;
                    labelPrice.OthUnitprice = labelPrice.Sellprice;
                    labelPrice.Locationcode = "";
                    labelPrice.Locationname = item.ProductPosition;
                    labelPrice.Producttype = item.ProductLoggr;
                    //labelPrice.s
                    labelPrice.DisplayOrder = _labelPrice.Count + 1;
                    labelPrice.DisplayOrderSpecified = true;
                    _labelPriceL.Add(labelPrice);
                }
                var docno = ServiceHelper.MobileServices.LabelPrintProductAddWithDetail(GlobalContext.BranchCode
                    , GlobalContext.UserCode
                    , string.Format("Request from PDA by {0}", GlobalContext.UserCode)
                    , cmbPrintType.SelectedValue.ToString()
                    , _labelPriceL.ToArray());

                _labelPrice.Clear();
                grdLocations.DataSource = null;
                Cursor.Current = Cursors.Default;
                GlobalMessageBox.ShowInfomation(string.Format("บันทึกข้อมูล เสร็จเรียบร้อยแล้ว\nเลขที่เอกสารที่ได้คือ\n{0}", docno));
                tbBarcode.Text = null;
                tbBarcode.Focus();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void grdLocations_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {
            try
            {
                //click on delete column
                if (e.Cell.ColumnIndex == 8)
                {
                    if (GlobalMessageBox.ShowQuestion("คุณต้องลบรายการ ใช่หรือไม่") == DialogResult.Yes)
                    {
                        var id = Convert.ToInt32(grdLocations.Cells[e.Cell.RowIndex, 0].Text);
                        _labelPrice.RemoveAll(p => p.DisplayOrder == id);
                        this.BindGridview();
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new NumericKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                tbBarcode.Text = oForm.Tag as string;
                tbBarcode.Focus();
            }
        }

        private void tbBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = tbBarcode.Text;
                if (string.IsNullOrEmpty(barcode))
                    barcode = CeReader.Barcode.Scan();
                tbBarcode.Text = barcode;


                var productOrBarcode = tbBarcode.Text.ToUpper().Trim();
                tbBarcode.Text = productOrBarcode;
                if (string.IsNullOrEmpty(productOrBarcode))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุบาร์โค้ดสินค้า");
                    return;
                }

                try
                {
                    AddLocationCode(productOrBarcode);
                    //tbBarcode.SelectAll();
                    tbBarcode.Text = "";
                }
                catch (Exception ex)
                {
                    GlobalMessageBox.ShowError(ex);
                }
            }
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {

        }

    }
}