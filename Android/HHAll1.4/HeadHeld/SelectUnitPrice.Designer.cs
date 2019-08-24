namespace DoHome.HandHeld.Client
{
    partial class SelectUnitPrice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.smartGrid = new Resco.Controls.SmartGrid.SmartGrid();
            this.Chk = new Resco.Controls.SmartGrid.Column();
            this.DisplayOrder = new Resco.Controls.SmartGrid.Column();
            this.Unitcode = new Resco.Controls.SmartGrid.Column();
            this.UnitName = new Resco.Controls.SmartGrid.Column();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(182, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 20);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(127, 241);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(55, 20);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "ยืนยัน";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // smartGrid
            // 
            this.smartGrid.Columns.Add(this.Chk);
            this.smartGrid.Columns.Add(this.DisplayOrder);
            this.smartGrid.Columns.Add(this.Unitcode);
            this.smartGrid.Columns.Add(this.UnitName);
            this.smartGrid.Location = new System.Drawing.Point(3, 7);
            this.smartGrid.Name = "smartGrid";
            this.smartGrid.Size = new System.Drawing.Size(234, 228);
            this.smartGrid.TabIndex = 3;
            this.smartGrid.CellClick += new Resco.Controls.SmartGrid.CellClickHandler(this.smartGrid_CellClick);
            // 
            // Chk
            // 
            this.Chk.CellEdit = Resco.Controls.SmartGrid.CellEditType.CheckBox;
            this.Chk.DataMember = "Chk";
            this.Chk.EditMode = Resco.Controls.SmartGrid.EditMode.Auto;
            this.Chk.Name = "Chk";
            this.Chk.Width = 16;
            // 
            // DisplayOrder
            // 
            this.DisplayOrder.DataMember = "DisplayOrder";
            this.DisplayOrder.HeaderText = "ลำดับ";
            this.DisplayOrder.Name = "DisplayOrder";
            this.DisplayOrder.Width = 37;
            // 
            // Unitcode
            // 
            this.Unitcode.DataMember = "Unitcode";
            this.Unitcode.HeaderText = "รหัสหน่วย";
            this.Unitcode.Name = "Unitcode";
            // 
            // UnitName
            // 
            this.UnitName.DataMember = "UnitName";
            this.UnitName.HeaderText = "ชื่อหน่วย";
            this.UnitName.Name = "UnitName";
            this.UnitName.Width = 100;
            // 
            // SelectUnitPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.smartGrid);
            this.Name = "SelectUnitPrice";
            this.Text = "เลือกหน่วย";
            this.Load += new System.EventHandler(this.SelectUnitPrice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private Resco.Controls.SmartGrid.SmartGrid smartGrid;
        private Resco.Controls.SmartGrid.Column DisplayOrder;
        private Resco.Controls.SmartGrid.Column Unitcode;
        private Resco.Controls.SmartGrid.Column UnitName;
        internal Resco.Controls.SmartGrid.Column Chk;
    }
}