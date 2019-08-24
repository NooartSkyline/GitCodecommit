namespace DoHome.HandHeld.Client
{
    partial class MainTopstock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTopstock));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnItemMain = new System.Windows.Forms.MenuItem();
            this.mnItemCreate = new System.Windows.Forms.MenuItem();
            this.mnItemDelete = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnItemClose = new System.Windows.Forms.MenuItem();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.smartGrid = new Resco.Controls.SmartGrid.SmartGrid();
            this.Row_Order = new Resco.Controls.SmartGrid.Column();
            this.DocNo = new Resco.Controls.SmartGrid.Column();
            this.Chk = new Resco.Controls.SmartGrid.Column();
            this.PDocNo = new Resco.Controls.SmartGrid.Column();
            this.Branch = new Resco.Controls.SmartGrid.Column();
            this.Warehouse = new Resco.Controls.SmartGrid.Column();
            this.LastUpdate = new Resco.Controls.SmartGrid.Column();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnItemMain);
            // 
            // mnItemMain
            // 
            this.mnItemMain.MenuItems.Add(this.mnItemCreate);
            this.mnItemMain.MenuItems.Add(this.mnItemDelete);
            this.mnItemMain.MenuItems.Add(this.menuItem2);
            this.mnItemMain.MenuItems.Add(this.mnItemClose);
            this.mnItemMain.Text = "เมนู";
            // 
            // mnItemCreate
            // 
            this.mnItemCreate.Text = "สร้างใบขอป้าย Topstock";
            // 
            // mnItemDelete
            // 
            this.mnItemDelete.Text = "ลบรายการที่เลือก";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "-";
            // 
            // mnItemClose
            // 
            this.mnItemClose.Text = "ปิดหน้านี้";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.chkSelectAll.Location = new System.Drawing.Point(4, 7);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(100, 20);
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.Text = "เลือกทั้งหมด";
            this.chkSelectAll.CheckStateChanged += new System.EventHandler(this.chkSelectAll_CheckStateChanged);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(180, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 20);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "ลบ";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // smartGrid
            // 
            this.smartGrid.Columns.Add(this.Row_Order);
            this.smartGrid.Columns.Add(this.DocNo);
            this.smartGrid.Columns.Add(this.Chk);
            this.smartGrid.Columns.Add(this.PDocNo);
            this.smartGrid.Columns.Add(this.Branch);
            this.smartGrid.Columns.Add(this.Warehouse);
            this.smartGrid.Columns.Add(this.LastUpdate);
            this.smartGrid.Location = new System.Drawing.Point(4, 34);
            this.smartGrid.Name = "smartGrid";
            this.smartGrid.Size = new System.Drawing.Size(232, 232);
            this.smartGrid.TabIndex = 7;
            this.smartGrid.DoubleClick += new System.EventHandler(this.smartGrid_DoubleClick);
            // 
            // Row_Order
            // 
            this.Row_Order.DataMember = "Row_Order";
            this.Row_Order.MinimumWidth = 0;
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
            // PDocNo
            // 
            this.PDocNo.DataMember = "PDocNo";
            this.PDocNo.HeaderText = "เลขที่เอกสารพักบิล";
            this.PDocNo.Name = "PDocNo";
            this.PDocNo.Width = 102;
            // 
            // Branch
            // 
            this.Branch.DataMember = "Branch";
            this.Branch.HeaderText = "สาขา";
            this.Branch.MinimumWidth = 0;
            this.Branch.Name = "Branch";
            this.Branch.Width = 0;
            // 
            // Warehouse
            // 
            this.Warehouse.DataMember = "Warehouse";
            this.Warehouse.HeaderText = "คลัง";
            this.Warehouse.MinimumWidth = 0;
            this.Warehouse.Name = "Warehouse";
            this.Warehouse.Width = 0;
            // 
            // LastUpdate
            // 
            this.LastUpdate.DataMember = "LastUpdate";
            this.LastUpdate.HeaderText = "วันที่ทำรายการ";
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.Width = 120;
            // 
            // MainTopstock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.smartGrid);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.chkSelectAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainTopstock";
            this.Text = "รายงานเอกสารพักบิล";
            this.Load += new System.EventHandler(this.MainTopstock_Load);
            this.Activated += new System.EventHandler(this.MainTopstock_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnItemMain;
        private System.Windows.Forms.MenuItem mnItemCreate;
        private System.Windows.Forms.MenuItem mnItemDelete;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnItemClose;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnDel;
        private Resco.Controls.SmartGrid.SmartGrid smartGrid;
        private Resco.Controls.SmartGrid.Column Row_Order;
        private Resco.Controls.SmartGrid.Column DocNo;
        private Resco.Controls.SmartGrid.Column PDocNo;
        private Resco.Controls.SmartGrid.Column Branch;
        private Resco.Controls.SmartGrid.Column Warehouse;
        private Resco.Controls.SmartGrid.Column LastUpdate;
        internal Resco.Controls.SmartGrid.Column Chk;

    }
}