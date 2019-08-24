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
    ///<para>Function    : To create a business tier relating to table LocationCheckDetail</para>
    ///<para>This object represents the properties of a LocationCheckDetail, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("LocationCheckDetail")]
    public partial class LocationCheckDetail
    {
        /// <summary>
        /// Gets the LocationCheckDetail identifier
        /// </summary>
        [DataMember]
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the LocationCheckID
        /// </summary>
        [DataMember]
        [MapField("LocationCheckID")]
        public int LocationCheckID { get; set; }

        /// <summary>
        /// Gets or sets the AgendaId
        /// </summary>
        [DataMember]
        [MapField("PeriodAgendaId")]
        public int PeriodAgendaId { get; set; }

        /// <summary>
        /// Gets or sets the AgendaCode
        /// </summary>
        [DataMember]
        [MapField("AgendaCode")]
        public string AgendaCode { get; set; }

        /// <summary>
        /// Gets or sets the AgendaName
        /// </summary>
        [DataMember]
        [MapField("AgendaName")]
        public string AgendaName { get; set; }

        /// <summary>
        /// Gets or sets the AgendaValue
        /// </summary>
        [DataMember]
        [MapField("AgendaValue")]
        public string AgendaValue { get; set; }

        /// <summary>
        /// Gets or sets the AgendaValue
        /// </summary>
        [DataMember]
        [MapField("IsChecked")]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Gets or sets the Score
        /// </summary>
        [DataMember]
        [MapField("Score")]
        public decimal Score { get; set; }
        

    }

    #endregion

    #region Service Interface

    public partial interface IMobileService
    {
        [OperationContract]
        void LocationCheckDetailAdd(LocationCheckDetail locationCheckDetail);

        [OperationContract]
        void LocationCheckDetailUpdate(LocationCheckDetail locationCheckDetail);

        [OperationContract]
        void LocationCheckDetailDelete(int id);

        [OperationContract]
        LocationCheckDetail LocationCheckDetailGetByID(int id);

        [OperationContract]
        List<LocationCheckDetail> LocationCheckDetailGetAll();
    }

    #endregion

    #region Service

    public partial class MobileService : IMobileService
    {
        public void LocationCheckDetailAdd(LocationCheckDetail locationCheckDetail)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDetail> query = new SqlQuery<LocationCheckDetail>();
                query.Insert(db, locationCheckDetail);
            }
        }

        public void LocationCheckDetailUpdate(LocationCheckDetail locationCheckDetail)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDetail> query = new SqlQuery<LocationCheckDetail>();
                query.Update(db, locationCheckDetail);
            }
        }

        public void LocationCheckDetailDelete(int Id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDetail> query = new SqlQuery<LocationCheckDetail>();
                query.DeleteByKey(db, Id);
            }
        }

        public LocationCheckDetail LocationCheckDetailGetByID(int id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDetail> query = new SqlQuery<LocationCheckDetail>();
                return query.SelectByKey(db, id);
            }
        }

        public List<LocationCheckDetail> LocationCheckDetailGetAll()
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDetail> query = new SqlQuery<LocationCheckDetail>();
                return query.SelectAll(db);
            }
        }

    }
    #endregion
}

