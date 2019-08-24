using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DohomeApplicationPolicy
{
    public partial class DohomeApplicationPolicy : Form
    {
        DBMasterDataContext db = new DBMasterDataContext();
        string group_code = null;
        string group_name;
        private string site = null;
        private string sloc = null;
        private string user_code;

        public DohomeApplicationPolicy()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Get_Group("");
        }
        private void Get_Group(string Group_Code)
        {
            dataGridView1.DataSource = db.TBMaster_DHApp_Group_Policies.Where(g => g.Group_Code.Contains(Group_Code)).ToList();

        }
        private void Get_Group_Detail(string Group_Code)
        {
            dataGridView2.DataSource = db.TBMaster_DHApp_Group_Details.Where(g => g.Group_Code.Contains(Group_Code)).ToList();
        }

        private void Get_User_Group(string Group_Code)
        {
            datagrid_user_ingroup.DataSource = db.TBMaster_DHApp_Users.Where(g => g.Group_Code.Contains(Group_Code)).ToList();
        }
        private void Delete_Site_In_Group(string Group_Code, string Site, string Sloc)
        {
            DialogResult res = MessageBox.Show("ยืนยันการลบข้อมูล Site ", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.Yes))
            {
                TBMaster_DHApp_Group_Detail gr_detail = db.TBMaster_DHApp_Group_Details.Where(sl => sl.Group_Code.Equals(Group_Code) && sl.Site.Equals(Site) && sl.Sloc.Equals(Sloc)).SingleOrDefault();
                if (gr_detail != null)
                {
                    db.TBMaster_DHApp_Group_Details.DeleteOnSubmit(gr_detail);
                    db.SubmitChanges();
                    Get_Group_Detail(group_code);
                    Get_User_Group(group_code);
                    MessageBox.Show("ลบข้อมูล Site เรียบร้อยแล้ว");
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ต้องการลบ");
                }
            }

        }
        private void Delete_User(string User_Code)
        {
            DialogResult res = MessageBox.Show("ยืนยันการลบข้อมูล User ", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.Yes))
            {
                TBMaster_DHApp_User user = db.TBMaster_DHApp_Users.Where(sl => sl.User_Code.Equals(User_Code)).SingleOrDefault();
                if (user != null)
                {
                    db.TBMaster_DHApp_Users.DeleteOnSubmit(user);
                    db.SubmitChanges();
                    Get_Group_Detail(group_code);
                    Get_User_Group(group_code);
                    MessageBox.Show("ลบข้อมูล User เรียบร้อยแล้ว");
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ต้องการลบ");
                }
            }

        }
        private void Add_Site_In_Group(TBMaster_DHApp_Group_Detail gr_detail)
        {
            DialogResult res = MessageBox.Show("ยืนยันการบันทึกข้อมูล Site ", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.Yes))
            {
                if (gr_detail != null)
                {
                    try
                    {
                        db.TBMaster_DHApp_Group_Details.InsertOnSubmit(gr_detail);
                        db.SubmitChanges();
                        Get_Group_Detail(group_code);
                        Get_User_Group(group_code);
                        MessageBox.Show("บันทึกข้อมูล Site เรียบร้อยแล้ว");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ต้องการบันทึก");
                }
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                group_code = dataGridView1.Rows[e.RowIndex].Cells["Group_Code"].Value.ToString();
                group_name = dataGridView1.Rows[e.RowIndex].Cells["Group_Name"].Value.ToString();
                Get_Group_Detail(group_code);
                Get_User_Group(group_code);
                lb_group_code.Text = group_code;
                lb_group_name.Text = group_name;
            }
        }

        private void btn_add_save_group_Click(object sender, EventArgs e)
        {
            db = new DBMasterDataContext();
            TBMaster_DHApp_Group_Policy gro = new TBMaster_DHApp_Group_Policy();
            gro.Group_Code = txt_group_code.Text;
            gro.Group_Name = txt_group_name.Text;
            gro.Group_Desc = txt_group_desc.Text;
            db.TBMaster_DHApp_Group_Policies.InsertOnSubmit(gro);
            db.SubmitChanges();

            lb_group_code.Text = "";
            lb_group_name.Text = "";
            group_code = null;
            group_name = null;

            Get_Group("");
        }

        private void btn_delete_group_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("ยืนยันการลบข้อมูล \n\"การลบข้อมูลนี้ จะเป็นการลบข้อมูลทั้งหมดที่เกี่ยวข้องกับกลุ่มนี้\"", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.Yes))
            {

            }

        }

        private void btn_add_user_to_group_Click(object sender, EventArgs e)
        {
            if (group_code == null)
            {
                MessageBox.Show("ยังไม่มีข้อมูลกลุ่ม");
                return;
            }
            if (string.IsNullOrEmpty(txt_user_id.Text))
            {
                MessageBox.Show("ยังไม่ได้กรอกข้อมูลพนักงาน");
                return;
            }
            DialogResult res = MessageBox.Show("ยืนยันการเพิ่มข้อมูล", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.Yes))
            {
                try
                {
                    TBMaster_DHApp_User user = new TBMaster_DHApp_User();
                    user.Group_Code = group_code;
                    user.User_Code = txt_user_id.Text;
                    db.TBMaster_DHApp_Users.InsertOnSubmit(user);
                    db.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("มี User คนนี้แล้ว\n" + ex.Message);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                Get_Group_Detail(group_code);
                Get_User_Group(group_code);
            }
        }

        private void btn_del_site_sloc_Click(object sender, EventArgs e)
        {

            if (group_code == null)
            {
                MessageBox.Show("ยังไม่มีข้อมูลกลุ่ม");
                return;
            }
            if (site == null)
            {
                MessageBox.Show("ยังไม่มีข้อมูล Site");
                return;
            }
            if (sloc == null)
            {
                MessageBox.Show("ยังไม่มีข้อมูล Sloc");
                return;
            }
            Delete_Site_In_Group(group_code, site, sloc);
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                site = dataGridView2.Rows[e.RowIndex].Cells["Site"].Value.ToString();
                sloc = dataGridView2.Rows[e.RowIndex].Cells["Sloc"].Value.ToString();
            }
        }

        private void btn_add_site_sloc_Click(object sender, EventArgs e)
        {
            if (group_code == null)
            {
                MessageBox.Show("ยังไม่มีข้อมูลกลุ่ม");
                return;
            }
            if (string.IsNullOrEmpty(txt_site.Text))
            {
                MessageBox.Show("ยังไม่มีข้อมูล Site");
                return;
            }
            if (string.IsNullOrEmpty(txt_sloc.Text))
            {
                MessageBox.Show("ยังไม่มีข้อมูล Sloc");
                return;
            }
            if (string.IsNullOrEmpty(txt_branch.Text))
            {
                MessageBox.Show("ยังไม่มีข้อมูล Branch");
                return;
            }
            TBMaster_DHApp_Group_Detail gr_dt = new TBMaster_DHApp_Group_Detail();
            gr_dt.Group_Code = group_code;
            gr_dt.Branch = txt_branch.Text;
            gr_dt.Site = txt_site.Text;
            gr_dt.Sloc = txt_sloc.Text;
            Add_Site_In_Group(gr_dt);
        }

        private void datagrid_user_ingroup_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                user_code = datagrid_user_ingroup.Rows[e.RowIndex].Cells["User_Code"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(user_code))
            {
                MessageBox.Show("ยังไม่มีข้อมูล User");
                return;
            }
            Delete_User(user_code);
        }
    }
}
