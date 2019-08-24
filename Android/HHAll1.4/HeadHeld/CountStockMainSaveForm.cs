using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoHome.HandHeld.Client
{
    public partial class CountStockMainSaveForm : Form
    {
        public bool ValueIsMajor
        {
            get
            {
                return rbMajor.Checked ? true : false;
            }
        }

        public string ValueMajorCounter1 { get; set; }

        public string ValueMajorCounter2 { get; set; }

        public string ValueOfficer1 { get; set; }

        public string ValueOfficer2 { get; set; }

        public string ValueOfficer3 { get; set; }

        public string ValueOfficer4 { get; set; }


        private void PrepareDropdown()
        {
            //Dictionary<string ,string> counter =new Dictionary<string,string> ();
            //counter.Add (GlobalContext.UserCode,GlobalContext.UserName);
            //ddlCounter.ValueMember = "";
            //ddlCounter.ValueMember = "";
            //ddlCounter.DataSource =counter;

            var employee = ServiceHelper.MobileServices.GetUserByBranch(GlobalContext.BranchCode);
            ddlMajorCounter1.DisplayMember = "Name";
            ddlMajorCounter1.ValueMember = "Code";
            ddlMajorCounter1.DataSource = employee;
            ddlMajorCounter2.DisplayMember = "Name";
            ddlMajorCounter2.ValueMember = "Code";
            ddlMajorCounter2.DataSource = employee;

            ddlOfficer1.DisplayMember = "Name";
            ddlOfficer1.ValueMember = "Code";
            ddlOfficer1.DataSource = employee;

            ddlOfficer2.DisplayMember = "Name";
            ddlOfficer2.ValueMember = "Code";
            ddlOfficer2.DataSource = employee;

            ddlOfficer3.DisplayMember = "Name";
            ddlOfficer3.ValueMember = "Code";
            ddlOfficer3.DataSource = employee;

            ddlOfficer4.DisplayMember = "Name";
            ddlOfficer4.ValueMember = "Code";
            ddlOfficer4.DataSource = employee;

        }

        private void PrepareControls()
        {
            ddlMajorCounter1.Enabled = rbMajor.Checked;
            ddlMajorCounter2.Enabled = rbMajor.Checked;
            ddlOfficer1.Enabled = rdMinor.Checked;
            ddlOfficer2.Enabled = rdMinor.Checked;
            ddlOfficer3.Enabled = rdMinor.Checked;
            ddlOfficer4.Enabled = rdMinor.Checked;
            txtPassword1.Enabled = rdMinor.Checked;
            txtPassword2.Enabled = rdMinor.Checked;
            txtPassword3.Enabled = rdMinor.Checked;
            txtPassword4.Enabled = rdMinor.Checked;

        }

        private bool ValidatePassword()
        {
            if (ValueIsMajor)
            {
                var officer = ddlMajorCounter1.SelectedValue as string;
                if (string.IsNullOrEmpty(officer))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ ผู้นับ 1");
                    return false;
                }
                officer = ddlMajorCounter2.SelectedValue as string;
                if (string.IsNullOrEmpty(officer))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ ผู้นับ 2");
                    return false;
                }
            }
            else
            {
                string officer = string.Empty;
                string password = string.Empty;

                officer = ddlOfficer1.SelectedValue as string;
                password = txtPassword1.Text.Trim();

                if (string.IsNullOrEmpty(officer))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ พนักงานคลัง 1");
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(password))
                    {
                        GlobalMessageBox.ShowInfomation("กรุณาระบุ รหัสผ่าน พนักงานคลัง 1");
                        return false;
                    }
                    else
                    {
                        if (!CheckUserPassword(officer, password))
                        {
                            GlobalMessageBox.ShowInfomation("รหัสผ่าน พนักงานคลัง 1 ไม่ถูกต้อง");
                            return false;
                        }
                    }
                }

                officer = ddlOfficer2.SelectedValue as string;
                password = txtPassword2.Text.Trim();

                if (string.IsNullOrEmpty(officer))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ พนักงานคลัง 2");
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(password))
                    {
                        GlobalMessageBox.ShowInfomation("กรุณาระบุ รหัสผ่าน พนักงานคลัง 2");
                        return false;
                    }
                    else
                    {
                        if (!CheckUserPassword(officer, password))
                        {
                            GlobalMessageBox.ShowInfomation("รหัสผ่าน พนักงานคลัง 2 ไม่ถูกต้อง");
                            return false;
                        }
                    }
                }

                officer = ddlOfficer3.SelectedValue as string;
                password = txtPassword3.Text.Trim();

                if (string.IsNullOrEmpty(officer))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ พนักงานตรวจสอบภายใน");
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(password))
                    {
                        GlobalMessageBox.ShowInfomation("กรุณาระบุ รหัสผ่าน พนักงานตรวจสอบภายใน");
                        return false;
                    }
                    else
                    {
                        if (!CheckUserPassword(officer, password))
                        {
                            GlobalMessageBox.ShowInfomation("รหัสผ่าน พนักงานตรวจสอบภายใน ไม่ถูกต้อง");
                            return false;
                        }
                    }
                }

                officer = ddlOfficer4.SelectedValue as string;
                password = txtPassword4.Text.Trim();

                if (string.IsNullOrEmpty(officer))
                {
                    GlobalMessageBox.ShowInfomation("กรุณาระบุ หัวหน้าโซน");
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(password))
                    {
                        GlobalMessageBox.ShowInfomation("กรุณาระบุ รหัสผ่าน หัวหน้าโซน");
                        return false;
                    }
                    else
                    {
                        if (!CheckUserPassword(officer, password))
                        {
                            GlobalMessageBox.ShowInfomation("รหัสผ่าน หัวหน้าโซน ไม่ถูกต้อง");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool CheckUserPassword(string userCode, string password)
        {
            var user = ServiceHelper.MobileServices.UserCheckLogin(GlobalContext.BranchCode, userCode, password);
            if (user == null)
                return false;
            else
                return true;
        }


        public CountStockMainSaveForm()
        {
            InitializeComponent();

            this.PrepareDropdown();
        }

        private void rbMajor_CheckedChanged(object sender, EventArgs e)
        {
            PrepareControls();
        }

        private void rdMinor_CheckedChanged(object sender, EventArgs e)
        {
            PrepareControls();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidatePassword())
            {
                this.DialogResult = DialogResult.OK;
                this.ValueMajorCounter1 = ddlMajorCounter1.SelectedValue as string;
                this.ValueMajorCounter2 = ddlMajorCounter2.SelectedValue as string;

                this.ValueOfficer1 = ddlOfficer1.SelectedValue as string;
                this.ValueOfficer2 = ddlOfficer2.SelectedValue as string;
                this.ValueOfficer3 = ddlOfficer3.SelectedValue as string;
                this.ValueOfficer4 = ddlOfficer4.SelectedValue as string;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}