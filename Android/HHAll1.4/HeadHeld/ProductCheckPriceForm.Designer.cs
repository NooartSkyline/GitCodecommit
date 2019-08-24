namespace DoHome.HandHeld.Client
{
    partial class ProductCheckPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCheckPriceForm));
            this.bsProductLocation = new System.Windows.Forms.BindingSource(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.txtLocationCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDisplayLists = new System.Windows.Forms.Button();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvProducts = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnDisplayOrder = new Resco.Controls.SmartGrid.Column();
            this.columnShopPrice = new Resco.Controls.SmartGrid.Column();
            this.columnSalePrice = new Resco.Controls.SmartGrid.Column();
            this.columnProductCode = new Resco.Controls.SmartGrid.Column();
            this.columnProductName = new Resco.Controls.SmartGrid.Column();
            this.columnProductUnitName = new Resco.Controls.SmartGrid.Column();
            this.columnRandomText = new Resco.Controls.SmartGrid.Column();
            this.styleRed = new Resco.Controls.SmartGrid.Style();
            this.styleDecimal = new Resco.Controls.SmartGrid.Style();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.btnOffLineView = new System.Windows.Forms.Button();
            this.btnSearchUser = new Resco.Controls.OutlookControls.ImageButton();
            this.btnKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            this.btnNumericKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            this.ChkLabel = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtChangePrice = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsProductLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeyboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNumericKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(166, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 40);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "ตำแหน่งใหม่";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocationCode.Location = new System.Drawing.Point(36, 19);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(107, 19);
            this.txtLocationCode.TabIndex = 17;
            this.txtLocationCode.TextChanged += new System.EventHandler(this.txtLocationCode_TextChanged);
            this.txtLocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationCode_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.Text = "ตน. :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(130, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 41);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDisplayLists
            // 
            this.btnDisplayLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDisplayLists.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDisplayLists.Location = new System.Drawing.Point(3, 227);
            this.btnDisplayLists.Name = "btnDisplayLists";
            this.btnDisplayLists.Size = new System.Drawing.Size(124, 20);
            this.btnDisplayLists.TabIndex = 25;
            this.btnDisplayLists.Text = "ตรวจสอบรายการ";
            this.btnDisplayLists.Click += new System.EventHandler(this.btnCheckLists_Click);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Enabled = false;
            this.txtProductCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtProductCode.Location = new System.Drawing.Point(36, 40);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(107, 19);
            this.txtProductCode.TabIndex = 27;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(-36, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.Text = "ร/บ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgvProducts
            // 
            //this.dgvProducts.AutoScroll = true;
            this.dgvProducts.Columns.Add(this.columnDisplayOrder);
            this.dgvProducts.Columns.Add(this.columnShopPrice);
            this.dgvProducts.Columns.Add(this.columnSalePrice);
            this.dgvProducts.Columns.Add(this.columnProductCode);
            this.dgvProducts.Columns.Add(this.columnProductName);
            this.dgvProducts.Columns.Add(this.columnProductUnitName);
            this.dgvProducts.Columns.Add(this.columnRandomText);
            this.dgvProducts.DataSource = this.bsProductLocation;
            this.dgvProducts.FullRowSelect = true;
            this.dgvProducts.KeyNavigation = true;
            this.dgvProducts.Location = new System.Drawing.Point(3, 108);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            this.dgvProducts.Size = new System.Drawing.Size(234, 116);
            this.dgvProducts.Styles.Add(this.styleRed);
            this.dgvProducts.Styles.Add(this.styleDecimal);
            this.dgvProducts.TabIndex = 50;
            this.dgvProducts.CustomizeCell += new Resco.Controls.SmartGrid.CustomizeCellHandler(this.dgvProducts_CustomizeCell);
            this.dgvProducts.DoubleClick += new System.EventHandler(this.dgvProducts_DoubleClick);
            this.dgvProducts.Click += new System.EventHandler(this.dgvProducts_Click_1);
            // 
            // columnDisplayOrder
            // 
            this.columnDisplayOrder.DataMember = "DisplayOrder";
            this.columnDisplayOrder.HeaderText = "ลำดับ";
            this.columnDisplayOrder.Name = "columnDisplayOrder";
            this.columnDisplayOrder.Width = 35;
            // 
            // columnShopPrice
            // 
            this.columnShopPrice.AlternatingStyle = "styleDecimal";
            this.columnShopPrice.CustomizeCells = true;
            this.columnShopPrice.DataMember = "ShopPrice";
            this.columnShopPrice.HeaderText = "ราคาป้าย";
            this.columnShopPrice.Name = "columnShopPrice";
            this.columnShopPrice.SelectionStyle = "styleDecimal";
            this.columnShopPrice.Style = "styleDecimal";
            this.columnShopPrice.Width = 60;
            // 
            // columnSalePrice
            // 
            this.columnSalePrice.AlternatingStyle = "styleDecimal";
            this.columnSalePrice.DataMember = "SalePrice";
            this.columnSalePrice.HeaderText = "ราคาระบบ";
            this.columnSalePrice.Name = "columnSalePrice";
            this.columnSalePrice.SelectionStyle = "styleDecimal";
            this.columnSalePrice.Style = "styleDecimal";
            this.columnSalePrice.Width = 60;
            // 
            // columnProductCode
            // 
            this.columnProductCode.DataMember = "ProductBarcode";
            this.columnProductCode.HeaderText = "บาร์โค้ด";
            this.columnProductCode.Name = "columnProductCode";
            // 
            // columnProductName
            // 
            this.columnProductName.DataMember = "ProductName";
            this.columnProductName.HeaderText = "ชื่อสินค้า";
            this.columnProductName.Name = "columnProductName";
            this.columnProductName.Width = 200;
            // 
            // columnProductUnitName
            // 
            this.columnProductUnitName.DataMember = "ProductUnitName";
            this.columnProductUnitName.HeaderText = "หน่วยนับ";
            this.columnProductUnitName.Name = "columnProductUnitName";
            // 
            // columnRandomText
            // 
            this.columnRandomText.DataMember = "RandomText";
            this.columnRandomText.HeaderText = "สุ่มตรวจ";
            this.columnRandomText.Name = "columnRandomText";
            // 
            // styleRed
            // 
            this.styleRed.BackColor = System.Drawing.Color.Red;
            this.styleRed.FormatString = "{0:N2}";
            this.styleRed.Name = "styleRed";
            this.styleRed.TextAlignment = Resco.Controls.SmartGrid.Alignment.MiddleRight;
            // 
            // styleDecimal
            // 
            this.styleDecimal.FormatString = "{0:N2}";
            this.styleDecimal.Name = "styleDecimal";
            this.styleDecimal.TextAlignment = Resco.Controls.SmartGrid.Alignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(-28, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.Text = "พนง. :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEmployeeName.Location = new System.Drawing.Point(105, 62);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(132, 19);
            this.txtEmployeeName.TabIndex = 68;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Enabled = false;
            this.txtEmployeeCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEmployeeCode.Location = new System.Drawing.Point(36, 62);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(68, 19);
            this.txtEmployeeCode.TabIndex = 67;
            this.txtEmployeeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeCode_KeyDown);
            // 
            // chkOffline
            // 
            this.chkOffline.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkOffline.Location = new System.Drawing.Point(36, -1);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(100, 20);
            this.chkOffline.TabIndex = 73;
            this.chkOffline.Text = "โหมดออฟไลน์ ";
            this.chkOffline.CheckStateChanged += new System.EventHandler(this.chkOffline_CheckStateChanged);
            // 
            // btnOffLineView
            // 
            this.btnOffLineView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnOffLineView.Location = new System.Drawing.Point(3, 248);
            this.btnOffLineView.Name = "btnOffLineView";
            this.btnOffLineView.Size = new System.Drawing.Size(124, 20);
            this.btnOffLineView.TabIndex = 78;
            this.btnOffLineView.Text = "ออฟไลน์ -> เซิร์ฟเวอร์";
            this.btnOffLineView.Click += new System.EventHandler(this.btnOffLineView_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Enabled = false;
            this.btnSearchUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnSearchUser.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnSearchUser.ImageDefault")));
            this.btnSearchUser.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSearchUser.ImagePressed")));
            this.btnSearchUser.Location = new System.Drawing.Point(6, 0);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(21, 21);
            this.btnSearchUser.TabIndex = 83;
            this.btnSearchUser.Visible = false;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnKeyboard.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImageDefault")));
            this.btnKeyboard.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.ImagePressed")));
            this.btnKeyboard.Location = new System.Drawing.Point(144, 19);
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
            this.btnNumericKeyboard.Location = new System.Drawing.Point(144, 40);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(21, 21);
            this.btnNumericKeyboard.TabIndex = 96;
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // ChkLabel
            // 
            this.ChkLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ChkLabel.Location = new System.Drawing.Point(136, -1);
            this.ChkLabel.Name = "ChkLabel";
            this.ChkLabel.Size = new System.Drawing.Size(100, 20);
            this.ChkLabel.TabIndex = 102;
            this.ChkLabel.Text = "ตรวจป้ายราคา";
            this.ChkLabel.CheckStateChanged += new System.EventHandler(this.ChkLabel_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(0, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.Text = "วดป.ป้ายปรับ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtChangePrice
            // 
           /* this.dtChangePrice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtChangePrice.Location = new System.Drawing.Point(74, 82);
            this.dtChangePrice.Name = "dtChangePrice";
            this.dtChangePrice.Size = new System.Drawing.Size(92, 24);
            this.dtChangePrice.TabIndex = 106;
            this.dtChangePrice.Value = new System.DateTime(2013, 1, 15, 16, 48, 8, 0);
            this.dtChangePrice.ValueChanged += new System.EventHandler(this.dtChangePrice_ValueChanged);*/
            this.dtChangePrice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtChangePrice.Location = new System.Drawing.Point(71, 84);
            this.dtChangePrice.Name = "dtChangePrice";
            this.dtChangePrice.Size = new System.Drawing.Size(88, 22);
            this.dtChangePrice.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(167, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.Text = "(เดือน/วัน/ปี)";
            // 
            // ProductCheckPriceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtChangePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkLabel);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.btnSearchUser);
            this.Controls.Add(this.btnOffLineView);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDisplayLists);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtLocationCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkOffline);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductCheckPriceForm";
            this.Text = "สุ่มตรวจราคาสินค้า";
            this.Load += new System.EventHandler(this.ProductCheckPriceForm_Load);
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
        private System.Windows.Forms.Button btnDisplayLists;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bsProductLocation;
        private Resco.Controls.SmartGrid.SmartGrid dgvProducts;
        private Resco.Controls.SmartGrid.Column columnDisplayOrder;
        private Resco.Controls.SmartGrid.Column columnProductCode;
        private Resco.Controls.SmartGrid.Column columnProductName;
        private Resco.Controls.SmartGrid.Column columnProductUnitName;
        private Resco.Controls.SmartGrid.Column columnSalePrice;
        private Resco.Controls.SmartGrid.Column columnShopPrice;
        private Resco.Controls.SmartGrid.Column columnRandomText;
        private Resco.Controls.SmartGrid.Style styleRed;
        private Resco.Controls.SmartGrid.Style styleDecimal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button btnOffLineView;
        private Resco.Controls.OutlookControls.ImageButton btnSearchUser;
        private Resco.Controls.OutlookControls.ImageButton btnKeyboard;
        private Resco.Controls.OutlookControls.ImageButton btnNumericKeyboard;
        private System.Windows.Forms.CheckBox ChkLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtChangePrice;
        private System.Windows.Forms.Label label5;
    }
}