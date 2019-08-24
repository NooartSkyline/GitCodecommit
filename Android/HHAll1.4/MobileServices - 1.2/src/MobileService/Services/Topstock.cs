using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using System.ServiceModel;
using BLToolkit.Data;


namespace DoHome.MobileService
{
    [DataContract]
    public class TopstockFormItem
    {
        [DataMember]
        public string FormCode { get; set; }
         [DataMember]
        public string FromName { get; set; }
    }
    [DataContract]
    public class TopStockItem 
    {
       [DataMember]
       public string MATNR { get; set; }
       [DataMember]
       public string MATNR_TXT { get; set; }
       [DataMember]
       public string WERKS { get; set; }
       [DataMember]
       public string LGORT { get; set; }
       [DataMember]
       public string MEINH { get; set; }
       [DataMember]
       public decimal UMREZ { get; set; }
       [DataMember]
       public string BARCODE { get; set; }
       [DataMember]
       public string LGORT_TXT { get; set; }
       [DataMember]
       public string MEINH_TXT { get; set; }
       [DataMember]
       public string LOCATION_T { get; set; }
       [DataMember]
       public string LOCATION_S { get; set; }
       [DataMember]
       public string LOCZONE { get; set; }
       [DataMember]
       public string LOCHSHELF { get; set; }
       [DataMember]
       public string LOCSIDE { get; set; }
       [DataMember]
       public string LOCSIDE_TXT { get; set; }
       [DataMember]
       public string LOCHOLE { get; set; }
       [DataMember]
       public string LOCCLASS { get; set; }
       [DataMember]
       public string LOGGR { get; set; }
       [DataMember]
       public string LOGGR_TXT { get; set; }
       [DataMember]
       public string QTY { get; set; }
       [DataMember]
       public string BAR { get; set; }
       [DataMember]
       public string STATUS { get; set; }
       [DataMember]
       public string MSG  { get; set; }
       [DataMember]
       public string FNAME { get; set; }

    }
    [DataContract]
    public class TopStockHeader
    {
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string EmpId { get; set; }
        [DataMember]
        public string WarhouseId { get; set; }
        [DataMember]
        public string ZDocNo { get; set; }
        [DataMember]
        public List<TopStockItem> Items { get; set; }
    }
    //[DataContract]
    //public class ShipmentItems
    //{
    //    [DataMember]
    //    public string TKNUM { get; set; }
    //    [DataMember]
    //    public string VBELN { get; set; }
    //    [DataMember]
    //    public string POSNR { get; set; }
    //    [DataMember]
    //    public string MATNR { get; set; }
    //    [DataMember]
    //    public string MAKTX { get; set; }
    //    [DataMember]
    //    public string MEINS { get; set; }
    //    [DataMember]
    //    public string MEINS_TXT { get; set; }
    //    [DataMember]
    //    public string VRKME { get; set; }
    //    [DataMember]
    //    public string VRKME_TXT { get; set; }
    //    [DataMember]
    //    public string WERKS { get; set; }
    //    [DataMember]
    //    public string WERKS_TXT { get; set; }
    //    [DataMember]
    //    public string LGORT { get; set; }
    //    [DataMember]
    //    public string LGORT_TXT { get; set; }
    //    [DataMember]
    //    public decimal LFIMG { get; set; }
    //    [DataMember]
    //    public decimal NTGEW { get; set; }
    //    [DataMember]
    //    public decimal BRGEW { get; set; }
    //    [DataMember]
    //    public string GEWEI { get; set; }
    //    [DataMember]
    //    public string WBSTA { get; set; }
    //    [DataMember]
    //    public string ISPARA { get; set; }
    //    [DataMember]
    //    public string PARAUNIT { get; set; }
    //    [DataMember]
    //    public string PARAUNIT_TXT { get; set; }
    //    [DataMember]
    //    public decimal ZMINPL { get; set; }
    //    [DataMember]
    //    public decimal ZMAXPL { get; set; }

