namespace DoHome.HandHeld.Client
{
    partial class OrderedSetForm
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOrderNo = new System.Windows.Forms.TextBox();
            this.grdForkLift = new Resco.Controls.SmartGrid.SmartGrid();
            this.column1 = new Resco.Controls.SmartGrid.Column();
            this.column3 = new Resco.Controls.SmartGrid.Column();
            this.column2 = new Resco.Controls.SmartGrid.Column();
            this.bindingSourceForklift = new System.Windows.Forms.BindingSource(this.components);
            this.style1 = new Resco.Controls.SmartGrid.Style();
            this.style2 = new Resco.Controls.SmartGrid.Style();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbShippoint = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForklift)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(-18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.Text = "เลขที่ใบจัด:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbOrderNo
            // 
            this.tbOrderNo.BackColor = System.Drawing.Color.White;
            this.tbOrderNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.tbOrderNo.Location = new System.Drawing.Point(59, 25);
            this.tbOrderNo.Name = "tbOrderNo";
            this.tbOrderNo.Size = new System.Drawing.Size(110, 19);
            this.tbOrderNo.TabIndex = 0;
            this.tbOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSerialNo_KeyDown);
            // 
            // grdForkLift
            // 
            this.grdForkLift.Columns.Add(this.column1);
            this.grdForkLift.Columns.Add(this.column3);
            this.grdForkLift.Columns.Add(this.column2);
            this.grdForkLift.DataSource = this.bindingSourceForklift;
            this.grdForkLift.Enabled = false;
            this.grdForkLift.FullRowSelect = true;
            this.grdForkLift.Location = new System.Drawing.Point(3, 49);
            this.grdForkLift.Name = "grdForkLift";
            this.grdForkLift.RowHeight = 20;
            this.grdForkLift.SelectionVistaStyle = true;
            this.grdForkLift.Size = new System.Drawing.Size(235, 176);
            this.grdForkLift.Styles.Add(this.style1);
            this.grdForkLift.Styles.Add(this.style2);
            this.grdForkLift.TabIndex = 42;
            this.grdForkLift.CellClick += new Resco.Controls.SmartGrid.CellClickHandler(this.grdForkLift_CellClick);
            // 
            // column1
            // 
            this.column1.AlternatingStyle = "style1";
            this.column1.CellEdit = Resco.Controls.SmartGrid.CellEditType.CheckBox;
            this.column1.DataMember = "IsSelected";
            this.column1.EditMode = Resco.Controls.SmartGrid.EditMode.OnEnter;
            this.column1.HeaderStyle = "style2";
            this.column1.HeaderText = "เลือก";
            this.column1.Name = "column1";
            this.column1.SelectionStyle = "style1";
            this.column1.Style = "style1";
            this.column1.Width = 30;
            // 
            // column3
            // 
            this.column3.DataMember = "ForkliftNumber";
            this.column3.HeaderStyle = "style2";
            this.column3.HeaderText = "รถ";
            this.column3.Name = "column3";
            this.column3.Width = 50;
            // 
            // column2
            // 
            this.column2.DataMember = "DriverName";
            this.column2.HeaderStyle = "style2";
            this.column2.HeaderText = "พนักงาน";
            this.column2.Name = "column2";
            this.column2.Width = 140;
            // 
            // style1
            // 
            this.style1.CheckBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(1)))));
            this.style1.CheckBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
            this.style1.ImageAlignment = Resco.Controls.SmartGrid.Alignment.MiddleCenter;
            this.style1.Name = "style1";
            this.style1.TextAlignment = Resco.Controls.SmartGrid.Alignment.MiddleCenter;
            // 
            // style2
            // 
            this.style2.Name = "style2";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnNew.Location = new System.Drawing.Point(172, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 20);
            this.btnNew.TabIndex = 43;
            this.btnNew.Text = "เอกสารใหม่";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnSave.Location = new System.Drawing.Point(161, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 40);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnFinish.Location = new System.Drawing.Point(3, 229);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(78, 40);
            this.btnFinish.TabIndex = 52;
            this.btnFinish.Text = "ปิดใบจัด";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnOrders.Location = new System.Drawing.Point(82, 229);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(78, 40);
            this.btnOrders.TabIndex = 54;
            this.btnOrders.Text = "รายการ";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(-18, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.Text = "จุดจ่าย:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbShippoint
            // 
            this.cmbShippoint.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cmbShippoint.Location = new System.Drawing.Point(59, 2);
            this.cmbShippoint.Name = "cmbShippoint";
            this.cmbShippoint.Size = new System.Drawing.Size(178, 19);
            this.cmbShippoint.TabIndex = 57;
            this.cmbShippoint.SelectedValueChanged += new System.EventHandler(this.cmbShippoint_SelectedValueChanged);
            // 
            // OrderedSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 270);
            this.Controls.Add(this.cmbShippoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grdForkLift);
            this.Controls.Add(this.tbOrderNo);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderedSetForm";
            this.Text = "จ่ายใบจัดสินค้า";
            this.Load += new System.EventHandler(this.OrderedSetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForklift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOrderNo;
        private Resco.Controls.SmartGrid.SmartGrid grdForkLift;
        private Resco.Controls.SmartGrid.Column column1;
        private Resco.Controls.SmartGrid.Column column2;
        private System.Windows.Forms.Button btnNew;
        private Resco.Controls.SmartGrid.Column column3;
        private System.Windows.Forms.Button btnSave;
        private Resco.Controls.SmartGrid.Style style1;
        private System.Windows.Forms.BindingSource bindingSourceForklift;
        private Resco.Controls.SmartGrid.Style style2;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbShippoint;
    }
}