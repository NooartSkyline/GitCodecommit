namespace DoHome.HandHeld.Client
{
    partial class CountStockForm
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
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnHoldBill = new System.Windows.Forms.Button();
            this.btnResumeBill = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdProduct = new Resco.Controls.SmartGrid.SmartGrid();
            this.column2 = new Resco.Controls.SmartGrid.Column();
            this.column5 = new Resco.Controls.SmartGrid.Column();
            this.column3 = new Resco.Controls.SmartGrid.Column();
            this.column4 = new Resco.Controls.SmartGrid.Column();
            this.column6 = new Resco.Controls.SmartGrid.Column();
            this.styleNumeric = new Resco.Controls.SmartGrid.Style();
            this.btnNumericKeyboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScan
            // 
            this.txtScan.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtScan.Location = new System.Drawing.Point(72, 3);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(133, 19);
            this.txtScan.TabIndex = 1;
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.Text = "รหัส/บาร์โค้ด :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNew.Location = new System.Drawing.Point(2, 244);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(45, 20);
            this.btnNew.TabIndex = 45;
            this.btnNew.Text = "นับใหม่";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnHoldBill
            // 
            this.btnHoldBill.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnHoldBill.Location = new System.Drawing.Point(49, 244);
            this.btnHoldBill.Name = "btnHoldBill";
            this.btnHoldBill.Size = new System.Drawing.Size(45, 20);
            this.btnHoldBill.TabIndex = 45;
            this.btnHoldBill.Text = "พักบิล";
            this.btnHoldBill.Click += new System.EventHandler(this.btnHoldBill_Click);
            // 
            // btnResumeBill
            // 
            this.btnResumeBill.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnResumeBill.Location = new System.Drawing.Point(97, 244);
            this.btnResumeBill.Name = "btnResumeBill";
            this.btnResumeBill.Size = new System.Drawing.Size(45, 20);
            this.btnResumeBill.TabIndex = 45;
            this.btnResumeBill.Text = "เรียกบิล";
            this.btnResumeBill.Click += new System.EventHandler(this.btnResumeBill_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnList.Location = new System.Drawing.Point(145, 244);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(45, 20);
            this.btnList.TabIndex = 45;
            this.btnList.Text = "รายการ";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSave.Location = new System.Drawing.Point(192, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 20);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdProduct
            // 
            this.grdProduct.Columns.Add(this.column2);
            this.grdProduct.Columns.Add(this.column5);
            this.grdProduct.Columns.Add(this.column3);
            this.grdProduct.Columns.Add(this.column4);
            this.grdProduct.Columns.Add(this.column6);
            this.grdProduct.DataSource = this.bindingSource;
            this.grdProduct.FullRowSelect = true;
            this.grdProduct.Location = new System.Drawing.Point(2, 25);
            this.grdProduct.Name = "grdProduct";
            this.grdProduct.RowHeight = 20;
            this.grdProduct.SelectionVistaStyle = true;
            this.grdProduct.Size = new System.Drawing.Size(235, 216);
            this.grdProduct.Styles.Add(this.styleNumeric);
            this.grdProduct.TabIndex = 47;
            // 
            // column2
            // 
            this.column2.DataMember = "Productcode";
            this.column2.HeaderText = "รหัส";
            this.column2.Name = "column2";
            this.column2.Width = 65;
            // 
            // column5
            // 
            this.column5.DataMember = "Unitname";
            this.column5.HeaderText = "หน่วย";
            this.column5.Name = "column5";
            this.column5.Width = 50;
            // 
            // column3
            // 
            this.column3.DataMember = "Location";
            this.column3.HeaderText = "ตำแหน่ง";
            this.column3.Name = "column3";
            // 
            // column4
            // 
            this.column4.AlternatingStyle = "styleNumeric";
            this.column4.CellEdit = Resco.Controls.SmartGrid.CellEditType.TextBox;
            this.column4.DataMember = "Quantity";
            this.column4.EditMode = Resco.Controls.SmartGrid.EditMode.Auto;
            this.column4.HeaderText = "นับได้";
            this.column4.Name = "column4";
            this.column4.SelectionStyle = "styleNumeric";
            this.column4.Style = "styleNumeric";
            this.column4.Width = 40;
            // 
            // column6
            // 
            this.column6.DataMember = "Productname";
            this.column6.HeaderText = "ชื่อสินค้า";
            this.column6.Name = "column6";
            this.column6.Width = 300;
            // 
            // styleNumeric
            // 
            this.styleNumeric.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.styleNumeric.Name = "styleNumeric";
            this.styleNumeric.TextAlignment = Resco.Controls.SmartGrid.Alignment.MiddleRight;
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.Location = new System.Drawing.Point(209, 3);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(25, 19);
            this.btnNumericKeyboard.TabIndex = 56;
            this.btnNumericKeyboard.Text = "KB";
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // CountStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 284);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.grdProduct);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnResumeBill);
            this.Controls.Add(this.btnHoldBill);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountStockForm";
            this.Text = "นับสต็อกสินค้า";
            this.Load += new System.EventHandler(this.CountStockForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CountStockForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnHoldBill;
        private System.Windows.Forms.Button btnResumeBill;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource bindingSource;
        private Resco.Controls.SmartGrid.SmartGrid grdProduct;
        private Resco.Controls.SmartGrid.Column column2;
        private Resco.Controls.SmartGrid.Column column3;
        private Resco.Controls.SmartGrid.Column column4;
        private Resco.Controls.SmartGrid.Column column5;
        private Resco.Controls.SmartGrid.Column column6;
        private Resco.Controls.SmartGrid.Style styleNumeric;
        private System.Windows.Forms.Button btnNumericKeyboard;
    }
}