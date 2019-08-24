using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KillProcessPowerShell
{
    public partial class Form1 : Form
    {
        string task_name_for_kill = "";
        int time_ticker = 0;
        string PathHistory = "";
        public Form1()
        {
            InitializeComponent();
            DataSet objds = new DataSet();
            objds.ReadXml(Application.StartupPath + @"\config.xml");
            DataRow drow = objds.Tables[0].Rows[0];
            task_name_for_kill = drow["task_name_for_kill"].ToString();
            PathHistory = drow["log_path"].ToString();
            time_ticker = Convert.ToInt32(drow["time_ticker"].ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = PathHistory;
            label7.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
            timer1.Interval = time_ticker;
            timer1.Start();
        }

        /// START SAVE LOG
        private void SaveLog(string PathDir, string FileName, string text)
        {
            string filepath = PathDir + @"\" + FileName + ".txt";
            if (!Directory.Exists(PathDir))
            {
                Directory.CreateDirectory(PathDir);

            }
            if (!File.Exists(filepath))
            {
                var f = File.Create(filepath);
                f.Close();
            }
            try
            {
                using (StreamWriter outputFile = new StreamWriter(filepath, true))
                {
                    outputFile.WriteLine(text);
                    outputFile.Close();
                    Thread.Sleep(1000);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        /// END SAVE LOG
        /// 

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                if (process.ProcessName.Contains(task_name_for_kill))
                {
                    process.Kill();
                    SaveLog(PathHistory, DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")), "Process name : " + process.ProcessName + " , Kill time : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff", CultureInfo.CreateSpecificCulture("en-US")));
                    label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
                }
            }
        }
    }
}
