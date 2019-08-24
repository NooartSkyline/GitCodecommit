﻿namespace DoHome.HandHeld.Client
{
    partial class ProductMixedOfflineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMixedOfflineForm));
            this.gvLocationProduct = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnLocationCode = new Resco.Controls.SmartGrid.Column();
            this.columnCountBarcode = new Resco.Controls.SmartGrid.Column();
            this.columnDelete = new Resco.Controls.SmartGrid.Column();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.styleImage = new Resco.Controls.SmartGrid.Style();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gvLocationProduct
            // 
            this.gvLocationProduct.Columns.Add(this.columnLocationCode);
            this.gvLocationProduct.Columns.Add(this.columnCountBarcode);
            this.gvLocationProduct.Columns.Add(this.columnDelete);
            this.gvLocationProduct.FullRowSelect = true;
            this.gvLocationProduct.Location = new System.Drawing.Point(3, 3);
            this.gvLocationProduct.Name = "gvLocationProduct";
            this.gvLocationProduct.RowHeight = 20;
            this.gvLocationProduct.SelectionVistaStyle = true;
            this.gvLocationProduct.Size = new System.Drawing.Size(235, 238);
            this.gvLocationProduct.Styles.Add(this.styleImage);
            this.gvLocationProduct.TabIndex = 0;
            this.gvLocationProduct.CellClick += new Resco.Controls.SmartGrid.CellClickHandler(this.gvLocationProduct_CellClick);
            // 
            // columnLocationCode
            // 
            this.columnLocationCode.DataMember = "LocationCode";
            this.columnLocationCode.HeaderText = "ตำแหน่ง";
            this.columnLocationCode.Name = "columnLocationCode";
            this.columnLocationCode.Width = 100;
            // 
            // columnCountBarcode
            // 
            this.columnCountBarcode.DataMember = "NumberOfChild";
            this.columnCountBarcode.HeaderText = "จำนวนสินค้า";
            this.columnCountBarcode.Name = "columnCountBarcode";
            this.columnCountBarcode.Width = 100;
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
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(3, 246);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 20);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "บันทึกไปยัง เซิร์ฟเวอร์";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(128, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 20);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProductMixedOfflineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gvLocationProduct);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductMixedOfflineForm";
            this.Text = "จำนวนรายการตรวจสินค้าปน";
            this.Load += new System.EventHandler(this.ProductMixedOfflineForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid gvLocationProduct;
        private Resco.Controls.SmartGrid.Column columnLocationCode;
        private Resco.Controls.SmartGrid.Column columnCountBarcode;
        private Resco.Controls.SmartGrid.Style styleImage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private Resco.Controls.SmartGrid.Column columnDelete;
    }
}