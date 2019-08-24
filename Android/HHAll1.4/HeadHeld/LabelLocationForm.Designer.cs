namespace DoHome.HandHeld.Client
{
    partial class LabelLocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelLocationForm));
            this.grdLocations = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnId = new Resco.Controls.SmartGrid.Column();
            this.columnLocationCode = new Resco.Controls.SmartGrid.Column();
            this.columnDelete = new Resco.Controls.SmartGrid.Column();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.styleImage = new Resco.Controls.SmartGrid.Style();
            this.tbRequestor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRequestList = new System.Windows.Forms.Button();
            this.tbLocationCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNumericKeyboard = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbPrintType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grdLocations
            // 
            this.grdLocations.Columns.Add(this.columnId);
            this.grdLocations.Columns.Add(this.columnLocationCode);
            this.grdLocations.Columns.Add(this.columnDelete);
            this.grdLocations.FullRowSelect = true;
            this.grdLocations.Location = new System.Drawing.Point(3, 71);
            this.grdLocations.Name = "grdLocations";
            this.grdLocations.RowHeight = 20;
            this.grdLocations.SelectionVistaStyle = true;
            this.grdLocations.Size = new System.Drawing.Size(235, 174);
            this.grdLocations.Styles.Add(this.styleImage);
            this.grdLocations.TabIndex = 2;
            this.grdLocations.CellClick += new Resco.Controls.SmartGrid.CellClickHandler(this.grdLocations_CellClick);
            // 
            // columnId
            // 
            this.columnId.DataMember = "Id";
            this.columnId.HeaderText = "ลำดับที่";
            this.columnId.MinimumWidth = 0;
            this.columnId.Name = "columnId";
            this.columnId.Width = 0;
            // 
            // columnLocationCode
            // 
            this.columnLocationCode.DataMember = "LocationCode";
            this.columnLocationCode.HeaderText = "ตำแหน่งสินค้า";
            this.columnLocationCode.Name = "columnLocationCode";
            this.columnLocationCode.Width = 180;
            // 
            // columnDelete
            // 
            this.columnDelete.AlternatingStyle = "styleImage";
            this.columnDelete.HeaderText = "ลบ";
            this.columnDelete.ImageList = this.imageList1;
            this.columnDelete.Name = "columnDelete";
            this.columnDelete.SelectionStyle = "styleImage";
            this.columnDelete.Style = "styleImage";
            this.columnDelete.Width = 40;
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // styleImage
            // 
            this.styleImage.ImageAlignment = Resco.Controls.SmartGrid.Alignment.MiddleCenter;
            this.styleImage.ImagePosition = Resco.Controls.SmartGrid.ImagePosition.Foreground;
            this.styleImage.Name = "styleImage";
            // 
            // tbRequestor
            // 
            this.tbRequestor.BackColor = System.Drawing.SystemColors.Info;
            this.tbRequestor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbRequestor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbRequestor.Location = new System.Drawing.Point(47, 25);
            this.tbRequestor.Name = "tbRequestor";
            this.tbRequestor.ReadOnly = true;
            this.tbRequestor.Size = new System.Drawing.Size(192, 19);
            this.tbRequestor.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.Text = "ผู้ขอป้าย :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnRequestList
            // 
            this.btnRequestList.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnRequestList.Location = new System.Drawing.Point(157, 248);
            this.btnRequestList.Name = "btnRequestList";
            this.btnRequestList.Size = new System.Drawing.Size(81, 19);
            this.btnRequestList.TabIndex = 13;
            this.btnRequestList.Text = "สถานะการพิมพ์";
            this.btnRequestList.Click += new System.EventHandler(this.btnRequestList_Click);
            // 
            // tbLocationCode
            // 
            this.tbLocationCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbLocationCode.Location = new System.Drawing.Point(47, 3);
            this.tbLocationCode.Name = "tbLocationCode";
            this.tbLocationCode.Size = new System.Drawing.Size(167, 19);
            this.tbLocationCode.TabIndex = 14;
            this.tbLocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLocationCode_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(-4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.Text = "ตำแหน่ง :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.Location = new System.Drawing.Point(217, 3);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(22, 19);
            this.btnNumericKeyboard.TabIndex = 55;
            this.btnNumericKeyboard.Text = "KB";
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSave.Location = new System.Drawing.Point(3, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 19);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbPrintType
            // 
            this.cmbPrintType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cmbPrintType.Items.Add("ป้ายซุปเปอร์");
            this.cmbPrintType.Items.Add("ป้ายใหญ่");
            this.cmbPrintType.Items.Add("ป้ายกลาง");
            this.cmbPrintType.Items.Add("ป้ายเล็ก");
            this.cmbPrintType.Location = new System.Drawing.Point(47, 48);
            this.cmbPrintType.Name = "cmbPrintType";
            this.cmbPrintType.Size = new System.Drawing.Size(191, 19);
            this.cmbPrintType.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(-4, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.Text = "ประเภท :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.cmbPrintType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.tbLocationCode);
            this.Controls.Add(this.btnRequestList);
            this.Controls.Add(this.tbRequestor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdLocations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.MinimizeBox = false;
            this.Name = "LabelLocationForm";
            this.Text = "ขอป้ายตำแหน่ง";
            this.Load += new System.EventHandler(this.RequestLocationLabelSuperForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid grdLocations;
        private Resco.Controls.SmartGrid.Column columnId;
        private Resco.Controls.SmartGrid.Column columnLocationCode;
        private System.Windows.Forms.TextBox tbRequestor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRequestList;
        private System.Windows.Forms.TextBox tbLocationCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNumericKeyboard;
        private Resco.Controls.SmartGrid.Column columnDelete;
        private System.Windows.Forms.Button btnSave;
        private Resco.Controls.SmartGrid.Style styleImage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbPrintType;
        private System.Windows.Forms.Label label3;
    }
}