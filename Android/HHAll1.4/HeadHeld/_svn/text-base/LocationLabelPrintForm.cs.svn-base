using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using DoHome.HandHeld.Client.DataAccess;

namespace DoHome.HandHeld.Client
{
    public partial class LocationLabelPrintForm : Form
    {
        private void BindGrid()
        {
            gvLocationProduct.DataSource = ServiceHelper.MobileServices.GetLabelPrint(GlobalContext.BranchCode, GlobalContext.UserCode);
        }

        public LocationLabelPrintForm()
        {
            InitializeComponent();
        }

        private void LocationLabelPrintForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);

            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}