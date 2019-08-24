namespace DoHome.HandHeld.Client
{
    partial class PurchaseInfoForm
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
            this.tbGroupingofmaterials = new System.Windows.Forms.TextBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdPurchaseOrder = new Resco.Controls.SmartGrid.SmartGrid();
            this.column1 = new Resco.Controls.SmartGrid.Column();
            this.column2 = new Resco.Controls.SmartGrid.Column();
            this.column3 = new Resco.Controls.SmartGrid.Column();
            this.column4 = new Resco.Controls.SmartGrid.Column();
            this.SuspendLayout();
            // 
            // tbGroupingofmaterials
            // 
            this.tbGroupingofmaterials.BackColor = System.Drawing.SystemColors.Info;
            this.tbGroupingofmaterials.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbGroupingofmaterials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbGroupingofmaterials.Location = new System.Drawing.Point(52, 44);
            this.tbGroupingofmaterials.Name = "tbGroupingofmaterials";
            this.tbGroupingofmaterials.ReadOnly = true;
            this.tbGroupingofmaterials.Size = new System.Drawing.Size(185, 19);
            this.tbGroupingofmaterials.TabIndex = 30;
            // 
            // tbProductName
            // 
            this.tbProductName.BackColor = System.Drawing.SystemColors.Info;
            this.tbProductName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbProductName.Location = new System.Drawing.Point(52, 23);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.ReadOnly = true;
            this.tbProductName.Size = new System.Drawing.Size(185, 19);
            this.tbProductName.TabIndex = 29;
            // 
            // tbProductCode
            // 
            this.tbProductCode.BackColor = System.Drawing.SystemColors.Info;
            this.tbProductCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbProductCode.Location = new System.Drawing.Point(52, 2);
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.ReadOnly = true;
            this.tbProductCode.Size = new System.Drawing.Size(185, 19);
            this.tbProductCode.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.Text = "รหัสสินค้า:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.Text = "ชื่อสินค้า:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(-1, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.Text = "ผู้ดูแลขาย:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(83, 248);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 19);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdPurchaseOrder
            // 
            this.grdPurchaseOrder.Columns.Add(this.column1);
            this.grdPurchaseOrder.Columns.Add(this.column2);
            this.grdPurchaseOrder.Columns.Add(this.column3);
            this.grdPurchaseOrder.Columns.Add(this.column4);
            this.grdPurchaseOrder.FullRowSelect = true;
            this.grdPurchaseOrder.Location = new System.Drawing.Point(2, 66);
            this.grdPurchaseOrder.Name = "grdPurchaseOrder";
            this.grdPurchaseOrder.RowHeight = 20;
            this.grdPurchaseOrder.SelectionVistaStyle = true;
            this.grdPurchaseOrder.Size = new System.Drawing.Size(235, 180);
            this.grdPurchaseOrder.TabIndex = 41;
            // 
            // column1
            // 
            this.column1.DataMember = "OrderNo";
            this.column1.HeaderText = "เลขที่เอกสาร";
            this.column1.Name = "column1";
            this.column1.Width = 80;
            // 
            // column2
            // 
            this.column2.DataMember = "OrderDate";
            this.column2.HeaderText = "วันที่เอกสาร";
            this.column2.Name = "column2";
            this.column2.Width = 70;
            // 
            // column3
            // 
            this.column3.DataMember = "AppointDate";
            this.column3.HeaderText = "วันที่นัดรับ";
            this.column3.Name = "column3";
            // 
            // column4
            // 
            this.column4.DataMember = "EmployeeNo";
            this.column4.HeaderText = "พนักงาน";
            this.column4.Name = "column4";
            this.column4.Width = 150;
            // 
            // PurchaseInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.tbGroupingofmaterials);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.tbProductCode);
            this.Controls.Add(this.grdPurchaseOrder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseInfoForm";
            this.Text = "ข้อมูลใบสั่งซื้อ";
            this.Load += new System.EventHandler(this.SalesInfoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbGroupingofmaterials;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.TextBox tbProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private Resco.Controls.SmartGrid.SmartGrid grdPurchaseOrder;
        private Resco.Controls.SmartGrid.Column column1;
        private Resco.Controls.SmartGrid.Column column2;
        private Resco.Controls.SmartGrid.Column column3;
        private Resco.Controls.SmartGrid.Column column4;
    }
}