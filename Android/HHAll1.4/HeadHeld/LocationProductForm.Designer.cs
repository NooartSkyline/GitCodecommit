namespace DoHome.HandHeld.Client
{
    partial class LocationProductForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductCodeOrBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlProductUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPutQty = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPutLevel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeep = new System.Windows.Forms.TextBox();
            this.chkRequestPrintLabel = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaxStock = new System.Windows.Forms.TextBox();
            this.btnNumericKeyboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(-1, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.Text = "รหัส/บาร์โค้ด :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProductCodeOrBarcode
            // 
            this.txtProductCodeOrBarcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtProductCodeOrBarcode.Location = new System.Drawing.Point(71, 13);
            this.txtProductCodeOrBarcode.Name = "txtProductCodeOrBarcode";
            this.txtProductCodeOrBarcode.Size = new System.Drawing.Size(125, 19);
            this.txtProductCodeOrBarcode.TabIndex = 0;
            this.txtProductCodeOrBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCodeOrBarcode_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(17, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.Text = "ชื่อสินค้า :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtProductName.Location = new System.Drawing.Point(71, 63);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(153, 19);
            this.txtProductName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(142, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 38);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "ปิดหน้าจอ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(67, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 38);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "เพิ่มสินค้า";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlProductUnit
            // 
            this.ddlProductUnit.DisplayMember = "Name";
            this.ddlProductUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ddlProductUnit.Location = new System.Drawing.Point(71, 239);
            this.ddlProductUnit.Name = "ddlProductUnit";
            this.ddlProductUnit.Size = new System.Drawing.Size(153, 19);
            this.ddlProductUnit.TabIndex = 3;
            this.ddlProductUnit.ValueMember = "Code";
            this.ddlProductUnit.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(17, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.Text = "หน่วยนับ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Visible = false;
            // 
            // txtPutQty
            // 
            this.txtPutQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtPutQty.Location = new System.Drawing.Point(71, 114);
            this.txtPutQty.Name = "txtPutQty";
            this.txtPutQty.Size = new System.Drawing.Size(153, 19);
            this.txtPutQty.TabIndex = 5;
            this.txtPutQty.Text = "1";
            this.txtPutQty.TextChanged += new System.EventHandler(this.txtPutQty_TextChanged);
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtProductCode.Location = new System.Drawing.Point(71, 38);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(153, 19);
            this.txtProductCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.Text = "รหัสสินค้า :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(13, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.Text = "จน.ขาวาง :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(13, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.Text = "จน.ชั้น :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPutLevel
            // 
            this.txtPutLevel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtPutLevel.Location = new System.Drawing.Point(71, 89);
            this.txtPutLevel.Name = "txtPutLevel";
            this.txtPutLevel.Size = new System.Drawing.Size(153, 19);
            this.txtPutLevel.TabIndex = 4;
            this.txtPutLevel.Text = "1";
            this.txtPutLevel.TextChanged += new System.EventHandler(this.txtPutLevel_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(-1, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.Text = "ลึก :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label6.Visible = false;
            // 
            // txtDeep
            // 
            this.txtDeep.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtDeep.Location = new System.Drawing.Point(28, 206);
            this.txtDeep.Name = "txtDeep";
            this.txtDeep.Size = new System.Drawing.Size(28, 19);
            this.txtDeep.TabIndex = 44;
            this.txtDeep.Visible = false;
            this.txtDeep.TextChanged += new System.EventHandler(this.txtDeep_TextChanged);
            // 
            // chkRequestPrintLabel
            // 
            this.chkRequestPrintLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkRequestPrintLabel.Location = new System.Drawing.Point(71, 161);
            this.chkRequestPrintLabel.Name = "chkRequestPrintLabel";
            this.chkRequestPrintLabel.Size = new System.Drawing.Size(151, 20);
            this.chkRequestPrintLabel.TabIndex = 7;
            this.chkRequestPrintLabel.Text = "ขอพิมพ์ป้ายตำแหน่ง";
            this.chkRequestPrintLabel.CheckStateChanged += new System.EventHandler(this.chkRequestPrintLabel_CheckStateChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(0, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.Text = "จน.เก็บสูงสุด :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMaxStock
            // 
            this.txtMaxStock.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMaxStock.Location = new System.Drawing.Point(71, 139);
            this.txtMaxStock.Name = "txtMaxStock";
            this.txtMaxStock.Size = new System.Drawing.Size(153, 19);
            this.txtMaxStock.TabIndex = 6;
            this.txtMaxStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaxStock_KeyDown);
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.Location = new System.Drawing.Point(199, 13);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(25, 19);
            this.btnNumericKeyboard.TabIndex = 54;
            this.btnNumericKeyboard.Text = "KB";
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // LocationProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMaxStock);
            this.Controls.Add(this.chkRequestPrintLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDeep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPutLevel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtPutQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlProductUnit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductCodeOrBarcode);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationProductForm";
            this.Text = "เลือกสินค้า";
            this.Load += new System.EventHandler(this.LocationProductForm_Load);
            this.Activated += new System.EventHandler(this.LocationProductForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductCodeOrBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlProductUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPutQty;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPutLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeep;
        private System.Windows.Forms.CheckBox chkRequestPrintLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxStock;
        private System.Windows.Forms.Button btnNumericKeyboard;
    }
}