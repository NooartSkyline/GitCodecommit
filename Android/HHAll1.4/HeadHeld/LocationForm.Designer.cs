﻿namespace DoHome.HandHeld.Client
{
    partial class LocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLocationCodeScan = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.bsLocation = new System.Windows.Forms.BindingSource(this.components);
            this.dgLocation = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.columnDisplayOrder = new System.Windows.Forms.DataGridTextBoxColumn();
            this.columnProductCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.columnProductName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.columnBarcode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.columnUnitName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.columnPutLevel = new System.Windows.Forms.DataGridTextBoxColumn();
            this.columnQuantity = new System.Windows.Forms.DataGridTextBoxColumn();
            this.columnMaxStock = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.btnOffLineView = new System.Windows.Forms.Button();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.btnKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            this.btnLabelPrintList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLabelType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.Text = "ตน :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(3, 226);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(37, 20);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.Click += new System.EventHandler(this.btnLevelAdd_Click);
            // 
            // txtLocationCodeScan
            // 
            this.txtLocationCodeScan.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocationCodeScan.Location = new System.Drawing.Point(28, 21);
            this.txtLocationCodeScan.Name = "txtLocationCodeScan";
            this.txtLocationCodeScan.Size = new System.Drawing.Size(108, 19);
            this.txtLocationCodeScan.TabIndex = 1;
            this.txtLocationCodeScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationCodeScan_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(160, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 19);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "ตำแหน่งใหม่";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // bsLocation
            // 
            this.bsLocation.AllowNew = false;
            // 
            // dgLocation
            // 
            this.dgLocation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgLocation.DataSource = this.bsLocation;
            this.dgLocation.Location = new System.Drawing.Point(3, 42);
            this.dgLocation.Name = "dgLocation";
            this.dgLocation.RowHeadersVisible = false;
            this.dgLocation.Size = new System.Drawing.Size(232, 158);
            this.dgLocation.TabIndex = 7;
            this.dgLocation.TableStyles.Add(this.dataGridTableStyle1);
            this.dgLocation.CurrentCellChanged += new System.EventHandler(this.dgLocation_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnDisplayOrder);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnProductCode);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnProductName);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnBarcode);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnUnitName);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnPutLevel);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnQuantity);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.columnMaxStock);
            this.dataGridTableStyle1.MappingName = "ProductLocation";
            // 
            // columnDisplayOrder
            // 
            this.columnDisplayOrder.Format = "";
            this.columnDisplayOrder.FormatInfo = null;
            this.columnDisplayOrder.HeaderText = "ลด.";
            this.columnDisplayOrder.MappingName = "DisplayOrder";
            this.columnDisplayOrder.Width = 0;
            // 
            // columnProductCode
            // 
            this.columnProductCode.Format = "";
            this.columnProductCode.FormatInfo = null;
            this.columnProductCode.HeaderText = "รหัสสินค้า";
            this.columnProductCode.MappingName = "ProductCode";
            this.columnProductCode.Width = 55;
            // 
            // columnProductName
            // 
            this.columnProductName.Format = "";
            this.columnProductName.FormatInfo = null;
            this.columnProductName.HeaderText = "ชื่อสินค้า";
            this.columnProductName.MappingName = "ProductName";
            this.columnProductName.Width = 200;
            // 
            // columnBarcode
            // 
            this.columnBarcode.Format = "";
            this.columnBarcode.FormatInfo = null;
            this.columnBarcode.HeaderText = "บาร์โค้ด";
            this.columnBarcode.MappingName = "ProductBarcode";
            this.columnBarcode.Width = 95;
            // 
            // columnUnitName
            // 
            this.columnUnitName.Format = "";
            this.columnUnitName.FormatInfo = null;
            this.columnUnitName.HeaderText = "หน่วย";
            this.columnUnitName.MappingName = "ProductUnitName";
            this.columnUnitName.Width = 0;
            // 
            // columnPutLevel
            // 
            this.columnPutLevel.Format = "";
            this.columnPutLevel.FormatInfo = null;
            this.columnPutLevel.HeaderText = "จน.ชั้น";
            this.columnPutLevel.MappingName = "PutLevel";
            this.columnPutLevel.Width = 40;
            // 
            // columnQuantity
            // 
            this.columnQuantity.Format = "";
            this.columnQuantity.FormatInfo = null;
            this.columnQuantity.HeaderText = "จน.ขาวาง";
            this.columnQuantity.MappingName = "PutQuantity";
            this.columnQuantity.Width = 56;
            // 
            // columnMaxStock
            // 
            this.columnMaxStock.Format = "";
            this.columnMaxStock.FormatInfo = null;
            this.columnMaxStock.HeaderText = "จน.เก็บสูงสุด";
            this.columnMaxStock.MappingName = "MaxStock";
            this.columnMaxStock.Width = 70;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(84, 226);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 20);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(125, 226);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 20);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnInsert.Location = new System.Drawing.Point(42, 226);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(40, 20);
            this.btnInsert.TabIndex = 16;
            this.btnInsert.Text = "แทรก";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(171, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 20);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Enabled = false;
            this.btnDeleteAll.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAll.Location = new System.Drawing.Point(171, 226);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(64, 20);
            this.btnDeleteAll.TabIndex = 19;
            this.btnDeleteAll.Text = "ลบทั้งหมด";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // chkOffline
            // 
            this.chkOffline.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkOffline.Location = new System.Drawing.Point(28, 0);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(100, 20);
            this.chkOffline.TabIndex = 23;
            this.chkOffline.Text = "โหมดออฟไลน์ ";
            this.chkOffline.CheckStateChanged += new System.EventHandler(this.chkOffline_CheckStateChanged);
            // 
            // btnOffLineView
            // 
            this.btnOffLineView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnOffLineView.Location = new System.Drawing.Point(3, 248);
            this.btnOffLineView.Name = "btnOffLineView";
            this.btnOffLineView.Size = new System.Drawing.Size(120, 20);
            this.btnOffLineView.TabIndex = 24;
            this.btnOffLineView.Text = "ออฟไลน์ -> เซิร์ฟเวอร์";
            this.btnOffLineView.Click += new System.EventHandler(this.btnOffLineView_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnKeyboard.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImageDefault")));
            this.btnKeyboard.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImagePressed")));
            this.btnKeyboard.Location = new System.Drawing.Point(137, 20);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(21, 21);
            this.btnKeyboard.TabIndex = 92;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnLabelPrintList
            // 
            this.btnLabelPrintList.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnLabelPrintList.Location = new System.Drawing.Point(125, 248);
            this.btnLabelPrintList.Name = "btnLabelPrintList";
            this.btnLabelPrintList.Size = new System.Drawing.Size(44, 20);
            this.btnLabelPrintList.TabIndex = 93;
            this.btnLabelPrintList.Text = "ขอป้าย";
            this.btnLabelPrintList.Click += new System.EventHandler(this.btnLabelPrintList_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.Text = "ประเภทป้าย :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbLabelType
            // 
            this.cmbLabelType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cmbLabelType.Items.Add("-- เลือก --");
            this.cmbLabelType.Items.Add("ป้ายซุปเปอร์");
            this.cmbLabelType.Items.Add("ป้ายใหญ่");
            this.cmbLabelType.Items.Add("ป้ายกลาง");
            this.cmbLabelType.Items.Add("ป้ายเล็ก");
            this.cmbLabelType.Location = new System.Drawing.Point(73, 202);
            this.cmbLabelType.Name = "cmbLabelType";
            this.cmbLabelType.Size = new System.Drawing.Size(162, 19);
            this.cmbLabelType.TabIndex = 97;
            // 
            // LocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.cmbLabelType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLabelPrintList);
            this.Controls.Add(this.btnOffLineView);
            this.Controls.Add(this.chkOffline);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgLocation);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtLocationCodeScan);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKeyboard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationForm";
            this.Text = "ผูกตำแหน่งสินค้า";
            this.Load += new System.EventHandler(this.LocationForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LocationForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.bsLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLocationCodeScan;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGrid dgLocation;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn columnProductCode;
        private System.Windows.Forms.DataGridTextBoxColumn columnPutLevel;
        private System.Windows.Forms.DataGridTextBoxColumn columnQuantity;
        private System.Windows.Forms.DataGridTextBoxColumn columnProductName;
        private System.Windows.Forms.DataGridTextBoxColumn columnUnitName;
        private System.Windows.Forms.BindingSource bsLocation;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridTextBoxColumn columnDisplayOrder;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button btnOffLineView;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private Resco.Controls.OutlookControls.ImageButton btnKeyboard;
        private System.Windows.Forms.DataGridTextBoxColumn columnBarcode;
        private System.Windows.Forms.Button btnLabelPrintList;
        private System.Windows.Forms.DataGridTextBoxColumn columnMaxStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLabelType;
    }
}