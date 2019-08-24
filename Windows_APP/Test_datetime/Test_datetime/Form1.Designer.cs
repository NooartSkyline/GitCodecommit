namespace Test_datetime
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
            this.lb_datetime = new System.Windows.Forms.Label();
            this.txt_date = new System.Windows.Forms.TextBox();
            this.btn_getdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_datetime
            // 
            this.lb_datetime.AutoSize = true;
            this.lb_datetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_datetime.Location = new System.Drawing.Point(12, 67);
            this.lb_datetime.Name = "lb_datetime";
            this.lb_datetime.Size = new System.Drawing.Size(88, 37);
            this.lb_datetime.TabIndex = 0;
            this.lb_datetime.Text = "Time";
            // 
            // txt_date
            // 
            this.txt_date.Location = new System.Drawing.Point(12, 12);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(292, 20);
            this.txt_date.TabIndex = 1;
            this.txt_date.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_date_KeyUp);
            // 
            // btn_getdate
            // 
            this.btn_getdate.Location = new System.Drawing.Point(12, 39);
            this.btn_getdate.Name = "btn_getdate";
            this.btn_getdate.Size = new System.Drawing.Size(75, 23);
            this.btn_getdate.TabIndex = 2;
            this.btn_getdate.Text = "GET";
            this.btn_getdate.UseVisualStyleBackColor = true;
            this.btn_getdate.Click += new System.EventHandler(this.btn_getdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 113);
            this.Controls.Add(this.btn_getdate);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.lb_datetime);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_datetime;
        private System.Windows.Forms.TextBox txt_date;
        private System.Windows.Forms.Button btn_getdate;
    }
}

