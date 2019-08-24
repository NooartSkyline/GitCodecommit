using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DoHome.MobileService
{
    [DataContract]
    public class LocationDescription
    {

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Text { get; set; }

        //[DataMember]
        //public short Mark { get; set; }

        [DataMember]
        public string BlankNumber { get; set; }

        //public bool Checked
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(this.CheckedState))
        //        {
        //            if (this.CheckedState.IndexOf("X") > -1)
        //                return true;
        //            else
        //                return false;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        //[DataMember]
        //public string CheckedState { get; set; }

        [DataMember]
        public bool Checked { get; set; }
    }

    public partial interface IMobileService
    {

        [OperationContract]
        List<LocationDescription> GetAllLocationDescription();

    }

    public partial class MobileService : IMobileService
    {
        public static List<LocationDescription> _cache;

        public List<LocationDescription> GetAllLocationDescription()
        {
            if (_cache == null)
            {
                _cache = new List<LocationDescription>();
                _cache.Add(new LocationDescription { ID = 0, Text = "ไม่มีป้ายหัวเชลล์" });
                _cache.Add(new LocationDescription { ID = 1, Text = "ป้ายหัวเชลล์ไม่ชัดเจน" });
                _cache.Add(new LocationDescription { ID = 2, Text = "ติดป้ายราคา/ป้ายตำแหน่งผิดประเภท" });
                _cache.Add(new LocationDescription { ID = 3, Text = "ป้ายราคา/ป้ายตำแหน่ง เก่า,ซีด" });
                _cache.Add(new LocationDescription { ID = 4, Text = "ติดป้ายผิดมุม (ป้ายตำแหน่ง,ป้ายราคา,ป้าย topstock)" });
                _cache.Add(new LocationDescription { ID = 5, Text = "ไม่ติดป้าย topstock" });
                _cache.Add(new LocationDescription { ID = 6, Text = "ไม่ติดเบอร์ในตัวโชว์" });
                _cache.Add(new LocationDescription { ID = 7, Text = "ไม่ติดเบอร์กับกล่องสินค้า/ป้ายราคา ในหน้าขาย" });
                _cache.Add(new LocationDescription { ID = 8, Text = "ช่องตำแหน่งเก็บวาง (ไม่ติดป้ายหมดชั่วคราว)" });
                _cache.Add(new LocationDescription { ID = 9, Text = "จำนวนช่องว่าง(ที่ติดป้าย+ไม่ติดป้ายหมดชั่วคราว)" });
                _cache.Add(new LocationDescription { ID = 10, Text = "กล่อง/ถุง ปิดไม่สนิท/ฉีกขาด" });
                _cache.Add(new LocationDescription { ID = 11, Text = "ไม่วางสินค้าชิดหน้า(ค้าปลีก)/ชิดหลัง(คลัง)" });
                _cache.Add(new LocationDescription { ID = 12, Text = "วางสินค้าไม่เป็นระเบียบ" });
                _cache.Add(new LocationDescription { ID = 13, Text = "มีสินค้าอื่นปน" });
                _cache.Add(new LocationDescription { ID = 14, Text = "มีสินค้าล้นตำแหน่งเก็บ" });
                _cache.Add(new LocationDescription { ID = 15, Text = "มีสินค้าชำรุด" });
                _cache.Add(new LocationDescription { ID = 16, Text = "ไม่เก็บอุปกรณ์ใช้งานเข้าที่เก็บ" });
                _cache.Add(new LocationDescription { ID = 17, Text = "พื้นที่ไม่สะอาด" });
                _cache.Add(new LocationDescription { ID = 18, Text = "วางเสี่ยง (ชำรุด, ตก)" });
                _cache.Add(new LocationDescription { ID = 19, Text = "คะแนนพิเศษ" });

            }


            return _cache;
        }

    }


}// end namespace