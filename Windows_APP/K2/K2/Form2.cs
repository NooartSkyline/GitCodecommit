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
    public partial class Form2 : Form
    {
        K2_ConvertDataContext k2 = new K2_ConvertDataContext();
        string running;

        public Form2(string runnings)
        {
            InitializeComponent();
            running = runnings;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            getuser_event(running);
        }
        private void getuser_event(string running) {
            List<TBREQUESTCONVERT_LIST_USER_APPROVE_AUTO> lIST_USER_APPROVE_AUTOs = new List<TBREQUESTCONVERT_LIST_USER_APPROVE_AUTO>();

            lIST_USER_APPROVE_AUTOs = (from userlist in k2.TBREQUESTCONVERT_LIST_USER_APPROVE_AUTOs
                                       where userlist.RUNNINGNUMBER == running && userlist.STATUS != null
                                       select userlist).ToList();
            dgv_listuser_event.DataSource = lIST_USER_APPROVE_AUTOs;
        }
    }
}
