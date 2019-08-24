using System;
using System.Drawing;
using System.Windows.Forms;
using DoHome.HandHeld.Client.DataAccess;
using System.Xml;

namespace DoHome.HandHeld.Client
{
    public partial class LoginForm : Form
    {
        #region Method

        //Log 12-07-2560 เพิ่มการแสดง วันที่รับล่าสุด/จำนวนรับล่าสุด และ วันที่ขายล่าสุด/จำนวนที่ขายล่าสุด ในฟอร์ม SalesInfoForm.cs

        private void PrepareDropdown()
        {
            if ("0000".Equals(ddlBranch.SelectedValue))
                return;

            GlobalContext.BranchCode = ddlBranch.SelectedValue as string;
            //ddlWarehouse.DataSource = ServiceHelper.MobileServices.WareHouseGetAllByBranch(GlobalContext.BranchCode);
            var warehouse = WarehouseManager.GetAllByBranch(GlobalContext.BranchCode);
            warehouse.Insert(0, new Warehouse { Code = "0000", Name = "-- เลือก --" });
            ddlWarehouse.DataSource = warehouse;

            //switch (GlobalContext.BranchCode)
            //{
            //    case "1100":
            //        ddlWarehouse.SelectedValue = "1111";
            //        break;
            //    case "1200":
            //        ddlWarehouse.SelectedValue = "1211";
            //        break;
            //    case "1300":
            //        ddlWarehouse.SelectedValue = "1311";
            //        break;
            //    default:
            //        break;
            //}

            //Dictionary<string,UseInPlaces> useInPlaces=new Dictionary<string,UseInPlaces> ();
            //useInPlaces.Add("สโตร์",UseInPlaces.STORE);
            //useInPlaces.Add("คลังสินค้า",UseInPlaces.WAREHOUSE);
        }

        private void SynchonizeData()
        {
            Synchonize sync = new Synchonize();
            sync.SyncBranch();
            sync.SyncWarehouse();
            sync.SyncEmployee(); 
            sync.SyncForms();
            sync.SyncLocationCheckAgenda();
         
        }
         
        #endregion

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Closed(object sender, EventArgs e)
        {
            ServiceHelper.MobileServicesDispose();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาระบุชื่อเข้าใช้งาน");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                GlobalMessageBox.ShowInfomation("กรุณาระบุรหัสผ่านเข้าใช้งาน");
                return;
            }
            if ("0000".Equals(ddlBranch.SelectedValue))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกสาขา");
                return;
            }
            if ("0000".Equals(ddlWarehouse.SelectedValue))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกคลังสินค้า");
                return;
            }
            if (ddlUseInPlaces.SelectedIndex == 0)
            {
                GlobalMessageBox.ShowInfomation("กรุณาสถานที่ใช้งาน");
                return;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //var user = ServiceHelper.MobileServices.UserCheckLogin(GlobalContext.BranchCode, txtUserName.Text.Trim(), txtPassword.Text.Trim());
                var user = UserManager.CheckLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                if (user != null)
                {
                    GlobalContext.UserCode = user.Code;
                    GlobalContext.UserName = user.Name;
                    GlobalContext.IsShowPrice = user.IsShowPrice;
                    GlobalContext.IsShowSaleProfit = user.IsShowSaleProfit;
                    GlobalContext.BranchCode = ddlBranch.SelectedValue.ToString();
                    GlobalContext.BranchName = ddlBranch.Text;
                    GlobalContext.WarehouseCode = ddlWarehouse.SelectedValue.ToString();
                    GlobalContext.WarehouseName = ddlWarehouse.Text;

                    if (ddlUseInPlaces.SelectedIndex == 1)
                    {
                        GlobalContext.UseInPlaces = UseInPlaces.STORE;
                        GlobalContext.IsShowPrice = true;
                    }
                    if (ddlUseInPlaces.SelectedIndex == 2)
                    {
                        GlobalContext.UseInPlaces = UseInPlaces.WAREHOUSE;
                        GlobalContext.IsShowPrice = false;
                    }
                    this.Hide();
                    new MainForm().Show();
                }
                else
                    GlobalMessageBox.ShowError("ไม่มีพนักงานชื่อนี้ในระบบ หรือ ระบุข้อมูลไม่ถูกต้อง!");
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            this.Location = new Point(
            (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2),
            (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtEnpoint.Text = GlobalContext.ServerEndpointAddress;
            label6.Text = Utils.ProductVersion;
            //label6.Text = this.Text = Utils.ProductVersion;
            //ddlBranch.DataSource = ServiceHelper.MobileServices.BranchGetAll();
            var branches = BranchManager.GetAll();
            branches.Insert(0, new Branch { Code = "0000", Name = "-- เลือก --" });
            ddlBranch.DataSource = branches;

            this.PrepareDropdown();
            this.txtUserName.Focus();

            ddlUseInPlaces.Items.Add("-- เลือก --");
            ddlUseInPlaces.Items.Add("ซุปเปอร์");
            ddlUseInPlaces.Items.Add("คลังสินค้า");
            ddlUseInPlaces.SelectedIndex = 0;
        }

        private void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareDropdown();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var oForm = new ChooseFromListForm((Array)ddlWarehouse.DataSource, "Code", "Name");
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                this.ddlWarehouse.SelectedValue = oForm.SelectedValue;
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void chkProtectPassword_CheckStateChanged(object sender, EventArgs e)
        {
            if (!chkProtectPassword.Checked)
                txtPassword.PasswordChar = '*';
            else
                txtPassword.PasswordChar = '\0';
        }      

        private void btnSync_Click(object sender, EventArgs e)
        {
            if ("0000".Equals(ddlBranch.SelectedValue))
            {
                GlobalMessageBox.ShowInfomation("กรุณาเลือกสาขา ก่อนทำการปรับปรุงข้อมูล");
                return;
            }

            try
            {
                //ImportForm oForm = new ImportForm();
                //oForm.Show();

                GlobalContext.BranchCode = ddlBranch.SelectedValue.ToString();
                this.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                SynchonizeData();
                Cursor.Current = Cursors.Default;
                this.Enabled = true;
                GlobalMessageBox.ShowInfomation("ปรับปรุงข้อมูลเรียบร้อยแล้ว");
                txtUserName.Focus();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                GlobalMessageBox.ShowError(ex);
                this.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}