namespace DoHome.HandHeld.Client
{
    partial class TopstockItemsDisplay
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
            this.smartGrid = new Resco.Controls.SmartGrid.SmartGrid();
            this.Row_Order = new Resco.Controls.SmartGrid.Column();
            this.LOCATION_T = new Resco.Controls.SmartGrid.Column();
            this.MATNR = new Resco.Controls.SmartGrid.Column();
            this.MEINH_TXT = new Resco.Controls.SmartGrid.Column();
            this.BARCODE = new Resco.Controls.SmartGrid.Column();
            this.QTY = new Resco.Controls.SmartGrid.Column();
            this.SuspendLayout();
            // 
            // smartGrid
            // 
            this.smartGrid.Columns.Add(this.Row_Order);
            this.smartGrid.Columns.Add(this.LOCATION_T);
            this.smartGrid.Columns.Add(this.MATNR);
            this.smartGrid.Columns.Add(this.MEINH_TXT);
            this.smartGrid.Columns.Add(this.BARCODE);
            this.smartGrid.Columns.Add(this.QTY);
            this.smartGrid.Location = new System.Drawing.Point(3, 3);
            this.smartGrid.Name = "smartGrid";
            this.smartGrid.Size = new System.Drawing.Size(234, 263);
            this.smartGrid.TabIndex = 125;
            // 
            // Row_Order
            // 
            this.Row_Order.DataMember = "Row_Order";
            this.Row_Order.MinimumWidth = 0;
            this.Row_Order.Name = "Row_Order";
            this.Row_Order.Width = 0;
            // 
            // LOCATION_T
            // 
            this.LOCATION_T.DataMember = "LOCATION_T";
            this.LOCATION_T.HeaderText = "ตำแหน่ง";
            this.LOCATION_T.Name = "LOCATION_T";
            this.LOCATION_T.Width = 80;
            // 
            // MATNR
            // 
            this.MATNR.DataMember = "MATNR";
            this.MATNR.HeaderText = "รหัสสินค้า";
            this.MATNR.Name = "MATNR";
            this.MATNR.Width = 70;
            // 
            // MEINH_TXT
            // 
            this.MEINH_TXT.DataMember = "MEINH_TXT";
            this.MEINH_TXT.HeaderText = "หน่วย";
            this.MEINH_TXT.Name = "MEINH_TXT";
            this.MEINH_TXT.Width = 80;
            // 
            // BARCODE
            // 
            this.BARCODE.DataMember = "BARCODE";
            this.BARCODE.HeaderText = "บาร์โค้ด";
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.Width = 80;
            // 
            // QTY
            // 
            this.QTY.DataMember = "QTY";
            this.QTY.HeaderText = "จำนวน";
            this.QTY.Name = "QTY";
            this.QTY.Width = 50;
            // 
            // TopstockItemsDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.smartGrid);
            this.Name = "TopstockItemsDisplay";
            this.Text = "รายการสินค้าที่ขอป้าย Topstock";
            this.Load += new System.EventHandler(this.TopstockItemsDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid smartGrid;
        private Resco.Controls.SmartGrid.Column Row_Order;
        private Resco.Controls.SmartGrid.Column LOCATION_T;
        private Resco.Controls.SmartGrid.Column MATNR;
        private Resco.Controls.SmartGrid.Column MEINH_TXT;
        private Resco.Controls.SmartGrid.Column BARCODE;
        internal Resco.Controls.SmartGrid.Column QTY;

    }
}