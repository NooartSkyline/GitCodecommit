using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using BLToolkit.Data;
using System.Runtime.Serialization;

namespace DoHome.MobileService
{
    [DataContract]
    [Serializable]
    public class Location
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string WarehouseCode { get; set; }

        [DataMember]
        public string LocationType { get; set; }
    }

    public partial interface IMobileService
    {
        [OperationContract]
        Location LocationGetByCode(string locationCode, string warehouseCode);

        [OperationContract]
        List<Location> LocationGetByWarehouse(string warehouseCode);
        //[OperationContract]
        //List<Location> LocationGetAll(string warehouseCode);
    }

    public partial class MobileService : IMobileService
    {

        public Location LocationGetByCode(string locationCode, string warehouseCode)
        {

            Location location = null;
            using (var db = new DbManager("HandHeldDB"))
            {
                var reader = db.SetCommand(GetSql(43),
               db.Parameter("@LocationCode", locationCode),
               db.Parameter("@WarehouseCode", warehouseCode))
               .ExecuteReader();
                while (reader.Read())
                {
                    location = new Location { Code = (string)reader["LocationCode"], WarehouseCode = (string)reader["WarehouseCode"] };
                }

            }

            return location;

            //List<SAPProxyII.ZLOCSTRC> locations;
            //string key = string.Format(LOCATION_ALL_KEY, DateTime.Now.Date.Day);
            //string keyOld = string.Format(LOCATION_ALL_KEY, DateTime.Now.AddDays(-1).Day);
            //object obj1 = _cacheManager.Get(keyOld);
            //object obj2 = _cacheManager.Get(key);

            //if (obj1 != null)
            //    _cacheManager.Remove(keyOld);

            //if (obj2 != null)
            //    locations = (List<SAPProxyII.ZLOCSTRC>)obj2;
            //else
            //{
            //    using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
            //    {
            //        using (var prx = new SAPProxyII.UWProxy())
            //        {
            //            prx.Connection = sapConnection;

            //            SAPProxyII.ZLOCSTRCTable Tables = new SAPProxyII.ZLOCSTRCTable();
            //            prx.Zdd_Handheld_Get_Zlockstrc(ref Tables);

            //            locations = (List<SAPProxyII.ZLOCSTRC>)CollectionHelper.ConvertTo<SAPProxyII.ZLOCSTRC>(Tables.ToADODataTable());
            //            _cacheManager.Add(key, locations);
            //        }
            //    }
            //}

            //var location = locations.Find(p => p.Binloc == locationCode);
            //if (location != null)
            //{
            //    var locat = new Location();
            //    locat.Code = location.Binloc;
            //    locat.LocationType = location.Loctype;
            //    return locat;
            //}
            //else
            //    return null;

        }

        public List<Location> LocationGetByWarehouse( string warehouseCode)
        {

            List<Location> locations = new List<Location>();
            using (var db = new DbManager("HandHeldDB"))
            {
                var reader = db.SetCommand(GetSql(45),
               db.Parameter("@WarehouseCode", warehouseCode))
               .ExecuteReader();
                while (reader.Read())
                {
                    locations.Add(new Location { Code = (string)reader["LocationCode"], WarehouseCode = (string)reader["WarehouseCode"] });
                }
            }

            return locations;
        }
        //public List<Location> LocationGetAll(string warehouseCode)
        //{
        //    if (string.IsNullOrEmpty(warehouseCode))
        //        throw new Exception("Warehouse Code is null value.");

        //    List<Location> locations = new List<Location>();
        //    //SAPProxyII.ZLOCSTRCTable Tables = new SAPProxyII.ZLOCSTRCTable();
        //    //using (var sapConnection = new SAP.Connector.SAPConnection(GlobalContext.SapDestination))
        //    //{
        //    //    using (var prx = new SAPProxyII.UWProxy())
        //    //    {
        //    //        prx.Connection = sapConnection;
        //    //        prx.Zdd_Handheld_Get_Zlockstrc(ref Tables);
        //    //    }
        //    //}

        //    //if (Tables.Count > 0)
        //    //    locations = new List<Location>();

        //    //foreach (SAPProxyII.ZLOCSTRC item in Tables)
        //    //{
        //    //    if (item.Lgort == warehouseCode)
        //    //        if (!locations.Exists(p => p.Code == item.Binloc))
        //    //            locations.Add(new Location { Code = item.Binloc, WarehouseCode = item.Lgort });

        //    //}

        //    //var sql = GetSql(41);
        //    //using (var db = new DbManager("UBSRV08"))
        //    //{
        //    //    foreach (SAPProxyII.ZLOCSTRC item in Tables)
        //    //    {
        //    //        db.SetCommand(sql,
        //    //       db.Parameter("@LocationCode", item.Binloc),
        //    //       db.Parameter("@WarehouseCode", item.Lgort))
        //    //       .ExecuteNonQuery();
        //    //    }


        //    //}


        //    using (var db = new DbManager("UBSRV08"))
        //    {
        //        var reader = db.SetCommand(GetSql(42),
        //       db.Parameter("@WarehouseCode", warehouseCode))
        //       .ExecuteReader();
        //        while (reader.Read())
        //        {
        //            locations.Add(new Location { Code = (string)reader["LocationCode"], WarehouseCode = warehouseCode });
        //        }
        //    }

        //    return locations;
        //}
    }

}


