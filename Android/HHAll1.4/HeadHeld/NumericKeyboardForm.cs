using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.WindowsCE.Forms;

namespace DoHome.HandHeld.Client
{
    public partial class NumericKeyboardForm : Form
    {
        public NumericKeyboardForm()
        {
            InitializeComponent();
        }

        private void AppendText(Button button)
        {
            textBox1.Text = textBox1.Text + button.Text;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Tag = textBox1.Text.Trim().ToUpper();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AppendText((Button)sender);
        }

        private void NumericKeyboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                btnOK_Click(sender, e);
            }

        }

        
    }
}