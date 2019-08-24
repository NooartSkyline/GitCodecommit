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
    ///<para>Date Created: 18/10/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table LocationCheckPeriodAgenda</para>
    ///<para>This object represents the properties of a LocationCheckPeriodAgenda, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("LocationCheckPeriodAgenda")]
    public partial class LocationCheckPeriodAgenda
    {
        /// <summary>
        /// Gets the LocationCheckPeriodAgenda identifier
        /// </summary>
        [DataMember]
        [MapField("Id"), PrimaryKey, NonUpdatable]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PeriodId
        /// </summary>
        [DataMember]
        [MapField("PeriodId")]
        public int PeriodId { get; set; }

        /// <summary>
        /// Gets or sets the AgendaTemplateId
        /// </summary>
        [DataMember]
        [MapField("AgendaTemplateId")]
        public int AgendaTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the AgendaTemplateCode
        /// </summary>
        [DataMember]
        [MapField("AgendaTemplateCode")]
        public string AgendaTemplateCode { get; set; }

        /// <summary>
        /// Gets or sets the AgendaTemplateName
        /// </summary>
        [DataMember]
        [MapField("AgendaTemplateName")]
        public string AgendaTemplateName { get; set; }

        /// <summary>
        /// Gets or sets the IsValue
        /// </summary>
        [DataMember]
        [MapField("IsValue")]
        public bool IsValue { get; set; }

        /// <summary>
        /// Gets or sets the MaxPoint
        /// </summary>
        [DataMember]
        [MapField("MaxPoint")]
        public decimal MaxPoint { get; set; }

        /// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        [DataMember]
        [MapField("DisplayOrder")]
        public int DisplayOrder { get; set; }

        [DataMember]
        [NonUpdatable]
        public string CheckedValue { get; set; }

        [DataMember]
        [NonUpdatable]
        public bool Checked { get; set; }

        [DataMember]
        [NonUpdatable]
        public int PeriodAgendaId { get; set; }
    }

    #endregion

    #region Service Interface

    public partial interface IMobileService
    {
        [OperationContract]
        void LocationCheckPeriodAgendaAdd(LocationCheckPeriodAgenda locationCheckPeriodAgenda);

        [OperationContract]
        void LocationCheckPeriodAgendaUpdate(LocationCheckPeriodAgenda locationCheckPeriodAgenda);

        [OperationContract]
        void LocationCheckPeriodAgendaDelete(int id);

        [OperationContract]
        LocationCheckPeriodAgenda LocationCheckPeriodAgendaGetByID(int id);

        [OperationContract]
        List<LocationCheckPeriodAgenda> LocationCheckPeriodAgendaGetAll();
    }

    #endregion

    #region Service

    public partial class MobileService : IMobileService
    {
        public void LocationCheckPeriodAgendaAdd(LocationCheckPeriodAgenda locationCheckPeriodAgenda)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckPeriodAgenda> query = new SqlQuery<LocationCheckPeriodAgenda>();
                query.Insert(db, locationCheckPeriodAgenda);
            }
        }

        public void LocationCheckPeriodAgendaUpdate(LocationCheckPeriodAgenda locationCheckPeriodAgenda)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckPeriodAgenda> query = new SqlQuery<LocationCheckPeriodAgenda>();
                query.Update(db, locationCheckPeriodAgenda);
            }
        }

        public void LocationCheckPeriodAgendaDelete(int Id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckPeriodAgenda> query = new SqlQuery<LocationCheckPeriodAgenda>();
                query.DeleteByKey(db, Id);
            }
        }

        public LocationCheckPeriodAgenda LocationCheckPeriodAgendaGetByID(int id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckPeriodAgenda> query = new SqlQuery<LocationCheckPeriodAgenda>();
                return query.SelectByKey(db, id);
            }
        }

        public List<LocationCheckPeriodAgenda> LocationCheckPeriodAgendaGetAll()
        {
            List<LocationCheckPeriodAgenda> locationCheckPeriodAgenda;
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                locationCheckPeriodAgenda = db.SetCommand(GetSql(49)).ExecuteList<LocationCheckPeriodAgenda>();
            }

            foreach (var item in locationCheckPeriodAgenda)
            {
                item.Checked = false;
            }

            return locationCheckPeriodAgenda;
        }

    }
    #endregion
}