    //}
    //[DataContract]
    //public class ShipmentHeader
    //{
    //    [DataMember]
    //    public bool Status { get; set; }
    //    [DataMember]
    //    public string Message { get; set; }
    //    [DataMember]
    //    public List<ShipmentItems> Items { get; set; }
    //}
    public partial interface IMobileService
    {
        [OperationContract]
        List<TopstockFormItem> GetTopstockForms();
        [OperationContract]
        TopStockHeader GetTopstockItems(string _ItemId, string _Barcode, string _Position, string _Branch, string _Warhouse, string _Status);
        [OperationContract]
        TopStockHeader CreateTopstockDoc(TopStockHeader TopIn);
        //[OperationContract]
        //ShipmentHeader GetItemShipment(string TKNUM);
    }
    public partial class MobileService : IMobileService
    {
        public List<TopstockFormItem> GetTopstockForms() 
        {
            var VReturn = new List<TopstockFormItem>();
            try
            {
                using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (var prx = new SAPProxyReqTopstock.SAPProxyReqTopstock())
                    {
                        prx.Connection = sapConnection;
                        var itIn = new SAPProxyReqTopstock.ZFORM_TSTTable();
                        prx.Z_Gtopstock_Forms(ref itIn);
                        foreach (SAPProxyReqTopstock.ZFORM_TST item in itIn)
                        {
                            VReturn.Add(new TopstockFormItem { FormCode = item.Vtext , FromName = item.Ttext });
                        }
                    }
                }
            }
            catch (Exception ex )
            {
            
            }

