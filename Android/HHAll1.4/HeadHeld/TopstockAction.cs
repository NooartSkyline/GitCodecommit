using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using DoHome.HandHeld.Client.DataAccess;
using System.Collections;
using Resco.Controls.SmartGrid;
using System.Threading;

namespace DoHome.HandHeld.Client
{
    public partial class TopstockAction : Form
    {
        bool DeleteState;
        ArrayList selectedRow = new ArrayList();
        public int CountRow = 0;
        public string StateFind { get; set; }
        public bool IsInit { get; set; }
        internal TopstockAction()
        {
            InitializeComponent();
        }
        private void pgFind_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim() != "") 
            {
                FindItem(txtBarcode.Text);
                if (GlobalContext.HHDoc != "")
                {
                    LoadData();
                }
            }
        }
        private void pgChangeReason_Click(object sender, EventArgs e)
        {

        }
        private void chkSelectAll_CheckStateChanged(object sender, EventArgs e)
        {

        }
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            chkSelectAll.CheckState = CheckState.Unchecked;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarcode.Text.Trim() == "")
                {
                    txtBarcode.Text = CeReader.Barcode.Scan().Trim();
                }
                if (txtBarcode.Text.Trim() != "") 
                {
                    StateFind = "B";
                    switch (cbType.SelectedIndex)
                    {
                        case 0: StateFind = "B"; break;
                        case 1: StateFind = "M"; break;
                        case 2: StateFind = "T"; break;
                        default:
                            break;
                    }
                    FindItem(txtBarcode.Text);             
                    if (StateFind != "C") 
                    {
                        switch (StateFind)
                        {
                            case "B": MessageBox.Show("บาร์โค้ด " + txtBarcode.Text + " นี้ยังไม่ผูกตำแหน่ง TopStock", "ข้อความ"); break;
                            case "M": MessageBox.Show("รหัสสินค้า " + txtBarcode.Text + " นี้ยังไม่ผูกตำแหน่ง TopStock", "ข้อความ"); break;
                            case "T": MessageBox.Show("ไม่มีตำแหน่ง " + txtBarcode.Text + " นี้ในระบบ", "ข้อความ"); break;
                            default: MessageBox.Show("ไม่พบข้อมูล", "ข้อความ");
                                break;
                        }                       
                    }
                    if (GlobalContext.HHDoc != "") 
                    {
                        LoadData();
                    }
                    txtBarcode.Text = "";
                }
            }
        }
        private void FindItem(string BarCode) 
        {
            if (GlobalContext.ZDoc != null)
            {
                if (GlobalContext.ZDoc != "")
                {
                    txtBarcode.Text = "";
                    StateFind = "C";
                    return;
                }
            }
            if(cbSize.SelectedIndex==-1)
            {
              MessageBox.Show("โปรดเลือกประเภทของฟอร์ม","ข้อความ");
              txtBarcode.Text = "";
              StateFind = "C";
              return;
            }
            var TypeForm = ((DoHome.HandHeld.Client.DataAccess.ItemBox)cbSize.SelectedItem).Value.ToString();
            var TYpeFromName = ((DoHome.HandHeld.Client.DataAccess.ItemBox)cbSize.SelectedItem).Text.ToString();
                    
            var EndPoint = GlobalContext.ServerEndpointAddress;
            var ServiceUrl = GlobalContext.remoteAddress;
            try
            {
                var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
                cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
                txtBarcode.Text = txtBarcode.Text.Trim();
                Cursor.Current = Cursors.WaitCursor;
                var ItemHead = cnn.GetTopstockItems(txtBarcode.Text, txtBarcode.Text, txtBarcode.Text, GlobalContext.BranchCode, GlobalContext.WarehouseCode, StateFind);
                Cursor.Current = Cursors.Default;
                if (ItemHead.Status)
                {
                    if (ItemHead.Items.Count() > 0)
                    {
                        if (GlobalContext.HHDoc == "")
                        {
                            InsertHHDoc();
                        }
                        else 
                        {
                            
                        }
                        try
                        {
                            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                            {
                                con.Open();
                                using (SqlCeCommand com = new SqlCeCommand())
                                {
                                    com.Connection = con;
                                    com.CommandText = " Insert into TopstockItems " +
                                                      " (MATNR,MATNR_TXT,WERKS,LGORT,MEINH,UMREZ,BARCODE,LGORT_TXT,MEINH_TXT,LOCATION_T,LOCATION_S,LOCZONE,LOCHSHELF,LOCSIDE,LOCSIDE_TXT,LOCHOLE,LOCCLASS,LOGGR,LOGGR_TXT,QTY,BAR,STATUS,MSG,FNAME,FNAME_txt,EmployeeId,DocNo) " +
                                                      " Values(@MATNR,@MATNR_TXT,@WERKS,@LGORT,@MEINH,@UMREZ,@BARCODE,@LGORT_TXT,@MEINH_TXT,@LOCATION_T,@LOCATION_S,@LOCZONE,@LOCHSHELF,@LOCSIDE,@LOCSIDE_TXT,@LOCHOLE,@LOCCLASS,@LOGGR,@LOGGR_TXT,@QTY,@BAR,@STATUS,@MSG,@FNAME,@FNAME_txt,@EmpId,@DocNo)";
                                    var ChkAlert = true; 
                                    foreach (var item in ItemHead.Items)
                                    {
                                        
                                        var Chk = CheckSame(item.LGORT, item.LOCATION_T, item.MATNR, item.MEINH);
                                        if (Chk > 0 && (StateFind == "M" || StateFind == "B")) // ซ้ำให้ข้าม
                                        {
                                            if (ChkAlert)
                                            {
                                                var Res = MessageBox.Show("มีรายการอยู่แล้วต้องการเพิ่มอีกหรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                                if (Res == DialogResult.Yes)
                                                {

                                                }
                                                else
                                                {
                                                    break;
                                                }
                                                ChkAlert = false;
                                            }
                                          
                                        }
                                        com.Parameters.Clear();
                                        com.Parameters.AddWithValue("@MATNR", item.MATNR);
                                        com.Parameters.AddWithValue("@MATNR_TXT", item.MATNR_TXT);
                                        com.Parameters.AddWithValue("@WERKS", item.WERKS);
                                        com.Parameters.AddWithValue("@LGORT", item.LGORT);
                                        com.Parameters.AddWithValue("@MEINH", item.MEINH);
                                        com.Parameters.AddWithValue("@UMREZ", item.UMREZ);
                                        com.Parameters.AddWithValue("@BARCODE", item.BARCODE);
                                        com.Parameters.AddWithValue("@LGORT_TXT", item.LGORT_TXT);
                                        com.Parameters.AddWithValue("@MEINH_TXT", item.MEINH_TXT);
                                        com.Parameters.AddWithValue("@LOCATION_T", item.LOCATION_T);
                                        com.Parameters.AddWithValue("@LOCATION_S", item.LOCATION_S);
                                        com.Parameters.AddWithValue("@LOCZONE", item.LOCZONE);
                                        com.Parameters.AddWithValue("@LOCHSHELF", item.LOCHSHELF);
                                        com.Parameters.AddWithValue("@LOCSIDE", item.LOCSIDE);
                                        com.Parameters.AddWithValue("@LOCSIDE_TXT", item.LOCSIDE_TXT);
                                        com.Parameters.AddWithValue("@LOCHOLE", item.LOCHOLE);
                                        com.Parameters.AddWithValue("@LOCCLASS", item.LOCCLASS);
                                        com.Parameters.AddWithValue("@LOGGR", item.LOGGR);
                                        com.Parameters.AddWithValue("@LOGGR_TXT", item.LOGGR_TXT);
                                        com.Parameters.AddWithValue("@QTY", Convert.ToDecimal(item.QTY));
                                        com.Parameters.AddWithValue("@BAR", item.BAR);
                                        com.Parameters.AddWithValue("@STATUS", item.STATUS);
                                        com.Parameters.AddWithValue("@MSG", item.MSG);
                                        com.Parameters.AddWithValue("@FNAME", TypeForm);
                                        com.Parameters.AddWithValue("@FNAME_txt", TYpeFromName);
                                        com.Parameters.AddWithValue("@EmpId", GlobalContext.UserCode);
                                        com.Parameters.AddWithValue("@DocNo", GlobalContext.HHDoc);
                                        com.ExecuteNonQuery();
                                    }
                                    if (ItemHead.Items.Count() > 0) 
                                    {
                                        StateFind = "C";
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                       // MessageBox.Show("ไม่พบข้อมูล", "ข้อความ");
                    }
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                   // MessageBox.Show(ItemHead.Message , "ข้อความ");
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("ระบบเครื่อข่ายไม่สามารถใช้งานได้โปรดตรวจสอบ " + ex.Message, "ข้อความ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }           
        }
        private void TopstockAction_Load(object sender, EventArgs e)
        {
            StateFind = "M";
            IsInit = true;
            AddSizeItem();
            cbType.SelectedIndex = 0;
            if (GlobalContext.HHDoc != "")
            {
                LoadData();
            }
            if (GlobalContext.IsDisable) 
            {
                MessageBox.Show("สาขาหรือคลังสินค้าที่ล็อคอินไม่ตรงกับที่มีในเอกสาร \r\n คุณจะไม่สามารถแก้ไขเอกสารนี้ได้");
                cbSize.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }            
            IsInit = false;
        }
        private void AddSizeItem() 
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("Select * From TopstockForm ", con))
                    {
                        using (var reader = com.ExecuteReader())
                        {
                            cbSize.Items.Clear();
                            while (reader.Read())
                            {
                                cbSize.Items.Add(new DoHome.HandHeld.Client.DataAccess.ItemBox {  Value = (string)reader["FormCode"],  Text = (string)reader["FormName"] });
                                if (reader["FormCode"].ToString().Trim() == "ZTOPST2")
                                {
                                    cbSize.SelectedIndex = cbSize.Items.Count -1;
                                    GlobalContext.IndexFormType = cbSize.SelectedIndex;
                                }
                                if (GlobalContext.FormType != null) 
                                {
                                    if (GlobalContext.FormType != "") 
                                    {
                                        if (GlobalContext.FormType == reader["FormCode"].ToString()) 
                                        {
                                            cbSize.SelectedIndex = cbSize.Items.Count - 1;
                                            GlobalContext.IndexFormType = cbSize.SelectedIndex;
                                        }
                                    }
                                }
                            }
                          
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkSelectAll.CheckState = CheckState.Unchecked;
            if (!IsInit && !GlobalContext.IsLoad)
            {
                //GlobalContext.IndexFormType = cbSize.SelectedIndex;
                if (cbSize.SelectedIndex != -1 && GlobalContext.HHDoc != "")
                {
                    if (MessageBox.Show("คุณต้องการเปลี่ยนรูปแบบพิมพ์ป้ายใช่หรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        try
                        {
                            var FNAME = ((ItemBox)cbSize.SelectedItem).Value;
                            var FNAMETxt = ((ItemBox)cbSize.SelectedItem).Text;
                            using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                            {
                                con.Open();
                                using (SqlCeCommand com = new SqlCeCommand("Update TopstockItems set FNAME  = @FNAME , FNAME_txt = @FNTXT WHERE DocNo = @DocNo", con))
                                {
                                    com.Parameters.AddWithValue("@DocNo", GlobalContext.HHDoc);
                                    com.Parameters.AddWithValue("@FNAME", FNAME);
                                    com.Parameters.AddWithValue("@FNTXT", FNAMETxt);
                                    com.ExecuteNonQuery();
                                }
                            }
                            LoadData();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }
        private void InsertHHDoc() 
        {
            try
            {
              using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
              {
                  con.Open();
                  using (SqlCeCommand com = new SqlCeCommand())
                  {
                      com.Connection = con;
                      com.CommandText = "Insert into TopstockDoc (DocNo,SAPDocNo,Branch,Warehouse,Employee,PDocNo) Values(@Doc,@SDoc,@Br,@Wr,@Emp,@PDoc)";
                      com.Parameters.Clear();
                      com.Parameters.AddWithValue("@Doc", "");                      
                      com.Parameters.AddWithValue("@SDoc", "");
                      com.Parameters.AddWithValue("@PDoc","");
                      com.Parameters.AddWithValue("@Br",GlobalContext.BranchCode);
                      com.Parameters.AddWithValue("@Wr",GlobalContext.WarehouseCode);
                      com.Parameters.AddWithValue("@Emp",GlobalContext.UserCode);
                      com.ExecuteNonQuery();
                      com.CommandText = "Select TOP(1) Row_Order From TopStockDoc Order by Row_Order DESC ";
                      com.Parameters.Clear();
                      var HHDoc = "";
                      var TopRow = 0;
                      using (var reader = com.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              TopRow = (int)reader["Row_Order"];
                              HHDoc = (((int)reader["Row_Order"]).ToString("00000000"));
                              break;
                          }
                      }
                      com.Parameters.Clear();
                      com.CommandText = "Update TopStockDoc  Set DocNo = @Doc WHERE Row_Order = @Row ";
                      com.Parameters.AddWithValue("@Doc", HHDoc);
                      com.Parameters.AddWithValue("@Row", TopRow);
                      com.ExecuteNonQuery();
                      GlobalContext.HHDoc = HHDoc;
                      //lblHHDoc.Text = "เอกสาร HH/" + HHDoc;
                  }
              }
           }
           catch (Exception ex)
           {

           }
        }
        private void LoadData() 
        {

            try
            {
                this.smartGrid.Rows.Clear();
                this.smartGrid.DbConnector.ConnectionString = SqlHelper.SqlCeConnectionString;
                this.smartGrid.DbConnector.CommandText = "Select * From TopstockItems Where DocNo ='" + GlobalContext.HHDoc + "'";
                this.smartGrid.LoadData(false);
                foreach (Column c in this.smartGrid.Columns)
                {
                    if (c.DataMember == "QTY" && !GlobalContext.IsDisable)
                    {
                        c.EditMode = EditMode.Auto;
                        c.CellEdit = CellEditType.Custom;
                        c.CellEditCustomControl = new NumericUpDown();
                    }
                }
                if (!GlobalContext.IsDisable)
                {
                    smartGrid.BeforeCustomEdit += new CustomEditHandler(smartGrid_BeforeCustomEdit);
                    smartGrid.AfterCustomEdit += new CustomEditHandler(smartGrid_AfterCustomEdit);
                }
            }
            catch (Exception ex)
            {

            }
        }
        void smartGrid_AfterCustomEdit(object sender, CustomEditEventArgs e)
        {
            e.Cell.Data = (e.Control as NumericUpDown).Value == 0 ? 1 : (e.Control as NumericUpDown).Value;
            var Row = (int)smartGrid.Rows[e.Cell.RowIndex]["Row_Order"];
            var Q  = (e.Control as NumericUpDown).Value;
            Thread thread = new Thread(() => SaveQty(Q, Row));
            thread.Start();
        }
        private delegate void SaveQtyDelegate(decimal q, int row);
        private void SaveQty(decimal q,int row) 
        {
           
            if (this.InvokeRequired)
            {
                var c = new SaveQtyDelegate(SaveQty);
                this.Invoke(new SaveQtyDelegate(SaveQty),
                    new object[] { q, row });
                return;
            }
            else
            {
                try
                {
                    using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                    {
                        con.Open();
                        using (SqlCeCommand com = new SqlCeCommand())
                        {
                            com.Connection = con;
                            com.CommandText = "Update TopstockItems Set Qty =@Qty  Where Row_Order = @Row";
                            com.Parameters.Clear();
                            com.Parameters.AddWithValue("@Row", row);
                            com.Parameters.AddWithValue("@Qty", q);
                            com.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        void smartGrid_BeforeCustomEdit(object sender, CustomEditEventArgs e)
        {
            var Tmp = Convert.ToInt32(e.Cell.Data);
            (e.Control as NumericUpDown).Value = Tmp == 0 ? 1 : Tmp;
        }
        private void chkSelectAll_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                for (int i = 0; i < smartGrid.Rows.Count; i++)
                {
                    smartGrid.Rows[i]["Chk"] = true;
                    smartGrid.UpdateLayout();
                }
            }
            else 
            {
                for (int i = 0; i < smartGrid.Rows.Count; i++)
                {
                    smartGrid.Rows[i]["Chk"] = false;
                    smartGrid.UpdateLayout();
                }
            }
            
        }
        private void gvContent_MouseUp(object sender, MouseEventArgs e)
        {
            if (gvContent.CurrentCell.ColumnNumber == 0)
            {
                int c = gvContent.CurrentRowIndex;
                if (c != -1)
                {
                    if (selectedRow.Contains(c))
                    {
                        gvContent.UnSelect(c);
                        selectedRow.Remove(c);
                    }
                    else
                    {
                        gvContent.Select(c);
                        selectedRow.Add(c);
                    }
                    for (int i = 0; i < selectedRow.Count; i++)
                    {
                        try
                        {
                            gvContent.Select(int.Parse(selectedRow[i].ToString()));
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
            }
        }
        private void Post(int CountCreate) 
        {
            var ObjectIn = new SAPCnn.TopStockHeader();
            ObjectIn.Items = new SAPCnn.TopStockItem[CountCreate];
            var flagPost = false;
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("Select * From TopstockItems Where DocNo = @Doc", con))
                    {
                        com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                        using (var reader = com.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                ObjectIn.Items[i] = new SAPCnn.TopStockItem();
                                ObjectIn.Items[i].MATNR = reader["MATNR"].ToString();
                                ObjectIn.Items[i].MATNR_TXT  = reader["MATNR_TXT"].ToString();
                                ObjectIn.Items[i].WERKS = reader["WERKS"].ToString();
                                ObjectIn.Items[i].LGORT = reader["LGORT"].ToString();
                                ObjectIn.Items[i].MEINH = reader["MEINH"].ToString();
                                ObjectIn.Items[i].UMREZ = Convert.ToDecimal(reader["UMREZ"].ToString());
                                ObjectIn.Items[i].BARCODE = reader["BARCODE"].ToString();
                                ObjectIn.Items[i].LGORT_TXT = reader["LGORT_TXT"].ToString();
                                ObjectIn.Items[i].MEINH_TXT = reader["MEINH_TXT"].ToString();
                                ObjectIn.Items[i].LOCATION_T = reader["LOCATION_T"].ToString();
                                ObjectIn.Items[i].LOCATION_S = reader["LOCATION_S"].ToString();
                                ObjectIn.Items[i].LOCZONE = reader["LOCZONE"].ToString();
                                ObjectIn.Items[i].LOCHSHELF = reader["LOCHSHELF"].ToString();
                                ObjectIn.Items[i].LOCSIDE = reader["LOCSIDE"].ToString();
                                ObjectIn.Items[i].LOCSIDE_TXT = reader["LOCSIDE_TXT"].ToString();
                                ObjectIn.Items[i].LOCHOLE = reader["LOCHOLE"].ToString();
                                ObjectIn.Items[i].LOCCLASS = reader["LOCCLASS"].ToString();
                                ObjectIn.Items[i].LOGGR = reader["LOGGR"].ToString();
                                ObjectIn.Items[i].LOGGR_TXT = reader["LOGGR_TXT"].ToString();
                                ObjectIn.Items[i].QTY = reader["QTY"].ToString();
                                ObjectIn.Items[i].BAR = reader["BAR"].ToString();
                                ObjectIn.Items[i].STATUS = reader["STATUS"].ToString();
                                ObjectIn.Items[i].MSG = reader["MSG"].ToString();
                                ObjectIn.Items[i].FNAME = reader["FNAME"].ToString();
                                i++;                               
                            }
                            flagPost = true;
                        }
                    }
                }
                if (flagPost) 
                {
                   var EndPoint = GlobalContext.ServerEndpointAddress;
                    var ServiceUrl = GlobalContext.remoteAddress;
                    try
                    {
                        var cnn = new DoHome.HandHeld.Client.SAPCnn.MobileService();
                        cnn.Url = ServiceUrl.Replace("localhost", EndPoint);
                        Cursor.Current = Cursors.WaitCursor;
                        ObjectIn.EmpId = GlobalContext.UserCode;
                        ObjectIn.WarhouseId = GlobalContext.WarehouseCode;
                        var ObjectOut = cnn.CreateTopstockDoc(ObjectIn);
                        Cursor.Current = Cursors.Default;
                        if(ObjectOut.Status)
                        {
                            try
                            {
                                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                                {
                                    con.Open();
                                    using (SqlCeCommand com = new SqlCeCommand("Update TopstockDoc Set SAPDocNo = @ZDoc , PDocNo = @PDoc  Where DocNo = @Doc", con))
                                    {
                                        com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                                        com.Parameters.AddWithValue("@ZDoc", ObjectOut.ZDocNo);
                                        com.Parameters.AddWithValue("@PDoc", "0000000");
                                        com.ExecuteNonQuery();
                                        MessageBox.Show("บันทึกสำเร็จ เลขที่ : " + ObjectOut.ZDocNo + "\r\n" + "กรุณาติดต่อพิมพ์ป้าย TopStock \r\n" + "ได้ที่ศูนย์บริการคลัง/ค้าปลีก");
                                        GlobalContext.HHDoc = "";
                                        GlobalContext.ZDoc = "";
                                        GlobalContext.PDocNo = "";                                        
                                        smartGrid.Rows.Clear();
                                    }
                                }
                            }
                            catch (Exception ex) 
                            {
                              
                            }
                           
                        }
                        else 
                        {
                            MessageBox.Show("สร้างใบขอไม่สำเร็จโปรดตรวจสอบ จำนวนที่ต้องการพิมพ์และแบบฟอร์มให้ถูกต้อง");
                        }
                    }
                    catch (Exception ex) 
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("ระบบเครื่อข่ายไม่สามารถใช้งานได้โปรดตรวจสอบ " + ex.Message, "ข้อความ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private int CheckSame(string Warehouse,string Location,string ItemId,string ItemUnit) 
        {
            if(GlobalContext.HHDoc == "")
            {
             return 0;
            }
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("Select Row_Order From TopstockItems Where DocNo = @Doc AND LGORT = @Lgo AND LOCATION_T = @Loc AND MATNR = @ItemId AND MEINH = @ItemUnit ", con))
                    {
                        com.Parameters.Clear();                         
                        com.Parameters.AddWithValue("@Doc",GlobalContext.HHDoc);
                        com.Parameters.AddWithValue("@Lgo", Warehouse);
                        com.Parameters.AddWithValue("@Loc", Location);
                        com.Parameters.AddWithValue("@ItemId", ItemId);
                        com.Parameters.AddWithValue("@ItemUnit", ItemUnit);
                        using (var reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return Convert.ToInt32(reader["Row_Order"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        private void btnNumericKeyboard_Click(object sender, EventArgs e)
        {
            var oForm = new LocationKeyboardForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                txtBarcode.Text = oForm.Tag as string;
                txtBarcode.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            var ChkHas = false;
            if (GlobalContext.HHDoc != "")
            {

                for (int i = 0; i < smartGrid.Rows.Count; i++)
                {

                    if ((bool)smartGrid.Rows[i]["Chk"])
                    {
                        ChkHas = true;
                        break;
                    }
                }
                if (!ChkHas)
                {
                    MessageBox.Show("ท่านยังไม่ได้เลือกรายการ");
                    return;
                }
                if (MessageBox.Show("คุณต้องการสร้างใบขอป้ายตามรายการที่เลือกใช่หรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    var CountSum = 0;
                    try
                    {
                        using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                        {
                            con.Open();
                            using (SqlCeCommand com = new SqlCeCommand())
                            {
                                com.Connection = con;
                                for (int i = 0; i < smartGrid.Rows.Count; i++)
                                {
                                    if (!((bool)smartGrid.Rows[i]["Chk"]))
                                    {
                                        com.CommandText = "Delete TopstockItems Where Row_Order = @Row";
                                        com.Parameters.Clear();
                                        com.Parameters.AddWithValue("@Row", (int)smartGrid.Rows[i]["Row_Order"]);
                                        com.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        CountSum++;
                                    }
                                }
                            }
                        }
                        
                        Post(CountSum);
                        cbType.SelectedIndex = 0;
                        cbSize.SelectedIndex = GlobalContext.IndexFormType;
                        
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            chkSelectAll.CheckState = CheckState.Unchecked;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
           // DeleteState = true;
            
            var ChkDel = true;
            
                try
                {
                    using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                    {
                        con.Open();
                        using (SqlCeCommand com = new SqlCeCommand())
                        {
                            com.Connection = con;
                            for (int i = 0; i < smartGrid.Rows.Count; i++)
                            {
                                try
                                {
                                    if ((bool)smartGrid.Rows[i]["Chk"])
                                    {
                                        if (ChkDel)
                                        {
                                            if (MessageBox.Show("ต้องการลบรายการที่เลือกใช่หรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                            {
                                                ChkDel = false;
                                            }
                                            else 
                                            {
                                                return;
                                            }
                                        }
                                        com.CommandText = "Delete TopstockItems Where Row_Order = @Row";
                                        com.Parameters.Clear();
                                        com.Parameters.AddWithValue("@Row", (int)smartGrid.Rows[i]["Row_Order"]);
                                        com.ExecuteNonQuery();
                                    };
                                }
                                catch (Exception)
                                {
                                    
                                   
                                }
                                                                
                            }                             
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                
               // DeleteState = false;
                if (ChkDel)
                {
                    MessageBox.Show("ท่านยังไม่ได้เลือกรายการ", "คำถาม");
                }
                else 
                {
                    LoadData();
                }
                chkSelectAll.CheckState = CheckState.Unchecked;
               // selectedRow.Clear();
            
            //DeleteState = false;
        }
        private void btnShowUnsucces_Click(object sender, EventArgs e)
        {
            chkSelectAll.CheckState = CheckState.Unchecked;
            if (GlobalContext.PDocNo == "" && GlobalContext.HHDoc != "")
            {
                // ถามว่าจะพักบิลให้
                if (MessageBox.Show("เอกสารยังไม่เสร็จสมบูรณ์คุณต้องการพักบิลหรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Pause();
                    GlobalContext.HHDoc = "";
                    GlobalContext.ZDoc = "";
                    GlobalContext.PDocNo = "";
                    GlobalContext.FormType = "";
                    smartGrid.Rows.Clear();
                    cbType.SelectedIndex = 0;
                    cbSize.SelectedIndex = GlobalContext.IndexFormType;
                    var frm = new MainTopstock();
                    frm.ShowDialog();
                    this.Activate();
                    
                }
                else
                {
                    try
                    {
                        using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                        {
                            con.Open();
                            using (SqlCeCommand com = new SqlCeCommand())
                            {
                                com.Connection = con;
                                com.CommandText = "Delete TopstockDoc  Where DocNo = @Doc ";
                                com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                                com.ExecuteNonQuery();
                                com.Parameters.Clear();
                                com.CommandText = "Delete TopstockItems  Where DocNo = @Doc ";
                                com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                                com.ExecuteNonQuery();
                                GlobalContext.HHDoc = "";
                                GlobalContext.ZDoc = "";
                                GlobalContext.PDocNo = "";
                                GlobalContext.FormType = "";
                                smartGrid.Rows.Clear();
                                cbType.SelectedIndex = 0;
                                cbSize.SelectedIndex = GlobalContext.IndexFormType;
                                var frm = new MainTopstock();
                                frm.ShowDialog();
                                this.Activate();
                                
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            else
            {
                GlobalContext.HHDoc = "";
                GlobalContext.ZDoc = "";
                GlobalContext.PDocNo = "";
                GlobalContext.FormType = "";
                smartGrid.Rows.Clear();
                cbType.SelectedIndex = 0;
                cbSize.SelectedIndex = GlobalContext.IndexFormType;
                var frm = new MainTopstock();
                frm.ShowDialog();
                this.Activate();
               
                // ไปได้
            }
        }
        private void btnPuase_Click(object sender, EventArgs e)
        {
            chkSelectAll.CheckState = CheckState.Unchecked;
            if (GlobalContext.HHDoc != "" && GlobalContext.PDocNo =="")
            {
                if (MessageBox.Show("คุณต้องการที่จะพักบิลใช่หรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Pause();
                    GlobalContext.HHDoc = "";
                    GlobalContext.ZDoc = "";
                    GlobalContext.PDocNo = "";
                    GlobalContext.FormType = "";
                    smartGrid.Rows.Clear();
                    cbType.SelectedIndex = 0;
                    cbSize.SelectedIndex = GlobalContext.IndexFormType;
                }
            }
        }
        private string GetNextDocNo()
        {
            string IReturn = "1"+(1).ToString("00000");
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand("Select DocCount,LDocCount From TopstockDocNo Where BranchCode = @Bch", con))
                    {
                        com.Parameters.AddWithValue("@Bch", GlobalContext.BranchCode);
                        using (var reader = com.ExecuteReader())
                        {
                            var CountW = true;
                            while (reader.Read())
                            {
                                var NextDoc = "";
                                var LDoc = (int)reader["LDocCount"];
                                if ((int)reader["DocCount"] + 1 == 100000)
                                {
                                    NextDoc = (1).ToString("00000");
                                    LDoc = LDoc + 1;
                                }
                                else 
                                {
                                    NextDoc = ((int)reader["DocCount"] +1).ToString("00000");
                                }                              
                              com.Parameters.Clear();
                              com.CommandText = "Update TopstockDocNo Set DocCount = " +NextDoc+ " , LDocCount = "+ LDoc +" Where BranchCode = '" + GlobalContext.BranchCode+ "'";
                              com.ExecuteNonQuery();
                              IReturn = "" + LDoc + NextDoc;                              
                              CountW = false;
                            }
                            if (CountW) 
                            {
                                com.Parameters.Clear();
                                com.CommandText = " Insert into TopstockDocNo (BranchCode,DocCount,LDocCount) Values('" + GlobalContext.BranchCode + "',1,1)";
                                com.ExecuteNonQuery();                            
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
            
            }
            return IReturn;       
        }
        private void TopstockAction_Closing(object sender, CancelEventArgs e)
        {
            if (GlobalContext.PDocNo == "" && GlobalContext.HHDoc != "")
            {
                // ถามว่าจะพักบิลให้
                if (MessageBox.Show("ยังไม่ได้บันทึกสร้างบิล" + "\r\n" + "คุณต้องการออกจากโปรแกรมหรือไม่" , "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Pause();
                    //GlobalContext.HHDoc = "";
                    //GlobalContext.ZDoc = "";
                    //GlobalContext.PDocNo = "";
                    //GlobalContext.FormType = "";
                    //smartGrid.Rows.Clear();
                    try
                    {
                        using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                        {
                            con.Open();
                            using (SqlCeCommand com = new SqlCeCommand())
                            {
                                com.Connection = con;
                                com.CommandText = "Delete TopstockDoc  Where DocNo = @Doc ";
                                com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                                com.ExecuteNonQuery();
                                com.Parameters.Clear();
                                com.CommandText = "Delete TopstockItems  Where DocNo = @Doc ";
                                com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                                com.ExecuteNonQuery();
                                GlobalContext.HHDoc = "";
                                GlobalContext.ZDoc = "";
                                GlobalContext.PDocNo = "";
                                GlobalContext.FormType = "";
                                smartGrid.Rows.Clear();
                                //var frm = new TopstockDocDisplay();
                                //frm.ShowDialog();
                                GlobalContext.HHDoc = "";
                                GlobalContext.ZDoc = "";
                                GlobalContext.PDocNo = "";
                                GlobalContext.FormType = "";
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                   
                    e.Cancel = true;
                   // base.OnClosing(e);
                    return;
                }
            }
            else
            {
                
            }
        }
        private void Pause() 
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                {
                    con.Open();
                    using (SqlCeCommand com = new SqlCeCommand())
                    {
                        com.Connection = con;
                        var Doc = GlobalContext.BranchCode + GetNextDocNo();
                        com.CommandText = "Update TopstockDoc Set PDocNo = @PDoc  Where DocNo = @Doc ";
                        com.Parameters.AddWithValue("@PDoc", Doc);
                        com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                        com.ExecuteNonQuery();
                        GlobalContext.PDocNo = Doc;
                        MessageBox.Show("เลขที่เอกสารพักบิล : " + Doc);
                    }
                     
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void TopstockAction_Activated(object sender, EventArgs e)
        {
            if (GlobalContext.IsLoad) 
            {
                LoadData();
                foreach (var item in cbSize.Items)
                {
                    if (((ItemBox)item).Value.ToString() == GlobalContext.FormType) 
                    {
                        cbSize.SelectedItem = item;
                    }
                }
                GlobalContext.IsLoad = false;
            }
        }
        private void btnAllSAP_Click(object sender, EventArgs e)
        {
            chkSelectAll.CheckState = CheckState.Unchecked;
            if (GlobalContext.PDocNo == "" && GlobalContext.HHDoc != "")
            {
                // ถามว่าจะพักบิลให้
                if (MessageBox.Show("เอกสารยังไม่เสร็จสมบูรณ์คุณต้องการพักบิลหรือไม่", "คำถาม", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Pause();
                    GlobalContext.HHDoc = "";
                    GlobalContext.ZDoc = "";
                    GlobalContext.PDocNo = "";
                    GlobalContext.FormType = "";
                    smartGrid.Rows.Clear();
                    var frm = new TopstockDocDisplay();
                    frm.ShowDialog();
                    cbSize.SelectedIndex= GlobalContext.IndexFormType ;
                    GlobalContext.HHDoc = "";
                    GlobalContext.ZDoc = "";
                    GlobalContext.PDocNo = "";
                    GlobalContext.FormType = "";
                }
                else
                {
                    try
                    {
                        using (SqlCeConnection con = new SqlCeConnection(SqlHelper.SqlCeConnectionString))
                        {
                            con.Open();
                            using (SqlCeCommand com = new SqlCeCommand())
                            {
                                com.Connection = con;
                                com.CommandText = "Delete TopstockDoc  Where DocNo = @Doc ";
                                com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                                com.ExecuteNonQuery();
                                com.Parameters.Clear();
                                com.CommandText = "Delete TopstockItems  Where DocNo = @Doc ";
                                com.Parameters.AddWithValue("@Doc", GlobalContext.HHDoc);
                                com.ExecuteNonQuery();
                                GlobalContext.HHDoc = "";
                                GlobalContext.ZDoc = "";
                                GlobalContext.PDocNo = "";
                                GlobalContext.FormType = "";
                                smartGrid.Rows.Clear();
                                var frm = new TopstockDocDisplay();
                                frm.ShowDialog();
                                cbSize.SelectedIndex = GlobalContext.IndexFormType;
                                GlobalContext.HHDoc = "";
                                GlobalContext.ZDoc = "";
                                GlobalContext.PDocNo = "";
                                GlobalContext.FormType = "";
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            else
            {
                GlobalContext.HHDoc = "";
                GlobalContext.ZDoc = "";
                GlobalContext.PDocNo = "";
                GlobalContext.FormType = "";
                smartGrid.Rows.Clear();
                var frm = new TopstockDocDisplay();
                frm.ShowDialog();
                cbSize.SelectedIndex = GlobalContext.IndexFormType;
                GlobalContext.HHDoc = "";
                GlobalContext.ZDoc = "";
                GlobalContext.PDocNo = "";
                GlobalContext.FormType = "";
                // ไปได้
            }
        }
        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (smartGrid.SelectedCell.RowIndex >= 0)
            {
                 
                var frm = new TopstockItemDetails(
                            smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["Row_Order"].ToString() 
                          , smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["LOCATION_T"].ToString()
                          , smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["MATNR"].ToString()
                          , smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["MEINH_TXT"].ToString()
                          , smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["BARCODE"].ToString()
                          , smartGrid.Rows[smartGrid.SelectedCell.RowIndex]["QTY"].ToString());
                frm.ShowDialog();
                
                LoadData();
            }
        }
    }
}