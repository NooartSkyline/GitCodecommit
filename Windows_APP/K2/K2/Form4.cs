using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K2
{
    public partial class Form4 : Form
    {
        string NUMBERRUNNING = "";
        public Form4(string RUNNING)
        {
            InitializeComponent();
            NUMBERRUNNING = RUNNING;
        }
        K2_ConvertDataContext k2 = new K2_ConvertDataContext();
        private void Form4_Load(object sender, EventArgs e)
        {
            cbb_serverip.Text = "192.168.0.175";
            List<TBREQUESTCONVERT_BATCH_SERIALNUMBER> linq = new List<TBREQUESTCONVERT_BATCH_SERIALNUMBER>();
            k2.Connection.Open();
            linq = (from bs in k2.TBREQUESTCONVERT_BATCH_SERIALNUMBERs
                    select bs).ToList();
            dgv_BS.DataSource = linq;
            k2.Connection.Close();
            txt_search.Text = NUMBERRUNNING;
        }
        public void getSerail_Bach(string NUMBERRUNNING) {
            k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
            k2.Connection.Open();
            List<TBREQUESTCONVERT_BATCH_SERIALNUMBER> linq = new List<TBREQUESTCONVERT_BATCH_SERIALNUMBER>();
                linq = (from bs in k2.TBREQUESTCONVERT_BATCH_SERIALNUMBERs
                        where bs.NUMBERRUNNING.Contains(NUMBERRUNNING)
                        select bs).ToList();
            k2.Connection.Close();
            dgv_BS.DataSource = linq;
            
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            string gettext = txt_search.Text;
            if (gettext.Length > 0) {
                getSerail_Bach(txt_search.Text);
            }
            else
            {
                txt_search.Focus();
            }
        }

        private void Txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                string gettext = txt_search.Text;
                if (gettext.Length > 0)
                {
                    getSerail_Bach(txt_search.Text);
                }
                else
                {
                    txt_search.Focus();
                }
            }
        }
    }
}
