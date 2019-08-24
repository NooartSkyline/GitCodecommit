namespace K2
{
    partial class Form1
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
            this.dgv_list_hd = new System.Windows.Forms.DataGridView();
            this.txt_numrunning = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_list_dt = new System.Windows.Forms.DataGridView();
            this.dgv_log = new System.Windows.Forms.DataGridView();
            this.txt_Docno = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_list_dtr = new System.Windows.Forms.DataGridView();
            this.lb_status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_kill = new System.Windows.Forms.Button();
            this.btn_BatchSerial = new System.Windows.Forms.Button();
            this.btn_listuser = new System.Windows.Forms.Button();
            this.cbb_serverip = new System.Windows.Forms.ComboBox();
            this.lb_statuss = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_hd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_dtr)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_list_hd
            // 
            this.dgv_list_hd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_list_hd.Location = new System.Drawing.Point(12, 68);
            this.dgv_list_hd.Name = "dgv_list_hd";
            this.dgv_list_hd.Size = new System.Drawing.Size(1621, 136);
            this.dgv_list_hd.TabIndex = 0;
            // 
            // txt_numrunning
            // 
            this.txt_numrunning.Location = new System.Drawing.Point(403, 19);
            this.txt_numrunning.Name = "txt_numrunning";
            this.txt_numrunning.Size = new System.Drawing.Size(247, 20);
            this.txt_numrunning.TabIndex = 1;
            this.txt_numrunning.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_numrunning_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "running : ";
            // 
            // dgv_list_dt
            // 
            this.dgv_list_dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_list_dt.Location = new System.Drawing.Point(12, 223);
            this.dgv_list_dt.Name = "dgv_list_dt";
            this.dgv_list_dt.Size = new System.Drawing.Size(1621, 168);
            this.dgv_list_dt.TabIndex = 3;
            // 
            // dgv_log
            // 
            this.dgv_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_log.Location = new System.Drawing.Point(12, 605);
            this.dgv_log.Name = "dgv_log";
            this.dgv_log.Size = new System.Drawing.Size(1621, 247);
            this.dgv_log.TabIndex = 4;
            // 
            // txt_Docno
            // 
            this.txt_Docno.Location = new System.Drawing.Point(941, 19);
            this.txt_Docno.Name = "txt_Docno";
            this.txt_Docno.Size = new System.Drawing.Size(247, 20);
            this.txt_Docno.TabIndex = 5;
            this.txt_Docno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Docno_KeyPress);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(1194, 16);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 6;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(896, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Docno";
            // 
            // dgv_list_dtr
            // 
            this.dgv_list_dtr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_list_dtr.Location = new System.Drawing.Point(12, 410);
            this.dgv_list_dtr.Name = "dgv_list_dtr";
            this.dgv_list_dtr.Size = new System.Drawing.Size(1621, 176);
            this.dgv_list_dtr.TabIndex = 8;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(12, 1025);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(0, 13);
            this.lb_status.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 589);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Log web service send to sap";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rawmat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Detail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Header";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_kill);
            this.groupBox1.Controls.Add(this.btn_BatchSerial);
            this.groupBox1.Controls.Add(this.btn_listuser);
            this.groupBox1.Controls.Add(this.cbb_serverip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.txt_Docno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_numrunning);
            this.groupBox1.Location = new System.Drawing.Point(16, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1275, 47);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // btn_kill
            // 
            this.btn_kill.Location = new System.Drawing.Point(6, 18);
            this.btn_kill.Name = "btn_kill";
            this.btn_kill.Size = new System.Drawing.Size(75, 23);
            this.btn_kill.TabIndex = 16;
            this.btn_kill.Text = "เตะ";
            this.btn_kill.UseVisualStyleBackColor = true;
            this.btn_kill.Click += new System.EventHandler(this.Btn_kill_Click);
            // 
            // btn_BatchSerial
            // 
            this.btn_BatchSerial.Location = new System.Drawing.Point(737, 19);
            this.btn_BatchSerial.Name = "btn_BatchSerial";
            this.btn_BatchSerial.Size = new System.Drawing.Size(108, 23);
            this.btn_BatchSerial.TabIndex = 10;
            this.btn_BatchSerial.Text = "เช็ค Batch&Serial";
            this.btn_BatchSerial.UseVisualStyleBackColor = true;
            this.btn_BatchSerial.Click += new System.EventHandler(this.Btn_BatchSerial_Click);
            // 
            // btn_listuser
            // 
            this.btn_listuser.Location = new System.Drawing.Point(656, 19);
            this.btn_listuser.Name = "btn_listuser";
            this.btn_listuser.Size = new System.Drawing.Size(75, 23);
            this.btn_listuser.TabIndex = 9;
            this.btn_listuser.Text = "ดูคนกด";
            this.btn_listuser.UseVisualStyleBackColor = true;
            this.btn_listuser.Click += new System.EventHandler(this.Btn_listuser_Click);
            // 
            // cbb_serverip
            // 
            this.cbb_serverip.FormattingEnabled = true;
            this.cbb_serverip.Items.AddRange(new object[] {
            "192.168.0.175",
            "192.168.0.106",
            "192.168.0.105",
            "192.168.0.104"});
            this.cbb_serverip.Location = new System.Drawing.Point(86, 19);
            this.cbb_serverip.Name = "cbb_serverip";
            this.cbb_serverip.Size = new System.Drawing.Size(235, 21);
            this.cbb_serverip.TabIndex = 8;
            this.cbb_serverip.SelectedIndexChanged += new System.EventHandler(this.Cbb_serverip_SelectedIndexChanged);
            // 
            // lb_statuss
            // 
            this.lb_statuss.AutoSize = true;
            this.lb_statuss.Location = new System.Drawing.Point(8, 855);
            this.lb_statuss.Name = "lb_statuss";
            this.lb_statuss.Size = new System.Drawing.Size(35, 13);
            this.lb_statuss.TabIndex = 15;
            this.lb_statuss.Text = "status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1645, 873);
            this.Controls.Add(this.lb_statuss);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.dgv_list_dtr);
            this.Controls.Add(this.dgv_log);
            this.Controls.Add(this.dgv_list_dt);
            this.Controls.Add(this.dgv_list_hd);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "K2";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_hd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_list_dtr)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_list_hd;
        private System.Windows.Forms.TextBox txt_numrunning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_list_dt;
        private System.Windows.Forms.DataGridView dgv_log;
        private System.Windows.Forms.TextBox txt_Docno;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_list_dtr;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_serverip;
        private System.Windows.Forms.Label lb_statuss;
        private System.Windows.Forms.Button btn_listuser;
        private System.Windows.Forms.Button btn_kill;
        private System.Windows.Forms.Button btn_BatchSerial;
    }
}

