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
    public partial class CountStockQuantityForm : Form
    {
        string _productCode;
        string _productName;
        string _unitCode;

        public decimal ValueQuantity { get; set; }

        public string ValueUnitCode { get; set; }
        
        public string ValueUnitName { get; set; }

        private void PrepareDropdown()
        {
            var productUnits = ServiceHelper.MobileServices.ProductUnitGetByProductCode(GlobalContext.BranchCode, _productCode);
            ddlUnit.DataSource = productUnits;

            ddlUnit.SelectedValue = this.ValueUnitCode;
        }

        public CountStockQuantityForm(string productCode, string productName, string unitCode)
        {
            InitializeComponent();

            _productCode = productCode;
            _productName = productName;
            _unitCode = unitCode;

            txtProductName.Text = _productName;
        }

        private void CountStockQuantityForm_Load(object sender, EventArgs e)
        {
            this.PrepareDropdown();
            txtPrice.Text = this.ValueQuantity.ToString("N2");
            txtPrice.Focus();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.ValueQuantity = Utils.DecimalParse(txtPrice.Text);
            this.ValueUnitCode = ddlUnit.SelectedValue as string;
            this.ValueUnitName = ddlUnit.Text;
            this.Close();
        }
    }
}