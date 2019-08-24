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
    public partial class Form3_kill : Form
    {
        K2_ConvertDataContext k2 = new K2_ConvertDataContext();
        List<TBREQUESTCONVERT_CHECK_USERLOGNO> list = new List<TBREQUESTCONVERT_CHECK_USERLOGNO>();
        string docno = null;
        public Form3_kill()
        {
            InitializeComponent();
            cbb_serverip.Text = "192.168.0.175";
        }

        private void Btn_search_kill_Click(object sender, EventArgs e)
        {
            k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
            k2.Connection.Open();
            if (txt_search_kill.Text != "" && txt_search_kill.Text != null)
            {
                list = (from lognouser in k2.TBREQUESTCONVERT_CHECK_USERLOGNOs
                        where lognouser.DOCUMENTNO == txt_search_kill.Text
                        select lognouser).ToList();
                dgv_killuser.DataSource = list;
            }
            else
            {
                list = (from lognouser in k2.TBREQUESTCONVERT_CHECK_USERLOGNOs
                         select lognouser).ToList();
                dgv_killuser.DataSource = list;
            }
            k2.Connection.Close();
        }

        private void Form3_kill_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void Cbb_serverip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loaddata();
        }
        private void Loaddata() {

            k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
            k2.Connection.Open();
            list = (from lognouser in k2.TBREQUESTCONVERT_CHECK_USERLOGNOs
                     select lognouser).ToList();
            k2.Connection.Close();
            dgv_killuser.DataSource = list;
        }

        private void Btn_kill_user_now_Click(object sender, EventArgs e)
        {
            k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";


            DialogResult result = MessageBox.Show("Do you want to kill user?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //...
                if (docno != null)
                {
                    // Delete CUSTOMER
                    TBREQUESTCONVERT_CHECK_USERLOGNO del = new TBREQUESTCONVERT_CHECK_USERLOGNO();
                    del = (from lognouser in k2.TBREQUESTCONVERT_CHECK_USERLOGNOs
                               where lognouser.DOCUMENTNO == docno
                               select lognouser).FirstOrDefault();

                    if (del != null)
                    {
                        try
                        {
                            k2.Connection.Open();
                            k2.Transaction = k2.Connection.BeginTransaction();
                            k2.TBREQUESTCONVERT_CHECK_USERLOGNOs.DeleteOnSubmit(del);
                            k2.SubmitChanges();
                            k2.Transaction.Commit();
                            k2.Connection.Close();
                            k2.Connection.Dispose();
                            Loaddata();
                            MessageBox.Show("kill success..");

                        }
                        catch (Exception ex)
                        {
                            var err = ex.Message;
                            k2.Transaction.Rollback();
                            k2.Connection.Close();
                            k2.Connection.Dispose();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            if (result == DialogResult.No)
            {
                //...
            }           
        }     

        private void Dgv_killuser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            docno = list[e.RowIndex].DOCUMENTNO;
            //MessageBox.Show(list[e.RowIndex].DOCUMENTNO);
            //MessageBox.Show(dgv_killuser.SelectedCells[0].Value.ToString());
        }
    }
}
