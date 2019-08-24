namespace DoHome.HandHeld.Client
{
    partial class LabelLocationViewForm
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
            this.gvLocationProduct = new Resco.Controls.SmartGrid.SmartGrid();
            this.columnDocno = new Resco.Controls.SmartGrid.Column();
            this.columnLocationCode = new Resco.Controls.SmartGrid.Column();
            this.columnStatus = new Resco.Controls.SmartGrid.Column();
            this.styleImage = new Resco.Controls.SmartGrid.Style();
            this.SuspendLayout();
            // 
            // gvLocationProduct
            // 
            this.gvLocationProduct.Columns.Add(this.columnDocno);
            this.gvLocationProduct.Columns.Add(this.columnLocationCode);
            this.gvLocationProduct.Columns.Add(this.columnStatus);
            this.gvLocationProduct.FullRowSelect = true;
            this.gvLocationProduct.Location = new System.Drawing.Point(3, 3);
            this.gvLocationProduct.Name = "gvLocationProduct";
            this.gvLocationProduct.RowHeight = 20;
            this.gvLocationProduct.SelectionVistaStyle = true;
            this.gvLocationProduct.Size = new System.Drawing.Size(232, 256);
            this.gvLocationProduct.Styles.Add(this.styleImage);
            this.gvLocationProduct.TabIndex = 0;
            // 
            // columnDocno
            // 
            this.columnDocno.DataMember = "Docno";
            this.columnDocno.HeaderText = "เลขที่เอกสาร";
            this.columnDocno.Name = "columnDocno";
            this.columnDocno.Width = 80;
            // 
            // columnLocationCode
            // 
            this.columnLocationCode.DataMember = "LocationCode";
            this.columnLocationCode.HeaderText = "ตำแหน่ง";
            this.columnLocationCode.Name = "columnLocationCode";
            this.columnLocationCode.Width = 80;
            // 
            // columnStatus
            // 
            this.columnStatus.DataMember = "PrintedStatus";
            this.columnStatus.HeaderText = "สถานะ";
            this.columnStatus.Name = "columnStatus";
            this.columnStatus.Width = 60;
            // 
            // styleImage
            // 
            this.styleImage.ImageAlignment = Resco.Controls.SmartGrid.Alignment.MiddleCenter;
            this.styleImage.ImagePosition = Resco.Controls.SmartGrid.ImagePosition.Foreground;
            this.styleImage.Name = "styleImage";
            // 
            // LabelLocationViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.gvLocationProduct);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabelLocationViewForm";
            this.Text = "สถานะการพิมพ์";
            this.Load += new System.EventHandler(this.RequestLocationLabelSuperOfflineForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid gvLocationProduct;
        private Resco.Controls.SmartGrid.Column columnLocationCode;
        private Resco.Controls.SmartGrid.Column columnStatus;
        private Resco.Controls.SmartGrid.Style styleImage;
        private Resco.Controls.SmartGrid.Column columnDocno;
    }
}