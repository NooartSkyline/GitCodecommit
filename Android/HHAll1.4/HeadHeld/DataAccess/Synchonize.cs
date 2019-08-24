﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client.DataAccess
{
    internal class Synchonize
    {

        public bool SyncBranch()
        {
            try
            {
                var branchs = ServiceHelper.MobileServices.BranchGetAll();

                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(20), con))
                    {
                        com.ExecuteNonQuery();
                        com.CommandText = SqlHelper.GetSql(21);
                        foreach (var item in branchs)
                        {
                            com.Parameters.Clear();
                            com.Parameters.AddWithValue("@Code", item.Code);
                            com.Parameters.AddWithValue("@Name", item.Name);
                            com.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool SyncWarehouse()
        {
            try
            {
                var warehouse = ServiceHelper.MobileServices.WareHouseGetAll(GlobalContext.BranchCode);

                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(22), con))
                    {
                        // clear old data for warehouse.
                        com.ExecuteNonQuery();

                        com.CommandText = SqlHelper.GetSql(23);
                        foreach (var item in warehouse)
                        {
                            com.Parameters.Clear();
                            com.Parameters.AddWithValue("@Code", item.Code);
                            com.Parameters.AddWithValue("@Name", item.Name);
                            com.Parameters.AddWithValue("@BranchCode", item.BranchCode);
                            com.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool SyncEmployee()
        {
            try
            {
                var employees = ServiceHelper.MobileServices.UserGetAll(GlobalContext.BranchCode);
                
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(5), con))
                    {
                        // Employee
                        com.Parameters.Clear();
                        com.ExecuteNonQuery();

                        com.CommandText = SqlHelper.GetSql(6);
                        foreach (var item in employees)
                        {
                            com.Parameters.AddWithValue("@EmployeeCode", item.Code);
                            com.Parameters.AddWithValue("@EmployeeName", item.Name);
                            com.Parameters.AddWithValue("@Password", item.PasswordDecrypt);
                            com.ExecuteNonQuery();
                            com.Parameters.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool SyncLocationCheckAgenda()
        {
            try
            {
                var agenda = ServiceHelper.MobileServices.LocationCheckPeriodAgendaGetAll();
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(34), con))
                    {
                        // LocationCheckAgenda
                        com.Parameters.Clear();
                        com.ExecuteNonQuery();

                        com.CommandText = SqlHelper.GetSql(35);
                        foreach (var item in agenda)
                        {
                            com.Parameters.AddWithValue("@Id", item.Id);
                            com.Parameters.AddWithValue("@Name", item.AgendaTemplateName);
                            com.Parameters.AddWithValue("@IsValue", item.IsValue);
                            com.Parameters.AddWithValue("@DisplayOrder", item.DisplayOrder);
                            com.Parameters.AddWithValue("@PeriodId", item.PeriodId);
                            com.ExecuteNonQuery();
                            com.Parameters.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool SyncForms()
        {
            var EndPoint = GlobalContext.ServerEndpointAddress;
            var ServiceUrl = GlobalContext.remoteAddress;
            try
            {
                var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
                cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
                var ListOfForms = cnn.GetTopstockForms();
                if (ListOfForms.Count() > 0)
                {
                    try
                    {
                        using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                        {
                            con.Open();
                            using (SqlCeCommand com = new SqlCeCommand("Delete TopstockForm", con))
                            {
                                com.ExecuteNonQuery();
                                com.CommandText = "Insert into TopstockForm (FormCode,FormName) Values(@FormCode,@FormName)";
                                foreach (var item in ListOfForms)
                                {
                                    com.Parameters.Clear();
                                    com.Parameters.AddWithValue("@FormCode", item.FormCode);
                                    com.Parameters.AddWithValue("@FormName", item.FromName);
                                    com.ExecuteNonQuery();
                                    if (item.FormCode.ToString().Trim() == "ZTOPST2")
                                    {
                                        GlobalContext.IndexFormType = 0;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                  
                }
            }
            catch (Exception ex)
            {
                throw ex;               
            }
            return true;
        } 
    }
}
