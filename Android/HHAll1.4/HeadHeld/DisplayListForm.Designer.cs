﻿namespace DoHome.HandHeld.Client
{
    partial class DisplayListForm
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
            this.bsDisplayList = new System.Windows.Forms.BindingSource(this.components);
            this.dgDisplayList = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsDisplayList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDisplayList
            // 
            this.dgDisplayList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDisplayList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDisplayList.DataSource = this.bsDisplayList;
            this.dgDisplayList.Location = new System.Drawing.Point(3, 3);
            this.dgDisplayList.Name = "dgDisplayList";
            this.dgDisplayList.RowHeadersVisible = false;
            this.dgDisplayList.Size = new System.Drawing.Size(234, 265);
            this.dgDisplayList.TabIndex = 19;
            this.dgDisplayList.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.MappingName = "DisplayList";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "วันที่";
            this.dataGridTextBoxColumn1.MappingName = "DocumentDate";
            this.dataGridTextBoxColumn1.Width = 160;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "N0";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "จำนวน";
            this.dataGridTextBoxColumn2.MappingName = "DataQuantity";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // DisplayListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 271);
            this.Controls.Add(this.dgDisplayList);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayListForm";
            this.Text = "จำนวนรายการ";
            this.Load += new System.EventHandler(this.DisplayListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsDisplayList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dgDisplayList;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.BindingSource bsDisplayList;
    }
}