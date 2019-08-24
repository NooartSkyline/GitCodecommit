using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using System.Collections.Generic;
using BLToolkit.Data;
using System;

namespace DoHome.MobileService
{
    #region Property

    ///<summary>
    ///<para>Date Created: 12/03/2012</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBPRINTLABEL_LOCATION</para>
    ///<para>This object represents the properties of a PrintLabelLocation, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("TBPRINTLABEL_LOCATION")]
    public partial class PrintLabelLocation
    {
        [DataMember]
        [MapField("DOCNO")]
        public string DocumentNo { get; set; }

        [DataMember]
        [MapField("DOCDATE")]
        public DateTime DocumentDate { get; set; }

        [DataMember]
        [MapField("CREATEDATE")]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        [MapField("CREATEUSER")]
        public string CreatedBy { get; set; }

        [DataMember]
        [MapField("REMARK")]
        public string Remark { get; set; }

        [DataMember]
        [MapField("PRINTDATE")]
        public DateTime? PrintedOn { get; set; }

        [DataMember]
        [MapField("PrintStatus")]
        public string PrintStatus { get; set; }

    }


    ///<summary>
    ///<para>Date Created: 12/03/2012</para>
    ///<para>Created By  : Mr.Suchart Joolrat.</para>
    ///<para>Function    : To create a business tier relating to table TBPRINTLABELSUB_LOCATION</para>
    ///<para>This object represents the properties of a PrintLabelLocationDetail, and is used to represent a single instance</para>
    ///</summary>    
    [DataContract]
    [TableName("TBPRINTLABELSUB_LOCATION")]
    public partial class PrintLabelLocationDetail
    {
        [DataMember]
        [MapField("DOCNO")]
        public string DocumentNo { get; set; }

        [DataMember]
        [MapField("ROWORDER")]
        public int DisplayOrder { get; set; }

        [DataMember]
        [MapField("DOCDATE")]
        public DateTime DocumentDate { get; set; }

        [DataMember]
        [MapField("LOCATION")]
        public string LocationCode { get; set; }

        [DataMember]
        [MapField("PRINTDATE")]
        public DateTime? PrintedOn { get; set; }

        [DataMember]
        [MapField("ISPRINTED")]
        [MapValue(true, 1)]
        [MapValue(false, 0)]
        public bool IsPrinted { get; set; }
    }

    [DataContract]
    public partial class PrintLabelLocationStatus
    {
        [DataMember]
        public string Docno { get; set; }

        [DataMember]
        public string LocationCode { get; set; }

        [DataMember]
        public string PrintedStatus { get; set; }
    }

    #endregion

    public partial interface IMobileService
    {
        [OperationContract]
        string PrintLabelLocationAdd(string branchCode, string warehouseCode, string createdBy, string labelType, List<PrintLabelLocationDetail> printLabelLocationDetails);

        [OperationContract]
        List<PrintLabelLocation> PrintLabelLocationGetAll(string branchCode, string documentNo, DateTime documentDate);

        [OperationContract]
        void PrintLabelLocationDelete(string branchCode, string documentNo);

        [OperationContract]
        List<PrintLabelLocationDetail> PrintLabelLocationDetailGetAll(string branchCode, string documentNo);

        [OperationContract]
        List<PrintLabelLocationStatus> PrintLabelLocationStatusGet(string branchCode, string createdBy);
    }


    public partial class MobileService : IMobileService
    {

