namespace DoHome.HandHeld.Client
{
    partial class SelectProductPosition
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
            this.smartGrid = new Resco.Controls.SmartGrid.SmartGrid();
            this.Order = new Resco.Controls.SmartGrid.Column();
            this.PositionCode = new Resco.Controls.SmartGrid.Column();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Chk = new Resco.Controls.SmartGrid.Column();
            this.SuspendLayout();
            // 
            // smartGrid
            // 
            this.smartGrid.Columns.Add(this.Chk);
            this.smartGrid.Columns.Add(this.Order);
            this.smartGrid.Columns.Add(this.PositionCode);
            this.smartGrid.Location = new System.Drawing.Point(3, 10);
            this.smartGrid.Name = "smartGrid";
            this.smartGrid.Size = new System.Drawing.Size(234, 228);
            this.smartGrid.TabIndex = 0;
            this.smartGrid.Click += new System.EventHandler(this.smartGrid_Click);
            // 
            // Order
            // 
            this.Order.DataMember = "Order";
            this.Order.HeaderText = "ลำดับ";
            this.Order.Name = "Order";
            this.Order.Width = 40;
            // 
            // PositionCode
            // 
            this.PositionCode.DataMember = "PositionCode";
            this.PositionCode.HeaderText = "ตำแหน่ง";
            this.PositionCode.Name = "PositionCode";
            this.PositionCode.Width = 180;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(127, 244);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(55, 20);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "ยืนยัน";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(182, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 20);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Chk
            // 
            this.Chk.CellEdit = Resco.Controls.SmartGrid.CellEditType.CheckBox;
            this.Chk.DataMember = "Chk";
            this.Chk.Name = "Chk";
            this.Chk.Width = 16;
            // 
            // SelectProductPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.smartGrid);
            this.Name = "SelectProductPosition";
            this.Text = "เลือกตำแหน่ง";
            this.Load += new System.EventHandler(this.SelectProductPosition_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid smartGrid;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private Resco.Controls.SmartGrid.Column Order;
        private Resco.Controls.SmartGrid.Column PositionCode;
        internal Resco.Controls.SmartGrid.Column Chk;
    }
}