﻿namespace DoHome.HandHeld.Client
{
    partial class LocationLabelPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationLabelPrintForm));
            this.gvLocationProduct = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnDocumentNo = new Resco.Controls.SmartGrid.Column();
            this.columnLocationCode = new Resco.Controls.SmartGrid.Column();
            this.columnQuantityOfLabel = new Resco.Controls.SmartGrid.Column();
            this.styleImage = new Resco.Controls.SmartGrid.Style();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gvLocationProduct
            // 
            this.gvLocationProduct.Columns.Add(this.columnDocumentNo);
            this.gvLocationProduct.Columns.Add(this.columnLocationCode);
            this.gvLocationProduct.Columns.Add(this.columnQuantityOfLabel);
            this.gvLocationProduct.FullRowSelect = true;
            this.gvLocationProduct.Location = new System.Drawing.Point(3, 3);
            this.gvLocationProduct.Name = "gvLocationProduct";
            this.gvLocationProduct.RowHeight = 20;
            this.gvLocationProduct.SelectionVistaStyle = true;
            this.gvLocationProduct.Size = new System.Drawing.Size(235, 237);
            this.gvLocationProduct.Styles.Add(this.styleImage);
            this.gvLocationProduct.TabIndex = 0;
            // 
            // columnDocumentNo
            // 
            this.columnDocumentNo.DataMember = "DocumentNo";
            this.columnDocumentNo.HeaderText = "เลขที่เอกสาร";
            this.columnDocumentNo.Name = "columnDocumentNo";
            this.columnDocumentNo.Width = 80;
            // 
            // columnLocationCode
            // 
            this.columnLocationCode.DataMember = "LocationCode";
            this.columnLocationCode.HeaderText = "ตำแหน่ง";
            this.columnLocationCode.Name = "columnLocationCode";
            this.columnLocationCode.Width = 70;
            // 
            // columnQuantityOfLabel
            // 
            this.columnQuantityOfLabel.DataMember = "QuantityOfLabel";
            this.columnQuantityOfLabel.HeaderText = "ป้ายที่ขอพิมพ์";
            this.columnQuantityOfLabel.Name = "columnQuantityOfLabel";
            this.columnQuantityOfLabel.Width = 80;
            // 
            // styleImage
            // 
            this.styleImage.ImageAlignment = Resco.Controls.SmartGrid.Alignment.MiddleCenter;
            this.styleImage.ImagePosition = Resco.Controls.SmartGrid.ImagePosition.Foreground;
            this.styleImage.Name = "styleImage";
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(3, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(234, 20);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LocationLabelPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gvLocationProduct);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationLabelPrintForm";
            this.Text = "รายการสุ่มตรวจราคาสินค้า";
            this.Load += new System.EventHandler(this.LocationLabelPrintForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid gvLocationProduct;
        private Resco.Controls.SmartGrid.Column columnDocumentNo;
        private Resco.Controls.SmartGrid.Column columnLocationCode;
        private Resco.Controls.SmartGrid.Style styleImage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnClose;
        private Resco.Controls.SmartGrid.Column columnQuantityOfLabel;
    }
}