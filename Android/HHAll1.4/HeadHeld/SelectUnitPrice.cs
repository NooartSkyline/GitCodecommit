using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DoHome.HandHeld.Client.DataAccess;

namespace DoHome.HandHeld.Client
{
    public partial class SelectUnitPrice : Form
    {
        public DoHome.HandHeld.Client.SAPCnn.ProductBarcode[] _Product { get; set; }
        public DoHome.HandHeld.Client.SAPCnn.ProductBarcode[] _ProductRT { get; set; }
        public bool IsUsePosition { get; set; }
        public bool IsUse { get; set; }
        public List<UnitList> sUnit = new List<UnitList>();
        public List<string> sCUnit = new List<string>();
        internal SelectUnitPrice(DoHome.HandHeld.Client.SAPCnn.ProductBarcode[] product,bool _IsUsePosition, string Barcode)
        {
            InitializeComponent();
            _Product = product;
            IsUsePosition = _IsUsePosition;
          //  product.Select(x=>x new UnitList{ OrderDisplay = 1, UniteCode = product.})
            var i = 1;
            sUnit = (from o in product
                     select new UnitList { UnitCode = o.UnitCode, UnitName = o.UnitName, Chk = false }).Distinct(new UnitListComparer()).ToList();
            for (int j = 0; j < sUnit.Count; j++)
            {
                sUnit[j].DisplayOrder = j + 1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < smartGrid.Rows.Count; i++)
            {
                if ((bool)smartGrid.Rows[i]["Chk"]) 
                {
                    if (smartGrid.Rows[i]["Unitcode"]!=null)
                    sCUnit.Add(smartGrid.Rows[i]["Unitcode"].ToString());
                }     
            }
            if (sCUnit.Count == 0)
            {
                this.Close();
            }
            else
            {
                _ProductRT = (from o in _Product where sCUnit.Contains(o.UnitCode)  select o).ToArray();
                IsUse = true;
                this.Close();
            }
        }

        private void smartGrid_Click(object sender, EventArgs e)
        {

        }

        private void SelectUnitPrice_Load(object sender, EventArgs e)
        {
            smartGrid.DataSource = sUnit;
        }

        private void smartGrid_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {
            if (IsUsePosition)
            {
                try
                {
                    var PCode = smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["Unitcode"].ToString();
                    for (int i = 0; i < smartGrid.Rows.Count; i++)
                    {
                        smartGrid.Rows[i]["Chk"] = smartGrid.Rows[i]["Unitcode"] == PCode;
                        smartGrid.UpdateLayout();
                    }
                }
                catch (Exception)
                {


                }
            }
        }
    }
}