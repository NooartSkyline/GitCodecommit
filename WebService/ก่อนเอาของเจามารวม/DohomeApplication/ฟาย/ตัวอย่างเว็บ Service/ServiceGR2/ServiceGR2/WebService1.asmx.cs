using MoreLinq;
using Newtonsoft.Json;
using SmartObjects;
using SourceCode.SmartObjects.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace ServiceGR2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        private string hh_docno = "";
        public string ConnStr()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBTRANSConnectionString"].ConnectionString;
        }
        public string ConnStrDBMASTER()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBMASTERConnectionString"].ConnectionString;

        }
        [WebMethod]
        public string LOAD_ARTICLE_FOR_COUNT(string JSON_DOCNO, string EMP_ID)
        {
            DataSet ds = new DataSet();
            DataTable dt_doc = JsonConvert.DeserializeObject<DataTable>(JSON_DOCNO);
            string DOCNO = "";
            for (int a = 0; a < dt_doc.Rows.Count; a++)
            {
                DOCNO += "'" + dt_doc.Rows[a]["VBELN"].ToString() + "'";
                if (a < dt_doc.Rows.Count - 1)
                {
                    DOCNO += ",";
                }
            }
            DataTable dt = new DataTable();
            dt.TableName = "LIST_ARTICLE";
            DBTRANSDataContext db = new DBTRANSDataContext();
            string sql = "select * from tbtrans_postgritem where VBELN in(" + DOCNO + ") and HH_DOCNO is null and lfimg <> 0 and emp_id ='" + EMP_ID + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            da.Fill(dt);
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }
        [WebMethod]
        public string GET_ARTICLE_FOR_SAP(string JSON_DOCNO, string EMP_ID)
        {
            DataSet ds = new DataSet();
            DataTable dt_doc = JsonConvert.DeserializeObject<DataTable>(JSON_DOCNO);
            string DOCNO = "";
            for (int a = 0; a < dt_doc.Rows.Count; a++)
            {
                dev.lib.Utilities util = new dev.lib.Utilities();
                DOCNO += "'" + util.AddZero(dt_doc.Rows[a]["VBELN"].ToString(), 10) + "'";
                if (a < dt_doc.Rows.Count - 1)
                {
                    DOCNO += ",";
                }
            }
            DataTable dt = new DataTable();
            dt.TableName = "LIST_ARTICLE";
            DBTRANSDataContext db = new DBTRANSDataContext();
            //string sql = "select * from tbtrans_postgritem where DOC_SEARCH  in(" + DOCNO + ") and QTY is not null  and emp_id ='" + EMP_ID + "' and WBSTK ='A'";       
            string sql = "select * from tbtrans_postgritem where DOC_SEARCH  in(" + DOCNO + ") and QTY <> 0 and HH_DOCNO is null  and emp_id ='" + EMP_ID + "' ";
            SqlDataAdapter da = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            da.Fill(dt);
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);

        }
        [WebMethod]
        public string UPDATE_QTY_WITH_SCAN(string VBELN, string POSNR, string PRODUCT_UNIT, string EMP_ID)
        {
            dev.lib.Utilities util = new dev.lib.Utilities();
            DataTable dt = new DataTable();
            DBTRANSDataContext db = new DBTRANSDataContext();
            try
            {
                if (!string.IsNullOrEmpty(PRODUCT_UNIT))
                {
                    TBTrans_PostGRItem gr_item = db.TBTrans_PostGRItems.Where(it => it.VBELN == util.AddZero(VBELN, 10) && it.POSNR == POSNR && it.VRKME.Equals(PRODUCT_UNIT) && it.EMP_ID.Equals(EMP_ID)).SingleOrDefault();
                    if (gr_item.QTY == null)
                    {
                        gr_item.QTY = 1;
                        gr_item.QTY_D = gr_item.QTY_D ??0;
                        gr_item.UNIT_SELECT = gr_item.VRKME;
                    }
                    else
                    {
                        gr_item.QTY += 1;
                    }
                    db.SubmitChanges();
                    return "true";
                }
                else
                {
                    TBTrans_PostGRItem gr_item = db.TBTrans_PostGRItems.Where(it => it.VBELN == util.AddZero(VBELN, 10) && it.POSNR == POSNR && it.EMP_ID.Equals(EMP_ID)).SingleOrDefault();
                    gr_item.QTY = 1;
                    gr_item.QTY_D = 0;
                    gr_item.UNIT_SELECT = PRODUCT_UNIT;
                    db.TBTrans_PostGRItems.InsertOnSubmit(gr_item);
                    db.SubmitChanges();
                    return "true";
                }

            }
            catch (Exception e)
            {
                return "false ," + e.Message;
            }

        }
        [WebMethod]
        public string CHECK_BARCODE(string barcode)
        {
            DBMASTERDataContext db = new DBMASTERDataContext();
            DataSet ds = new DataSet();
            DataTable barcode_item = (from tb in db.TBMaster_Barcodes where tb.BARCODE.Equals(barcode) select tb).ToDataTable();
            barcode_item.TableName = "TBMaster_Barcodes";
            ds.Tables.Add(barcode_item);
            return ConvertDataSetToJSON(ds);

        }
        [WebMethod]
        public string LOAD_DATA(string JSON_IT_IM_DOC, string EMP_ID)
        {
            dev.lib.Utilities util = new dev.lib.Utilities();
            DBTRANSDataContext db = new DBTRANSDataContext();
            string ret = "false";
            try
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(JSON_IT_IM_DOC);
                #region Connect K2
                string startupPath = Environment.CurrentDirectory;
                DataSet ds = new DataSet();

                SmartObjectClientServer serverName = K2_CONNECT_SERVER();

                //
                #endregion Connect K2    


                SmartObject smartObject = serverName.GetSmartObject("ZGET_DETAIL_DOC");
                smartObject.MethodToExecute = "ZGET_DETAILDOC_ZGET_DETAIL_DOC";

                string data_send = "";
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    ZGET_DETAIL_DOC_IT_IM_DOC item2 = new ZGET_DETAIL_DOC_IT_IM_DOC();
                    if (dt.Rows[a]["DOCTYPE"] != null)
                        item2.DOCTYPE = dt.Rows[a]["DOCTYPE"].ToString();
                    if (dt.Rows[a]["ERDAT"] != null && dt.Rows[a]["ERDAT"].ToString().Length > 0)
                        item2.ERDAT = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[a]["ERDAT"].ToString()).ToString("yyyy-MM-dd"));
                    if (dt.Rows[a]["WERKS"] != null)
                        item2.WERKS = dt.Rows[a]["WERKS"].ToString();
                    if (dt.Rows[a]["VBELN"] != null)
                        item2.VBELN = dt.Rows[a]["VBELN"].ToString();

                    ZGET_DETAIL_DOC_IT_IM_DOC_properties list_pro = item2.Serialize();
                    XElement xmlTree = XElement.Parse(list_pro.Serialized_Item__IT_IM_DOC_);
                    data_send += xmlTree.FirstNode.ToString();
                }
                smartObject.ListMethods["ZGET_DETAILDOC_ZGET_DETAIL_DOC"].InputProperties["IT_IM_DOC"].Value = "<connect>" + data_send + "</connect>";
                SmartObjectList SmartObjectList = serverName.ExecuteList(smartObject);

                try
                {
                    db = new DBTRANSDataContext();
                    db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    TBTrans_PostGRItem item = new TBTrans_PostGRItem();
                    if (SmartObjectList.SmartObjectsList.Count == 0)
                    {
                        return "false";
                    }
                    foreach (SmartObject sm in SmartObjectList.SmartObjectsList)
                    {
                        if (sm.Properties != null)
                        {
                            if (!string.IsNullOrEmpty(sm.Properties["IT_EX_DOC_MATNR"].Value))
                            {
                                //DataRow dr = dt_out.NewRow();
                                List<TBTrans_PostGRItem> list_del = db.TBTrans_PostGRItems.Where(v => v.VBELN == sm.Properties["IT_EX_DOC_VBELN"].Value && v.EMP_ID == EMP_ID && v.POSNR == sm.Properties["IT_EX_DOC_POSNR"].Value && v.HH_DOCNO == null).ToList();
                                if (list_del != null && list_del.Count > 0)
                                {
                                    db.TBTrans_PostGRItems.DeleteAllOnSubmit(list_del);
                                    db.SubmitChanges();
                                }
                                #region Insert TBTrans_PostGRItems
                                item = db.TBTrans_PostGRItems.Where(k => k.VBELN == sm.Properties["IT_EX_DOC_VBELN"].Value && k.MATNR == util.RemoveZero(sm.Properties["IT_EX_DOC_MATNR"].Value) && k.EMP_ID == EMP_ID && k.POSNR == sm.Properties["IT_EX_DOC_POSNR"].Value).SingleOrDefault();
                                if (item == null)
                                {
                                    item = new TBTrans_PostGRItem();
                                    item.VBELN = sm.Properties["IT_EX_DOC_VBELN"].Value;
                                    item.MATNR = sm.Properties["IT_EX_DOC_MATNR"].Value.TrimStart(Convert.ToChar("0"));
                                    item.MAKTX = sm.Properties["IT_EX_DOC_MAKTX"].Value ?? null;
                                    item.VRKME = sm.Properties["IT_EX_DOC_VRKME"].Value ?? null;
                                    item.UNIT_SELECT = sm.Properties["IT_EX_DOC_VRKME"].Value ?? null;
                                    item.WERKS = sm.Properties["IT_EX_DOC_WERKS"].Value ?? null;
                                    item.LGORT = sm.Properties["IT_EX_DOC_LGORT"].Value ?? null;
                                    if (!string.IsNullOrEmpty(sm.Properties["IT_EX_DOC_LFIMG"].Value.ToString()))
                                        item.LFIMG = Convert.ToInt32(sm.Properties["IT_EX_DOC_LFIMG"].Value);
                                    else
                                    {
                                        item.LFIMG = 0;
                                    }
                                    if (!string.IsNullOrEmpty(sm.Properties["IT_EX_DOC_LFIMG"].Value.ToString()))
                                        item.RFMNG = Convert.ToInt32(sm.Properties["IT_EX_DOC_RFMNG"].Value);
                                    else
                                    {
                                        item.RFMNG = 0;
                                    }
                                    if (!string.IsNullOrEmpty(sm.Properties["IT_EX_DOC_ERDAT"].Value.ToString()))
                                        item.ERDAT = Convert.ToDateTime(sm.Properties["IT_EX_DOC_ERDAT"].Value);
                                    else
                                    {
                                        item.ERDAT = null;
                                    }
                                    item.SERIAL = sm.Properties["IT_EX_DOC_SERAIL"].Value ?? null;
                                    item.XCHPF = sm.Properties["IT_EX_DOC_XCHPF"].Value ?? null;
                                    item.MHDRZ = sm.Properties["IT_EX_DOC_MHDRZ"].Value ?? null;
                                    item.MHDHB = sm.Properties["IT_EX_DOC_MHDHB"].Value ?? null;
                                    item.POSNR = sm.Properties["IT_EX_DOC_POSNR"].Value ?? null;
                                    item.LGMNG = sm.Properties["IT_EX_DOC_LGMNG"].Value ?? null;
                                    item.MEINS = sm.Properties["IT_EX_DOC_MEINS"].Value ?? null;
                                    item.UMVKZ = sm.Properties["IT_EX_DOC_UMVKZ"].Value ?? null;
                                    item.BWART = sm.Properties["IT_EX_DOC_BWART"].Value ?? null;
                                    item.SERIAL = sm.Properties["IT_EX_DOC_SERAIL"].Value ?? null;
                                    item.PKSTK = sm.Properties["IT_EX_DOC_PKSTK"].Value ?? null;
                                    item.WBSTK = sm.Properties["IT_EX_DOC_WBSTK"].Value ?? null;
                                    item.KOSTK = sm.Properties["IT_EX_DOC_KOSTK"].Value ?? null;
                                    item.VSBED = sm.Properties["IT_EX_DOC_VSBED"].Value ?? null;
                                    item.LFART = sm.Properties["IT_EX_DOC_LFART"].Value ?? null;
                                    item.CHARG = sm.Properties["IT_EX_DOC_CHARG"].Value ?? null;
                                    item.UECHA = sm.Properties["IT_EX_DOC_UECHA"].Value ?? null;
                                    item.VGBEL = sm.Properties["IT_EX_DOC_VGBEL"].Value ?? null;
                                    item.VGPOS = sm.Properties["IT_EX_DOC_VGPOS"].Value ?? null;
                                    item.EMP_ID = EMP_ID;
                                    item.STATUS = 0;
                                    if (dt.Rows[0]["DOCTYPE"].ToString().Equals("QE") || dt.Rows[0]["DOCTYPE"].ToString().Equals("SH") || dt.Rows[0]["DOCTYPE"].ToString().Equals("ISH"))
                                    {
                                        item.DOC_SEARCH = dt.Rows[0]["VBELN"].ToString();
                                        item.DOC_TYPE = dt.Rows[0]["DOCTYPE"].ToString();
                                        if (dt.Rows[0]["DOCTYPE"].ToString().Equals("QE"))
                                        {
                                            item.DOC_SITE = dt.Rows[0]["WERKS"].ToString();
                                            item.DOC_DATE = Convert.ToDateTime(dt.Rows[0]["ERDAT"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        item.DOC_SEARCH = sm.Properties["IT_EX_DOC_VBELN"].Value;
                                        item.DOC_TYPE = dt.Rows[0]["DOCTYPE"].ToString();
                                        item.DOC_SITE = dt.Rows[0]["WERKS"].ToString();
                                    }
                                    item.CREATEDATE = DateTime.Now;
                                    db.TBTrans_PostGRItems.InsertOnSubmit(item);
                                    db.SubmitChanges();
                                    ret = "true";
                                }
                                #endregion
                            }
                            else if (!string.IsNullOrEmpty(sm.Properties["IT_EX_DOC_MATNR"].Value) && SmartObjectList.SmartObjectsList.Count == 1)
                            {
                                ret = "false";
                            }
                        }
                        else if (sm.IsEmpty && SmartObjectList.SmartObjectsList.Count == 1)
                        {
                            ret = "false,ไม่พบข้อมูล SAP หรือ Input ข้อมูลไม่ถูกต้อง";
                        }
                    }

                    db.Transaction.Commit();
                    return ret;

                }
                catch (Exception ex)
                {
                    db.Transaction.Rollback();
                    return "false > " + ex.Message;
                }
            }
            catch (Exception ex)
            {

                return "false > " + ex.Message;
            }
        }

        [WebMethod]
        public string ZHANDHELD_GR_COUNT(String JSON_DOCNO, String EMP_CONFIRM_DAM, String EMP_ID, String SITE, String SLOC, String P_RPOINT)
        {
            string O_MSG = "";
            try
            {
                string json = JSON_DOCNO;
                DataTable dt_doc = JsonConvert.DeserializeObject<DataTable>(JSON_DOCNO);
                string vbeln, matnr, posnr, emp_id, unit, site, sloc;


                DataSet ds = new DataSet();
                DataTable dt_return = new DataTable();
                dt_return.Columns.Add("VBELN", typeof(string));
                dt_return.Columns.Add("O_MSG", typeof(string));
                dt_return.Columns.Add("STATUS", typeof(string));
                if (dt_doc != null)
                {
                    foreach (DataRow drow in dt_doc.Rows)
                    {
                        DBTRANSDataContext db_c = new DBTRANSDataContext();
                        List<TBTrans_PostGRItem> data = (from it_gr in db_c.TBTrans_PostGRItems where it_gr.VBELN.Contains(drow["VBELN"].ToString()) && it_gr.EMP_ID.Equals(EMP_ID) && it_gr.POSNR.Equals(drow["POSNR"].ToString()) select it_gr).ToList();
                        for (int a = 0; a < data.Count; a++)
                        {
                            #region Connect K2 
                            SmartObjectClientServer serverName = K2_CONNECT_SERVER();

                            SmartObject smartObject = serverName.GetSmartObject("ZHANDHELD_GR_COUNT");
                            smartObject.MethodToExecute = "ZHANDHELD_GRCOUNT_ZHANDHELD_GR_COUNT";
                            #endregion Connect K2
                            vbeln = data[a].VBELN.ToString() ?? "";
                            matnr = data[a].MATNR.ToString() ?? "";
                            posnr = data[a].POSNR.ToString() ?? "";
                            unit = data[a].UNIT_SELECT.ToString() ?? "";
                            emp_id = data[a].EMP_ID.ToString() ?? "";
                            site = SITE;
                            sloc = SLOC;
                            string IN_COUNT = getItemCount(vbeln, posnr, unit, emp_id, EMP_CONFIRM_DAM, site, sloc,P_RPOINT);
                            string IN_COUNT_SER = getItemSerial(vbeln, posnr, unit, emp_id, EMP_CONFIRM_DAM, site, sloc);

                            if (!string.IsNullOrEmpty(data[a].XCHPF) && string.IsNullOrEmpty(data[a].BATCH_CHECK))
                            {
                                DataRow dr = dt_return.NewRow();
                                dr["VBELN"] = vbeln;
                                dr["O_MSG"] = "Please input BATCH NO.";
                                dr["STATUS"] = "0";
                                dt_return.Rows.Add(dr);
                                dt_return.TableName = "RETURN_MSG";
                                ds.Tables.Add(dt_return);
                                return ConvertDataSetToJSON(ds); ;
                            }

                            if (!string.IsNullOrEmpty(data[a].SERIAL) && IN_COUNT_SER.Equals("false"))
                            { 
                                DataRow dr = dt_return.NewRow();
                                dr["VBELN"] = vbeln;
                                dr["O_MSG"] = "Plaase input Serial No.";
                                dr["STATUS"] = "0";
                                dt_return.Rows.Add(dr);
                                dt_return.TableName = "RETURN_MSG";
                                ds.Tables.Add(dt_return);
                                return ConvertDataSetToJSON(ds); ;
                            }
                            smartObject.Methods["ZHANDHELD_GRCOUNT_ZHANDHELD_GR_COUNT"].InputProperties["p_P_RPOINT"].Value = P_RPOINT;
                            smartObject.Methods["ZHANDHELD_GRCOUNT_ZHANDHELD_GR_COUNT"].InputProperties["IN_COUNT"].Value = IN_COUNT;
                            smartObject.Methods["ZHANDHELD_GRCOUNT_ZHANDHELD_GR_COUNT"].InputProperties["IN_COUNT_SER"].Value = IN_COUNT_SER;
                            try
                            {
                                SmartObject smart_return = serverName.ExecuteScalar(smartObject);
                                if (smart_return != null)
                                {
                                    if (!string.IsNullOrEmpty(smart_return.Properties["O_MSG"].Value))
                                    { 
                                        DataRow dr = dt_return.NewRow();
                                        dr["VBELN"] = vbeln;
                                        dr["O_MSG"] = smart_return.Properties["O_MSG"].Value.ToString();
                                        dr["STATUS"] = "0";
                                        dt_return.Rows.Add(dr);
                                    }
                                    else
                                    {
                                        XElement xmlTreeSerial = XElement.Parse(smart_return.Properties["GOODSMVT_HEADRET"].Value.ToString());
                                        data[a].HH_DOCNO  = hh_docno;
                                        data[a].EMP_CONFIRM_DAM  = EMP_CONFIRM_DAM;
                                        data[a].SAP_DOCNO  = xmlTreeSerial.Value.ToString();
                                         
                                        db_c.SubmitChanges();
                                        DataRow dr = dt_return.NewRow();
                                        dr["VBELN"] = vbeln;
                                        dr["O_MSG"] = xmlTreeSerial.Value.ToString();  
                                        dr["STATUS"] = "1";
                                        dt_return.Rows.Add(dr);
                                    }
                                }
                                else
                                {
                                    O_MSG = "";
                                }
                            }
                            catch (Exception ex)
                            {
                                DataRow dr = dt_return.NewRow();
                                dr["VBELN"] = vbeln;
                                dr["O_MSG"] = ex.Message;
                                dr["STATUS"] = "0";
                                dt_return.Rows.Add(dr);
                            }
                            
                        }
                        dt_return.TableName = "RETURN_MSG";
                        ds.Tables.Add(dt_return);
                    }
                }
                return ConvertDataSetToJSON(ds);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string getItemSerial(string vbeln, string posnr, string unit, string emp_id, string emp_conf, string site, string sloc)
        {
            string new_serial = "";
            DBTRANSDataContext db = new DBTRANSDataContext();
            ZHANDHELD_GR_COUNT_IN_COUNT_SER item_ser = new ZHANDHELD_GR_COUNT_IN_COUNT_SER();
            List<ZHANDHELD_GR_COUNT_IN_COUNT_SER> list_item_ser = new List<ZHANDHELD_GR_COUNT_IN_COUNT_SER>();
            List<TBTrans_PostGISerial> list_res_serial = (from tb_serial in db.TBTrans_PostGISerials where tb_serial.DELIV_NUMB.ToString().Contains(vbeln) && tb_serial.ITM_NUMBER.Equals(posnr) select tb_serial).ToList();
            TBTrans_PostGRItem list_in_count = (from tb_in in db.TBTrans_PostGRItems where tb_in.VBELN.ToString().Contains(vbeln) && tb_in.POSNR.Equals(posnr) select tb_in).SingleOrDefault();
            if (!list_res_serial.Count.Equals(list_in_count.QTY) && !string.IsNullOrEmpty(list_in_count.SERIAL))
            {
                return "false";
            }
            if (list_res_serial != null)
            {
                string docno = RunningNewDocNo();
                for (int a = 0; a < list_res_serial.Count; a++)
                {
                    item_ser = new ZHANDHELD_GR_COUNT_IN_COUNT_SER();
                    item_ser.VBELN = vbeln;
                    item_ser.POSNR = Convert.ToInt32(posnr);
                    item_ser.UNIT = unit;
                    item_ser.SERIALNO = list_res_serial[a].SERIALNO;
                    item_ser.PLANT_HH = site;
                    item_ser.STGE_LOC_HH = sloc;
                    item_ser.GGOODS = 1;
                    item_ser.SGOODS = 0;
                    if (!string.IsNullOrEmpty(emp_id))
                        item_ser.PERNR = Convert.ToDouble(emp_id);
                    if (!string.IsNullOrEmpty(emp_id))
                        item_ser.CHECKED_USER = emp_id;
                    if (!string.IsNullOrEmpty(emp_conf))
                        item_ser.APPROVE_USER = emp_conf;
                    item_ser.HH_DOCNO = docno;

                    ZHANDHELD_GR_COUNT_IN_COUNT_SER_properties serialize_serial = item_ser.Serialize();
                    XElement xmlTreeSerial = XElement.Parse(serialize_serial.Serialized_Item__IN_COUNT_SER_);
                    new_serial += xmlTreeSerial.FirstNode.ToString();

                }
                return "<connect>" + new_serial + "</connect>";
            }
            else
            {
                return "false";
            }
        }

        private string RunningNewDocNo()
        {
            string sResult = "";
            dev.lib.SQLConnection devdb = new dev.lib.SQLConnection(ConnStr());
            dev.lib.UtilityDataBase dbutil = new dev.lib.UtilityDataBase();
            SqlConnection Conn1 = devdb.getSqlConncetion;
            dbutil.ConnectionString = ConnStr();
            dbutil.RunningFieldName = "HH_DOCNO";
            string sformat = "yyyyMMdd-####";
            string sShortName = "MMGR";
            dbutil.RunningGroup = sShortName;
            dbutil.RunningFormat = sformat;
            dbutil.RunningTableName = "dbtrans.dbo.TBTrans_Gen_HHDOC";
            sResult = dbutil.RunningNewDocNo(devdb);
            string sql_update = "INSERT INTO dbtrans.dbo.TBTrans_Gen_HHDOC (HH_DOCNO) VALUES ('" + sResult + "')";
            devdb.ExecuteNoneQuery(sql_update, ref Conn1);
            return sResult;
        }
        private string getItemCount(string vbeln, string posnr, string unit, string emp_id, string emp_conf, string site, string sloc,string P_RPOINT)
        {
            string new_item_count = "";
            DBTRANSDataContext db = new DBTRANSDataContext();
            ZHANDHELD_GR_COUNT_IN_COUNT item_count = new ZHANDHELD_GR_COUNT_IN_COUNT();
            List<ZHANDHELD_GR_COUNT_IN_COUNT> list_item_ser = new List<ZHANDHELD_GR_COUNT_IN_COUNT>();
            List<TBTrans_PostGRItem> list_item_gr = (from tb_item in db.TBTrans_PostGRItems where tb_item.VBELN.ToString().Contains(vbeln) && tb_item.POSNR.Equals(posnr) && tb_item.EMP_ID.Equals(emp_id) select tb_item).ToList();
            if (list_item_gr != null)
            {
                hh_docno = RunningNewDocNo();
                for (int a = 0; a < list_item_gr.Count; a++)
                {
                    if (P_RPOINT.Equals("01"))
                        sloc = list_item_gr[a].LGORT ?? sloc;
                    item_count = new ZHANDHELD_GR_COUNT_IN_COUNT();
                    item_count.VBELN = vbeln ?? "";
                    item_count.POSNR = Convert.ToInt32(posnr);
                    item_count.UNIT = unit ?? "";
                    item_count.PLANT_HH = site ?? "";
                    item_count.STGE_LOC_HH = sloc ?? "";//
                    item_count.GGOODS = list_item_gr[a].QTY ?? 0;//จำนวนของดี
                    item_count.SGOODS = list_item_gr[a].QTY_D ?? 0;//จำนวนของชุำรุด
                    item_count.PGOODS = list_item_gr[a].WEIGHTS ?? 0;//น้ำหนัก
                    if (!string.IsNullOrEmpty(emp_id))
                        item_count.PERNR = Convert.ToDouble(emp_id);
                    if (!string.IsNullOrEmpty(emp_id))
                        item_count.CHECKED_USER = emp_id;
                    if (!string.IsNullOrEmpty(emp_conf))
                        item_count.APPROVE_PERNR = Convert.ToDouble(emp_conf);
                    item_count.HH_DOCNO = hh_docno;
                    if (list_item_gr[a].BATCH_EXP_DATE != null)
                        item_count.LIQDT = Convert.ToDateTime(Convert.ToDateTime(list_item_gr[a].BATCH_EXP_DATE.Value.ToString("yyyy/MM/dd")));//วันหมดอายุ
                    if (list_item_gr[a].BATCH_MANUFAC_DATE != null)
                        item_count.HSDAT = Convert.ToDateTime(Convert.ToDateTime(list_item_gr[a].BATCH_MANUFAC_DATE.Value.ToString("yyyy/MM/dd")));//วันผลิต
                    item_count.BATCH = list_item_gr[a].BATCH_CHECK ?? null;//เลขแบช

                    ZHANDHELD_GR_COUNT_IN_COUNT_properties serialize_item_count = item_count.Serialize();
                    XElement xmlItemCount = XElement.Parse(serialize_item_count.Serialized_Item__IN_COUNT_);
                    new_item_count += xmlItemCount.FirstNode.ToString();

                }
                return "<connect>" + new_item_count + "</connect>";
            }
            else
            {
                return "<connect>" + new_item_count + "</connect>";
            }
        }
        [WebMethod]
        public string LOAD_DOC_FOR_COUNT(string JSON_DOCNO, string EMP_ID)
        {
            dev.lib.Utilities util = new dev.lib.Utilities();
            DataTable dt_doc = JsonConvert.DeserializeObject<DataTable>(JSON_DOCNO);
            string DOCNO = "";
            for (int a = 0; a < dt_doc.Rows.Count; a++)
            {
                DOCNO += "'" + util.AddZero(dt_doc.Rows[a]["VBELN"].ToString(), 10) + "'";
                if (a < dt_doc.Rows.Count - 1)
                {
                    DOCNO += ",";
                }
            }
            string query = "";
            query = "select VBELN,WBSTK,WERKS,LGORT,sum(LFIMG) as SUMLFIMG,sum(RFMNG) as SUMRFMNG,sum(QTY ) as SUMSQTY from TBTrans_PostGRItem  where DOC_SEARCH in(" + DOCNO + ") and   EMP_ID = '" + EMP_ID + "' and SAP_DOCNO is  null   GROUP BY VBELN,WBSTK,WERKS,LGORT";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConnStr());
            SqlDataAdapter da = new SqlDataAdapter(query, ConnStr());
            da.Fill(dt);
            dt.TableName = "LIST_DO";
            dt.Columns.Add("READY", typeof(bool));
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                DBTRANSDataContext db = new DBTRANSDataContext();
                List<TBTrans_PostGRItem> dt_check_ready = (from itm in db.TBTrans_PostGRItems where itm.QTY.Equals(null) && itm.VBELN.Equals(dt.Rows[a]["VBELN"].ToString()) && itm.EMP_ID.Equals(EMP_ID) select itm).ToList();
                if (dt_check_ready.Count > 0)
                {
                    dt.Rows[a]["READY"] = false;
                }
                else
                {
                    dt.Rows[a]["READY"] = true;
                }

            }
            ds.Tables.Add(dt);
            return ConvertDataSetToJSON(ds);
        }
        [WebMethod]
        public string UPDATE_QTY_GR(string VBELN, string EMP_ID, string QTY, string QTY_D, string MATNR, string POSNR, string UNIT, string BATCH_CHECK, string BATCH_EXP_DATE, string BATCH_MANUFAC_DATE)
        {
            try
            {
                string row_no_header = "0";
                DBTRANSDataContext db_con = new DBTRANSDataContext();
                //สำหรับตัวที่มีแบท
                TBTrans_PostGRItem item = (from it in db_con.TBTrans_PostGRItems
                                           where it.EMP_ID == EMP_ID && it.MATNR == MATNR && it.VBELN.Contains(VBELN) && it.POSNR == POSNR
                                           select it).SingleOrDefault();

                row_no_header = item.UECHA;
                item.QTY = Convert.ToInt32(QTY);
                item.QTY_D = Convert.ToInt32(QTY_D);
                if (!string.IsNullOrEmpty(BATCH_CHECK))
                    item.BATCH_CHECK = BATCH_CHECK;
                if (!string.IsNullOrEmpty(BATCH_EXP_DATE))
                    item.BATCH_EXP_DATE = Convert.ToDateTime(BATCH_EXP_DATE);
                if (!string.IsNullOrEmpty(BATCH_MANUFAC_DATE))
                    item.BATCH_MANUFAC_DATE = Convert.ToDateTime(BATCH_MANUFAC_DATE);
                item.UNIT_SELECT = UNIT;
                db_con.SubmitChanges();

                if (row_no_header != "0")
                {
                    TBTrans_PostGRItem item_header = (from it in db_con.TBTrans_PostGRItems
                                                      where it.EMP_ID == EMP_ID && it.MATNR == MATNR && it.VBELN == VBELN && it.POSNR == row_no_header
                                                      select it).SingleOrDefault();
                    item_header.QTY = 0;
                    item_header.UNIT_SELECT = UNIT;
                    item.QTY_D = Convert.ToInt32(QTY_D);
                    if (!string.IsNullOrEmpty(BATCH_CHECK))
                        item.BATCH_CHECK = BATCH_CHECK;
                    if (!string.IsNullOrEmpty(BATCH_EXP_DATE))
                        item.BATCH_EXP_DATE = Convert.ToDateTime(BATCH_EXP_DATE);
                    if (!string.IsNullOrEmpty(BATCH_MANUFAC_DATE))
                        item.BATCH_MANUFAC_DATE = Convert.ToDateTime(BATCH_MANUFAC_DATE);
                    db_con.SubmitChanges();
                }
                return "true";
            }
            catch (Exception ex)
            {
                return "false," + ex.Message;
            }
        }

        private SmartObjectClientServer K2_CONNECT_SERVER()
        {
            #region Connect K2 
            DataSet ds = new DataSet();
            SmartObjectClientServer serverName = new SmartObjectClientServer();
            SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder connectionString = new SourceCode.Hosting.Client.BaseAPI.SCConnectionStringBuilder();
            connectionString.Authenticate = true;
            connectionString.Host = System.Configuration.ConfigurationManager.AppSettings["K2Server"];
            connectionString.Integrated = true;
            connectionString.IsPrimaryLogin = true;
            connectionString.Port = Convert.ToUInt32(System.Configuration.ConfigurationManager.AppSettings["Port"].ToString());
            connectionString.UserID = System.Configuration.ConfigurationManager.AppSettings["K2User"];
            connectionString.WindowsDomain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            connectionString.Password = System.Configuration.ConfigurationManager.AppSettings["K2Password"];
            connectionString.SecurityLabelName = System.Configuration.ConfigurationManager.AppSettings["SecurityLabel"];
            serverName.CreateConnection();
            serverName.Connection.Open(connectionString.ToString());
            #endregion Connect K2
            return serverName;
        }

        public string ConvertDataSetToJSON(DataSet ds)
        {
            string JSONString = string.Empty;
            if (ds != null)
            {
                return JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            else
            {
                return JSONString;
            }
        }
    }
}
