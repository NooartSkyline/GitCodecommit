namespace DoHome.HandHeld.Client
{
    partial class CountStockMainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgProduct = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.BinCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.QuantityForSale = new System.Windows.Forms.DataGridTextBoxColumn();
            this.UnitNameForSale = new System.Windows.Forms.DataGridTextBoxColumn();
            this.QuantityForSKU = new System.Windows.Forms.DataGridTextBoxColumn();
            this.UnitNameForSKU = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnHoldBill = new System.Windows.Forms.Button();
            this.btnResumeBill = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlCounterBill = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(-15, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.Text = "เลขที่ใบนับ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgProduct
            // 
            this.dgProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgProduct.DataSource = this.bindingSource;
            this.dgProduct.Location = new System.Drawing.Point(3, 25);
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.RowHeadersVisible = false;
            this.dgProduct.Size = new System.Drawing.Size(234, 233);
            this.dgProduct.TabIndex = 40;
            this.dgProduct.TableStyles.Add(this.dataGridTableStyle1);
            this.dgProduct.DoubleClick += new System.EventHandler(this.dgProduct_DoubleClick);
            this.dgProduct.Click += new System.EventHandler(this.dgProduct_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.BinCode);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.ProductCode);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.Barcode);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.ProductName);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.QuantityForSale);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.UnitNameForSale);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.QuantityForSKU);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.UnitNameForSKU);
            this.dataGridTableStyle1.MappingName = "HandHeldCounterMainHold";
            // 
            // BinCode
            // 
            this.BinCode.Format = "";
            this.BinCode.FormatInfo = null;
            this.BinCode.HeaderText = "ตำแหน่ง";
            this.BinCode.MappingName = "BinCode";
            this.BinCode.Width = 80;
            // 
            // ProductCode
            // 
            this.ProductCode.Format = "";
            this.ProductCode.FormatInfo = null;
            this.ProductCode.HeaderText = "รหัสสินค้า";
            this.ProductCode.MappingName = "ProductCode";
            this.ProductCode.Width = 70;
            // 
            // Barcode
            // 
            this.Barcode.Format = "";
            this.Barcode.FormatInfo = null;
            this.Barcode.HeaderText = "บาร์โค็ด";
            this.Barcode.MappingName = "Barcode";
            this.Barcode.Width = 0;
            // 
            // ProductName
            // 
            this.ProductName.Format = "";
            this.ProductName.FormatInfo = null;
            this.ProductName.HeaderText = "ชื่อสินค้า";
            this.ProductName.MappingName = "Maktx";
            this.ProductName.Width = 120;
            // 
            // QuantityForSale
            // 
            this.QuantityForSale.Format = "N2";
            this.QuantityForSale.FormatInfo = null;
            this.QuantityForSale.HeaderText = "จน. (ขาย)";
            this.QuantityForSale.MappingName = "ErfmgSales";
            this.QuantityForSale.Width = 70;
            // 
            // UnitNameForSale
            // 
            this.UnitNameForSale.Format = "";
            this.UnitNameForSale.FormatInfo = null;
            this.UnitNameForSale.HeaderText = "น.(ขาย)";
            this.UnitNameForSale.MappingName = "UnitNameForSale";
            // 
            // QuantityForSKU
            // 
            this.QuantityForSKU.Format = "N2";
            this.QuantityForSKU.FormatInfo = null;
            this.QuantityForSKU.HeaderText = "จน. (Stock)";
            this.QuantityForSKU.MappingName = "ErfmgSku";
            this.QuantityForSKU.Width = 70;
            // 
            // UnitNameForSKU
            // 
            this.UnitNameForSKU.Format = "";
            this.UnitNameForSKU.FormatInfo = null;
            this.UnitNameForSKU.HeaderText = "น.(สต็อค)";
            this.UnitNameForSKU.MappingName = "UnitNameForSKU";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNew.Location = new System.Drawing.Point(0, 261);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(40, 20);
            this.btnNew.TabIndex = 41;
            this.btnNew.Text = "นับใหม่";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnHoldBill
            // 
            this.btnHoldBill.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnHoldBill.Location = new System.Drawing.Point(42, 261);
            this.btnHoldBill.Name = "btnHoldBill";
            this.btnHoldBill.Size = new System.Drawing.Size(40, 20);
            this.btnHoldBill.TabIndex = 42;
            this.btnHoldBill.Text = "พักบิล";
            this.btnHoldBill.Click += new System.EventHandler(this.btnHoldBill_Click);
            // 
            // btnResumeBill
            // 
            this.btnResumeBill.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnResumeBill.Location = new System.Drawing.Point(84, 261);
            this.btnResumeBill.Name = "btnResumeBill";
            this.btnResumeBill.Size = new System.Drawing.Size(41, 20);
            this.btnResumeBill.TabIndex = 43;
            this.btnResumeBill.Text = "เรียกบิล";
            this.btnResumeBill.Click += new System.EventHandler(this.btnResumeBill_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnList.Location = new System.Drawing.Point(127, 261);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(69, 20);
            this.btnList.TabIndex = 44;
            this.btnList.Text = "รายการ";
            this.btnList.Visible = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSave.Location = new System.Drawing.Point(198, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 20);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlCounterBill
            // 
            this.ddlCounterBill.DisplayMember = "Name";
            this.ddlCounterBill.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ddlCounterBill.Location = new System.Drawing.Point(58, 3);
            this.ddlCounterBill.Name = "ddlCounterBill";
            this.ddlCounterBill.Size = new System.Drawing.Size(136, 19);
            this.ddlCounterBill.TabIndex = 36;
            this.ddlCounterBill.ValueMember = "Code";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(196, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(41, 19);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // CountStockMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 284);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnResumeBill);
            this.Controls.Add(this.btnHoldBill);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgProduct);
            this.Controls.Add(this.ddlCounterBill);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountStockMainForm";
            this.Text = "นับสต็อกใหญ่";
            this.Load += new System.EventHandler(this.CountStockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid dgProduct;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnHoldBill;
        private System.Windows.Forms.Button btnResumeBill;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridTextBoxColumn QuantityForSale;
        private System.Windows.Forms.DataGridTextBoxColumn QuantityForSKU;
        private System.Windows.Forms.DataGridTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridTextBoxColumn Barcode;
        private System.Windows.Forms.ComboBox ddlCounterBill;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridTextBoxColumn UnitNameForSale;
        private System.Windows.Forms.DataGridTextBoxColumn UnitNameForSKU;
        private System.Windows.Forms.DataGridTextBoxColumn BinCode;
    }
}