using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Security.Cryptography;
using System.IO;

namespace DoHome.HandHeld.Client.DataAccess
{

    class UserManager
    {
        public static List<User> GetAllEmployee()
        {
            List<User> _employees = null;
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(7), con))
                {
                    _employees = new List<User>();
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _employees.Add(new User
                            {
                                Code = (string)reader[0],
                                Name = (string)reader[1]
                            });
                        }
                    }
                }
            }
            return _employees;
        }

        public static User GetByCode(string userCode)
        {
            User user = null;
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(26), con))
                {
                    user = new User();
                    com.Parameters.AddWithValue("@EmployeeCode", userCode);
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.Code = (string)reader["EmployeeCode"];
                            user.Name = (string)reader["EmployeeName"];
                            user.Password = (string)reader["Password"];
                        }
                    }
                }
            }
            return user;
        }

        public static User CheckLogin(string userCode, string password)
        {
            var user = GetByCode(userCode);
            if (user != null)
            {
                if (user.Password != password)
                {
                    user = null;
                }
            }


            return user;
        }
    }
}
