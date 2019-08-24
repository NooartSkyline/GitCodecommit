using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Collections;
using Resco.Controls.SmartGrid;

namespace DoHome.HandHeld.Client
{
    public partial class MainTopstock : Form
    {
        bool DeleteState;
        ArrayList selectedRow = new ArrayList();
        public int CountRow = 0;
        public MainTopstock()
        {
            InitializeComponent();
        }
        private void MainTopstock_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("delete TopstockDoc WHERE LastUpdate < DATEADD(day,-3,GETDATE())",con))
                    {
                        com.ExecuteNonQuery();                         
                    }
                }
            }
            catch (Exception ex)
            {

            }
            LoadData();
        }
        private void LoadData() 
        {
            try
            {
                this.smartGrid.Rows.Clear();
                this.smartGrid.DbConnector.ConnectionString = SqlHelper.SqlCeConnectionString;
                this.smartGrid.DbConnector.CommandText = "Select * From TopstockDoc Where Employee = '"+GlobalContext.UserCode+"' AND SAPDocNo = '' Order by LastUpdate DESC";
                this.smartGrid.LoadData(false);                          
            }
            catch (Exception ex)
            {

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
        private void btnGoCreate_Click(object sender, EventArgs e)
        {
            GlobalContext.ZDoc = "";
            GlobalContext.HHDoc = "";
            GlobalContext.IsDisable = false;
            var frm = new TopstockAction();
            frm.ShowDialog();
        }
        private void gvContent_MouseUp(object sender, MouseEventArgs e)
        {
        }
        private string GetWareName(string WareId,string BranchId) 
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("Select Name From Warehouse Where  Code=@ICode AND BranchCode =@IBranchCode", con))
                    {
                        com.Parameters.AddWithValue("@ICode", WareId);
                        com.Parameters.AddWithValue("@IBranchCode", BranchId);
                        using (var reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WareId = (string)reader["Name"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return WareId;
        }
        private string GetBranchName( string BranchId)
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("Select Name From Branch Where  Code =@IBranchCode", con))
                    {
                       
                        com.Parameters.AddWithValue("@IBranchCode", BranchId);
                        using (var reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BranchId = (string)reader["Name"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return BranchId;
        }
        private void MainTopstock_Activated(object sender, EventArgs e)
        {
           
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
                                    }
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
               // LoadData();
           
        }
        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (smartGrid.SelectedCell.RowIndex >= 0)
            {
                GlobalContext.HHDoc = smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["DocNo"].ToString();
                GlobalContext.ZDoc = smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["SAPDocNo"].ToString();
                GlobalContext.PDocNo = "";
                GlobalContext.IsLoad = true;
                if (smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["Branch"].ToString() == GlobalContext.BranchCode.Trim()
                     && smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["Warehouse"].ToString() == GlobalContext.WarehouseCode.Trim()
                     )
                {
                    try
                    {
                        using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                        {
                            con.Open();
                            using (SqlCeCommand com = new SqlCeCommand("Update TopstockDoc Set PDocNo = '' WHERE DocNo = @Doc", con))
                            {
                                com.Parameters.AddWithValue("@Doc",GlobalContext.HHDoc);
                                com.ExecuteNonQuery();
                                com.CommandText = "Select FNAME FROM TopstockItems WHERE DocNo = '"+GlobalContext.HHDoc+"'";
                                 com.Parameters.Clear();
                                using (var reader = com.ExecuteReader()) 
                                {
                                    while (reader.Read())
                                    {
                                        GlobalContext.FormType = reader["FNAME"].ToString();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("สาขาหรือคลังสินค้าที่ล็อคอินไม่ตรงกับที่มีในเอกสาร \r\n คุณจะไม่สามารถแก้ไขเอกสารนี้ได้");
                    var frm = new TopstockItemsDisplay();
                    frm.ShowDialog();
                }
            }
        }
    }
}