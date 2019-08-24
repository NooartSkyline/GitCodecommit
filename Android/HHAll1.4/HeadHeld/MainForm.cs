using System;
using System.ComponentModel;
using System.Windows.Forms;
using CeReader;

namespace DoHome.HandHeld.Client
{
    public partial class MainForm : Form
    {
        #region Method

        private void PrepareMenuPermission()
        {
            //var menuPermission = ServiceHelper.MobileServices.GetMenuPermission(GlobalContext.UserCode).ToList<MenuPermission>();

            ////Handheld - สามารถผูกสินค้ากับตำแหน่งจัดเก็บได้
            //if (menuPermission.Find(p => p.MenuName == "HANDHELD - PRDLOCATION") != null)
            //    this.mnuProductLocation.Enabled = false;
            ////กำหนดสิทธิ์การใช้ Heldheld นับสต๊อค
            //if (menuPermission.Find(p => p.MenuName == "TBHANDHELDCOUNTER") != null)
            //    this.mnuItemCountStock.Enabled = false;
            ////Handheld - สามารถดูราคาสินค้าได้
            //if (menuPermission.Find(p => p.MenuName == "HANDHELD - PRICE") != null)
            //    this.menuItem2.Enabled = false;

        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
            PrepareMenuPermission();
            //txtUserCode.Text = GlobalContext.UserCode;
            //txtUserName.Text = GlobalContext.UserName;
            //txtBranch.Text = GlobalContext.BranchName;
            //txtWarehouse.Text = GlobalContext.WarehouseCode;
            //txtServer.Text = ServiceHelper.MobileServices.ApplicationSAPServer();
            //txtClient.Text = ServiceHelper.MobileServices.ApplicationSAPClient();
            //txtAccountYear.Text = ServiceHelper.MobileServices.AccountingYear();
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {
            ServiceHelper.MobileServicesDispose();
            Barcode.FreeModule();
            Application.Exit();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new ProductCheckForm2();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void mnuProductLocation_Click(object sender, EventArgs e)
        {
            try
            {
                var oform = new LocationForm();
                oform.ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            if (GlobalMessageBox.ShowQuestion("คุณต้องการออกจากโปรแกรม ใช่หรือไม่ ?") == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = Utils.ProductVersion;
            if (GlobalContext.UseInPlaces == UseInPlaces.STORE)
            {
                mnuItems.Enabled = false;
            }

            Barcode.InitModule();
        }

        private void mnuChangeWarehouse_Click(object sender, EventArgs e)
        {
            try
            {
                new ChangeWarehouseForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void mnuMixProduct_Click(object sender, EventArgs e)
        {
            try
            {
                new ProductMixForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void mnuBlankProduct_Click(object sender, EventArgs e)
        {
            try
            {
                new ProductBlankForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void mnuItemCheckPrice_Click(object sender, EventArgs e)
        {
            try
            {
                new ProductCheckPriceForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void mnuItemCountStock_Click(object sender, EventArgs e)
        {
            try
            {
                new CountStockForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void mnuLocationCheck_Click(object sender, EventArgs e)
        {
            try
            {
                new LocationCheckForm2().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void mnuMainStockCounter_Click(object sender, EventArgs e)
        {
            try
            {
                new CountStockMainForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            txtUserCode.Text = GlobalContext.UserCode;
            txtUserName.Text = GlobalContext.UserName;
            txtBranch.Text = GlobalContext.BranchName;
            txtWarehouse.Text = GlobalContext.WarehouseName;
        }

        private void mnuTransferToServer_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    new TransferToServerForm().ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    GlobalMessageBox.ShowError(ex);
            //}
        }

        //private void mnuCheckProductProfile_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        new ProductCheckForm3().ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        GlobalMessageBox.ShowError(ex);
        //    }
        //}

        private void mnuRequestLocationLabelSuper_Click(object sender, EventArgs e)
        {
            try
            {
                new LabelLocationForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }
        private void mnuLabelPrice_Click(object sender, EventArgs e)
        {
            try
            {
                new LabelPriceForm().ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }
        private void mnuOrdersSet_Click(object sender, EventArgs e)
        {
            try
            {
                var oform = new OrderedSetForm();
                oform.ShowDialog();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }
        private void btnScanerFix_Click(object sender, EventArgs e)
        {
            try
            {
                CeReader.Barcode.FreeModule();
                CeReader.Barcode.InitModule();
                GlobalMessageBox.ShowInfomation("แก้ไขระบบสแกนเรียบร้อยแล้ว กรุณาทดสอบการสแกนบาร์โค้ดอีกครั้ง");
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex.Message);
            }
        }
        private void mnItemTopstock_Click(object sender, EventArgs e)
        {
            GlobalContext.HHDoc = "";
            GlobalContext.ZDoc = "";
            GlobalContext.PDocNo = "";
            GlobalContext.FormType = "";
            var frm = new TopstockAction();
            frm.ShowDialog();
        }
    }
}