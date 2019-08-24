using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Data;

namespace DoHome.HandHeld.Client.DataAccess
{
    public class RequestLocationLabelSuperManager
    {
        public static DataTable GetAll()
        {
            DataTable dtRequestLocationLabelSuper = new DataTable();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(55), con))
                {
                    using (SqlCeDataAdapter adap = new SqlCeDataAdapter(com))
                    {
                        adap.Fill(dtRequestLocationLabelSuper);
                    }
                }
            }
            return dtRequestLocationLabelSuper;
        }

        public static void Add(string locationCode, string requester, string warehouseCode)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(57), con))
                {
                    com.Parameters.AddWithValue("@LocationCode", locationCode);
                    com.Parameters.AddWithValue("@Requester", requester);
                    com.Parameters.AddWithValue("@WarehouseCode", warehouseCode);
                    com.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(56), con))
                {
                    com.Parameters.AddWithValue("@Id", id);
                    com.ExecuteNonQuery();
                }
            }
        }
    }

    //public class RequestLocationLabelSuper
    //{
    //    public int Id { get; set; }
    //    public string LocationCode { get; set; }
    //    //public string Requester { get; set; }
    //    //public string WarehouseCode { get; set; }

    //}
}
