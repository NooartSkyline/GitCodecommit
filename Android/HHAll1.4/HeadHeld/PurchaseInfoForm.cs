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
    public partial class PurchaseInfoForm : Form
    {
        private string _productCode;
        private string _productName;
        private string _groupingofmaterials;

        public PurchaseInfoForm(string productCode, string productName, string groupingofmaterials)
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
                grdPurchaseOrder.DataSource = ServiceHelper.MobileServices.OrderAccrualGetByProductCode(_productCode, GlobalContext.BranchCode);
            }
            catch (Exception ex) { GlobalMessageBox.ShowError(ex); }
            finally { Cursor.Current = Cursors.Default; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdLocations_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {

        }
    }
}