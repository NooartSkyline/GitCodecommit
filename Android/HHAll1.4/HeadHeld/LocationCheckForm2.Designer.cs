﻿namespace DoHome.HandHeld.Client
{
    partial class LocationCheckForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationCheckForm2));
            this.btnClear = new System.Windows.Forms.Button();
            this.txtLocationCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDisplayLists = new System.Windows.Forms.Button();
            this.bsAgenda = new System.Windows.Forms.BindingSource(this.components);
            this.smartGridDesc = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnID = new Resco.Controls.SmartGrid.Column();
            this.columnChecked = new Resco.Controls.SmartGrid.Column();
            this.columnText = new Resco.Controls.SmartGrid.Column();
            this.columnPoint = new Resco.Controls.SmartGrid.Column();
            this.CheckBox = new Resco.Controls.SmartGrid.Style();
            this.Discontinued = new Resco.Controls.SmartGrid.Style();
            this.Disable = new Resco.Controls.SmartGrid.Style();
            this.Number = new Resco.Controls.SmartGrid.Style();
            this.label2 = new System.Windows.Forms.Label();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.btnOfflineToSap = new System.Windows.Forms.Button();
            this.btnSearchUser = new Resco.Controls.OutlookControls.ImageButton();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.btnKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(150, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 19);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "ตำแหน่งใหม่";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocationCode.Location = new System.Drawing.Point(34, 20);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(92, 19);
            this.txtLocationCode.TabIndex = 17;
            this.txtLocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationCode_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.Text = "ตน. :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(128, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 41);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDisplayLists
            // 
            this.btnDisplayLists.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDisplayLists.Location = new System.Drawing.Point(2, 227);
            this.btnDisplayLists.Name = "btnDisplayLists";
            this.btnDisplayLists.Size = new System.Drawing.Size(124, 20);
            this.btnDisplayLists.TabIndex = 25;
            this.btnDisplayLists.Text = "ตรวจสอบรายการ";
            this.btnDisplayLists.Click += new System.EventHandler(this.btnCheckLists_Click);
            // 
            // smartGridDesc
            // 
           // this.smartGridDesc.AutoScroll = true;
            this.smartGridDesc.Columns.Add(this.columnID);
            this.smartGridDesc.Columns.Add(this.columnChecked);
            this.smartGridDesc.Columns.Add(this.columnText);
            this.smartGridDesc.Columns.Add(this.columnPoint);
            this.smartGridDesc.DataSource = this.bsAgenda;
            this.smartGridDesc.Enabled = false;
            this.smartGridDesc.FullRowSelect = true;
            this.smartGridDesc.KeyNavigation = true;
            this.smartGridDesc.Location = new System.Drawing.Point(2, 78);
            this.smartGridDesc.Name = "smartGridDesc";
            this.smartGridDesc.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            this.smartGridDesc.Size = new System.Drawing.Size(234, 147);
            this.smartGridDesc.Styles.Add(this.CheckBox);
            this.smartGridDesc.Styles.Add(this.Discontinued);
            this.smartGridDesc.Styles.Add(this.Disable);
            this.smartGridDesc.Styles.Add(this.Number);
            this.smartGridDesc.TabIndex = 48;
            this.smartGridDesc.CustomizeCell += new Resco.Controls.SmartGrid.CustomizeCellHandler(this.smartGridDesc_CustomizeCell);
            this.smartGridDesc.CheckBoxEdit += new Resco.Controls.SmartGrid.CheckBoxEditHandler(this.smartGridDesc_CheckBoxEdit);
            // 
            // columnID
            // 
            this.columnID.DataMember = "AgendaTemplateId";
            this.columnID.Name = "columnID";
            this.columnID.Width = 0;
            // 
            // columnChecked
            // 
            this.columnChecked.AlternatingStyle = "CheckBox";
            this.columnChecked.CellEdit = Resco.Controls.SmartGrid.CellEditType.CheckBox;
            this.columnChecked.DataMember = "Checked";
            this.columnChecked.EditMode = Resco.Controls.SmartGrid.EditMode.OnEnter;
            this.columnChecked.Name = "columnChecked";
            this.columnChecked.SelectionStyle = "CheckBox";
            this.columnChecked.Style = "CheckBox";
            this.columnChecked.Width = 15;
            // 
            // columnText
            // 
            this.columnText.DataMember = "AgendaTemplateName";
            this.columnText.HeaderText = "รายการ";
            this.columnText.Name = "columnText";
            this.columnText.Width = 245;
            // 
            // columnPoint
            // 
            this.columnPoint.AlternatingStyle = "Disable";
            this.columnPoint.CustomizeCells = true;
            this.columnPoint.DataMember = "CheckedValue";
            this.columnPoint.HeaderText = "จำนวน";
            this.columnPoint.Name = "columnPoint";
            this.columnPoint.SelectionStyle = "Disable";
            this.columnPoint.Style = "Disable";
            this.columnPoint.Width = 45;
            // 
            // CheckBox
            // 
            this.CheckBox.AutoTransparent = true;
            this.CheckBox.ImagePosition = Resco.Controls.SmartGrid.ImagePosition.Foreground;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.TextAlignment = Resco.Controls.SmartGrid.Alignment.MiddleCenter;
            // 
            // Discontinued
            // 
            this.Discontinued.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Italic);
            this.Discontinued.Name = "Discontinued";
            // 
            // Disable
            // 
            this.Disable.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Disable.Name = "Disable";
            // 
            // Number
            // 
            this.Number.BackColor = System.Drawing.Color.White;
            this.Number.ForeColor = System.Drawing.Color.Black;
            this.Number.Name = "Number";
            this.Number.TextAlignment = Resco.Controls.SmartGrid.Alignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(0, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.Text = "พนง. :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkOffline
            // 
            this.chkOffline.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkOffline.Location = new System.Drawing.Point(34, 0);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(100, 20);
            this.chkOffline.TabIndex = 74;
            this.chkOffline.Text = "โหมดออฟไลน์ ";
            this.chkOffline.CheckStateChanged += new System.EventHandler(this.chkOffline_CheckStateChanged);
            // 
            // btnOfflineToSap
            // 
            this.btnOfflineToSap.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnOfflineToSap.Location = new System.Drawing.Point(2, 248);
            this.btnOfflineToSap.Name = "btnOfflineToSap";
            this.btnOfflineToSap.Size = new System.Drawing.Size(124, 20);
            this.btnOfflineToSap.TabIndex = 75;
            this.btnOfflineToSap.Text = "ออฟไลน์ -> เซิร์ฟเวอร์";
            this.btnOfflineToSap.Click += new System.EventHandler(this.btnOfflineToSap_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Enabled = false;
            this.btnSearchUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnSearchUser.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnSearchUser.ImageDefault")));
            this.btnSearchUser.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSearchUser.ImagePressed")));
            this.btnSearchUser.Location = new System.Drawing.Point(4, 0);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(21, 21);
            this.btnSearchUser.TabIndex = 86;
            this.btnSearchUser.Visible = false;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEmployeeName.Location = new System.Drawing.Point(128, 41);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(108, 19);
            this.txtEmployeeName.TabIndex = 85;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Enabled = false;
            this.txtEmployeeCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEmployeeCode.Location = new System.Drawing.Point(34, 41);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(92, 19);
            this.txtEmployeeCode.TabIndex = 84;
            this.txtEmployeeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeCode_KeyDown);
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.Enabled = false;
            this.chkCheckAll.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkCheckAll.Location = new System.Drawing.Point(3, 59);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(100, 20);
            this.chkCheckAll.TabIndex = 90;
            this.chkCheckAll.Text = "เลือกทั้งหมด";
            this.chkCheckAll.CheckStateChanged += new System.EventHandler(this.chkCheckAll_CheckStateChanged);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnKeyboard.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImageDefault")));
            this.btnKeyboard.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImagePressed")));
            this.btnKeyboard.Location = new System.Drawing.Point(127, 19);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(21, 21);
            this.btnKeyboard.TabIndex = 91;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // LocationCheckForm2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.btnSearchUser);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.btnOfflineToSap);
            this.Controls.Add(this.chkOffline);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smartGridDesc);
            this.Controls.Add(this.btnDisplayLists);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtLocationCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkCheckAll);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationCheckForm2";
            this.Text = "ตรวจสอบตำแหน่งสินค้า";
            this.Load += new System.EventHandler(this.ProductCheckPriceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtLocationCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDisplayLists;
        private System.Windows.Forms.BindingSource bsAgenda;
        private Resco.Controls.SmartGrid.SmartGrid smartGridDesc;
        private Resco.Controls.SmartGrid.Column columnID;
        private Resco.Controls.SmartGrid.Column columnChecked;
        private Resco.Controls.SmartGrid.Column columnText;
        private Resco.Controls.SmartGrid.Column columnPoint;
        internal Resco.Controls.SmartGrid.Style CheckBox;
        internal Resco.Controls.SmartGrid.Style Discontinued;
        private Resco.Controls.SmartGrid.Style Disable;
        private Resco.Controls.SmartGrid.Style Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button btnOfflineToSap;
        private Resco.Controls.OutlookControls.ImageButton btnSearchUser;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private Resco.Controls.OutlookControls.ImageButton btnKeyboard;
    }
}