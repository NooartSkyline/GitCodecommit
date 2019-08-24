using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DoHome .HandHeld .Client .DataAccess
{
   public class LabelPrintProductDetailLocal
    {
        
                           public string Productcode {get; set;}
                          public string Productname {get; set;}
                          public string Barcode   {get; set;}
                          public string Unitcode   {get; set;}
                          public string Unitname   {get; set;}
                          public string OthUnitcode {get; set;}
                          public string OthUnitname {get; set;}
                          public string PrintLabelTypeCode {get; set;}
                          public decimal Sellprice {get; set;}
                          public decimal OthUnitprice {get; set;}
                          public string Locationcode {get; set;}
                          public int DisplayOrder {get; set;}
                          public string ProductLoggr { get; set; }
                          public string ProductPosition { get; set; }
                          public bool DisplayOrderSpecified { get; set; }
    }
}
