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
    public partial class Form1 : Form
    {
        K2_ConvertDataContext k2 = new K2_ConvertDataContext();
        public Form1()
        {
            InitializeComponent();
            cbb_serverip.Text = "192.168.0.175";
        }
        private void Getlist() {
            try
            {

                k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
                string gettext = txt_numrunning.Text;
                if (gettext.Count() > 1)
                {
                    k2.Connection.Open();
                    List<TBREQUESTCONVERT_HD> vhd = (from hd in k2.TBREQUESTCONVERT_HDs
                                                     where hd.NUMBERRUNNING.Contains(gettext)
                                                     select hd).ToList();

                    List<TBREQUESTCONVERT_DT> vdt = (from dt in k2.TBREQUESTCONVERT_DTs
                                                     where dt.NUMBERRUNNING.Contains(gettext)
                                                     select dt).ToList();

                    List<TBREQUESTCONVERT_DT_RAWMAT> vdtr = (from dtr in k2.TBREQUESTCONVERT_DT_RAWMATs
                                                             where dtr.NUMBERRUNNING.Contains(gettext)
                                                             select dtr).ToList();


                    List<TBREQUESTCONVERT_RETURN_WEBSERVICE_TEMP> vlog = (from log in k2.TBREQUESTCONVERT_RETURN_WEBSERVICE_TEMPs
                                                                          where log.NUMBER_RUNNING.Contains(gettext)
                                                                          select log).ToList();

                    k2.Connection.Close();
                    dgv_list_hd.DataSource = vhd;
                    dgv_list_dt.DataSource = vdt;
                    dgv_list_dtr.DataSource = vdtr;
                    dgv_log.DataSource = vlog;
                }
                lb_statuss.Text = "สถานะ : เสร็จสิ้น";
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                lb_statuss.Text = "สถานะ : เกิดข้อผิดพลาด!!";
            }
        }
               
        private void Button1_Click(object sender, EventArgs e)
        {
            string getdocno = txt_Docno.Text;
            var linq = (from hd in k2.TBREQUESTCONVERT_HDs
                        where hd.DOCUMENTNO == getdocno
                        select new { Docno = hd.NUMBERRUNNING }).SingleOrDefault();
            if (linq != null)
            {
                txt_numrunning.Text = linq.Docno;
                k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
                Getlist();
            }
        }

        private void Cbb_serverip_SelectedIndexChanged(object sender, EventArgs e)
        {
            k2.Connection.ConnectionString = "Data Source="+ cbb_serverip.Text +";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
            Getlist();
        }

        private void Txt_Docno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                string getdocno = txt_Docno.Text;
                var linq = (from hd in k2.TBREQUESTCONVERT_HDs
                            where hd.DOCUMENTNO == getdocno
                            select new { Docno = hd.NUMBERRUNNING }).SingleOrDefault();
                if (linq != null)
                {
                    txt_numrunning.Text = linq.Docno;
                    k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
                    Getlist();
                }
            }
        }

        private void Txt_numrunning_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToInt16(Keys.Enter))
            {
                k2.Connection.ConnectionString = "Data Source=" + cbb_serverip.Text + ";Initial Catalog=UWREQUESTCONVERTARTICLE;User ID=udd;Password=emailearn";
                Getlist();
            }
        }

        private void Btn_listuser_Click(object sender, EventArgs e)
        {
            if (txt_numrunning.Text == "")
            {
                txt_numrunning.Focus();
            }
            else
            {
                Form2 form2 = new Form2(txt_numrunning.Text);
                form2.ShowDialog();
            }
           
        }

        private void Btn_kill_Click(object sender, EventArgs e)
        {
            Form3_kill form3 = new Form3_kill();
            form3.ShowDialog();
        }

        private void Btn_BatchSerial_Click(object sender, EventArgs e)
        {
            if (txt_numrunning.Text == "")
            {
                txt_numrunning.Focus();
            }
            else
            {
                Form4 form4 = new Form4(txt_numrunning.Text);
                form4.ShowDialog();
            }
        }
      
    }
}