            return VReturn;
        }
        public TopStockHeader GetTopstockItems(string _ItemId, string _Barcode, string _Position, string _Branch, string _Warhouse, string _Status)
        {
            var VReturn = new TopStockHeader();
            try
            {
                using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (var prx = new SAPProxyReqTopstock.SAPProxyReqTopstock())
                    {
                        prx.Connection = sapConnection;
                        var itIn = new SAPProxyReqTopstock.ZREQTOPSTOCKTable();
                        var Msg = "";
                        var Status = "";
                        prx.Z_Gtopstock_Items(_Branch,_Barcode,_ItemId,_Position,_Status,_Warhouse,out Msg,out Status ,ref itIn);
                        if (Status.Trim().ToLower() == "y")
                        {
                            VReturn.Status = true;
                            VReturn.Items = new List<TopStockItem>();
                            foreach (SAPProxyReqTopstock.ZREQTOPSTOCK item in itIn)
                            {
                                VReturn.Items.Add(new TopStockItem
                                          {
                                              BAR = item.Bar,
                                              BARCODE = item.Barcode,
                                              FNAME = item.Fname,
                                              LGORT = item.Lgort,
                                              LGORT_TXT = item.Lgort_Txt,
                                              LOCATION_S = item.Location_S,
                                              LOCATION_T = item.Location_T,
                                              LOCCLASS = item.Locclass,
                                              LOCHOLE = item.Lochole,
                                              LOCHSHELF = item.Lochshelf,
                                              LOCSIDE = item.Locside,
                                              LOCSIDE_TXT = item.Locside_Txt,
                                              LOCZONE = item.Loczone,
                                              LOGGR = item.Loggr,
                                              LOGGR_TXT = item.Loggr_Txt,
                                              MATNR = item.Matnr,
                                              MATNR_TXT = item.Matnr_Txt,
                                              MEINH = item.Meinh,
                                              MEINH_TXT = item.Meinh_Txt,
                                              MSG = item.Msg,
                                              QTY = item.Qty,
                                              STATUS = item.Status,
                                              UMREZ = item.Umrez,
                                              WERKS = item.Werks

                                          });
                            }
                        }
                        else
                        {
                            VReturn.Status = false;
                            VReturn.Message = Msg;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                VReturn.Status = false;
                VReturn.Message = ex.Message;
            }
            return VReturn;
        }
        public TopStockHeader CreateTopstockDoc(TopStockHeader TopIn)
        {
            var VReturn = new TopStockHeader();
            try
            {
                using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (var prx = new SAPProxyReqTopstock.SAPProxyReqTopstock())
                    {
                        prx.Connection = sapConnection;
                        var itIn = new SAPProxyReqTopstock.ZREQTOPSTOCKTable();
                        var Msg = "";
                        var ZDocNo = "";
                        foreach (var item in TopIn.Items)
                        {
                            var ItemAdd = new SAPProxyReqTopstock.ZREQTOPSTOCK();
                            ItemAdd.Bar = item.BAR;
                            ItemAdd.Barcode = item.BARCODE;
                            ItemAdd.Fname = item.FNAME;
                            ItemAdd.Lgort = item.LGORT;
                            ItemAdd.Lgort_Txt = item.LGORT_TXT;
                            ItemAdd.Location_S = item.LOCATION_S;
                            ItemAdd.Location_T = item.LOCATION_T;
                            ItemAdd.Locclass = item.LOCCLASS;
                            ItemAdd.Lochole = item.LOCHOLE;
                            ItemAdd.Lochshelf = item.LOCHSHELF;
                            ItemAdd.Locside = item.LOCSIDE;
                            ItemAdd.Locside_Txt = item.LOCSIDE_TXT;
                            ItemAdd.Loczone = item.LOCZONE;
                            ItemAdd.Loggr = item.LOGGR;
                            ItemAdd.Loggr_Txt = item.LOGGR_TXT;
                            ItemAdd.Matnr = item.MATNR;
                            ItemAdd.Matnr_Txt = item.MATNR_TXT;
                            ItemAdd.Meinh = item.MEINH;
                            ItemAdd.Meinh_Txt = item.MEINH_TXT;
                            ItemAdd.Qty = item.QTY;
                            ItemAdd.Status = item.STATUS;
                            ItemAdd.Msg = item.MSG;
                            ItemAdd.Umrez = item.UMREZ;
                            ItemAdd.Werks = item.WERKS;
                            itIn.Add(ItemAdd);
                        }
                        prx.Z_Ctopstock_Hh(TopIn.EmpId,TopIn.WarhouseId,out ZDocNo, ref itIn);
                        if(ZDocNo.Trim()!="")
                        {
                            VReturn.Status = true;
                            VReturn.ZDocNo = ZDocNo;
                            VReturn.Message = Msg;
                        }
                        else
                        {
                            VReturn.Status = false;
                            VReturn.Message = Msg;
                            VReturn.Items = new List<TopStockItem>();
                            foreach (SAPProxyReqTopstock.ZREQTOPSTOCK item in itIn)
	                        {
		                       VReturn.Items.Add(new TopStockItem 
                                          {
                                              BAR = item.Bar ,
                                              BARCODE = item.Barcode,
                                              FNAME = item.Fname,
                                              LGORT = item.Lgort,
                                              LGORT_TXT = item.Lgort_Txt,
                                              LOCATION_S = item.Location_S,
                                              LOCATION_T = item.Location_T,
                                              LOCCLASS = item.Locclass,
                                                      LOCHOLE = item.Lochole,
                                                       LOCHSHELF = item.Lochshelf,
                                                        LOCSIDE = item.Locside,
                                                         LOCSIDE_TXT = item.Locside_Txt,
                                                          LOCZONE = item.Loczone,
                                                           LOGGR = item.Loggr,
                                                            LOGGR_TXT = item.Loggr_Txt,
                                                             MATNR = item.Matnr,
                                                              MATNR_TXT = item.Matnr_Txt,
                                                               MEINH = item.Meinh,
                                                                MEINH_TXT = item.Meinh_Txt,
                                                                 MSG = item.Msg,
                                                                  QTY = item.Qty,
                                                                   STATUS = item.Status,
                                                                    UMREZ = item.Umrez,
                                                                     WERKS = item.Werks

                                          });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                VReturn.Status = false;
                VReturn.Message = ex.Message;
            }
            return VReturn;
        }
        //public ShipmentHeader GetItemShipment(string TKNUM)
        //{
        //    var Return = new ShipmentHeader();
        //    try
        //    {
        //        using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
        //        {
        //            using (var prx = new SAPGetShipmentForPC.SAPGetShipmentForPC())
        //            {
        //                prx.Connection = sapConnection;
        //                SAPGetShipmentForPC.ZRA_VTTP_LGORT_DTable I_Lgort = new SAPGetShipmentForPC.ZRA_VTTP_LGORT_DTable();
        //                SAPGetShipmentForPC.ZRA_VTTP_VBELNTable I_Vbeln = new SAPGetShipmentForPC.ZRA_VTTP_VBELNTable();
        //                SAPGetShipmentForPC.ZRA_VTTP_VSTELTable I_Vstel = new SAPGetShipmentForPC.ZRA_VTTP_VSTELTable();
        //                SAPGetShipmentForPC.LIKPTable It_Likp = new SAPGetShipmentForPC.LIKPTable();
        //                SAPGetShipmentForPC.ZLIKP_ADDTable It_LikpAdd = new SAPGetShipmentForPC.ZLIKP_ADDTable();
        //                SAPGetShipmentForPC.LIPSTable It_Lips = new SAPGetShipmentForPC.LIPSTable();
        //                SAPGetShipmentForPC.ZLIPS_ADDTable It_LipsAdd = new SAPGetShipmentForPC.ZLIPS_ADDTable();
        //                SAPGetShipmentForPC.VTTKTable It_Vttk = new SAPGetShipmentForPC.VTTKTable();
        //                SAPGetShipmentForPC.ZVTTK_ADDTable It_VttkAdd = new SAPGetShipmentForPC.ZVTTK_ADDTable();
        //                SAPGetShipmentForPC.VTTPTable It_Vttp = new SAPGetShipmentForPC.VTTPTable();
        //                SAPGetShipmentForPC.ZLIPS_UNITTable It_Lips_Unit = new SAPGetShipmentForPC.ZLIPS_UNITTable();
        //                SAPGetShipmentForPC.ZLIPS_UNITTable It_Lips_UnitU = new SAPGetShipmentForPC.ZLIPS_UNITTable();
        //                var Msg = "";
        //                var Status = "";
        //                prx.Zm_Getshipment_Pcs(TKNUM, out Msg
        //                , ref I_Lgort
        //                , ref I_Vbeln
        //                , ref I_Vstel
        //                , ref It_Likp
        //                , ref It_LikpAdd
        //                , ref It_Lips
        //                , ref It_LipsAdd
        //                , ref It_Vttk
        //                , ref It_VttkAdd
        //                , ref It_Vttp
        //                , ref It_Lips_Unit
        //                , ref It_Lips_UnitU);
        //                if (Status.Trim().ToLower() == "OK")
        //                {
        //                    Return.Status = true;
        //                    Return.Items = new List<ShipmentItems>();
        //                    foreach (SAPGetShipmentForPC.ZLIPS_ADD item in It_LipsAdd)
        //                    {
        //                        Return.Items.Add(new ShipmentItems
        //                        {
        //                            BRGEW = item.Brgew,
        //                            GEWEI = item.Gewei,
        //                            ISPARA = item.Ispara,
        //                            LFIMG = item.Lfimg,
        //                            LGORT = item.Lgort,
        //                            LGORT_TXT = item.Lgort_Txt,
        //                            MAKTX = item.Maktx,
        //                            MATNR = item.Matnr,
        //                            MEINS = item.Meins,
        //                            MEINS_TXT = item.Meins_Txt,
        //                            NTGEW = item.Ntgew,
        //                            PARAUNIT = item.Paraunit,
        //                            PARAUNIT_TXT = item.Paraunit_Txt,
        //                            POSNR = item.Posnr,
        //                            TKNUM = TKNUM,
        //                            VBELN = item.Vbeln,
        //                            VRKME = item.Vrkme,
        //                            VRKME_TXT = item.Vrkme_Txt,
        //                            WBSTA = item.Wbsta,
        //                            WERKS = item.Werks,
        //                            WERKS_TXT = item.Werks_Txt,
        //                            ZMAXPL = item.Zmaxpl,
        //                            ZMINPL = item.Zminpl
        //                        });
        //                    }
        //                }
        //                else
        //                {
        //                    Return.Status = false;
        //                    Return.Message = Msg;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Return.Status = false;
        //        Return.Message = ex.Message;
        //    }
        //    return Return;
        //}
    }

   
    
}