        public string PrintLabelLocationAdd(string branchCode, string warehouseCode, string createdBy, string labelType, List<PrintLabelLocationDetail> printLabelLocationDetails)
        {
            string documentNo = string.Empty;//PL541215-0001
            try
            {
                using (DbManager db = new DbManager(branchCode))
                {
                    documentNo = db.SetCommand(GetSql(51)).ExecuteScalar<string>();
                }

                var culture = new System.Globalization.CultureInfo("th-TH");
                int index = 1;
                if (!string.IsNullOrEmpty(documentNo))
                    index = Convert.ToInt32(documentNo) + 1;

                documentNo = string.Format("PL{0}-{1:0000}", DateTime.Now.Date.ToString("yyMMdd", culture), index);

                using (DbManager db = new DbManager(branchCode))
                {
                    try
                    {
                        db.BeginTransaction();

                        // insert to master
                        db.SetCommand(GetSql(52)
                            , db.Parameter("@DocumentNo", documentNo)
                            , db.Parameter("@CreatedBy", createdBy)
                            , db.Parameter("@Remark", labelType))
                            .ExecuteNonQuery();

                        // insert to detail
                        string sql = GetSql(53);
                        int displayOrder = 0;
                        foreach (var item in printLabelLocationDetails)
                        {
                            string LocationType = item.LocationCode.Substring(9, 1);
                            string LocationZone = item.LocationCode.Substring(0, 1);
                            string LocationShelf = item.LocationCode.Substring(1, 3);
                            string LocationSide = item.LocationCode.Substring(4, 1);
                            string LocationHold = item.LocationCode.Substring(5, 2);
                            string LocationClass = item.LocationCode.Substring(7, 2);

                            db.SetCommand(sql,
                            db.Parameter("@DocumentNo", documentNo),
                            db.Parameter("@DisplayOrder", displayOrder),
                            db.Parameter("@WarehouseCode", warehouseCode),//ProductInLocationGetWarehouseCode(item.LocationCode)),
                            db.Parameter("@LocationCode", item.LocationCode),
                            db.Parameter("@LocationType", LocationType),
                            db.Parameter("@LocationZone", LocationZone),
                            db.Parameter("@LocationShelf", LocationShelf),
                            db.Parameter("@LocationSide", LocationSide),
                            db.Parameter("@LocationHold", LocationHold),
                            db.Parameter("@LocationClass", LocationClass),
                            db.Parameter("@ProductCode", ""),
                            db.Parameter("@ProductName", ""),
                            db.Parameter("@UnitCode", ""),
                            db.Parameter("@UnitName", ""),
                            db.Parameter("@Remark", ""))
                            .ExecuteNonQuery();
                            displayOrder++;
                        }

                        db.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        db.RollbackTransaction();
                        log.Error(ex);
                        documentNo = "ERROR";
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
                documentNo = "ERROR";
            }

            return documentNo;
        }
        public List<PrintLabelLocation> PrintLabelLocationGetAll(string branchCode, string documentNo, DateTime documentDate)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                var result = db.SetCommand(GetSql(73),
                      db.Parameter("@DocumentNo", "%" + documentNo + "%"),
                      db.Parameter("@DocumentDate", documentDate)).ExecuteList<PrintLabelLocation>();
                foreach (var item in result)
                {
                    if (item.PrintedOn.HasValue)
                        item.PrintStatus = "พิมพ์แล้ว";
                    else
                        item.PrintStatus = "ยังไม่พิมพ์";
                }

                return result;
            }

        }
        public void PrintLabelLocationDelete(string branchCode, string documentNo)
        {
            using (var db = new DbManager(branchCode))
            {
                db.SetCommand(GetSql(87), db.Parameter("@Docno", documentNo)).ExecuteNonQuery();
            }
        }
        public List<PrintLabelLocationDetail> PrintLabelLocationDetailGetAll(string branchCode, string documentNo)
        {
            List<PrintLabelLocationDetail> details;
            using (DbManager db = new DbManager(branchCode))
            {
                details = db.SetCommand(GetSql(74),
                    db.Parameter("@DocumentNo", documentNo)).ExecuteList<PrintLabelLocationDetail>();

            }

            return details;

        }
        public List<PrintLabelLocationStatus> PrintLabelLocationStatusGet(string branchCode, string createdBy)
        {
            using (DbManager db = new DbManager(branchCode))
            {
                return db.SetCommand(GetSql(85),
                    db.Parameter("@CreatedBy", createdBy)).ExecuteList<PrintLabelLocationStatus>();

            }
        }

    }
}

