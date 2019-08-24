using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_datetime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string sdate = Convert.ToString(DateTime.Now);
            //lb_datetime.Text ="Get : " + sdate + " ---> " + Convert.ToDateTime(sdate).ToString("yyyy-MM-dd", new CultureInfo("en-US"));//en-US


            DateTime oDate = DateTime.Now.Date;
            string sDate = oDate.ToString("yyyy-MM-dd", new CultureInfo("th-TH"));
            lb_datetime.Text = sDate;
        }

        private void txt_date_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sDate = txt_date.Text;
                lb_datetime.Text = "Get : " + sDate + " ---> " + Convert.ToDateTime(sDate).ToString("yyyy-MM-dd", new CultureInfo("en-US"));//en-US
            }
        }

        private void btn_getdate_Click(object sender, EventArgs e)
        {
            string sdate = Convert.ToString(DateTime.Now);
            lb_datetime.Text = "Get : " + sdate + " ---> " + Convert.ToDateTime(sdate).ToString("yyyy-MM-dd", new CultureInfo("en-US"));//en-US
        }
    }
}
