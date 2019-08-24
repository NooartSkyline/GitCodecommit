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
    public partial class LocationCheckOfflineForm : Form
    {
        private void BindGrid()
        {
            var locationProduct = LocationCheckManager.GetByCreatedBy(GlobalContext.UserCode);
            gvLocationProduct.DataSource = locationProduct;
        }

        private void SaveData()
        {
            if (gvLocationProduct.DataSource != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    LocationCheckManager.TransferToServer();
                    Cursor.Current = Cursors.Default;
                    GlobalMessageBox.ShowInfomation("บันทึกข้อมูลไปยัง SAP สำเร็จ");
                    this.Close();
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    GlobalMessageBox.ShowError("บันทึกข้อมูลไม่สำเร็จ กรุณาลองใหม่อีกครั้ง " + ex.Message);
                    BindGrid();

                }
            }
        }

        public LocationCheckOfflineForm()
        {
            InitializeComponent();
        }

        private void LocationOfflineModeForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);

            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                GlobalMessageBox.ShowError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void gvLocationProduct_CellClick(object sender, Resco.Controls.SmartGrid.CellEventArgs e)
        {
            //click on delete column
            if (e.Cell.ColumnIndex == 2)
            {
                if (GlobalMessageBox.ShowQuestion("คุณต้องลบรายการ ใช่หรือไม่")== DialogResult.Yes)
                {
                    var locationCode = gvLocationProduct.Cells[e.Cell.RowIndex,0].Text;
                    LocationCheckManager.DeleteByLocation(locationCode, GlobalContext.UserCode);
                    this.BindGrid();
                }
            }
        }


    }
}