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
    public partial class CountStockMainQuantityForm : Form
    {
        public decimal ValueQuantitySales
        {
            get
            {
                return Utils.DecimalParse(txtQuantitySales.Text);
            }
            set
            {
                txtQuantitySales.Text = value.ToString("N2");

            }
        }

        public decimal ValueQuantityStock
        {
            get
            {
                return Utils.DecimalParse(txtQuantityStock.Text);
            }
            set
            {
                txtQuantityStock.Text = value.ToString("N2");

            }
        }

        public string ValueUnitSales
        {
            get
            {
                return txtUnitSales.Text;
            }
            set
            {
                txtUnitSales.Text = value;
            }
        }


        public string ValueUnitStock
        {
            get
            {
                return txtUnitStock.Text;
            }
            set
            {
                txtUnitStock.Text = value;
            }
        }
        public string ValueProductName
        {
            get
            {
                return txtProductName.Text;
            }
            set
            {
                txtProductName.Text = value;
            }
        }

        public CountStockMainQuantityForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CountStockMainQuantityForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);
        }

    }
}