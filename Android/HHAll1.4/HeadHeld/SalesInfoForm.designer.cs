namespace DoHome.HandHeld.Client
{
    partial class SalesInfoForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSaleProfit = new System.Windows.Forms.TextBox();
            this.tbSaleProductType = new System.Windows.Forms.TextBox();
            this.tbSaleQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSaleRate = new System.Windows.Forms.TextBox();
            this.tbGroupingofmaterials = new System.Windows.Forms.TextBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbLastSaleQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLastSaleDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLastGrQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLastGrDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(8, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 14);
            this.label8.Text = "กำไรที่ได้ :";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(9, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 14);
            this.label7.Text = "ประเภทสินค้า :";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(9, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 14);
            this.label6.Text = "จำนวนขาย 1 เดือนล่าสุด :";
            // 
            // tbSaleProfit
            // 
            this.tbSaleProfit.BackColor = System.Drawing.SystemColors.Info;
            this.tbSaleProfit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbSaleProfit.Location = new System.Drawing.Point(67, 225);
            this.tbSaleProfit.Name = "tbSaleProfit";
            this.tbSaleProfit.ReadOnly = true;
            this.tbSaleProfit.Size = new System.Drawing.Size(163, 19);
            this.tbSaleProfit.TabIndex = 26;
            this.tbSaleProfit.Visible = false;
            // 
            // tbSaleProductType
            // 
            this.tbSaleProductType.BackColor = System.Drawing.SystemColors.Info;
            this.tbSaleProductType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbSaleProductType.Location = new System.Drawing.Point(83, 70);
            this.tbSaleProductType.Name = "tbSaleProductType";
            this.tbSaleProductType.ReadOnly = true;
            this.tbSaleProductType.Size = new System.Drawing.Size(147, 19);
            this.tbSaleProductType.TabIndex = 25;
            // 
            // tbSaleQuantity
            // 
            this.tbSaleQuantity.BackColor = System.Drawing.SystemColors.Info;
            this.tbSaleQuantity.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbSaleQuantity.Location = new System.Drawing.Point(133, 93);
            this.tbSaleQuantity.Name = "tbSaleQuantity";
            this.tbSaleQuantity.ReadOnly = true;
            this.tbSaleQuantity.Size = new System.Drawing.Size(97, 19);
            this.tbSaleQuantity.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(9, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 14);
            this.label5.Text = "อัตราหมุนเวียน (คิดตามจำนวน) :";
            // 
            // tbSaleRate
            // 
            this.tbSaleRate.BackColor = System.Drawing.SystemColors.Info;
            this.tbSaleRate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbSaleRate.Location = new System.Drawing.Point(10, 130);
            this.tbSaleRate.Name = "tbSaleRate";
            this.tbSaleRate.ReadOnly = true;
            this.tbSaleRate.Size = new System.Drawing.Size(220, 19);
            this.tbSaleRate.TabIndex = 23;
            // 
            // tbGroupingofmaterials
            // 
            this.tbGroupingofmaterials.BackColor = System.Drawing.SystemColors.Info;
            this.tbGroupingofmaterials.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbGroupingofmaterials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbGroupingofmaterials.Location = new System.Drawing.Point(67, 47);
            this.tbGroupingofmaterials.Name = "tbGroupingofmaterials";
            this.tbGroupingofmaterials.ReadOnly = true;
            this.tbGroupingofmaterials.Size = new System.Drawing.Size(163, 19);
            this.tbGroupingofmaterials.TabIndex = 30;
            // 
            // tbProductName
            // 
            this.tbProductName.BackColor = System.Drawing.SystemColors.Info;
            this.tbProductName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbProductName.Location = new System.Drawing.Point(61, 24);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.ReadOnly = true;
            this.tbProductName.Size = new System.Drawing.Size(169, 19);
            this.tbProductName.TabIndex = 29;
            // 
            // tbProductCode
            // 
            this.tbProductCode.BackColor = System.Drawing.SystemColors.Info;
            this.tbProductCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbProductCode.Location = new System.Drawing.Point(67, 1);
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.ReadOnly = true;
            this.tbProductCode.Size = new System.Drawing.Size(163, 19);
            this.tbProductCode.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 14);
            this.label1.Text = "รหัสสินค้า :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.Text = "ชื่อสินค้า :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.Text = "ผู้ดูแลขาย";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(90, 247);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 19);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbLastSaleQty
            // 
            this.tbLastSaleQty.BackColor = System.Drawing.SystemColors.Info;
            this.tbLastSaleQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbLastSaleQty.Location = new System.Drawing.Point(121, 202);
            this.tbLastSaleQty.Name = "tbLastSaleQty";
            this.tbLastSaleQty.ReadOnly = true;
            this.tbLastSaleQty.Size = new System.Drawing.Size(110, 19);
            this.tbLastSaleQty.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(120, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 14);
            this.label10.Text = "จำนวนขายล่าสุด :";
            // 
            // tbLastSaleDate
            // 
            this.tbLastSaleDate.BackColor = System.Drawing.SystemColors.Info;
            this.tbLastSaleDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbLastSaleDate.Location = new System.Drawing.Point(11, 202);
            this.tbLastSaleDate.Name = "tbLastSaleDate";
            this.tbLastSaleDate.ReadOnly = true;
            this.tbLastSaleDate.Size = new System.Drawing.Size(104, 19);
            this.tbLastSaleDate.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(10, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 14);
            this.label11.Text = "วันที่ขายล่าสุด :";
            // 
            // tbLastGrQty
            // 
            this.tbLastGrQty.BackColor = System.Drawing.SystemColors.Info;
            this.tbLastGrQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbLastGrQty.Location = new System.Drawing.Point(120, 165);
            this.tbLastGrQty.Name = "tbLastGrQty";
            this.tbLastGrQty.ReadOnly = true;
            this.tbLastGrQty.Size = new System.Drawing.Size(110, 19);
            this.tbLastGrQty.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(119, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 14);
            this.label9.Text = "จำนวนรับล่าสุด :";
            // 
            // tbLastGrDate
            // 
            this.tbLastGrDate.BackColor = System.Drawing.SystemColors.Info;
            this.tbLastGrDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbLastGrDate.Location = new System.Drawing.Point(10, 165);
            this.tbLastGrDate.Name = "tbLastGrDate";
            this.tbLastGrDate.ReadOnly = true;
            this.tbLastGrDate.Size = new System.Drawing.Size(104, 19);
            this.tbLastGrDate.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(9, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.Text = "วันที่รับล่าสุด :";
            // 
            // SalesInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.tbLastSaleQty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbLastSaleDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbLastGrQty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbLastGrDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSaleProfit);
            this.Controls.Add(this.tbGroupingofmaterials);
            this.Controls.Add(this.tbSaleProductType);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.tbProductCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSaleQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSaleRate);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesInfoForm";
            this.Text = "ข้อมูลการขาย";
            this.Load += new System.EventHandler(this.SalesInfoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSaleProfit;
        private System.Windows.Forms.TextBox tbSaleProductType;
        private System.Windows.Forms.TextBox tbSaleQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSaleRate;
        private System.Windows.Forms.TextBox tbGroupingofmaterials;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.TextBox tbProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbLastSaleQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbLastSaleDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLastGrQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLastGrDate;
        private System.Windows.Forms.Label label4;
    }
}