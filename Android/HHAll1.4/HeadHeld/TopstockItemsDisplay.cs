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
    public partial class TopstockItemsDisplay : Form
    {
        public TopstockItemsDisplay()
        {
            InitializeComponent();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnShowUnsucces_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnPuase_Click(object sender, EventArgs e)
        {

        }

        private void btnAllSAP_Click(object sender, EventArgs e)
        {

        }

        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {

        }

        private void chkSelectAll_CheckStateChanged_1(object sender, EventArgs e)
        {

        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvContent_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void mnItemDelete_Click(object sender, EventArgs e)
        {

        }
        private void mnItemPost_Click(object sender, EventArgs e)
        {

        }
        private void mnItemGetSize_Click(object sender, EventArgs e)
        {

        }
        private void TopstockItemsDisplay_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            try
            {
                this.smartGrid.Rows.Clear();
                this.smartGrid.DbConnector.ConnectionString = SqlHelper.SqlCeConnectionString;
                this.smartGrid.DbConnector.CommandText = "Select * From TopstockItems Where DocNo ='" + GlobalContext.HHDoc + "'";
                this.smartGrid.LoadData(false);
                 
            }
            catch (Exception ex)
            {

            }

        }
    }
}