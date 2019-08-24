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
    public partial class OrderedInfoForm : Form
    {
        public OrderedInfoForm(OrderedSet order)
        {
            InitializeComponent();

            tbOrderNo.Text = order.OrderNo;
            tbForkLiftNumber.Text = order.ForkliftNumber;
            tbDriverName.Text = order.DriverName;
            tbStartOn.Text = order.StartOn.ToString("dd/MM/yyyy HH:mm:ss");
            if (order.FinishOn.HasValue)
                tbFinishOn.Text = order.FinishOn.Value.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderedInfoForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);
        }

    }
}