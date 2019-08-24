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
    public partial class ProductOrderRequest : Form
    {
        string _productCode;
        string _productName;

        private void PrepareData()
        {
            txtProductCode.Text = _productCode;
            txtProductName.Text = _productName;
            txtCreatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-US"));
            cbUnit.DataSource = ServiceHelper.MobileServices.ProductUnitGetByProductCode(GlobalContext.BranchCode,_productCode);
        }

        public ProductOrderRequest(string productCode, string productName)
        {
            InitializeComponent();
            _productCode = productCode;
            _productName = productName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductOrderRequest_Load(object sender, EventArgs e)
        {
            this.PrepareData();
        }

        private void ProductOrderRequest_Activated(object sender, EventArgs e)
        {
            this.Location = new Point(
            (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2),
            (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //bool orderAccrualAdd;
                //bool orderAccrualAddSpecified;
                double quantity = Convert.ToDouble(txtQuantity.Text);
                var unitCode = cbUnit.SelectedValue.ToString();
                ServiceHelper.MobileServices.OrderAccrualAdd(_productCode,
                    _productName,
                    unitCode,
                    quantity,
                    GlobalContext.BranchCode,
                    GlobalContext.UserCode,
                    GlobalContext.UserName);

                GlobalMessageBox.ShowInfomation("บันทึกข้อมูลเรียบร้อยแล้ว");
                // close form.
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "พบข้อผิดพลาด");
            }
        }
    }
}