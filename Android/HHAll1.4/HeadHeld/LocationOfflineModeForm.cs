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
    public partial class LocationOfflineModeForm : Form
    {
        private void BindGrid()
        {
            DataTable locationProductData = new DataTable();
            locationProductData.Columns.Add("Id", typeof(int));
            locationProductData.Columns.Add("LocationCode", typeof(string));
            locationProductData.Columns.Add("Barcode", typeof(string));

            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(50), con))
                {
                    com.Parameters.AddWithValue("@UserCode", GlobalContext.UserCode);

                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = locationProductData.NewRow();
                            row["Id"] = reader["Id"];
                            row["LocationCode"] = reader["LocationCode"];
                            row["Barcode"] = string.Format("{0:N0}", reader["Barcode"]);
                            locationProductData.Rows.Add(row);
                        }
                    }

                }
            }

            gvLocationProduct.DataSource = locationProductData;
        }
        private void SaveData()
        {
            if (gvLocationProduct.DataSource != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable data = (DataTable)gvLocationProduct.DataSource;
                var id = 0;
                var locationCode = string.Empty;
                foreach (DataRow item in data.Rows)
                {
                    id = Convert.ToInt32(item["Id"]);
                    locationCode = item["LocationCode"].ToString();

                    DataTable locationProduct = new DataTable();
                    using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                    {
                        con.Open();

                        using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(52), con))
                        {
                            com.Parameters.AddWithValue("@Id", id);
                            using (SqlCeDataAdapter adap = new SqlCeDataAdapter(com))
                            {
                                adap.Fill(locationProduct);
                            }
                        }
                    }

                    List<ProductLocation> productLocations = new List<ProductLocation>();
                    foreach (DataRow row in locationProduct.Rows)
                    {

                        productLocations.Add(new ProductLocation
                        {
                            //LocationCode = locationCode,
                            LocationType = Utils.GetLocationTypeByLocationCode(locationCode),
                            ProductBarcode = row["ProductCode"].ToString(),
                            //WarehouseCode = GlobalContext.WarehouseCode,
                            PutQuantity = Utils.DecimalParse(row["PutQty"].ToString()),
                            PutQuantitySpecified = true,
                            PutLevel = Utils.DecimalParse(row["PutLevel"].ToString()),
                            PutLevelSpecified = true,
                            DisplayOrder = Utils.Int32Parse(row["DisplayOrder"].ToString()),
                            DisplayOrderSpecified = true,
                            RequestPrintLabel = Convert.IsDBNull(row["RequestPrintLabel"]) ? false : Convert.ToBoolean(row["RequestPrintLabel"]),
                            RequestPrintLabelSpecified = true,
                            MaxStock = Utils.DecimalParse(row["MaxStock"].ToString()),
                            MaxStockSpecified = true,
                            UserID = GlobalContext.UserCode,
                            Remark = row["PrintLabelType"].ToString()

                        });
                    }

                    var result = string.Empty;
                    result = ServiceHelper.MobileServices.ProductLocationAdd(GlobalContext.BranchCode, locationCode, GlobalContext.WarehouseCode, productLocations.ToArray());
                    if (!"ERROR".Equals(result))
                    {
                        Delete(id);
                        //using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                        //{
                        //    con.Open();

                        //    using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(51), con))
                        //    {
                        //        com.Parameters.AddWithValue("@Id", id);
                        //        com.ExecuteNonQuery();
                        //    }
                        //}
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        GlobalMessageBox.ShowError("บันทึกข้อมูลไม่สำเร็จ กรุณาติดต่อผู้ดูแล");
                        BindGrid();
                        return;
                    }
                }
                Cursor.Current = Cursors.Default;
                GlobalMessageBox.ShowInfomation("บันทึกข้อมูลไปยัง SAP สำเร็จ");
                BindGrid();
            }
        }
        public LocationOfflineModeForm()
        {
            InitializeComponent();
        }
        private void LocationOfflineModeForm_Load(object sender, EventArgs e)
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
        private void Delete(int id)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();

                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(53), con))
                {
                    com.Parameters.AddWithValue("@Id", id);
                    com.ExecuteNonQuery();

                    com.CommandText = SqlHelper.GetSql(54);
                    com.ExecuteNonQuery();

                }
            }
        }
        private void gvLocationProduct_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {
            //click on delete column
            if (e.Cell.ColumnIndex == 2)
            {
                if (GlobalMessageBox.ShowQuestion("คุณต้องลบรายการ ใช่หรือไม่") == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(gvLocationProduct.Cells[e.Cell.RowIndex, 3].Text);
                    Delete(id);
                    this.BindGrid();
                }
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

    }
}