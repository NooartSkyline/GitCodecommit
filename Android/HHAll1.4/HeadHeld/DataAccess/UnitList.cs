using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DoHome.HandHeld.Client.DataAccess
{
    public class UnitList
    {
      public bool Chk { get; set; }
      public int DisplayOrder { get; set; }
      public string UnitCode { get; set; }
      public string UnitName { get; set; }
    }
    public class UnitListComparer : IEqualityComparer<UnitList>
    {
        public bool Equals(UnitList x, UnitList y)
        {
            if (x.UnitCode == y.UnitCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetHashCode(UnitList obj)
        {
            return obj.UnitCode.GetHashCode();
        }
    }
}
