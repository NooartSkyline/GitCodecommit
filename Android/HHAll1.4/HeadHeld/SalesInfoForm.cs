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
    public partial class SalesInfoForm : Form
    {
        private string _productCode;
        private string _productName;
        private string _groupingofmaterials;


        public SalesInfoForm(string productCode, string productName, string groupingofmaterials)
        {
            InitializeComponent();

            _productCode = productCode;
            _productName = productName;
            _groupingofmaterials = groupingofmaterials;
        }

        private void SalesInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                tbGroupingofmaterials.Text = _groupingofmaterials;
                tbProductCode.Text = _productCode;
                tbProductName.Text = _productName;

                var salesDetail = ServiceHelper.MobileServices.ProductSaleDetailGetByProductCode(_productCode, GlobalContext.BranchCode, GlobalContext.IsShowSaleProfit);
                if (salesDetail != null)
                {
                    tbSaleRate.Text = salesDetail.SaleRate.ToString("N2");
                    tbSaleQuantity.Text = salesDetail.SaleQuantity.ToString("N2");
                    tbSaleProductType.Text = salesDetail.SaleProductType;
                    tbSaleProfit.Text = salesDetail.SaleProfit;

                    if (salesDetail.LastGrDate == "00000000")
                        tbLastGrDate.Text = "";
                    else
                        tbLastGrDate.Text = salesDetail.LastGrDate.Substring(6, 2) + "/" + salesDetail.LastGrDate.Substring(4, 2) + "/" + salesDetail.LastGrDate.Substring(0, 4);
                    tbLastGrQty.Text = salesDetail.LastGrQty.ToString("N2");
                    if (salesDetail.LastSaleDate == "00000000")
                        tbLastSaleDate.Text = "";
                    else
                        tbLastSaleDate.Text = salesDetail.LastSaleDate.Substring(6, 2) + "/" + salesDetail.LastSaleDate.Substring(4, 2) + "/" + salesDetail.LastSaleDate.Substring(0, 4);
                    tbLastSaleQty.Text = salesDetail.LastSaleQty.ToString("N2");
                }
            }
            catch (Exception ex) { GlobalMessageBox.ShowError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}