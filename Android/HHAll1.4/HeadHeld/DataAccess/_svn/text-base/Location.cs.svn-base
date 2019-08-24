using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client.DataAccess
{
    class Location
    {
        public string LocationCode { get; set; }

        public string WarehouseCode { get; set; }

    }

    class LocationManager
    {
        public static bool CheckExistsLocation(string locationCode)
        {
            bool isExists = false;
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(10), con))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            isExists = reader.GetInt32(0) > 0 ? true : false;
                        }
                    }
                }
            }

            return isExists;
        }
    }
}
