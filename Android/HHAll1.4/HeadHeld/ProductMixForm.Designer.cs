﻿namespace DoHome.HandHeld.Client
{
    partial class ProductMixForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMixForm));
            this.bsProductLocation = new System.Windows.Forms.BindingSource(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.txtLocationCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckLists = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gvProduct = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnStatusText = new Resco.Controls.SmartGrid.Column();
            this.columnProductCode = new Resco.Controls.SmartGrid.Column();
            this.columnProductBarcode = new Resco.Controls.SmartGrid.Column();
            this.columnProductUnitName = new Resco.Controls.SmartGrid.Column();
            this.columnProductName = new Resco.Controls.SmartGrid.Column();
            this.styleBlack = new Resco.Controls.SmartGrid.Style();
            this.styleRed = new Resco.Controls.SmartGrid.Style();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.btnOffLineView = new System.Windows.Forms.Button();
            this.btnSearchUser = new Resco.Controls.OutlookControls.ImageButton();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            this.btnNumericKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsProductLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeyboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNumericKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(167, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 42);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "ตำแหน่งใหม่";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocationCode.Location = new System.Drawing.Point(37, 23);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(107, 19);
            this.txtLocationCode.TabIndex = 17;
            this.txtLocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationCode_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(0, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.Text = "ตน. :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(130, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 41);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckLists
            // 
            this.btnCheckLists.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCheckLists.Location = new System.Drawing.Point(4, 227);
            this.btnCheckLists.Name = "btnCheckLists";
            this.btnCheckLists.Size = new System.Drawing.Size(124, 20);
            this.btnCheckLists.TabIndex = 25;
            this.btnCheckLists.Text = "ตรวจสอบรายการ";
            this.btnCheckLists.Click += new System.EventHandler(this.btnCheckLists_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarcode.Location = new System.Drawing.Point(37, 45);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(107, 19);
            this.txtBarcode.TabIndex = 27;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(-2, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.Text = "ร/บ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gvProduct
            // 
            //this.gvProduct.AutoScroll = true;
            this.gvProduct.Columns.Add(this.columnStatusText);
            this.gvProduct.Columns.Add(this.columnProductCode);
            this.gvProduct.Columns.Add(this.columnProductBarcode);
            this.gvProduct.Columns.Add(this.columnProductUnitName);
            this.gvProduct.Columns.Add(this.columnProductName);
            this.gvProduct.DataSource = this.bsProductLocation;
            this.gvProduct.FullRowSelect = true;
            this.gvProduct.KeyNavigation = true;
            this.gvProduct.Location = new System.Drawing.Point(3, 88);
            this.gvProduct.Name = "gvProduct";
            this.gvProduct.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            this.gvProduct.SelectionVistaStyle = true;
            this.gvProduct.Size = new System.Drawing.Size(234, 137);
            this.gvProduct.Styles.Add(this.styleBlack);
            this.gvProduct.Styles.Add(this.styleRed);
            this.gvProduct.TabIndex = 50;
            this.gvProduct.CustomizeCell += new Resco.Controls.SmartGrid.CustomizeCellHandler(this.gvProduct_CustomizeCell);
            // 
            // columnStatusText
            // 
            this.columnStatusText.CustomizeCells = true;
            this.columnStatusText.DataMember = "StatusText";
            this.columnStatusText.FillWeight = 70F;
            this.columnStatusText.HeaderText = "สถานะ";
            this.columnStatusText.Name = "columnStatusText";
            this.columnStatusText.Width = 40;
            // 
            // columnProductCode
            // 
            this.columnProductCode.CustomizeCells = true;
            this.columnProductCode.DataMember = "ProductCode";
            this.columnProductCode.HeaderText = "รหัสสินค้า";
            this.columnProductCode.Name = "columnProductCode";
            this.columnProductCode.Width = 65;
            // 
            // columnProductBarcode
            // 
            this.columnProductBarcode.CustomizeCells = true;
            this.columnProductBarcode.DataMember = "ProductBarcode";
            this.columnProductBarcode.HeaderText = "บาร์โค้ด";
            this.columnProductBarcode.Name = "columnProductBarcode";
            this.columnProductBarcode.Width = 80;
            // 
            // columnProductUnitName
            // 
            this.columnProductUnitName.CustomizeCells = true;
            this.columnProductUnitName.DataMember = "ProductUnitName";
            this.columnProductUnitName.FillWeight = 50F;
            this.columnProductUnitName.HeaderText = "หน่วยนับ";
            this.columnProductUnitName.Name = "columnProductUnitName";
            this.columnProductUnitName.Width = 60;
            // 
            // columnProductName
            // 
            this.columnProductName.CustomizeCells = true;
            this.columnProductName.DataMember = "ProductName";
            this.columnProductName.FillWeight = 150F;
            this.columnProductName.HeaderText = "ชื่อสินค้า";
            this.columnProductName.Name = "columnProductName";
            this.columnProductName.Width = 300;
            // 
            // styleBlack
            // 
            this.styleBlack.Name = "styleBlack";
            // 
            // styleRed
            // 
            this.styleRed.BackColor = System.Drawing.Color.Red;
            this.styleRed.Name = "styleRed";
            // 
            // chkOffline
            // 
            this.chkOffline.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkOffline.Location = new System.Drawing.Point(37, 3);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(100, 20);
            this.chkOffline.TabIndex = 53;
            this.chkOffline.Text = "โหมดออฟไลน์ ";
            this.chkOffline.CheckStateChanged += new System.EventHandler(this.chkOffline_CheckStateChanged);
            // 
            // btnOffLineView
            // 
            this.btnOffLineView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnOffLineView.Location = new System.Drawing.Point(4, 248);
            this.btnOffLineView.Name = "btnOffLineView";
            this.btnOffLineView.Size = new System.Drawing.Size(124, 20);
            this.btnOffLineView.TabIndex = 54;
            this.btnOffLineView.Text = "ออฟไลน์ -> เซิร์ฟเวอร์";
            this.btnOffLineView.Click += new System.EventHandler(this.btnOffLineView_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Enabled = false;
            this.btnSearchUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnSearchUser.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnSearchUser.ImageDefault")));
            this.btnSearchUser.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSearchUser.ImagePressed")));
            this.btnSearchUser.Location = new System.Drawing.Point(4, 3);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(21, 21);
            this.btnSearchUser.TabIndex = 88;
            this.btnSearchUser.Visible = false;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEmployeeName.Location = new System.Drawing.Point(94, 67);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(143, 19);
            this.txtEmployeeName.TabIndex = 87;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Enabled = false;
            this.txtEmployeeCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEmployeeCode.Location = new System.Drawing.Point(37, 67);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(56, 19);
            this.txtEmployeeCode.TabIndex = 86;
            this.txtEmployeeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeCode_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(-2, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.Text = "นพง. :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnKeyboard.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImageDefault")));
            this.btnKeyboard.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImagePressed")));
            this.btnKeyboard.Location = new System.Drawing.Point(145, 23);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(21, 21);
            this.btnKeyboard.TabIndex = 92;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnNumericKeyboard.ImageDefault")));
            this.btnNumericKeyboard.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnNumericKeyboard.ImagePressed")));
            this.btnNumericKeyboard.Location = new System.Drawing.Point(145, 43);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(21, 21);
            this.btnNumericKeyboard.TabIndex = 93;
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // ProductMixForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.btnSearchUser);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOffLineView);
            this.Controls.Add(this.chkOffline);
            this.Controls.Add(this.gvProduct);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCheckLists);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtLocationCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKeyboard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductMixForm";
            this.Text = "ตรวจสินค้าปนในตำแหน่ง";
            this.Load += new System.EventHandler(this.ProductMixForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsProductLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeyboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNumericKeyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtLocationCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCheckLists;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bsProductLocation;
        private Resco.Controls.SmartGrid.SmartGrid gvProduct;
        private Resco.Controls.SmartGrid.Column columnStatusText;
        private Resco.Controls.SmartGrid.Column columnProductCode;
        private Resco.Controls.SmartGrid.Column columnProductBarcode;
        private Resco.Controls.SmartGrid.Column columnProductName;
        private Resco.Controls.SmartGrid.Column columnProductUnitName;
        private Resco.Controls.SmartGrid.Style styleBlack;
        private Resco.Controls.SmartGrid.Style styleRed;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button btnOffLineView;
        private Resco.Controls.OutlookControls.ImageButton btnSearchUser;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label3;
        private Resco.Controls.OutlookControls.ImageButton btnKeyboard;
        private Resco.Controls.OutlookControls.ImageButton btnNumericKeyboard;
    }
}