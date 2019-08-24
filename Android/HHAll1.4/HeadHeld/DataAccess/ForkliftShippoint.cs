using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client.DataAccess
{
    public class ForkliftShippoint
    {
        public int Id { get; set; }
        public string BranchCode { get; set; }
        public string ShippointCode { get; set; }
        public string ShippointName { get; set; }
    }

    class ForkliftShippointManager
    {
        public static List<ForkliftShippoint> GetShippointByBranch(string branchCode)
        {
            var shippoints = new List<ForkliftShippoint>();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(58), con))
                {
                    com.Parameters.AddWithValue("@BranchCode", branchCode);
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shippoints.Add(new ForkliftShippoint
                            {
                                Id = reader.GetInt32(0),
                                BranchCode = reader.GetString(1),
                                ShippointCode = reader.GetString(2),
                                ShippointName = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return shippoints;
        }
    }
}
