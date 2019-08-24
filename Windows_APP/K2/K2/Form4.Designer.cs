namespace K2
{
    partial class Form4
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
            this.dgv_BS = new System.Windows.Forms.DataGridView();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.cbb_serverip = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_BS
            // 
            this.dgv_BS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BS.Location = new System.Drawing.Point(12, 12);
            this.dgv_BS.Name = "dgv_BS";
            this.dgv_BS.Size = new System.Drawing.Size(1030, 426);
            this.dgv_BS.TabIndex = 0;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(288, 444);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(227, 20);
            this.txt_search.TabIndex = 1;
            this.txt_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_search_KeyPress);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(521, 444);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "ค้นหา";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // cbb_serverip
            // 
            this.cbb_serverip.FormattingEnabled = true;
            this.cbb_serverip.Items.AddRange(new object[] {
            "192.168.0.175",
            "192.168.0.106",
            "192.168.0.105",
            "192.168.0.104"});
            this.cbb_serverip.Location = new System.Drawing.Point(12, 444);
            this.cbb_serverip.Name = "cbb_serverip";
            this.cbb_serverip.Size = new System.Drawing.Size(270, 21);
            this.cbb_serverip.TabIndex = 3;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 481);
            this.Controls.Add(this.cbb_serverip);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dgv_BS);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Sarial";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_BS;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cbb_serverip;
    }
}