using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DoHome.HandHeld.Client
{
    public partial class ChooseFromListForm : Form
    {
        private DataTable tableList;

        public string SelectedValue { get; set; }

        public string SelectedText { get; set; }

        private void PrepareTable(Array arrayList, string keyColumnName, string valueColumnName)
        {
            tableList = new DataTable();
            tableList.TableName = "ChooseFromList";
            tableList.Columns.Add("Key", typeof(string));
            tableList.Columns.Add("Value", typeof(string));
            object[] obj = new object[0];
            object item;
            for (int index = 0; index < arrayList.Length; index++)
            {
                var row = tableList.NewRow();
                item = arrayList.GetValue(index);
                row["Key"] = GetValueByPropertyName(keyColumnName, item, obj);
                row["Value"] = GetValueByPropertyName(valueColumnName, item, obj);

                tableList.Rows.Add(row);
            }

        }

        private object GetValueByPropertyName(string propertyName, object item, object[] obj)
        {
            try
            {
                PropertyInfo[] propertyInfos;
                propertyInfos = item.GetType().GetProperties();

                return propertyInfos.SingleOrDefault(p => p.Name == propertyName).GetValue(item, obj);
            }
            catch
            {
                return string.Empty;
            }
        }

        private void BindGrid()
        {
            try
            {
                var condition = string.Format("Key LIKE '%{0}%' OR Value LIKE '%{0}%'", txtSearchWord.Text.Trim());
                tableList.DefaultView.RowFilter = condition;
                bsDisplayList.DataSource = tableList.DefaultView;
                this.Text = string.Format("พบรายการทั้งหมด {0:N0} รายการ", tableList.DefaultView.Count);
                bsDisplayList.ResetBindings(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ChooseFromListForm(Array arrayList, string keyColumnName, string valueColumnName)
        {
            InitializeComponent();

            PrepareTable(arrayList, keyColumnName, valueColumnName);
            BindGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void ChooseFromListForm_Load(object sender, EventArgs e)
        {
            Utils.FormSetCenterSceen(this);
            this.txtSearchWord.Focus();
        }

        private void txtSearchWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindGrid();
            }
        }

        private void dgDisplayList_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = dgDisplayList.CurrentRowIndex;
            if (rowIndex > -1)
            {
                this.SelectedValue = dgDisplayList[dgDisplayList.CurrentRowIndex, 0].ToString();
                this.SelectedText = dgDisplayList[dgDisplayList.CurrentRowIndex, 1].ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}