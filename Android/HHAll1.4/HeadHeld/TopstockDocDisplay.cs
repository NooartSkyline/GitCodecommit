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
    public partial class TopstockDocDisplay : Form
    {
        public TopstockDocDisplay()
        {
            InitializeComponent();
        }
        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (smartGrid.SelectedCell.RowIndex >= 0)
            {
                GlobalContext.HHDoc = smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["DocNo"].ToString();
                GlobalContext.ZDoc = smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["SAPDocNo"].ToString();
                GlobalContext.PDocNo = smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["PDocNo"].ToString();
                var frm = new TopstockItemsDisplay();
                frm.ShowDialog();
                GlobalContext.HHDoc = "";
                GlobalContext.ZDoc = "";
                GlobalContext.PDocNo = "";
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
                var ChkDel = true;
                try
                {
                    using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                    {
                        con.Open();
                        using (SqlCeCommand com = new SqlCeCommand())
                        {
                            com.Connection = con;
                            for (int i = 0; i < smartGrid.Rows.Count; i++)
                            {
                                try
                                {
                                    if ((bool)smartGrid.Rows[i]["Chk"])
                                    {
                                        if (ChkDel)
                                        {
                                            if (MessageBox.Show("ต้องการลบรายการที่เลือกใช่หรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                            {
                                                ChkDel = false;
                                            }
                                            else
                                            {
                                                return;
                                            }
                                        }
                                        com.CommandText = "Delete TopstockDoc Where Row_Order = @Row";
                                        com.Parameters.Clear();
                                        com.Parameters.AddWithValue("@Row", (int)smartGrid.Rows[i]["Row_Order"]);
                                        com.ExecuteNonQuery();
                                        com.CommandText = "Delete TopstockItems Where DocNo = @Doc";
                                        com.Parameters.Clear();
                                        com.Parameters.AddWithValue("@Doc", smartGrid.Rows[i]["DocNo"].ToString());
                                        com.ExecuteNonQuery();
                                    };
                                }
                                catch (Exception)
                                {
                                    
                                   
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                if (ChkDel)
                {
                    MessageBox.Show("ท่านยังไม่ได้เลือกรายการ", "คำถาม");
                }
                else
                {
                    LoadData();
                }

             
           
        }
        private void chkSelectAll_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                for (int i = 0; i < smartGrid.Rows.Count; i++)
                {
                    smartGrid.Rows[i]["Chk"] = true;
                    smartGrid.UpdateLayout();
                }
            }
            else
            {
                for (int i = 0; i < smartGrid.Rows.Count; i++)
                {
                    smartGrid.Rows[i]["Chk"] = false;
                    smartGrid.UpdateLayout();
                }
            }
        }
        private void TopstockDocDisplay_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                this.smartGrid.Rows.Clear();
                this.smartGrid.DbConnector.ConnectionString = SqlHelper.SqlCeConnectionString;
                this.smartGrid.DbConnector.CommandText = "Select * From TopstockDoc Where Employee = '" + GlobalContext.UserCode + "' AND SAPDocNo <> '' Order by LastUpdate DESC";
                this.smartGrid.LoadData(false);
            }
            catch (Exception ex)
            {

            }
        }
    }
}