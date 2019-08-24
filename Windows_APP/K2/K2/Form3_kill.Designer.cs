namespace K2
{
    partial class Form3_kill
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
            this.dgv_killuser = new System.Windows.Forms.DataGridView();
            this.btn_kill_user_now = new System.Windows.Forms.Button();
            this.btn_search_kill = new System.Windows.Forms.Button();
            this.txt_search_kill = new System.Windows.Forms.TextBox();
            this.cbb_serverip = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_killuser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_killuser
            // 
            this.dgv_killuser.AllowUserToAddRows = false;
            this.dgv_killuser.AllowUserToDeleteRows = false;
            this.dgv_killuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_killuser.Location = new System.Drawing.Point(12, 12);
            this.dgv_killuser.Name = "dgv_killuser";
            this.dgv_killuser.ReadOnly = true;
            this.dgv_killuser.Size = new System.Drawing.Size(544, 358);
            this.dgv_killuser.TabIndex = 0;
            this.dgv_killuser.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_killuser_CellMouseClick);
            // 
            // btn_kill_user_now
            // 
            this.btn_kill_user_now.Location = new System.Drawing.Point(481, 376);
            this.btn_kill_user_now.Name = "btn_kill_user_now";
            this.btn_kill_user_now.Size = new System.Drawing.Size(75, 23);
            this.btn_kill_user_now.TabIndex = 1;
            this.btn_kill_user_now.Text = "เตะ";
            this.btn_kill_user_now.UseVisualStyleBackColor = true;
            this.btn_kill_user_now.Click += new System.EventHandler(this.Btn_kill_user_now_Click);
            // 
            // btn_search_kill
            // 
            this.btn_search_kill.Location = new System.Drawing.Point(389, 376);
            this.btn_search_kill.Name = "btn_search_kill";
            this.btn_search_kill.Size = new System.Drawing.Size(75, 23);
            this.btn_search_kill.TabIndex = 2;
            this.btn_search_kill.Text = "Search";
            this.btn_search_kill.UseVisualStyleBackColor = true;
            this.btn_search_kill.Click += new System.EventHandler(this.Btn_search_kill_Click);
            // 
            // txt_search_kill
            // 
            this.txt_search_kill.Location = new System.Drawing.Point(179, 376);
            this.txt_search_kill.Name = "txt_search_kill";
            this.txt_search_kill.Size = new System.Drawing.Size(204, 20);
            this.txt_search_kill.TabIndex = 3;
            // 
            // cbb_serverip
            // 
            this.cbb_serverip.FormattingEnabled = true;
            this.cbb_serverip.Items.AddRange(new object[] {
            "192.168.0.104",
            "192.168.0.106",
            "192.168.0.175"});
            this.cbb_serverip.Location = new System.Drawing.Point(12, 376);
            this.cbb_serverip.Name = "cbb_serverip";
            this.cbb_serverip.Size = new System.Drawing.Size(161, 21);
            this.cbb_serverip.TabIndex = 4;
            this.cbb_serverip.SelectedIndexChanged += new System.EventHandler(this.Cbb_serverip_SelectedIndexChanged);
            // 
            // Form3_kill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 407);
            this.Controls.Add(this.cbb_serverip);
            this.Controls.Add(this.txt_search_kill);
            this.Controls.Add(this.btn_search_kill);
            this.Controls.Add(this.btn_kill_user_now);
            this.Controls.Add(this.dgv_killuser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3_kill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3_kill";
            this.Load += new System.EventHandler(this.Form3_kill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_killuser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_killuser;
        private System.Windows.Forms.Button btn_kill_user_now;
        private System.Windows.Forms.Button btn_search_kill;
        private System.Windows.Forms.TextBox txt_search_kill;
        private System.Windows.Forms.ComboBox cbb_serverip;
    }
}