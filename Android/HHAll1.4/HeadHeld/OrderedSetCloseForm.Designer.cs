namespace DoHome.HandHeld.Client
{
    partial class OrderedSetCloseForm
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
            this.tbOrderNoFinish = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOrderNoFinish
            // 
            this.tbOrderNoFinish.BackColor = System.Drawing.Color.White;
            this.tbOrderNoFinish.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbOrderNoFinish.Location = new System.Drawing.Point(3, 31);
            this.tbOrderNoFinish.Name = "tbOrderNoFinish";
            this.tbOrderNoFinish.Size = new System.Drawing.Size(234, 19);
            this.tbOrderNoFinish.TabIndex = 0;
            this.tbOrderNoFinish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOrderNoFinish_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 16);
            this.label3.Text = "เลขที่ใบจัด";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(3, 56);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(234, 67);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OrderedSetCloseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 270);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbOrderNoFinish);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderedSetCloseForm";
            this.Text = "ปิดใบจัดสินค้า";
            this.Load += new System.EventHandler(this.OrderedSetCloseForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbOrderNoFinish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}