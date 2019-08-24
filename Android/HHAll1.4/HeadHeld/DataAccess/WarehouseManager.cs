using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client.DataAccess
{
    class WarehouseManager
    {
        public static List<Warehouse> GetAllByBranch(string branchCode)
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(25), con))
                {
                    com.Parameters.AddWithValue("@BranchCode", branchCode);
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            warehouses.Add(new Warehouse
                            {
                                Code = reader.GetString(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return warehouses;
        }
    }
}
