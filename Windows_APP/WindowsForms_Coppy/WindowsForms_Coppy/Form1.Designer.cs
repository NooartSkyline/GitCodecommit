namespace WindowsForms_Coppy
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
            this.btn_CopyFile = new System.Windows.Forms.Button();
            this.txt_file_name = new System.Windows.Forms.TextBox();
            this.txt_input_name = new System.Windows.Forms.TextBox();
            this.btn_format_file_Name = new System.Windows.Forms.Button();
            this.cbb_Dos = new System.Windows.Forms.ComboBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lb_Countfile = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lb_position_from = new System.Windows.Forms.Label();
            this.lb_position_to = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_CopyFile
            // 
            this.btn_CopyFile.Location = new System.Drawing.Point(714, 259);
            this.btn_CopyFile.Name = "btn_CopyFile";
            this.btn_CopyFile.Size = new System.Drawing.Size(75, 23);
            this.btn_CopyFile.TabIndex = 0;
            this.btn_CopyFile.Text = "คัดลอกไฟล์";
            this.btn_CopyFile.UseVisualStyleBackColor = true;
            this.btn_CopyFile.Click += new System.EventHandler(this.Btn_kod_Click_1);
            // 
            // txt_file_name
            // 
            this.txt_file_name.Location = new System.Drawing.Point(284, 29);
            this.txt_file_name.Multiline = true;
            this.txt_file_name.Name = "txt_file_name";
            this.txt_file_name.ReadOnly = true;
            this.txt_file_name.Size = new System.Drawing.Size(505, 197);
            this.txt_file_name.TabIndex = 1;
            // 
            // txt_input_name
            // 
            this.txt_input_name.Location = new System.Drawing.Point(12, 29);
            this.txt_input_name.Multiline = true;
            this.txt_input_name.Name = "txt_input_name";
            this.txt_input_name.Size = new System.Drawing.Size(185, 197);
            this.txt_input_name.TabIndex = 2;
            this.txt_input_name.Tag = "";
            // 
            // btn_format_file_Name
            // 
            this.btn_format_file_Name.Location = new System.Drawing.Point(203, 82);
            this.btn_format_file_Name.Name = "btn_format_file_Name";
            this.btn_format_file_Name.Size = new System.Drawing.Size(75, 23);
            this.btn_format_file_Name.TabIndex = 3;
            this.btn_format_file_Name.Text = "จัดรูปแบบ";
            this.btn_format_file_Name.UseVisualStyleBackColor = true;
            this.btn_format_file_Name.Click += new System.EventHandler(this.Btn_format_file_Name_Click);
            // 
            // cbb_Dos
            // 
            this.cbb_Dos.FormattingEnabled = true;
            this.cbb_Dos.Items.AddRange(new object[] {
            ".CR2",
            ".ARW",
            ".JPG"});
            this.cbb_Dos.Location = new System.Drawing.Point(203, 55);
            this.cbb_Dos.Name = "cbb_Dos";
            this.cbb_Dos.Size = new System.Drawing.Size(75, 21);
            this.cbb_Dos.TabIndex = 4;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(203, 29);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(75, 20);
            this.txt_name.TabIndex = 5;
            this.txt_name.Text = "IMG_";
            // 
            // lb_Countfile
            // 
            this.lb_Countfile.AutoSize = true;
            this.lb_Countfile.Location = new System.Drawing.Point(9, 9);
            this.lb_Countfile.Name = "lb_Countfile";
            this.lb_Countfile.Size = new System.Drawing.Size(60, 13);
            this.lb_Countfile.TabIndex = 6;
            this.lb_Countfile.Text = "จำนวนไฟล์";
            this.lb_Countfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_position_from
            // 
            this.lb_position_from.AutoSize = true;
            this.lb_position_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_position_from.Location = new System.Drawing.Point(12, 229);
            this.lb_position_from.Name = "lb_position_from";
            this.lb_position_from.Size = new System.Drawing.Size(142, 13);
            this.lb_position_from.TabIndex = 7;
            this.lb_position_from.Text = "คลิกเลือกตำแหน่งที่จะคัดลอก";
            this.lb_position_from.Click += new System.EventHandler(this.Lb_position_from_Click);
            // 
            // lb_position_to
            // 
            this.lb_position_to.AutoSize = true;
            this.lb_position_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_position_to.Location = new System.Drawing.Point(12, 247);
            this.lb_position_to.Name = "lb_position_to";
            this.lb_position_to.Size = new System.Drawing.Size(125, 13);
            this.lb_position_to.TabIndex = 8;
            this.lb_position_to.Text = "คลิกเลือกตำแหน่งที่จะวาง";
            this.lb_position_to.Click += new System.EventHandler(this.Lb_position_to_Click);
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(9, 272);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(38, 13);
            this.lb_status.TabIndex = 9;
            this.lb_status.Text = "สถานะ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 294);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.lb_position_to);
            this.Controls.Add(this.lb_position_from);
            this.Controls.Add(this.lb_Countfile);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.cbb_Dos);
            this.Controls.Add(this.btn_format_file_Name);
            this.Controls.Add(this.txt_input_name);
            this.Controls.Add(this.txt_file_name);
            this.Controls.Add(this.btn_CopyFile);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy file";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CopyFile;
        private System.Windows.Forms.TextBox txt_file_name;
        private System.Windows.Forms.TextBox txt_input_name;
        private System.Windows.Forms.Button btn_format_file_Name;
        private System.Windows.Forms.ComboBox cbb_Dos;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lb_Countfile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label lb_position_from;
        private System.Windows.Forms.Label lb_position_to;
        private System.Windows.Forms.Label lb_status;
    }
}

