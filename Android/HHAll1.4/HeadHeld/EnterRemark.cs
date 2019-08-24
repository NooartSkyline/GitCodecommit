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
    public partial class EnterRemark : Form
    {
        public decimal Remark { get; set; }

        private bool IsValidate
        {
            get
            {
                if (txtRemark.Enabled && string.IsNullOrEmpty(txtRemark.Text))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ สาเหตุการพักบิลก่อน");
                    return false;
                }

                return true;
            }
        }

        private void Save()
        {
            if (this.IsValidate)
            {
                this.Remark = Utils.DecimalParse(txtRemark.Text.Trim());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public EnterRemark()
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
           
            txtRemark.Enabled = true;
        }

      
        private void txtRemarkValue_TextChanged(object sender, EventArgs e)
        {
            //this.Save();
            //btnSave.Focus();
        }

        private void txtRemarkValue_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}