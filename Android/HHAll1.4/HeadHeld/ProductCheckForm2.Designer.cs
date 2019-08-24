namespace DoHome.HandHeld.Client
{
    partial class ProductCheckForm2
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
            this.gvProductInfo = new Resco.Controls.SmartGrid.SmartGrid();
            this.column4 = new Resco.Controls.SmartGrid.Column();
            this.column5 = new Resco.Controls.SmartGrid.Column();
            this.column2StockQuantity = new Resco.Controls.SmartGrid.Column();
            this.column6 = new Resco.Controls.SmartGrid.Column();
            this.column2StoreLocation = new Resco.Controls.SmartGrid.Column();
            this.btnSaveProductOutOfStock = new System.Windows.Forms.Button();
            this.txtGroupingofmaterials = new System.Windows.Forms.TextBox();
            this.txtProductCodeOrBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNumericKeyboard = new System.Windows.Forms.Button();
            this.gvOutOfStock = new Resco.Controls.SmartGrid.SmartGrid();
            this.column1 = new Resco.Controls.SmartGrid.Column();
            this.column2 = new Resco.Controls.SmartGrid.Column();
            this.column3 = new Resco.Controls.SmartGrid.Column();
            this.column7 = new Resco.Controls.SmartGrid.Column();
            this.bsProductOutOfStock = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalesInfo = new System.Windows.Forms.Button();
            this.btnPurchaseInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsProductOutOfStock)).BeginInit();
            this.SuspendLayout();
            // 
            // gvProductInfo
            // 
            this.gvProductInfo.AlternatingBackColor = System.Drawing.Color.PaleGoldenrod;
            //this.gvProductInfo.AutoScroll = true;
            this.gvProductInfo.Columns.Add(this.column4);
            this.gvProductInfo.Columns.Add(this.column5);
            this.gvProductInfo.Columns.Add(this.column2StockQuantity);
            this.gvProductInfo.Columns.Add(this.column6);
            this.gvProductInfo.Columns.Add(this.column2StoreLocation);
            this.gvProductInfo.FullRowSelect = true;
            this.gvProductInfo.HeaderVistaStyle = true;
            this.gvProductInfo.KeyNavigation = true;
            this.gvProductInfo.Location = new System.Drawing.Point(3, 65);
            this.gvProductInfo.Name = "gvProductInfo";
            this.gvProductInfo.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            this.gvProductInfo.SelectionVistaStyle = true;
            this.gvProductInfo.Size = new System.Drawing.Size(234, 92);
            this.gvProductInfo.TabIndex = 50;
            this.gvProductInfo.TouchScrolling = true;
            // 
            // column4
            // 
            this.column4.DataMember = "Barcode";
            this.column4.HeaderText = "บาร์โค้ด";
            this.column4.Name = "column4";
            this.column4.Width = 90;
            // 
            // column5
            // 
            this.column5.DataMember = "UnitName";
            this.column5.HeaderText = "หน่วย";
            this.column5.Name = "column5";
            this.column5.Width = 50;
            // 
            // column2StockQuantity
            // 
            this.column2StockQuantity.DataMember = "StockQuantity";
            this.column2StockQuantity.HeaderText = "จำนวน";
            this.column2StockQuantity.Name = "column2StockQuantity";
            this.column2StockQuantity.Width = 42;
            // 
            // column6
            // 
            this.column6.DataMember = "ProductPriceText";
            this.column6.HeaderText = "ราคา";
            this.column6.Name = "column6";
            this.column6.Width = 50;
            // 
            // column2StoreLocation
            // 
            this.column2StoreLocation.DataMember = "StoreLocation";
            this.column2StoreLocation.HeaderText = "ที่เก็บ";
            this.column2StoreLocation.Name = "column2StoreLocation";
            this.column2StoreLocation.Width = 0;
            // 
            // btnSaveProductOutOfStock
            // 
            this.btnSaveProductOutOfStock.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSaveProductOutOfStock.Location = new System.Drawing.Point(171, 249);
            this.btnSaveProductOutOfStock.Name = "btnSaveProductOutOfStock";
            this.btnSaveProductOutOfStock.Size = new System.Drawing.Size(13, 19);
            this.btnSaveProductOutOfStock.TabIndex = 21;
            this.btnSaveProductOutOfStock.Text = "บันทึกสินค้าหมดชั่วคราว";
            this.btnSaveProductOutOfStock.Visible = false;
            this.btnSaveProductOutOfStock.Click += new System.EventHandler(this.btnSaveProductOutOfStock_Click);
            // 
            // txtGroupingofmaterials
            // 
            this.txtGroupingofmaterials.BackColor = System.Drawing.SystemColors.Info;
            this.txtGroupingofmaterials.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtGroupingofmaterials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGroupingofmaterials.Location = new System.Drawing.Point(69, 24);
            this.txtGroupingofmaterials.Name = "txtGroupingofmaterials";
            this.txtGroupingofmaterials.ReadOnly = true;
            this.txtGroupingofmaterials.Size = new System.Drawing.Size(168, 19);
            this.txtGroupingofmaterials.TabIndex = 21;
            // 
            // txtProductCodeOrBarcode
            // 
            this.txtProductCodeOrBarcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtProductCodeOrBarcode.Location = new System.Drawing.Point(69, 3);
            this.txtProductCodeOrBarcode.Name = "txtProductCodeOrBarcode";
            this.txtProductCodeOrBarcode.Size = new System.Drawing.Size(108, 19);
            this.txtProductCodeOrBarcode.TabIndex = 1;
            this.txtProductCodeOrBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.Text = "รหัส/บาร์โค้ด:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtProductCode.Location = new System.Drawing.Point(3, 24);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(65, 19);
            this.txtProductCode.TabIndex = 8;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtProductName.Location = new System.Drawing.Point(3, 45);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(234, 19);
            this.txtProductName.TabIndex = 9;
            // 
            // btnRequest
            // 
            this.btnRequest.Enabled = false;
            this.btnRequest.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnRequest.Location = new System.Drawing.Point(202, 3);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(35, 19);
            this.btnRequest.TabIndex = 12;
            this.btnRequest.Text = "ขอซื้อ";
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(183, 249);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 19);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.Location = new System.Drawing.Point(179, 3);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(22, 19);
            this.btnNumericKeyboard.TabIndex = 53;
            this.btnNumericKeyboard.Text = "KB";
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // gvOutOfStock
            // 
            this.gvOutOfStock.AlternatingBackColor = System.Drawing.Color.PaleGoldenrod;
            //this.gvOutOfStock.AutoScroll = true;
            this.gvOutOfStock.Columns.Add(this.column1);
            this.gvOutOfStock.Columns.Add(this.column2);
            this.gvOutOfStock.Columns.Add(this.column3);
            this.gvOutOfStock.Columns.Add(this.column7);
            this.gvOutOfStock.DataSource = this.bsProductOutOfStock;
            this.gvOutOfStock.FullRowSelect = true;
            this.gvOutOfStock.KeyNavigation = true;
            this.gvOutOfStock.Location = new System.Drawing.Point(4, 158);
            this.gvOutOfStock.Name = "gvOutOfStock";
            this.gvOutOfStock.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            this.gvOutOfStock.SelectionVistaStyle = true;
            this.gvOutOfStock.Size = new System.Drawing.Size(235, 90);
            this.gvOutOfStock.TabIndex = 55;
            // 
            // column1
            // 
            this.column1.DataMember = "BalanceQuantityText";
            this.column1.HeaderText = "จำนวน";
            this.column1.Name = "column1";
            this.column1.Width = 50;
            // 
            // column2
            // 
            this.column2.DataMember = "LocationCode";
            this.column2.HeaderText = "ตำแหน่ง";
            this.column2.Name = "column2";
            this.column2.Width = 70;
            // 
            // column3
            // 
            this.column3.DataMember = "WarehouseCode";
            this.column3.HeaderText = "รหัสคลัง";
            this.column3.Name = "column3";
            this.column3.Width = 50;
            // 
            // column7
            // 
            this.column7.DataMember = "WarehouseName";
            this.column7.HeaderText = "ชื่อคลัง";
            this.column7.Name = "column7";
            this.column7.Width = 100;
            // 
            // btnSalesInfo
            // 
            this.btnSalesInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSalesInfo.Location = new System.Drawing.Point(3, 249);
            this.btnSalesInfo.Name = "btnSalesInfo";
            this.btnSalesInfo.Size = new System.Drawing.Size(74, 19);
            this.btnSalesInfo.TabIndex = 57;
            this.btnSalesInfo.Text = "ข้อมูลการขาย";
            this.btnSalesInfo.Click += new System.EventHandler(this.btnSalesInfo_Click);
            // 
            // btnPurchaseInfo
            // 
            this.btnPurchaseInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnPurchaseInfo.Location = new System.Drawing.Point(81, 249);
            this.btnPurchaseInfo.Name = "btnPurchaseInfo";
            this.btnPurchaseInfo.Size = new System.Drawing.Size(84, 19);
            this.btnPurchaseInfo.TabIndex = 58;
            this.btnPurchaseInfo.Text = "ข้อมูลใบสั่งซื้อ";
            this.btnPurchaseInfo.Click += new System.EventHandler(this.btnPurchaseInfo_Click);
            // 
            // ProductCheckForm2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnPurchaseInfo);
            this.Controls.Add(this.btnSalesInfo);
            this.Controls.Add(this.gvOutOfStock);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvProductInfo);
            this.Controls.Add(this.txtGroupingofmaterials);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtProductCodeOrBarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveProductOutOfStock);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductCheckForm2";
            this.Text = "ตรวจสอบสินค้า";
            this.Load += new System.EventHandler(this.ProductCheckForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsProductOutOfStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductCodeOrBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnSaveProductOutOfStock;
        private System.Windows.Forms.BindingSource bsProductOutOfStock;
        private Resco.Controls.SmartGrid.SmartGrid gvProductInfo;
        private Resco.Controls.SmartGrid.Column column2StockQuantity;
        private Resco.Controls.SmartGrid.Column column2StoreLocation;
        private Resco.Controls.SmartGrid.Column column5;
        private Resco.Controls.SmartGrid.Column column6;
        private System.Windows.Forms.TextBox txtGroupingofmaterials;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNumericKeyboard;
        private Resco.Controls.SmartGrid.SmartGrid gvOutOfStock;
        private Resco.Controls.SmartGrid.Column column1;
        private Resco.Controls.SmartGrid.Column column2;
        private Resco.Controls.SmartGrid.Column column3;
        private Resco.Controls.SmartGrid.Column column7;
        private Resco.Controls.SmartGrid.Column column4;
        private System.Windows.Forms.Button btnSalesInfo;
        private System.Windows.Forms.Button btnPurchaseInfo;


    }
}