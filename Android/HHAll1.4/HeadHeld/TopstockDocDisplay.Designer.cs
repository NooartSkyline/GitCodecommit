namespace DoHome.HandHeld.Client
{
    partial class TopstockDocDisplay
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
            this.btnDel = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.smartGrid = new Resco.Controls.SmartGrid.SmartGrid();
            this.Row_Order = new Resco.Controls.SmartGrid.Column();
            this.DocNo = new Resco.Controls.SmartGrid.Column();
            this.Chk = new Resco.Controls.SmartGrid.Column();
            this.SAPDocNo = new Resco.Controls.SmartGrid.Column();
            this.LastUpdate = new Resco.Controls.SmartGrid.Column();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(180, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 20);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "ลบ";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.chkSelectAll.Location = new System.Drawing.Point(4, 5);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(100, 20);
            this.chkSelectAll.TabIndex = 8;
            this.chkSelectAll.Text = "เลือกทั้งหมด";
            this.chkSelectAll.CheckStateChanged += new System.EventHandler(this.chkSelectAll_CheckStateChanged);
            // 
            // smartGrid
            // 
            this.smartGrid.Columns.Add(this.Row_Order);
            this.smartGrid.Columns.Add(this.DocNo);
            this.smartGrid.Columns.Add(this.Chk);
            this.smartGrid.Columns.Add(this.SAPDocNo);
            this.smartGrid.Columns.Add(this.LastUpdate);
            this.smartGrid.Location = new System.Drawing.Point(2, 31);
            this.smartGrid.Name = "smartGrid";
            this.smartGrid.Size = new System.Drawing.Size(236, 235);
            this.smartGrid.TabIndex = 10;
            this.smartGrid.DoubleClick += new System.EventHandler(this.smartGrid_DoubleClick);
            // 
            // Row_Order
            // 
            this.Row_Order.DataMember = "Row_Order";
            this.Row_Order.Name = "Row_Order";
            this.Row_Order.Width = 0;
            // 
            // DocNo
            // 
            this.DocNo.DataMember = "DocNo";
            this.DocNo.MinimumWidth = 0;
            this.DocNo.Name = "DocNo";
            this.DocNo.Width = 0;
            // 
            // Chk
            // 
            this.Chk.CellEdit = Resco.Controls.SmartGrid.CellEditType.CheckBox;
            this.Chk.DataMember = "Chk";
            this.Chk.EditMode = Resco.Controls.SmartGrid.EditMode.Auto;
            this.Chk.Name = "Chk";
            this.Chk.Width = 16;
            // 
            // SAPDocNo
            // 
            this.SAPDocNo.DataMember = "SAPDocNo";
            this.SAPDocNo.HeaderText = "เลขที่ใบขอ";
            this.SAPDocNo.Name = "SAPDocNo";
            this.SAPDocNo.Width = 80;
            // 
            // LastUpdate
            // 
            this.LastUpdate.DataMember = "LastUpdate";
            this.LastUpdate.HeaderText = "วันที่ขอ";
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.Width = 120;
            // 
            // TopstockDocDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.smartGrid);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.chkSelectAll);
            this.Name = "TopstockDocDisplay";
            this.Text = "รายงานใบขอป้าย Topsock";
            this.Load += new System.EventHandler(this.TopstockDocDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private Resco.Controls.SmartGrid.SmartGrid smartGrid;
        private Resco.Controls.SmartGrid.Column Row_Order;
        private Resco.Controls.SmartGrid.Column SAPDocNo;
        private Resco.Controls.SmartGrid.Column LastUpdate;
        private Resco.Controls.SmartGrid.Column DocNo;
        internal Resco.Controls.SmartGrid.Column Chk;

    }
}