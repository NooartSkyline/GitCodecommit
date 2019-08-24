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
    public partial class EnterPriceForm : Form
    {
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }

        private bool IsValidate
        {
            get
            {
                if (txtPriceValue.Enabled && string.IsNullOrEmpty(txtPriceValue.Text))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ ราคาสินค้า");
                    return false;
                }

                return true;
            }
        }

        private void Save()
        {
            if (this.IsValidate)
            {
                this.Price = Utils.DecimalParse(txtPriceValue.Text.Trim());
                if (this.ddlProductUnit.SelectedValue != null)
                {
                    this.UnitCode = this.ddlProductUnit.SelectedValue.ToString();
                    this.UnitName = this.ddlProductUnit.Text;
                }
                else
                {
                    this.UnitCode = "";
                    this.UnitName = "";
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public EnterPriceForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void EnterPriceForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);
            //switch (GlobalContext.UseInPlaces)
            //{
            //    case UseInPlaces.WAREHOUSE:// กรณีใช้ใน WAREHOUSE TBProduct
            //        txtPriceValue.Enabled = false;
            //        break;
            //    case UseInPlaces.STORE:// กรณีใช้ใน STORE นำข้อมูลมาจาก TBBarcode
            //        txtPriceValue.Enabled = true;
            //        break;
            //    default:
            //        break;
            //}
            ddlProductUnit.DataSource = ServiceHelper.MobileServices.ProductUnitGetByProductCode(GlobalContext.BranchCode + "ALL", this.ProductCode);
            ddlProductUnit.Enabled = true;
            txtPriceValue.Enabled = true;
            //this.txtPriceValue.Focus();
            this.ddlProductUnit.Focus();
        }

        private void txtPriceValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        private void txtPriceValue_TextChanged(object sender, EventArgs e)
        {
            //this.Save();
            //btnSave.Focus();
        }
    }
}