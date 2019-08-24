using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoHome.HandHeld.Client
{
    public partial class OrderedSetCloseForm : Form
    {
        public OrderedSetCloseForm()
        {
            InitializeComponent();
        }

        private void tbOrderNoFinish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    Cursor.Current = Cursors.WaitCursor;

                    var barcode = tbOrderNoFinish.Text.Trim();
                    if (string.IsNullOrEmpty(barcode))
                        barcode = CeReader.Barcode.Scan();
                    //if (!RF1DHelper.Scan(out barcode))
                    //    barcode = tbOrderNoFinish.Text.Trim();


                    if (string.IsNullOrEmpty(barcode))
                    {
                        GlobalMessageBox.ShowWarnning("กรุณาระบุเลขที่เอกสาร");
                        return;
                    }
                    else
                    {
                        if (barcode.Length > 10)
                            barcode = barcode.Substring(0, 10);

                        tbOrderNoFinish.Text = barcode;
                        var order = ServiceHelper.MobileServices.OrderedSetGetByOrderNo(barcode);
                        if (order != null)
                        {
                            if (order.FinishOn == null)
                            {
                                ServiceHelper.MobileServices.OrderedSetUpdate(barcode);
                                tbOrderNoFinish.Text = barcode;
                                GlobalMessageBox.ShowInfomation(string.Format("ปิดใบจัดเลขที่\n{0}\nเรียบร้อยแล้ว", barcode));
                                //tbOrderNoFinish.Text = string.Empty;
                                //tbOrderNoFinish.Focus();  
                            }
                            else
                            {
                                new OrderedInfoForm(order).ShowDialog();
                            }
                            this.Close();
                        }
                        else
                        {
                            GlobalMessageBox.ShowWarnning("ไม่พบเลขที่เอกสารนี้ ในระบบ");
                        }
                    }

                }
                catch (Exception ex)
                {
                    GlobalMessageBox.ShowError(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void OrderedSetCloseForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}