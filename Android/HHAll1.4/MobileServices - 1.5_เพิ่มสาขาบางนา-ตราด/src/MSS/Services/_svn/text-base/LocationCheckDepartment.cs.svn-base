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
    ///<para>Date Created: 18/11/2011</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table LocationCheckDepartment</para>
    ///<para>This object represents the properties of a LocationCheckDepartment, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("LocationCheckDepartment")]
    public partial class LocationCheckDepartment
    {
        /// <summary>
        /// Gets the LocationCheckDepartment identifier
        /// </summary>
        [DataMember]
        [MapField("Id"), PrimaryKey, NonUpdatable]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the LocationCheckId
        /// </summary>
        [DataMember]
        [MapField("LocationCheckId")]
        public int LocationCheckId { get; set; }

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        [DataMember]
        [MapField("Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [DataMember]
        [MapField("Name")]
        public string Name { get; set; }

    }

    #endregion

    #region Service Interface

    public partial interface IMobileService
    {
        [OperationContract]
        void LocationCheckDepartmentAdd(LocationCheckDepartment locationCheckDepartment);

        [OperationContract]
        void LocationCheckDepartmentUpdate(LocationCheckDepartment locationCheckDepartment);

        [OperationContract]
        void LocationCheckDepartmentDelete(int id);

        [OperationContract]
        LocationCheckDepartment LocationCheckDepartmentGetByID(int id);

        [OperationContract]
        List<LocationCheckDepartment> LocationCheckDepartmentGetAll();
    }

    #endregion

    #region Service

    public partial class MobileService : IMobileService
    {
        public void LocationCheckDepartmentAdd(LocationCheckDepartment locationCheckDepartment)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDepartment> query = new SqlQuery<LocationCheckDepartment>();
                query.Insert(db, locationCheckDepartment);
            }
        }

        public void LocationCheckDepartmentUpdate(LocationCheckDepartment locationCheckDepartment)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDepartment> query = new SqlQuery<LocationCheckDepartment>();
                query.Update(db, locationCheckDepartment);
            }
        }

        public void LocationCheckDepartmentDelete(int Id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDepartment> query = new SqlQuery<LocationCheckDepartment>();
                query.DeleteByKey(db, Id);
            }
        }

        public LocationCheckDepartment LocationCheckDepartmentGetByID(int id)
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDepartment> query = new SqlQuery<LocationCheckDepartment>();
                return query.SelectByKey(db, id);
            }
        }

        public List<LocationCheckDepartment> LocationCheckDepartmentGetAll()
        {
            using (DbManager db = new DbManager("HandHeldDB"))
            {
                SqlQuery<LocationCheckDepartment> query = new SqlQuery<LocationCheckDepartment>();
                return query.SelectAll(db);
            }
        }

    }
    #endregion
}

