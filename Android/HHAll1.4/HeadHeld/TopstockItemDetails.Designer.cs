namespace DoHome.HandHeld.Client
{
    partial class TopstockItemDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopstockItemDetails));
            this.Save = new System.Windows.Forms.Button();
            this.txtLoca = new System.Windows.Forms.TextBox();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtBar = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNumericKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnNumericKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(75, 132);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(72, 20);
            this.Save.TabIndex = 0;
            this.Save.Text = "บันทึก";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // txtLoca
            // 
            this.txtLoca.Enabled = false;
            this.txtLoca.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLoca.Location = new System.Drawing.Point(59, 18);
            this.txtLoca.Name = "txtLoca";
            this.txtLoca.Size = new System.Drawing.Size(165, 19);
            this.txtLoca.TabIndex = 1;
            this.txtLoca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnit_KeyDown);
            // 
            // txtItemId
            // 
            this.txtItemId.Enabled = false;
            this.txtItemId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtItemId.Location = new System.Drawing.Point(59, 40);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(165, 19);
            this.txtItemId.TabIndex = 2;
            this.txtItemId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnit_KeyDown);
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtUnit.Location = new System.Drawing.Point(59, 63);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(165, 19);
            this.txtUnit.TabIndex = 3;
            this.txtUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnit_KeyDown);
            // 
            // txtBar
            // 
            this.txtBar.Enabled = false;
            this.txtBar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBar.Location = new System.Drawing.Point(59, 85);
            this.txtBar.Name = "txtBar";
            this.txtBar.Size = new System.Drawing.Size(165, 19);
            this.txtBar.TabIndex = 4;
            this.txtBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnit_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(59, 107);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(142, 19);
            this.txtQty.TabIndex = 5;
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "ตำแหน่ง";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "รหัส";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "หน่วย";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "บาร์โค้ด";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "จำนวน";
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnNumericKeyboard.ImageDefault")));
            this.btnNumericKeyboard.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnNumericKeyboard.ImagePressed")));
            this.btnNumericKeyboard.Location = new System.Drawing.Point(203, 106);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(21, 21);
            this.btnNumericKeyboard.TabIndex = 98;
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 99;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TopstockItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBar);
            this.Controls.Add(this.txtLoca);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "TopstockItemDetails";
            this.Text = "แก้ไขจำนวนที่ขอพิมพ์ป้าย";
            this.Load += new System.EventHandler(this.TopstockItemDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnNumericKeyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox txtLoca;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtBar;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Resco.Controls.OutlookControls.ImageButton btnNumericKeyboard;
        private System.Windows.Forms.Button btnCancel;
    }
}