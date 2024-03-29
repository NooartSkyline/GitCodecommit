﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoHome.HandHeld.Client
{
    public partial class InputNumberForm : Form
    {
        public string SelectedValue
        {
            get
            {
                return txtPriceValue.Text.Trim();
            }
            set
            {
                txtPriceValue.Text = value;
            }
        }

        public string LableTitle
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        private bool IsValidate
        {
            get
            {
                if (string.IsNullOrEmpty(txtPriceValue.Text))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุจำนวน ก่อนทำการบันทึก");
                    return false;
                }

                return true;
            }
        }

        private void Save()
        {
            if (this.IsValidate)
            {
                //this.SelectedValue = txtPriceValue.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public InputNumberForm()
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
            this.txtPriceValue.Focus();
        }

        private void txtPriceValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtPriceValue.Text;
                if (string.IsNullOrEmpty(barcode))
                    barcode = CeReader.Barcode.Scan();
                txtPriceValue.Text = barcode;

                Save();
            }
        }
    }
}