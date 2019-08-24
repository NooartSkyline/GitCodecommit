namespace DoHome.HandHeld.Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuCheckProduct = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuItemCheckPrice = new System.Windows.Forms.MenuItem();
            this.mnuMixProduct = new System.Windows.Forms.MenuItem();
            this.mnuLocationCheck = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuProductLocation = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuRequestLocationLabelSuper = new System.Windows.Forms.MenuItem();
            this.mnuLabelPrice = new System.Windows.Forms.MenuItem();
            this.mnItemTopstock = new System.Windows.Forms.MenuItem();
            this.mnuItems = new System.Windows.Forms.MenuItem();
            this.mnuChangeWarehouse = new System.Windows.Forms.MenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItem1);
            this.mainMenu.MenuItems.Add(this.mnuChangeWarehouse);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.mnuCheckProduct);
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.MenuItems.Add(this.mnuItemCheckPrice);
            this.menuItem1.MenuItems.Add(this.mnuMixProduct);
            this.menuItem1.MenuItems.Add(this.mnuLocationCheck);
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.MenuItems.Add(this.mnuProductLocation);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.MenuItems.Add(this.mnuRequestLocationLabelSuper);
            this.menuItem1.MenuItems.Add(this.mnuLabelPrice);
            this.menuItem1.MenuItems.Add(this.mnItemTopstock);
            this.menuItem1.MenuItems.Add(this.mnuItems);
            this.menuItem1.Text = "โมดูล";
            // 
            // mnuCheckProduct
            // 
            this.mnuCheckProduct.Text = "ตรวจสินค้า";
            this.mnuCheckProduct.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "-";
            // 
            // mnuItemCheckPrice
            // 
            this.mnuItemCheckPrice.Text = "สุ่มตรวจราคาสินค้า";
            this.mnuItemCheckPrice.Click += new System.EventHandler(this.mnuItemCheckPrice_Click);
            // 
            // mnuMixProduct
            // 
            this.mnuMixProduct.Text = "ตรวจสอบสินค้าปน";
            this.mnuMixProduct.Click += new System.EventHandler(this.mnuMixProduct_Click);
            // 
            // mnuLocationCheck
            // 
            this.mnuLocationCheck.Text = "ตรวจสอบตำแหน่ง";
            this.mnuLocationCheck.Click += new System.EventHandler(this.mnuLocationCheck_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // mnuProductLocation
            // 
            this.mnuProductLocation.Text = "ผูกตำแหน่งสินค้า";
            this.mnuProductLocation.Click += new System.EventHandler(this.mnuProductLocation_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "-";
            // 
            // mnuRequestLocationLabelSuper
            // 
            this.mnuRequestLocationLabelSuper.Text = "ขอป้ายตำแหน่ง";
            this.mnuRequestLocationLabelSuper.Click += new System.EventHandler(this.mnuRequestLocationLabelSuper_Click);
            // 
            // mnuLabelPrice
            // 
            this.mnuLabelPrice.Text = "ขอป้ายราคา";
            this.mnuLabelPrice.Click += new System.EventHandler(this.mnuLabelPrice_Click);
            // 
            // mnItemTopstock
            // 
            this.mnItemTopstock.Text = "ขอป้าย Topstock";
            this.mnItemTopstock.Click += new System.EventHandler(this.mnItemTopstock_Click);
            // 
            // mnuItems
            // 
            this.mnuItems.Text = "-";
            // 
            // mnuChangeWarehouse
            // 
            this.mnuChangeWarehouse.Enabled = false;
            this.mnuChangeWarehouse.Text = "เปลี่ยนคลัง";
            this.mnuChangeWarehouse.Click += new System.EventHandler(this.mnuChangeWarehouse_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(1, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.Text = "รหัสผู้ใช้ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUserCode
            // 
            this.txtUserCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtUserCode.Location = new System.Drawing.Point(56, 46);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.ReadOnly = true;
            this.txtUserCode.Size = new System.Drawing.Size(174, 19);
            this.txtUserCode.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(1, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.Text = "ชื่อผู้ใช้ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtUserName.Location = new System.Drawing.Point(56, 71);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(174, 19);
            this.txtUserName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(1, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.Text = "Server :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Visible = false;
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.SystemColors.Info;
            this.txtServer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtServer.Location = new System.Drawing.Point(56, 158);
            this.txtServer.Name = "txtServer";
            this.txtServer.ReadOnly = true;
            this.txtServer.Size = new System.Drawing.Size(174, 19);
            this.txtServer.TabIndex = 9;
            this.txtServer.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(1, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.Text = "สาขา :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBranch
            // 
            this.txtBranch.BackColor = System.Drawing.SystemColors.Info;
            this.txtBranch.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBranch.Location = new System.Drawing.Point(56, 96);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.ReadOnly = true;
            this.txtBranch.Size = new System.Drawing.Size(174, 19);
            this.txtBranch.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(1, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.Text = "ปีบัญชี :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Visible = false;
            // 
            // txtAccountYear
            // 
            this.txtAccountYear.BackColor = System.Drawing.SystemColors.Info;
            this.txtAccountYear.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtAccountYear.Location = new System.Drawing.Point(56, 208);
            this.txtAccountYear.Name = "txtAccountYear";
            this.txtAccountYear.ReadOnly = true;
            this.txtAccountYear.Size = new System.Drawing.Size(174, 19);
            this.txtAccountYear.TabIndex = 15;
            this.txtAccountYear.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(1, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.Text = "Client :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label6.Visible = false;
            // 
            // txtClient
            // 
            this.txtClient.BackColor = System.Drawing.SystemColors.Info;
            this.txtClient.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtClient.Location = new System.Drawing.Point(56, 183);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(174, 19);
            this.txtClient.TabIndex = 18;
            this.txtClient.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(1, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.Text = "คลัง :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.BackColor = System.Drawing.SystemColors.Info;
            this.txtWarehouse.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtWarehouse.Location = new System.Drawing.Point(56, 121);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.ReadOnly = true;
            this.txtWarehouse.Size = new System.Drawing.Size(174, 19);
            this.txtWarehouse.TabIndex = 25;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAccountYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserCode);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DHandHeld";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuCheckProduct;
        private System.Windows.Forms.MenuItem mnuProductLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccountYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.MenuItem mnuChangeWarehouse;
        private System.Windows.Forms.MenuItem mnuMixProduct;
        private System.Windows.Forms.MenuItem mnuItemCheckPrice;
        private System.Windows.Forms.MenuItem mnuLocationCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWarehouse;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem mnuRequestLocationLabelSuper;
        private System.Windows.Forms.MenuItem mnuLabelPrice;
        private System.Windows.Forms.MenuItem mnuItems;
        private System.Windows.Forms.MenuItem mnItemTopstock;
    }
}