﻿using System;
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
    public partial class LocationKeyboardForm : Form
    {
        //[DllImport("coredll.dll", SetLastError = true)]

        //static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        //const int KEYEVENTF_KEYUP = 0x2;
        //const int KEYEVENTF_KEYDOWN = 0x0;

        private static readonly int EM_GETSEL = 0xB0;

        private static readonly int EM_POSFROMCHAR = 0xD6;



        [System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint = "SendMessage")]

        private static extern int SendGetSelMessage(IntPtr hWnd, int msg, int wParam, ref int lParam);



        [System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint = "SendMessage")]

        private static extern UInt32 SendGetPosFromCharMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public LocationKeyboardForm()
        {
            InitializeComponent();
            //Utils.FormSetCenterSceen(this);
        }

        private void SendKey(byte vk)
        {
            //  textBox1.Focus();
            //  keybd_event(vk, 0, KEYEVENTF_KEYDOWN, 0);
        }

        Point GetCursorPoint(TextBox tb)
        {

            // Get index of cursor in textbox contents
            int caretPos = -1;

            SendGetSelMessage(tb.Handle, EM_GETSEL, 0, ref caretPos);


            // Convert cursor index into an x,y co-ordinate pair
            UInt32 result = SendGetPosFromCharMessage(tb.Handle, EM_POSFROMCHAR, caretPos, 0);

            return new Point((int)(result & 0xFFFF), ((int)(result >> 16)));

        }

        private void AppendText(Button button)
        {
            textBox1.Text = textBox1.Text + button.Text;
            int caretPos = textBox1.Text.Length;

            SendGetSelMessage(textBox1.Handle, EM_GETSEL, 0, ref caretPos);
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            ////byte VK_BACK = 0x09;
            ////const int KEYEVENTF_KEYDOWN = 0x0;
            ////keybd_event(VK_BACK, 0, KEYEVENTF_KEYDOWN, 0);
            //byte VK_BACK = 0x09;
            //SendKey(VK_BACK);

            //var a = GetCursorPoint(textBox1);
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

        private void LocationKeyboardForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}