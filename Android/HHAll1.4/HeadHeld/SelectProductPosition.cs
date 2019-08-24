using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DoHome.HandHeld.Client.SAPCnn;
using DoHome.HandHeld.Client.DataAccess;

namespace DoHome.HandHeld.Client
{

    public partial class SelectProductPosition : Form
    {
        ProductPosition[] _position;
        public DoHome.HandHeld.Client.SAPCnn.ProductBarcode[] _Product { get; set; }
        public DoHome.HandHeld.Client.SAPCnn.ProductBarcode[] _ProductRT { get; set; }
        public List<ProductPositionList> sBin = new List<ProductPositionList>();
        public List<string> sCBin = new List<string>();
        public bool IsUse { get; set; }
        internal SelectProductPosition(DoHome.HandHeld.Client.SAPCnn.ProductBarcode[] product)
        {
             InitializeComponent();            
            _Product = product;
        }
        private void SelectProductPosition_Load(object sender, EventArgs e)
        {
            List<ProductPositionList> li = new List<ProductPositionList>();
            var i = 1;
            sBin = (from o in _Product where o.PositionCode != null
                    select new ProductPositionList { Order = i++,  PositionCode = o.PositionCode, Chk = false }).Distinct().ToList();
            //var i = 1;
            //foreach (var item in _position)
            //{
            //    if (li != null)
            //    {
            //        if (li.Where(x => x.PositionCode == item.PositionCode).Count() > 0) 
            //        {
            //            continue;
            //        }
            //    }
            //    li.Add(new ProductPositionList {  Chk =  false, Order = i, PositionCode = item.PositionCode});
            //    i += 1;
            //}
            smartGrid.DataSource = sBin;
        }
        private void smartGrid_Click(object sender, EventArgs e)
        {
            try 
	        {	        
        		var PCode = smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["PositionCode"].ToString();
                for (int i = 0; i < smartGrid.Rows.Count; i++)
                {
                    smartGrid.Rows[i]["Chk"] = smartGrid.Rows[i]["PositionCode"] == PCode;
                    smartGrid.UpdateLayout();
                }
	        }
	        catch (Exception)
	        {
        		
        		 
	        }
            
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < smartGrid.Rows.Count; i++)
            {
                if ((bool)smartGrid.Rows[i]["Chk"])
                {
                    if (smartGrid.Rows[i]["PositionCode"] != null)
                        sCBin.Add(smartGrid.Rows[i]["PositionCode"].ToString());
                }
            }
            if (sCBin.Count == 0)
            {
                this.Close();
            }
            else
            {
                _ProductRT = (from o in _Product where sCBin.Contains(o.PositionCode) select o).ToArray();
                IsUse = true;
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _ProductRT = null;
            this.Close();
        }
    }
}