using DataGridCustomColumns;
namespace DoHome.HandHeld.Client
{
    partial class TopstockAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopstockAction));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnItemPost = new System.Windows.Forms.MenuItem();
            this.mnItemGetSize = new System.Windows.Forms.MenuItem();
            this.mnItemDelete = new System.Windows.Forms.MenuItem();
            this.mnItemSAPDoc = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.gvContent = new System.Windows.Forms.DataGrid();
            this.dStytblQuotationDoc = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnAllSAP = new System.Windows.Forms.Button();
            this.btnPuase = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShowUnsucces = new System.Windows.Forms.Button();
            this.smartGrid = new Resco.Controls.SmartGrid.SmartGrid();
            this.Row_Order = new Resco.Controls.SmartGrid.Column();
            this.Chk = new Resco.Controls.SmartGrid.Column();
            this.LOCATION_T = new Resco.Controls.SmartGrid.Column();
            this.MATNR = new Resco.Controls.SmartGrid.Column();
            this.MEINH_TXT = new Resco.Controls.SmartGrid.Column();
            this.BARCODE = new Resco.Controls.SmartGrid.Column();
            this.QTY = new Resco.Controls.SmartGrid.Column();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnNumericKeyboard = new Resco.Controls.OutlookControls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnNumericKeyboard)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.mnItemSAPDoc);
            this.mainMenu1.MenuItems.Add(this.menuItem4);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.mnItemPost);
            this.menuItem1.MenuItems.Add(this.mnItemGetSize);
            this.menuItem1.MenuItems.Add(this.mnItemDelete);
            this.menuItem1.Text = "เมนู";
            // 
            // mnItemPost
            // 
            this.mnItemPost.Text = "ยืนยันการสร้างใบขอป้าย Topstock";
            // 
            // mnItemGetSize
            // 
            this.mnItemGetSize.Text = "ดึงข้อมูลแบบฟอร์ม";
            // 
            // mnItemDelete
            // 
            this.mnItemDelete.Text = "ลบรายการที่เลือก";
            // 
            // mnItemSAPDoc
            // 
            this.mnItemSAPDoc.Text = "แสดงใบขอ";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "พักบิล";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "บันทึก";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "ลบ";
            // 
            // gvContent
            // 
            this.gvContent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gvContent.Location = new System.Drawing.Point(5, 120);
            this.gvContent.Name = "gvContent";
            this.gvContent.Size = new System.Drawing.Size(232, 57);
            this.gvContent.TabIndex = 4;
            this.gvContent.TableStyles.Add(this.dStytblQuotationDoc);
            this.gvContent.Visible = false;
            this.gvContent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gvContent_MouseUp);
            this.gvContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // dStytblQuotationDoc
            // 
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn8);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn9);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn10);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn11);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn12);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn13);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn14);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn15);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn16);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn17);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn18);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn19);
            this.dStytblQuotationDoc.GridColumnStyles.Add(this.dataGridTextBoxColumn20);
            this.dStytblQuotationDoc.MappingName = "TopItem";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.MappingName = "Row_Order";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "รหัสสินค้า";
            this.dataGridTextBoxColumn2.MappingName = "MATNR";
            this.dataGridTextBoxColumn2.Width = 90;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "ชื่อ";
            this.dataGridTextBoxColumn3.MappingName = "MATNR_TXT";
            this.dataGridTextBoxColumn3.Width = 110;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "หน่วย";
            this.dataGridTextBoxColumn4.MappingName = "MEINH";
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "ชื่อหน่วย";
            this.dataGridTextBoxColumn5.MappingName = "MEINH_TXT";
            this.dataGridTextBoxColumn5.Width = 80;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "บาร์โค้ด";
            this.dataGridTextBoxColumn6.MappingName = "BARCODE";
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "จำนวน";
            this.dataGridTextBoxColumn7.MappingName = "QTY";
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "อัตราส่วน";
            this.dataGridTextBoxColumn8.MappingName = "UMRZ";
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "สาขา";
            this.dataGridTextBoxColumn9.MappingName = "WERKS";
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "คลัง";
            this.dataGridTextBoxColumn10.MappingName = "LOGRT";
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "ชื่อคลัง";
            this.dataGridTextBoxColumn11.MappingName = "LGORT_TXT";
            this.dataGridTextBoxColumn11.Width = 90;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "ตำแหน่ง T";
            this.dataGridTextBoxColumn12.MappingName = "LOCATION_T";
            this.dataGridTextBoxColumn12.Width = 100;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "ตำแหน่งขาย";
            this.dataGridTextBoxColumn13.MappingName = "LOCATION_S";
            this.dataGridTextBoxColumn13.Width = 100;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "โซน";
            this.dataGridTextBoxColumn14.MappingName = "LOCZONE";
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "หัวเชลฟ์";
            this.dataGridTextBoxColumn15.MappingName = "LOCHSHELF";
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.MappingName = "LOCSIDE";
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "ด้าน";
            this.dataGridTextBoxColumn17.MappingName = "LOCSIDE_TXT";
            this.dataGridTextBoxColumn17.Width = 180;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "ช่อง";
            this.dataGridTextBoxColumn18.MappingName = "LOCHOLE";
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "ชั้น";
            this.dataGridTextBoxColumn19.MappingName = "LOCCLASS";
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "แบบฟอร์ม";
            this.dataGridTextBoxColumn20.MappingName = "FNAME_txt";
            this.dataGridTextBoxColumn20.Width = 100;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarcode.Location = new System.Drawing.Point(87, 50);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(124, 19);
            this.txtBarcode.TabIndex = 7;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // cbSize
            // 
            this.cbSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbSize.Location = new System.Drawing.Point(61, 74);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(176, 19);
            this.cbSize.TabIndex = 9;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
            this.cbSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.Text = "แบบฟอร์ม";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkSelectAll.Location = new System.Drawing.Point(1, 94);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(100, 20);
            this.chkSelectAll.TabIndex = 13;
            this.chkSelectAll.Text = "เลือกทั้งหมด";
            this.chkSelectAll.CheckStateChanged += new System.EventHandler(this.chkSelectAll_CheckStateChanged_1);
            this.chkSelectAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnAllSAP
            // 
            this.btnAllSAP.Location = new System.Drawing.Point(6, 4);
            this.btnAllSAP.Name = "btnAllSAP";
            this.btnAllSAP.Size = new System.Drawing.Size(112, 20);
            this.btnAllSAP.TabIndex = 100;
            this.btnAllSAP.Text = "แสดงใบขอ SAP";
            this.btnAllSAP.Click += new System.EventHandler(this.btnAllSAP_Click);
            this.btnAllSAP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnPuase
            // 
            this.btnPuase.Location = new System.Drawing.Point(5, 26);
            this.btnPuase.Name = "btnPuase";
            this.btnPuase.Size = new System.Drawing.Size(113, 20);
            this.btnPuase.TabIndex = 101;
            this.btnPuase.Text = "พักบิล";
            this.btnPuase.Click += new System.EventHandler(this.btnPuase_Click);
            this.btnPuase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(121, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 20);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 102;
            this.button1.Text = "บันทึก";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(183, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 20);
            this.btnDelete.TabIndex = 105;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // btnShowUnsucces
            // 
            this.btnShowUnsucces.Location = new System.Drawing.Point(121, 26);
            this.btnShowUnsucces.Name = "btnShowUnsucces";
            this.btnShowUnsucces.Size = new System.Drawing.Size(114, 20);
            this.btnShowUnsucces.TabIndex = 107;
            this.btnShowUnsucces.Text = "เรียกคืน";
            this.btnShowUnsucces.Click += new System.EventHandler(this.btnShowUnsucces_Click);
            this.btnShowUnsucces.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // smartGrid
            // 
            this.smartGrid.Columns.Add(this.Row_Order);
            this.smartGrid.Columns.Add(this.Chk);
            this.smartGrid.Columns.Add(this.LOCATION_T);
            this.smartGrid.Columns.Add(this.MATNR);
            this.smartGrid.Columns.Add(this.MEINH_TXT);
            this.smartGrid.Columns.Add(this.BARCODE);
            this.smartGrid.Columns.Add(this.QTY);
            this.smartGrid.Location = new System.Drawing.Point(5, 120);
            this.smartGrid.Name = "smartGrid";
            this.smartGrid.Size = new System.Drawing.Size(231, 146);
            this.smartGrid.TabIndex = 110;
            this.smartGrid.DoubleClick += new System.EventHandler(this.smartGrid_DoubleClick);
            this.smartGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // Row_Order
            // 
            this.Row_Order.DataMember = "Row_Order";
            this.Row_Order.MinimumWidth = 0;
            this.Row_Order.Name = "Row_Order";
            this.Row_Order.Width = 0;
            // 
            // Chk
            // 
            this.Chk.CellEdit = Resco.Controls.SmartGrid.CellEditType.CheckBox;
            this.Chk.DataMember = "Chk";
            this.Chk.EditMode = Resco.Controls.SmartGrid.EditMode.Auto;
            this.Chk.Name = "Chk";
            this.Chk.Width = 16;
            // 
            // LOCATION_T
            // 
            this.LOCATION_T.DataMember = "LOCATION_T";
            this.LOCATION_T.HeaderText = "ตำแหน่ง";
            this.LOCATION_T.Name = "LOCATION_T";
            this.LOCATION_T.Width = 80;
            // 
            // MATNR
            // 
            this.MATNR.DataMember = "MATNR";
            this.MATNR.HeaderText = "รหัสสินค้า";
            this.MATNR.Name = "MATNR";
            this.MATNR.Width = 70;
            // 
            // MEINH_TXT
            // 
            this.MEINH_TXT.DataMember = "MEINH_TXT";
            this.MEINH_TXT.HeaderText = "หน่วย";
            this.MEINH_TXT.Name = "MEINH_TXT";
            this.MEINH_TXT.Width = 80;
            // 
            // BARCODE
            // 
            this.BARCODE.DataMember = "BARCODE";
            this.BARCODE.HeaderText = "บาร์โค้ด";
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.Width = 80;
            // 
            // QTY
            // 
            this.QTY.DataMember = "QTY";
            this.QTY.HeaderText = "จำนวน";
            this.QTY.Name = "QTY";
            this.QTY.Width = 50;
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbType.Items.Add("บาร์โค้ด");
            this.cbType.Items.Add("รหัส");
            this.cbType.Items.Add("ตำแหน่ง");
            this.cbType.Location = new System.Drawing.Point(5, 50);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(77, 19);
            this.cbType.TabIndex = 113;
            // 
            // btnNumericKeyboard
            // 
            this.btnNumericKeyboard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnNumericKeyboard.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnNumericKeyboard.ImageDefault")));
            this.btnNumericKeyboard.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnNumericKeyboard.ImagePressed")));
            this.btnNumericKeyboard.Location = new System.Drawing.Point(216, 49);
            this.btnNumericKeyboard.Name = "btnNumericKeyboard";
            this.btnNumericKeyboard.Size = new System.Drawing.Size(21, 21);
            this.btnNumericKeyboard.TabIndex = 97;
            this.btnNumericKeyboard.Click += new System.EventHandler(this.btnNumericKeyboard_Click);
            // 
            // TopstockAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 269);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.smartGrid);
            this.Controls.Add(this.btnShowUnsucces);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPuase);
            this.Controls.Add(this.btnAllSAP);
            this.Controls.Add(this.btnNumericKeyboard);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvContent);
            this.Name = "TopstockAction";
            this.Text = "รายการสินค้า";
            this.Load += new System.EventHandler(this.TopstockAction_Load);
            this.Activated += new System.EventHandler(this.TopstockAction_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TopstockAction_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.btnNumericKeyboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid gvContent;
        private System.Windows.Forms.DataGridTableStyle dStytblQuotationDoc;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuItem mnItemPost;
        private System.Windows.Forms.MenuItem mnItemGetSize;
        private System.Windows.Forms.MenuItem mnItemDelete;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.MenuItem mnItemSAPDoc;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
        private Resco.Controls.OutlookControls.ImageButton btnNumericKeyboard;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.Button btnAllSAP;
        private System.Windows.Forms.Button btnPuase;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShowUnsucces;
        private Resco.Controls.SmartGrid.SmartGrid smartGrid;
        private Resco.Controls.SmartGrid.Column Row_Order;
        private Resco.Controls.SmartGrid.Column Chk;
        private Resco.Controls.SmartGrid.Column MATNR;
        private Resco.Controls.SmartGrid.Column LOCATION_T;
        private Resco.Controls.SmartGrid.Column MEINH_TXT;
        private Resco.Controls.SmartGrid.Column BARCODE;
        private System.Windows.Forms.ComboBox cbType;
        private Resco.Controls.SmartGrid.Column QTY;
        //private Resco.Controls.SmartGrid.SmartGrid sGrid;
 
    }
}