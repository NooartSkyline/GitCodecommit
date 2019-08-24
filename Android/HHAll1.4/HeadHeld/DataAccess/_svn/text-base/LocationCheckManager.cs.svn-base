using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace DoHome.HandHeld.Client.DataAccess
{
    class LocationCheckManager
    {
        public static List<LocationCheckPeriodAgenda> LocationCheckAgendaGetAllActive()
        {
            var agenda = new List<LocationCheckPeriodAgenda>();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(36), con))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            agenda.Add(new LocationCheckPeriodAgenda
                            {
                                AgendaTemplateId = reader.GetInt32(0),
                                AgendaTemplateName = reader.GetString(1),
                                IsValue = reader.GetBoolean(2),
                                CheckedValue = "0"
                            });
                        }
                    }
                }
            }


            foreach (var item in agenda)
            {
                if (item.IsValue)
                    item.CheckedValue = "0";
                else
                    item.CheckedValue = "";

                item.Checked = false;
            }

            return agenda;
        }

        public static void Add(string locationCode, string OfficerCode, List<LocationCheckPeriodAgenda> agenda)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                var trans = con.BeginTransaction();

                
                try
                {
                    //clear if LocationCode exists
                    DeleteByLocation(locationCode, GlobalContext.UserCode);

                    using (SqlCeCommand cmd = new SqlCeCommand(SqlHelper.GetSql(37), con))
                    {
                        foreach (var item in agenda)
                        {
                            //if (item.Checked)
                            //{
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@LocationCode", locationCode);
                            cmd.Parameters.AddWithValue("@OfficerCode", OfficerCode);
                            cmd.Parameters.AddWithValue("@CheckerCode", GlobalContext.UserCode);
                            cmd.Parameters.AddWithValue("@AgendaId", item.AgendaTemplateId);
                            cmd.Parameters.AddWithValue("@AgendaValue", item.CheckedValue);
                            cmd.Parameters.AddWithValue("@IsChecked", item.Checked);
                            cmd.Parameters.AddWithValue("@WarehouseCode", GlobalContext.WarehouseCode);
                            cmd.ExecuteNonQuery();
                            //}
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

        public static DataTable GetByCreatedBy(string createdBy)
        {
            DataTable locationCheckProductTable = new DataTable();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(38), con))
                {
                    com.Parameters.AddWithValue("@CheckerCode", createdBy);

                    using (SqlCeDataAdapter adab = new SqlCeDataAdapter(com))
                    {
                        adab.Fill(locationCheckProductTable);
                    }
                }
            }

            return locationCheckProductTable;
        }

        public static DataTable GetByLocation(string locationCode, string checkerCode)
        {
            DataTable locationCheckProductTable = new DataTable();
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(39), con))
                {
                    com.Parameters.AddWithValue("@LocationCode", locationCode);
                    com.Parameters.AddWithValue("@CheckerCode", checkerCode);

                    using (SqlCeDataAdapter adab = new SqlCeDataAdapter(com))
                    {
                        adab.Fill(locationCheckProductTable);
                    }
                }
            }

            return locationCheckProductTable;
        }

        public static void DeleteByLocation(string locationCode, string checkerCode)
        {
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand cmd = new SqlCeCommand(SqlHelper.GetSql(40), con))
                {
                    cmd.Parameters.AddWithValue("@LocationCode", locationCode);
                    cmd.Parameters.AddWithValue("@CheckerCode", checkerCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void TransferToServer()
        {
            var userCode = GlobalContext.UserCode;
            var locationCheckProductTable = GetByCreatedBy(userCode);
            LocationCheck locationCheck = null;
            foreach (DataRow item in locationCheckProductTable.Rows)
            {
                locationCheck = new LocationCheck
                {
                    Location = item["LocationCode"].ToString(),
                    CheckerCode = item["CheckerCode"].ToString(),
                    OfficerCode = item["OfficerCode"].ToString(),
                    WarehouseCode = item["WarehouseCode"].ToString(),
                    PeriodId = GetCurrentPeriodId(),
                    PeriodIdSpecified = true
                };

                var locationCheckTable = GetByLocation(locationCheck.Location, userCode);
                var locationCheckDetail = new List<LocationCheckDetail>();
                foreach (DataRow row in locationCheckTable.Rows)
                {
                    locationCheckDetail.Add(new LocationCheckDetail
                    {
                        PeriodAgendaId = Convert.ToInt32(row["AgendaId"]),
                        PeriodAgendaIdSpecified = true,
                        AgendaValue = row["AgendaValue"] as string,
                        IsChecked = Convert.ToBoolean(row["IsChecked"]),
                        IsCheckedSpecified = true
                    });
                }

                ServiceHelper.MobileServices.LocationCheckAdd(GlobalContext.BranchCode, locationCheck, locationCheckDetail.ToArray());

                DeleteByLocation(locationCheck.Location, userCode);

            }

        }

        public static int GetCurrentPeriodId()
        {
            int periodId = 0;
            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
            {
                con.Open();
                using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(41), con))
                {
                    periodId = Convert.ToInt32(com.ExecuteScalar());
                }
            }

            return periodId;

        }

    }
}
