namespace DoHome.HandHeld.Client
{
    partial class OrderedSetListForm
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
            this.grdList = new Resco.Controls.SmartGrid.SmartGrid();
            this.column3 = new Resco.Controls.SmartGrid.Column();
            this.column2 = new Resco.Controls.SmartGrid.Column();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.style1 = new Resco.Controls.SmartGrid.Style();
            this.style2 = new Resco.Controls.SmartGrid.Style();
            this.chkDisplayOnlyNotClose = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.column1 = new Resco.Controls.SmartGrid.Column();
            this.column4 = new Resco.Controls.SmartGrid.Column();
            this.styleTime = new Resco.Controls.SmartGrid.Style();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.grdList.Columns.Add(this.column3);
            this.grdList.Columns.Add(this.column1);
            this.grdList.Columns.Add(this.column4);
            this.grdList.Columns.Add(this.column2);
            this.grdList.DataSource = this.bindingSource;
            this.grdList.FullRowSelect = true;
            this.grdList.Location = new System.Drawing.Point(0, 19);
            this.grdList.Name = "grdList";
            this.grdList.RowHeight = 20;
            this.grdList.SelectionVistaStyle = true;
            this.grdList.Size = new System.Drawing.Size(240, 207);
            this.grdList.Styles.Add(this.style1);
            this.grdList.Styles.Add(this.style2);
            this.grdList.Styles.Add(this.styleTime);
            this.grdList.TabIndex = 42;
            // 
            // column3
            // 
            this.column3.DataMember = "OrderNo";
            this.column3.HeaderStyle = "style2";
            this.column3.HeaderText = "เลขที่เอกสาร";
            this.column3.Name = "column3";
            // 
            // column2
            // 
            this.column2.DataMember = "DriverName";
            this.column2.HeaderStyle = "style2";
            this.column2.HeaderText = "พนักงานขับรถ/จัดสินค้า";
            this.column2.Name = "column2";
            this.column2.Width = 150;
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
            // chkDisplayOnlyNotClose
            // 
            this.chkDisplayOnlyNotClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkDisplayOnlyNotClose.Location = new System.Drawing.Point(3, -1);
            this.chkDisplayOnlyNotClose.Name = "chkDisplayOnlyNotClose";
            this.chkDisplayOnlyNotClose.Size = new System.Drawing.Size(22, 20);
            this.chkDisplayOnlyNotClose.TabIndex = 44;
            this.chkDisplayOnlyNotClose.CheckStateChanged += new System.EventHandler(this.chkDisplayOnlyNotClose_CheckStateChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(22, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 20);
            this.label8.Text = "แสดงเฉพาะใบจัดที่ยังไม่ปิด";
            // 
            // column1
            // 
            this.column1.AlternatingStyle = "styleTime";
            this.column1.DataMember = "StartOn";
            this.column1.HeaderStyle = "style2";
            this.column1.HeaderText = "เริ่ม";
            this.column1.Name = "column1";
            this.column1.SelectionStyle = "styleTime";
            this.column1.Style = "styleTime";
            this.column1.Width = 50;
            // 
            // column4
            // 
            this.column4.AlternatingStyle = "styleTime";
            this.column4.DataMember = "FinishOn";
            this.column4.HeaderStyle = "style2";
            this.column4.HeaderText = "ปิด";
            this.column4.Name = "column4";
            this.column4.SelectionStyle = "styleTime";
            this.column4.Style = "styleTime";
            this.column4.Width = 50;
            // 
            // styleTime
            // 
            this.styleTime.FormatString = "{0:HH:mm:ss}";
            this.styleTime.Name = "styleTime";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnClose.Location = new System.Drawing.Point(3, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(234, 40);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OrderedSetListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(240, 270);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkDisplayOnlyNotClose);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderedSetListForm";
            this.Text = "รายการใบจัดประจำวันนี้";
            this.Load += new System.EventHandler(this.OrderedSetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Resco.Controls.SmartGrid.SmartGrid grdList;
        private Resco.Controls.SmartGrid.Column column2;
        private Resco.Controls.SmartGrid.Column column3;
        private Resco.Controls.SmartGrid.Style style1;
        private System.Windows.Forms.BindingSource bindingSource;
        private Resco.Controls.SmartGrid.Style style2;
        private System.Windows.Forms.CheckBox chkDisplayOnlyNotClose;
        private System.Windows.Forms.Label label8;
        private Resco.Controls.SmartGrid.Column column1;
        private Resco.Controls.SmartGrid.Column column4;
        private Resco.Controls.SmartGrid.Style styleTime;
        private System.Windows.Forms.Button btnClose;
    }
}