using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
namespace TestWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
            //var cnn = new ServiceReference.MobileServiceClient();
            //var rt = cnn.ProductBarcodeGetByProductCodeOrBarcode5("1100", "99000707", "1111");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cnn = new ServiceReference.MobileServiceClient();
            var x = cnn.ProductBarcodeGetByProductCodeOrBarcode5("1700", "70003239", "1711");
            //var cn = new ServiceReference.MobileServiceClient();
            //var T = new ServiceReference.TopStockHeader();
            //T.EmpId = "0000004";
            //T.WarhouseId = "1111";
            //T.Items = new ServiceReference.TopStockItem[1];
            //T.Items[0] = new ServiceReference.TopStockItem { MATNR = "10000197",
            // WERKS = "1100",
            // LGORT = "1111",
            //  MEINH = "EA",
            //   FNAME = "ZTOPST1",
            //    UMREZ = 1, QTY = "50"
            //};
            //cn.CreateTopstockDoc(T);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
             
        }
    }
}
