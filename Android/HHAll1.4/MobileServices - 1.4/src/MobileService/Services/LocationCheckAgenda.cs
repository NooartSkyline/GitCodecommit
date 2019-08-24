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
    ///<para>Date Created: 07/10/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table LocationCheckAgenda</para>
    ///<para>This object represents the properties of a LocationCheckAgenda, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("LocationCheckAgenda")]
    public partial class LocationCheckAgenda
    {
        /// <summary>
        /// Gets the LocationCheckAgenda identifier
        /// </summary>
        [DataMember]
        [MapField("ID"), PrimaryKey]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [DataMember]
        [MapField("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IsValue
        /// </summary>
        [DataMember]
        [MapField("IsValue")]
        public bool IsValue { get; set; }

        /// <summary>
        /// Gets or sets the IsActive
        /// </summary>
        [DataMember]
        [MapField("IsActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        [DataMember]
        [MapField("DisplayOrder")]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        [DataMember]
        [MapField("CreatedOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        [DataMember]
        [MapField("CreatedBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the MaxPoint
        /// </summary>
        [DataMember]
        [MapField("MaxPoint")]
        public decimal MaxPoint { get; set; }

        /// <summary>
        /// Gets or sets the Checked
        /// </summary>
        [DataMember]
        [MapIgnore]
        public bool Checked { get; set; }

        /// <summary>
        /// Gets or sets the CheckedValue
        /// </summary>
        [DataMember]
        [MapIgnore]
        public string CheckedValue { get; set; }
    }

    #endregion

    public partial interface IMobileService
    {
        [OperationContract]
        void LocationCheckAgendaAdd(LocationCheckAgenda locationCheckAgenda);

        [OperationContract]
        void LocationCheckAgendaUpdate(LocationCheckAgenda locationCheckAgenda);

        [OperationContract]
        void LocationCheckAgendaDelete(int locationCheckAgendaID);

        [OperationContract]
        LocationCheckAgenda LocationCheckAgendaGetByID(int locationCheckAgendaID);

        [OperationContract]
        List<LocationCheckAgenda> LocationCheckAgendaGetAll();

        [OperationContract]
        List<LocationCheckAgenda> LocationCheckAgendaGetAllActive();

        [OperationContract]
        List<LocationCheckAgenda> LocationCheckAgendaGetByIsActive(bool isActive);

    }

    public partial class MobileService : IMobileService
    {

        public void LocationCheckAgendaAdd(LocationCheckAgenda locationCheckAgenda)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckAgenda> query = new SqlQuery<LocationCheckAgenda>();
                query.Insert(db, locationCheckAgenda);
            }
        }

        public void LocationCheckAgendaUpdate(LocationCheckAgenda locationCheckAgenda)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckAgenda> query = new SqlQuery<LocationCheckAgenda>();
                query.Update(db, locationCheckAgenda);
            }

        }

        public void LocationCheckAgendaDelete(int locationCheckAgendaID)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckAgenda> query = new SqlQuery<LocationCheckAgenda>();
                query.DeleteByKey(db, locationCheckAgendaID);
            }

        }

        public LocationCheckAgenda LocationCheckAgendaGetByID(int locationCheckAgendaID)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckAgenda> query = new SqlQuery<LocationCheckAgenda>();

                return query.SelectByKey(db, locationCheckAgendaID);
            }
        }

        public List<LocationCheckAgenda> LocationCheckAgendaGetAll()
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckAgenda> query = new SqlQuery<LocationCheckAgenda>();

                return query.SelectAll(db);
            }

        }

        public List<LocationCheckAgenda> LocationCheckAgendaGetAllActive()
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db
                    .SetCommand(GetSql(49))
                    .ExecuteList<LocationCheckAgenda>();
            }

        }

        public List<LocationCheckAgenda> LocationCheckAgendaGetByIsActive(bool isActive)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                return db
                    .SetCommand(GetSql(49)
                    , db.Parameter("@IsActive", isActive))
                    .ExecuteList<LocationCheckAgenda>();
            }

        }

    }

}


