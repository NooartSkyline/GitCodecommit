using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client.DataAccess
{
    class BranchManager
    {
        public static  List<Branch> GetAll()
        {
            List<Branch> branchs = new List<Branch>();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(24), con))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            branchs.Add(new Branch
                            {
                                Code = reader.GetString(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return branchs;
        }
    }
}
