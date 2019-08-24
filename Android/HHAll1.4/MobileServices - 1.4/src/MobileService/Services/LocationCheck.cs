using System;
using System.Linq;
using System.Web;
using System.ServiceModel;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DoHome.MobileService
{
    #region Property

    ///<summary>
    ///<para>Date Created: 11/10/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table LocationCheck</para>
    ///<para>This object represents the properties of a LocationCheck, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("LocationCheck")]
    public partial class LocationCheck
    {
        /// <summary>
        /// Gets the LocationCheck identifier
        /// </summary>
        [DataMember]
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Location
        /// </summary>
        [DataMember]
        [MapField("Location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Remark
        /// </summary>
        [DataMember]
        [MapField("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the OfficerCode
        /// </summary>
        [DataMember]
        [MapField("OfficerCode")]
        public string OfficerCode { get; set; }

        /// <summary>
        /// Gets or sets the CheckerCode
        /// </summary>
        [DataMember]
        [MapField("CheckerCode")]
        public string CheckerCode { get; set; }

        /// <summary>
        /// Gets or sets the CheckDate
        /// </summary>
        [DataMember]
        [MapField("CheckDate")]
        public DateTime CheckDate { get; set; }

        /// <summary>
        /// Gets or sets the BranchCode
        /// </summary>
        [DataMember]
        [MapField("BranchCode")]
        public string BranchCode { get; set; }

        /// <summary>
        /// Gets or sets the OfficerName
        /// </summary>
        [DataMember]
        [MapField("OfficerName")]
        public string OfficerName { get; set; }

        /// <summary>
        /// Gets or sets the CheckerName
        /// </summary>
        [DataMember]
        [MapField("CheckerName")]
        public string CheckerName { get; set; }

        /// <summary>
        /// Gets or sets the PeriodId
        /// </summary>
        [DataMember]
        [MapField("PeriodId")]
        public int PeriodId { get; set; }

        /// <summary>
        /// Gets or sets the WarehouseCode
        /// </summary>
        [DataMember]
        [MapField("WarehouseCode")]
        public string WarehouseCode { get; set; }

    }

    #endregion

    #region Service Interface

    public partial interface IMobileService
    {
        [OperationContract]
        void LocationCheckAdd(string branchCode, LocationCheck locationCheck, List<LocationCheckDetail> locationCheckDetail);

        [OperationContract]
        void LocationCheckUpdate(LocationCheck locationCheck, List<LocationCheckDetail> locationCheckDetail);

        [OperationContract]
        void LocationCheckDelete(int id);

        [OperationContract]
        LocationCheck LocationCheckGetByID(int id);

        [OperationContract]
        List<LocationCheck> LocationCheckGetAll();
    }

    #endregion

    #region Service

    public partial class MobileService : IMobileService
    {
        public void LocationCheckAdd(string branchCode, LocationCheck locationCheck, List<LocationCheckDetail> locationCheckDetail)
        {
            try
            {
                using (DbManager db = new DbManager("HandHeldDB"))
                {
                    try
                    {
                        db.BeginTransaction();

                        var queryMaster = new SqlQuery<LocationCheck>();
                        locationCheck.Location = locationCheck.Location.ToUpper();
                        locationCheck.CheckDate = DateTime.Now;
                        locationCheck.BranchCode = branchCode;
                        locationCheck.CheckerName = GetUserByCode(branchCode, locationCheck.CheckerCode).Name;
                        locationCheck.OfficerName = GetUserByCode(branchCode, locationCheck.OfficerCode).Name;

                        var locationCheckId = queryMaster.InsertWithIdentity(db, locationCheck);
                        var queryDetail = new SqlQuery<LocationCheckDetail>();

                        var agendas = LocationCheckPeriodAgendaGetAll();

                        LocationCheckPeriodAgenda agenda;
                        foreach (var item in locationCheckDetail)
                        {
                            agenda = agendas.Find(p => p.Id == item.PeriodAgendaId);
                            item.LocationCheckID = locationCheckId;
                            item.AgendaCode = agenda.AgendaTemplateCode;
                            item.AgendaName = agenda.AgendaTemplateName;
                            if (item.IsChecked)
                                item.Score = agenda.MaxPoint;
                            else
                                item.Score = 0;
                            // no insert list because bug in bltoolkit transaction.
                            queryDetail.Insert(db, item);
                        }

                        var queryDepartment = new SqlQuery<LocationCheckDepartment>();
                        var depts = SapDepartmentGetByLocationCode(locationCheck.BranchCode, locationCheck.WarehouseCode, locationCheck.Location);
                        foreach (var item in depts)
                        {
                            queryDepartment.Insert(db, new LocationCheckDepartment
                            {
                                LocationCheckId = locationCheckId,
                                Code = item.DepartmentCode,
                                Name = item.DepartmentName
                            });
                        }


                        //throw new Exception("blah?");
                        db.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void LocationCheckUpdate(LocationCheck locationCheck, List<LocationCheckDetail> locationCheckDetail)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                db.BeginTransaction();
                //master
                locationCheck.OfficerName = GetUserByCode(locationCheck.BranchCode, locationCheck.OfficerCode).Name;
                db.SetCommand(GetSql(57)
                , db.Parameter("@Id", locationCheck.Id)
                , db.Parameter("@Remark", locationCheck.Remark)
                , db.Parameter("@OfficerCode", locationCheck.OfficerCode)
                , db.Parameter("@OfficerName", locationCheck.OfficerName)).ExecuteNonQuery();

                //detail                
                db.SetCommand(GetSql(58)).ExecuteForEach<LocationCheckDetail>(locationCheckDetail);
          
                db.CommitTransaction();
            }
        }

        public void LocationCheckDelete(int Id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheck> query = new SqlQuery<LocationCheck>();
                query.DeleteByKey(db, Id);

                //delete detail
                db.SetCommand(GetSql(56), db.Parameter("@LocationCheckId", Id)).ExecuteNonQuery();
            }
        }

        public LocationCheck LocationCheckGetByID(int id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheck> query = new SqlQuery<LocationCheck>();
                return query.SelectByKey(db, id);
            }
        }

        public List<LocationCheck> LocationCheckGetAll()
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheck> query = new SqlQuery<LocationCheck>();
                return query.SelectAll(db);
            }
        }

    }
    #endregion
}

