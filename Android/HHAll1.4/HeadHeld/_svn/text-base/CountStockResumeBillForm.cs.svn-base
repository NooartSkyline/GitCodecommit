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
    public partial class CountStockFormResumeBillForm : Form
    {
        int _currentRowIndex = -1;

        public string SelectedValue { get; set; }

        private void BindGrid()
        {

            var products = ServiceHelper.MobileServices.GetHandHeldCounterHoldByToDay(GlobalContext.BranchCode);
            bsDisplayList.DataSource = products;
        }

        public CountStockFormResumeBillForm()
        {
            InitializeComponent();
        }

        private void dgDisplayList_Click(object sender, EventArgs e)
        {
            _currentRowIndex = dgDisplayList.CurrentRowIndex;
            if (_currentRowIndex > -1)
            {
                dgDisplayList.Select(_currentRowIndex);
            }
        }

        private void dgDisplayList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedValue = dgDisplayList[_currentRowIndex, 0] as string;
                this.Close();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);

            }
        }

        private void CountStockFormResumeBillForm_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

       


    }
}