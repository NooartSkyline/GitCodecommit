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

namespace DoHome.HandHeld.Client
{
    public partial class LabelLocationViewForm : Form
    {
        private void BindGridView()
        {
            gvLocationProduct.DataSource = ServiceHelper.MobileServices.PrintLabelLocationStatusGet(GlobalContext.BranchCode, GlobalContext.UserCode);
        }

        //private void SaveData()
        //{
        //    if (gvLocationProduct.DataSource != null)
        //    {
        //        try
        //        {
        //            Cursor.Current = Cursors.WaitCursor;
        //            var data = (DataTable)gvLocationProduct.DataSource;
        //            var list = new List<PrintLabelLocationDetail>();
        //            foreach (DataRow row in data.Rows)
        //            {
        //                list.Add(new PrintLabelLocationDetail
        //                {
        //                    LocationCode = row["LocationCode"].ToString()
        //                });
        //            }

        //            //var documentNo = ServiceHelper.MobileServices.PrintLabelLocationAdd(GlobalContext.BranchCode,
        //            //     GlobalContext.UserCode, list.ToArray());
        //            //if (documentNo == "ERROR")
        //            //    throw new Exception("ERROR");
        //            //foreach (var item in list)
        //            //    RequestLocationLabelSuperManager.Delete(item.Id);

        //            Cursor.Current = Cursors.Default;
        //            GlobalMessageBox.ShowInfomation("บันทึกข้อมูลไปยัง Server สำเร็จ");
        //            this.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            Cursor.Current = Cursors.Default;
        //            GlobalMessageBox.ShowError("บันทึกข้อมูลไม่สำเร็จ กรุณาลองใหม่อีกครั้ง " + ex.Message);
        //            BindGridView();
        //        }
        //    }
        //}

        public LabelLocationViewForm()
        {
            InitializeComponent();
        }

        private void RequestLocationLabelSuperOfflineForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);

            try
            {
                BindGridView();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (gvLocationProduct.DataSource != null && ((DataTable)gvLocationProduct.DataSource).Rows.Count > 0)
        //        this.SaveData();
        //}

        //private void gvLocationProduct_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        //{
        //    //click on delete column
        //    if (e.Cell.ColumnIndex == 2)
        //    {
        //        if (GlobalMessageBox.ShowQuestion("คุณต้องลบรายการ ใช่หรือไม่") == DialogResult.Yes)
        //        {
        //            var Id = Convert.ToInt32(gvLocationProduct.Cells[e.Cell.RowIndex, 0].Text);
        //            RequestLocationLabelSuperManager.Delete(Id);
        //            this.BindGridView();
        //        }
        //    }
        //}

    }
}