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
    public partial class ProductMixedOfflineForm : Form
    {
        private void BindGrid()
        {
            DataTable productMixedTable = new DataTable();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(32), con))
                {
                    com.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);
                    using (SqlCeDataAdapter adab = new SqlCeDataAdapter(com))
                    {
                        adab.Fill(productMixedTable);
                    }
                }
            }
            gvLocationProduct.DataSource = productMixedTable;
        }

        private void SaveData()
        {
            if (gvLocationProduct.DataSource != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //LocationCheckProductManager.TransferToServer();
                    DataTable productMixedTable = new DataTable();
                    List<ProductLocation> productLocations = new List<ProductLocation>();
                    using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                    {
                        con.Open();
                        using (SqlCeCommand com = new SqlCeCommand())
                        {
                            com.Connection = con;
                            foreach (Resco.Controls.SmartGrid.Row item in gvLocationProduct.Rows)
                            {
                                var locationCode = ((System.Data.DataRowView)(item.Data)).Row.ItemArray[0].ToString();

                                using (SqlCeDataAdapter adab = new SqlCeDataAdapter(com))
                                {
                                    com.CommandText = SqlHelper.GetSql(33);
                                    com.Parameters.Clear();
                                    com.Parameters.AddWithValue("@LocationCode", locationCode);
                                    com.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);
                                    adab.Fill(productMixedTable);

                                    var isWarehouse = GlobalContext.UseInPlaces == UseInPlaces.WAREHOUSE ? true : false;
                                    foreach (DataRow row in productMixedTable.Rows)
                                    {
                                        var productLocation = ServiceHelper.MobileServices.ProductLocationGetByBarcode(row["Barcode"].ToString(),
                                            locationCode,
                                            GlobalContext.WarehouseCode,
                                            GlobalContext.BranchCode,
                                            isWarehouse);
                                        productLocation.OfficerID = row["OfficerId"].ToString();
                                        productLocations.Add(productLocation);
                                    }

                                    // transfer to server.
                                    ServiceHelper.MobileServices.ProductLocationMixAdd(GlobalContext.BranchCode,
                                                         GlobalContext.WarehouseCode,
                                                         GlobalContext.UserCode,
                                                         productLocations.ToArray());


                                    //delete

                                    com.CommandText = SqlHelper.GetSql(30);
                                    com.ExecuteNonQuery();

                                    productMixedTable.Clear();
                                    productLocations.Clear();

                                }
                            }

                        }
                    }


                    Cursor.Current = Cursors.Default;
                    GlobalMessageBox.ShowInfomation("บันทึกข้อมูลไปยัง SAP สำเร็จ");
                    this.Close();
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    GlobalMessageBox.ShowError("บันทึกข้อมูลไม่สำเร็จ กรุณาลองใหม่อีกครั้ง " + ex.Message);
                    BindGrid();

                }
            }
        }

        public ProductMixedOfflineForm()
        {
            InitializeComponent();
        }

        private void ProductMixedOfflineForm_Load(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void gvLocationProduct_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {
            //click on delete column
            if (e.Cell.ColumnIndex == 2)
            {
                if (GlobalMessageBox.ShowQuestion("คุณต้องลบรายการ ใช่หรือไม่") == DialogResult.Yes)
                {
                    var locationCode = gvLocationProduct.Cells[e.Cell.RowIndex, 0].Text;
                    using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                    {
                        con.Open();
                        using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(30), con))
                        {
                            com.Parameters.AddWithValue("@LocationCode", locationCode);
                            com.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);
                            com.ExecuteNonQuery();
                        }
                    }
                    this.BindGrid();
                }
            }
        }


    }
}