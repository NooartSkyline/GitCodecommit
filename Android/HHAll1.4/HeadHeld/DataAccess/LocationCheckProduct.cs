using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace DoHome.HandHeld.Client.DataAccess
{
    class LocationCheckProductManager
    {
        public static DataTable GetByCreatedBy(string createdBy)
        {
            DataTable locationCheckProductTable = new DataTable();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(19), con))
                {
                    com.Parameters.AddWithValue("@CreatedBy", createdBy);

                    using (SqlCeDataAdapter adab = new SqlCeDataAdapter(com))
                    {
                        adab.Fill(locationCheckProductTable);
                    }
                }
            }

            return locationCheckProductTable;
        }

        public static void Add(List<ProductLocation> products)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand cmd = new SqlCeCommand())
                {
                    IDbTransaction trans = con.BeginTransaction(IsolationLevel.Serializable);
                    try
                    {
                        //clear LocationCheckProductDetail.
                        cmd.Connection = con;
                        int id = GetLocationCheckProductID(products[0].LocationCode, GlobalContext.UserCode);
                        cmd.CommandText = SqlHelper.GetSql(28);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        //clear LocationCheckProduct.
                        cmd.CommandText = SqlHelper.GetSql(29);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        cmd.Connection = con;
                        cmd.CommandText = SqlHelper.GetSql(13);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@LocationCode", products[0].LocationCode);
                        cmd.Parameters.AddWithValue("@EmployeeCode", products[0].OfficerID);
                        cmd.Parameters.AddWithValue("@WarehouseCode", products[0].WarehouseCode);
                        cmd.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);
                        cmd.Parameters.AddWithValue("@BranchCode", GlobalContext.BranchCode);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT @@IDENTITY";
                        cmd.Parameters.Clear();
                        id = 0;
                        id = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.CommandText = SqlHelper.GetSql(14);
                        foreach (var item in products)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@LocationCheckProductID", id);
                            cmd.Parameters.AddWithValue("@ProductBarCode", item.ProductBarcode);
                            cmd.Parameters.AddWithValue("@DisplayOrder", item.DisplayOrder);
                            cmd.Parameters.AddWithValue("@ShopPrice", item.ShopPrice);
                            cmd.ExecuteNonQuery();

                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int id)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(15), con))
                {
                    com.Parameters.AddWithValue("@ID", id);
                    com.ExecuteNonQuery();

                    com.CommandText = SqlHelper.GetSql(18);
                    com.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string locationCode)
        {
            DataTable locationCheckProductTable = new DataTable();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(42), con))
                {
                    com.Parameters.AddWithValue("@LocationCode", locationCode);
                    com.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);

                    var id = com.ExecuteScalar();
                    if (!Convert.IsDBNull(id) || id == null)
                    {
                        Delete(Convert.ToInt32(id));
                    }
                }
            }
        }

        public static int GetLocationCheckProductID(string locationCode, string createdBy)
        {
            int id = 0;
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(27), con))
                {
                    com.Parameters.AddWithValue("@LocationCode", locationCode);
                    com.Parameters.AddWithValue("@CreatedBy", createdBy);
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                    }

                }
            }

            return id;
        }

        public static void TransferToServer()
        {
            int locationCheckProductID = 0;
            DataTable locationTable = new DataTable();
            DataTable productTable = new DataTable();
            List<ProductLocation> productOfLocation = new List<ProductLocation>();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand cmd = new SqlCeCommand())
                {
                    cmd.Connection = con;

                    cmd.Parameters.Clear();
                    cmd.CommandText = SqlHelper.GetSql(16);
                    cmd.Parameters.AddWithValue("@CreatedBy", GlobalContext.UserCode);
                    cmd.ExecuteNonQuery();
                    using (SqlCeDataAdapter adab = new SqlCeDataAdapter(cmd))
                    {
                        adab.Fill(locationTable);
                    }

                    foreach (DataRow item in locationTable.Rows)
                    {
                        locationCheckProductID = (int)item["LocationCheckProductID"];
                        cmd.Parameters.Clear();
                        cmd.CommandText = SqlHelper.GetSql(17);
                        cmd.Parameters.AddWithValue("@ID", locationCheckProductID);

                        using (SqlCeDataAdapter adab = new SqlCeDataAdapter(cmd))
                        {
                            adab.Fill(productTable);
                        }

                        foreach (DataRow row in productTable.Rows)
                        {
                            productOfLocation.Add(new ProductLocation
                            {
                                ProductBarcode = (string)row["ProductBarcode"],
                                ShopPrice = (decimal)row["ShopPrice"],
                                ShopPriceSpecified = true,
                                DisplayOrder = (int)row["DisplayOrder"],
                                DisplayOrderSpecified = true,
                                CreateDateSpecified = true,
                                OfficerID = (string)item["EmployeeCode"],
                                WarehouseCode = (string)item["WarehouseCode"],
                                UserID = (string)item["CreatedBy"],
                                LocationCode = (string)item["LocationCode"],
                            });
                        }

                        //Transfer to SAP
                        ServiceHelper.MobileServices.ProductLocationAddHandHeldLocation((string)item["BranchCode"], productOfLocation.ToArray());
                        productOfLocation.Clear();
                        productTable.Clear();

                        //Delete if Transfer to SAP success.
                        Delete(locationCheckProductID);
                    }
                }
            }

        }

    }

}
