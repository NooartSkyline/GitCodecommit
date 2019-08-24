using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client
{
    public partial class TopstockItemDetails : Form
    {
        string Row, Loc, Item, Bar, Qty , Unit;
        internal TopstockItemDetails(string _Row ,string _Loc , string _Item, string _Unit ,string _Bar,string _Qty)
        {
            InitializeComponent();
            Row = _Row; Loc = _Loc; Item = _Item; Bar = _Bar; Qty = _Qty;
            Unit = _Unit;
        }
        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new NumericKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtQty.Text = oForm.Tag as string;                
            }
        }
        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(txtQty.Text);
            }
            catch (Exception)
            {
                txtQty.Text = "1";
                 
            }
        }
        private void TopstockItemDetails_Load(object sender, EventArgs e)
        {
            txtQty.Text = Qty;
            txtItemId.Text = Item;
            txtLoca.Text = Loc;
            txtBar.Text = Bar;
            txtUnit.Text = Unit;
        }
        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {

            }
            else 
            {
                return;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("Update TopstockItems set QTY = "+txtQty.Text+" WHERE Row_ORder = " +Row , con))
                    {
                        com.ExecuteNonQuery();     
                    }
                }
            }
            catch (Exception ex)
            {

            }
            this.Close();
        }
    }
}