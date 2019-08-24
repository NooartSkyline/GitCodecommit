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
    public partial class ChangeWarehouseForm : Form
    {
        public ChangeWarehouseForm()
        {
            InitializeComponent();
        }

        private void ChangeWarehouseForm_Activated(object sender, EventArgs e)
        {
            this.Location = new Point(
            (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2),
            (Screen.PrimaryScreen.WorkingArea.Height / 2) - (this.Height / 2));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalContext.WarehouseCode = ddlWarehouse.SelectedValue.ToString();
            GlobalContext.WarehouseName = ddlWarehouse.Text;
            this.Close();
        }

        private void ChangeWarehouseForm_Load(object sender, EventArgs e)
        {
            var warehouses = ServiceHelper.MobileServices.WareHouseGetAllByBranch(GlobalContext.BranchCode);
            ddlWarehouse.DataSource = warehouses;

            ddlWarehouse.SelectedValue = GlobalContext.WarehouseCode;
        }
    }
}