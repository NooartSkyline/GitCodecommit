using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DoHome.HandHeld.Client
{
    public class GlobalMessageBox
    {
        public static void ShowInfomation(string message)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(message, "สถานะ", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static void ShowError(string message)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(message, "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        public static void ShowError(Exception exception)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(exception.Message, "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        public static void ShowWarnning(string message)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowQuestion(string message)
        {
            Cursor.Current = Cursors.Default;
            return MessageBox.Show(message, "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

    }
}
