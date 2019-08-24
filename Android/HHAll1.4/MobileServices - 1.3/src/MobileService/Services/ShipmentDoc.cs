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
    public class ShipmentItems
    {
        [DataMember]
        public string TKNUM { get; set; }
        [DataMember]
        public string VBELN { get; set; }
        [DataMember]
        public string POSNR { get; set; }
        [DataMember]
        public string MATNR { get; set; }
        [DataMember]
        public string MAKTX { get; set; }
        [DataMember]
        public string MEINS { get; set; }
        [DataMember]
        public string MEINS_TXT { get; set; }
        [DataMember]
        public string VRKME { get; set; }
        [DataMember]
        public string VRKME_TXT { get; set; }
        [DataMember]
        public string WERKS { get; set; }
        [DataMember]
        public string WERKS_TXT { get; set; }
        [DataMember]
        public string LGORT { get; set; }
        [DataMember]
        public string LGORT_TXT { get; set; }
        [DataMember]
        public decimal LFIMG { get; set; }
        [DataMember]
        public decimal NTGEW { get; set; }
        [DataMember]
        public decimal BRGEW { get; set; }
        [DataMember]
        public string GEWEI { get; set; }
        [DataMember]
        public string WBSTA { get; set; }
        [DataMember]
        public string ISPARA { get; set; }
        [DataMember]
        public string PARAUNIT { get; set; }
        [DataMember]
        public string PARAUNIT_TXT { get; set; }
        [DataMember]
        public decimal ZMINPL { get; set; }
        [DataMember]
        public decimal ZMAXPL { get; set; }

    }
    [DataContract]
    public class ShipmentHeader
    {
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<ShipmentItems> Items { get; set; }
    }
    public partial interface IMobileService
    {
        [OperationContract]
        ShipmentHeader GetItemShipment(string TKNUM);
        //[OperationContract]
        //string GRT();
    }
    public partial class MobileService : IMobileService
    {
        public ShipmentHeader GetItemShipment(string TKNUM)
        {
            var Return = new ShipmentHeader();
            try
            {
                using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
                {
                    using (var prx = new SAPGetShipmentForPC.SAPGetShipmentForPC())
                    {
                        prx.Connection = sapConnection;
                        SAPGetShipmentForPC.ZRA_VTTP_LGORT_DTable I_Lgort = new SAPGetShipmentForPC.ZRA_VTTP_LGORT_DTable();
                        SAPGetShipmentForPC.ZRA_VTTP_VBELNTable I_Vbeln = new SAPGetShipmentForPC.ZRA_VTTP_VBELNTable();
                        SAPGetShipmentForPC.ZRA_VTTP_VSTELTable I_Vstel = new SAPGetShipmentForPC.ZRA_VTTP_VSTELTable();
                        SAPGetShipmentForPC.LIKPTable It_Likp = new SAPGetShipmentForPC.LIKPTable();
                        SAPGetShipmentForPC.ZLIKP_ADDTable It_LikpAdd = new SAPGetShipmentForPC.ZLIKP_ADDTable();
                        SAPGetShipmentForPC.LIPSTable It_Lips = new SAPGetShipmentForPC.LIPSTable();
                        SAPGetShipmentForPC.ZLIPS_ADDTable It_LipsAdd = new SAPGetShipmentForPC.ZLIPS_ADDTable();
                        SAPGetShipmentForPC.VTTKTable It_Vttk = new SAPGetShipmentForPC.VTTKTable();
                        SAPGetShipmentForPC.ZVTTK_ADDTable It_VttkAdd = new SAPGetShipmentForPC.ZVTTK_ADDTable();
                        SAPGetShipmentForPC.VTTPTable It_Vttp = new SAPGetShipmentForPC.VTTPTable();
                        SAPGetShipmentForPC.ZLIPS_UNITTable It_Lips_Unit = new SAPGetShipmentForPC.ZLIPS_UNITTable();
                        SAPGetShipmentForPC.ZLIPS_UNITTable It_Lips_UnitU = new SAPGetShipmentForPC.ZLIPS_UNITTable();
                        var Msg = "";
                        var Status = "";
                        prx.Zm_Getshipment_Pcs(TKNUM, out Msg
                        , ref I_Lgort
                        , ref I_Vbeln
                        , ref I_Vstel
                        , ref It_Likp
                        , ref It_LikpAdd
                        , ref It_Lips
                        , ref It_LipsAdd
                        , ref It_Vttk
                        , ref It_VttkAdd
                        , ref It_Vttp
                        , ref It_Lips_Unit
                        , ref It_Lips_UnitU);
                        if (Msg.Trim().ToLower() == "ok")
                        {
                            Return.Status = true;
                            Return.Items = new List<ShipmentItems>();
                            foreach (SAPGetShipmentForPC.ZLIPS_ADD item in It_LipsAdd)
                            {
                                Return.Items.Add(new ShipmentItems
                                {
                                    BRGEW = item.Brgew,
                                    GEWEI = item.Gewei,
                                    ISPARA = item.Ispara,
                                    LFIMG = item.Lfimg,
                                    LGORT = item.Lgort,
                                    LGORT_TXT = item.Lgort_Txt,
                                    MAKTX = item.Maktx,
                                    MATNR = item.Matnr.TrimStart('0'),
                                    MEINS = item.Meins,
                                    MEINS_TXT = item.Meins_Txt,
                                    NTGEW = item.Ntgew,
                                    PARAUNIT = item.Paraunit,
                                    PARAUNIT_TXT = item.Paraunit_Txt,
                                    POSNR = item.Posnr.TrimStart('0'),
                                    TKNUM = TKNUM,
                                    VBELN = item.Vbeln.TrimStart('0'),
                                    VRKME = item.Vrkme,
                                    VRKME_TXT = item.Vrkme_Txt,
                                    WBSTA = item.Wbsta,
                                    WERKS = item.Werks,
                                    WERKS_TXT = item.Werks_Txt,
                                    ZMAXPL = item.Zmaxpl,
                                    ZMINPL = item.Zminpl
                                });
                            }
                        }
                        else
                        {
                            Return.Status = false;
                            Return.Message = Msg;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Return.Status = false;
                Return.Message = ex.Message;
            }
            return Return;
        }
        
    }
    
}