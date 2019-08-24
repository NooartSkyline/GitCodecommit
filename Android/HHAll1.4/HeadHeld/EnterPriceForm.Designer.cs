namespace DoHome.HandHeld.Client
{
    partial class EnterPriceForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPriceValue = new System.Windows.Forms.TextBox();
            this.ddlProductUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(69, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 20);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ตกลง";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(22, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.Text = "ราคา :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 20);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPriceValue
            // 
            this.txtPriceValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPriceValue.Location = new System.Drawing.Point(69, 28);
            this.txtPriceValue.Name = "txtPriceValue";
            this.txtPriceValue.Size = new System.Drawing.Size(116, 19);
            this.txtPriceValue.TabIndex = 0;
            this.txtPriceValue.TextChanged += new System.EventHandler(this.txtPriceValue_TextChanged);
            this.txtPriceValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPriceValue_KeyDown);
            // 
            // ddlProductUnit
            // 
            /*this.ddlProductUnit.DisplayMember = "Name";
            this.ddlProductUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ddlProductUnit.Location = new System.Drawing.Point(69, 5);
            this.ddlProductUnit.Name = "ddlProductUnit";
            this.ddlProductUnit.Size = new System.Drawing.Size(116, 19);
            this.ddlProductUnit.TabIndex = 7;
            this.ddlProductUnit.ValueMember = "Code";
            this.ddlProductUnit.SelectedIndexChanged += new System.EventHandler(this.ddlProductUnit_SelectedIndexChanged);*/
            this.ddlProductUnit.DisplayMember = "Name";
            this.ddlProductUnit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ddlProductUnit.Location = new System.Drawing.Point(69, 8);
            this.ddlProductUnit.Name = "ddlProductUnit";
            this.ddlProductUnit.Size = new System.Drawing.Size(116, 20);
            this.ddlProductUnit.TabIndex = 6;
            this.ddlProductUnit.ValueMember = "Code";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.Text = "หน่วยนับ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EnterPriceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(242, 80);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlProductUnit);
            this.Controls.Add(this.txtPriceValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterPriceForm";
            this.Text = "แสกนราคาสินค้า";
            this.Load += new System.EventHandler(this.EnterPriceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPriceValue;
        private System.Windows.Forms.ComboBox ddlProductUnit;
        private System.Windows.Forms.Label label1;
    }
}