using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client.DataAccess
{
    public class LabelLocationPrint
    {
        public int Id { get; set; }

        public string LocationCode { get; set; }

        public int Quantity { get; set; }

    }

    public class LabelLocationPrintManager
    {

        public static List<LabelLocationPrint> GetAll()
        {
            var locations = new List<LabelLocationPrint>();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(43), con))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            locations.Add(new LabelLocationPrint
                            {
                                Id = reader.GetInt32(0),
                                LocationCode = reader.GetString(1),
                                Quantity = reader.GetInt32(2)
                            });

                        }
                    }
                }
            }
            return locations;
        }

        public static void Add(List<LabelLocationPrint> locations)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                var trans = con.BeginTransaction();
                try
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(SqlHelper.GetSql(44), con))
                    {
                        //clear all old data.
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = SqlHelper.GetSql(46);
                        foreach (var item in locations)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@LocationCode", item.LocationCode);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.ExecuteNonQuery();
                        }
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

        public static void UpdateQuantity(List<LabelLocationPrint> locations)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                var trans = con.BeginTransaction();
                try
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(SqlHelper.GetSql(47), con))
                    {
                        foreach (var item in locations)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@LocationCode", item.LocationCode);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.ExecuteNonQuery();
                        }
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

        public static void Delete(string locationCode)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(45), con))
                {
                    com.Parameters.AddWithValue("@LocationCode", locationCode);
                    com.ExecuteNonQuery();
                }
            }
        }

    }
}
