namespace DoHome.HandHeld.Client
{
    partial class LabelPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelPriceForm));
            this.grdLocations = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnId = new Resco.Controls.SmartGrid.Column();
            this.columnProductcode = new Resco.Controls.SmartGrid.Column();
            this.columnBarcode = new Resco.Controls.SmartGrid.Column();
            this.columnProductname = new Resco.Controls.SmartGrid.Column();
            this.columnUnitname = new Resco.Controls.SmartGrid.Column();
            this.columnBin = new Resco.Controls.SmartGrid.Column();
            this.columnLogg = new Resco.Controls.SmartGrid.Column();
            this.columnPrice = new Resco.Controls.SmartGrid.Column();
            this.columnDelete = new Resco.Controls.SmartGrid.Column();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.styleImage = new Resco.Controls.SmartGrid.Style();
            this.styleCurrency = new Resco.Controls.SmartGrid.Style();
            this.btnRequestList = new System.Windows.Forms.Button();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNumericKeyboard = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbPrintType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRequestor = new System.Windows.Forms.TextBox();
            this.chkPosition = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // grdLocations
            // 
            this.grdLocations.Columns.Add(this.columnId);
            this.grdLocations.Columns.Add(this.columnProductcode);
            this.grdLocations.Columns.Add(this.columnBarcode);
            this.grdLocations.Columns.Add(this.columnProductname);
            this.grdLocations.Columns.Add(this.columnUnitname);
            this.grdLocations.Columns.Add(this.columnBin);
            this.grdLocations.Columns.Add(this.columnLogg);
            this.grdLocations.Columns.Add(this.columnPrice);
            this.grdLocations.Columns.Add(this.columnDelete);
            this.grdLocations.FullRowSelect = true;
            this.grdLocations.Location = new System.Drawing.Point(3, 82);
            this.grdLocations.Name = "grdLocations";
            this.grdLocations.RowHeight = 20;
            this.grdLocations.SelectionVistaStyle = true;
            this.grdLocations.Size = new System.Drawing.Size(235, 164);
            this.grdLocations.Styles.Add(this.styleImage);
            this.grdLocations.Styles.Add(this.styleCurrency);
            this.grdLocations.TabIndex = 2;
            this.grdLocations.CellClick += new Resco.Controls.SmartGrid.CellClickHandler(this.grdLocations_CellClick);
            // 
            // columnId
            // 
            this.columnId.DataMember = "DisplayOrder";
            this.columnId.HeaderText = "ลำดับที่";
            this.columnId.MinimumWidth = 0;
            this.columnId.Name = "columnId";
            this.columnId.Width = 0;
            // 
            // columnProductcode
            // 
            this.columnProductcode.DataMember = "Productcode";
            this.columnProductcode.HeaderText = "รหัส";
            this.columnProductcode.Name = "columnProductcode";
            this.columnProductcode.Width = 60;
            // 
            // columnBarcode
            // 
            this.columnBarcode.DataMember = "Barcode";
            this.columnBarcode.HeaderText = "บาร์โค้ด";
            this.columnBarcode.Name = "columnBarcode";
            this.columnBarcode.Width = 85;
            // 
            // columnProductname
            // 
            this.columnProductname.DataMember = "Productname";
            this.columnProductname.HeaderText = "ชื่อ";
            this.columnProductname.Name = "columnProductname";
            this.columnProductname.Width = 200;
            // 
            // columnUnitname
            // 
            this.columnUnitname.DataMember = "Unitname";
            this.columnUnitname.HeaderText = "หน่วย";
            this.columnUnitname.Name = "columnUnitname";
            // 
            // columnBin
            // 
            this.columnBin.DataMember = "ProductPosition";
            this.columnBin.HeaderText = "ตำแหน่งเก็บ";
            this.columnBin.Name = "columnBin";
            // 
            // columnLogg
            // 
            this.columnLogg.DataMember = "ProductLoggr";
            this.columnLogg.HeaderText = "ผู้ดูแลจัดซื้อ";
            this.columnLogg.Name = "columnLogg";
            // 
            // columnPrice
            // 
            this.columnPrice.AlternatingStyle = "styleCurrency";
            this.columnPrice.DataMember = "Sellprice";
            this.columnPrice.HeaderText = "ราคา";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.SelectionStyle = "styleCurrency";
            this.columnPrice.Style = "styleCurrency";
            this.columnPrice.Width = 50;
            // 
            // columnDelete
            // 
            this.columnDelete.AlternatingStyle = "styleImage";
            this.columnDelete.HeaderText = "ลบ";
            this.columnDelete.ImageList = this.imageList1;
            this.columnDelete.Name = "columnDelete";
            this.columnDelete.SelectionStyle = "styleImage";
            this.columnDelete.Style = "styleImage";
            this.columnDelete.Width = 30;
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // styleImage
            // 
            this.styleImage.ImageAlignment = Resco.Controls.SmartGrid.Alignment.MiddleCenter;
            this.styleImage.ImagePosition = Resco.Controls.SmartGrid.ImagePosition.Foreground;
            this.styleImage.Name = "styleImage";
            // 
            // styleCurrency
            // 
            this.styleCurrency.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.styleCurrency.FormatString = "{0:N2}";
            this.styleCurrency.Name = "styleCurrency";
            this.styleCurrency.TextAlignment = Resco.Controls.SmartGrid.Alignment.MiddleRight;
            // 
            // btnRequestList
            // 
            this.btnRequestList.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnRequestList.Location = new System.Drawing.Point(157, 249);
            this.btnRequestList.Name = "btnRequestList";
            this.btnRequestList.Size = new System.Drawing.Size(81, 19);
            this.btnRequestList.TabIndex = 13;
            this.btnRequestList.Text = "สถานะการพิมพ์";
            this.btnRequestList.Click += new System.EventHandler(this.btnRequestList_Click);
            // 
            // tbBarcode
            // 
            this.tbBarcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbBarcode.Location = new System.Drawing.Point(47, 3);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(167, 19);
            this.tbBarcode.TabIndex = 14;
            this.tbBarcode.TextChanged += new System.EventHandler(this.tbBarcode_TextChanged);
            this.tbBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(-4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.Text = "รหัส/บาร์ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.Location = new System.Drawing.Point(217, 3);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(22, 19);
            this.btnNumericKeyboard.TabIndex = 55;
            this.btnNumericKeyboard.Text = "Kb";
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSave.Location = new System.Drawing.Point(3, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 19);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbPrintType
            // 
            this.cmbPrintType.DisplayMember = "Name";
            this.cmbPrintType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cmbPrintType.Location = new System.Drawing.Point(47, 44);
            this.cmbPrintType.Name = "cmbPrintType";
            this.cmbPrintType.Size = new System.Drawing.Size(191, 19);
            this.cmbPrintType.TabIndex = 61;
            this.cmbPrintType.ValueMember = "Code";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(-4, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.Text = "ประเภท :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.Text = "ผู้ขอป้าย :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbRequestor
            // 
            this.tbRequestor.BackColor = System.Drawing.SystemColors.Info;
            this.tbRequestor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbRequestor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbRequestor.Location = new System.Drawing.Point(47, 23);
            this.tbRequestor.Name = "tbRequestor";
            this.tbRequestor.ReadOnly = true;
            this.tbRequestor.Size = new System.Drawing.Size(192, 19);
            this.tbRequestor.TabIndex = 10;
            // 
            // chkPosition
            // 
            this.chkPosition.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkPosition.Location = new System.Drawing.Point(2, 66);
            this.chkPosition.Name = "chkPosition";
            this.chkPosition.Size = new System.Drawing.Size(146, 15);
            this.chkPosition.TabIndex = 65;
            this.chkPosition.Text = "เลือกตำแหน่ง";
            this.chkPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarcode_KeyDown);
            // 
            // LabelPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.chkPosition);
            this.Controls.Add(this.cmbPrintType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.tbBarcode);
            this.Controls.Add(this.btnRequestList);
            this.Controls.Add(this.tbRequestor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdLocations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabelPriceForm";
            this.Text = "ขอป้ายราคา";
            this.Load += new System.EventHandler(this.RequestLocationLabelSuperForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid grdLocations;
        private Resco.Controls.SmartGrid.Column columnId;
        private Resco.Controls.SmartGrid.Column columnProductcode;
        private System.Windows.Forms.Button btnRequestList;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNumericKeyboard;
        private Resco.Controls.SmartGrid.Column columnDelete;
        private System.Windows.Forms.Button btnSave;
        private Resco.Controls.SmartGrid.Style styleImage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbPrintType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRequestor;
        private Resco.Controls.SmartGrid.Column columnBarcode;
        private Resco.Controls.SmartGrid.Column columnProductname;
        private Resco.Controls.SmartGrid.Column columnPrice;
        private Resco.Controls.SmartGrid.Style styleCurrency;
        private Resco.Controls.SmartGrid.Column columnUnitname;
        private System.Windows.Forms.CheckBox chkPosition;
        private Resco.Controls.SmartGrid.Column columnBin;
        private Resco.Controls.SmartGrid.Column columnLogg;
    }
}