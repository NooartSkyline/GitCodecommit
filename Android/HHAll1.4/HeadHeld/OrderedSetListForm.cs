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
    public partial class OrderedSetListForm : Form
    {
        #region Method

        private void BindGridview()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                bindingSource.DataSource = ServiceHelper.MobileServices.OrderedSetGetAllByPresent(GlobalContext.BranchCode
                    , GlobalContext.ShippointCode
                    , chkDisplayOnlyNotClose.Checked).ToList<OrderedSet>();
                bindingSource.ResetBindings(false);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                GlobalMessageBox.ShowError(ex.Message);
            }
        }

        #endregion

        public OrderedSetListForm()
        {
            InitializeComponent();
        }

        private void OrderedSetForm_Load(object sender, EventArgs e)
        {
            try
            {                
                BindGridview();
                chkDisplayOnlyNotClose.Checked = true;
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void chkDisplayOnlyNotClose_CheckStateChanged(object sender, EventArgs e)
        {
            BindGridview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}