using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using MoreLinq;

namespace CompareExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DBMasterDataContext master = new DBMasterDataContext();
            //DataTable dt1 = master.TBMaster_Articles.Take(1000).ToDataTable();
            //DataTable dt2 = master.TBMaster_Articles.Take(1000).OrderByDescending(b => b.Article).ToDataTable();
            //DataRow dr = dt1.NewRow();
            //dr[0] = "Hello";
            //dr[1] = "World";
            //dt1.Rows.Add(dr);
            //DataTable new_dt = compareDatatable(dt1, dt2);
            //MessageBox.Show("");
        }

        private DataTable compareDatatable(DataTable dt1, DataTable dt2)
        {
            var differences =
            dt1.AsEnumerable().Except(dt2.AsEnumerable(), DataRowComparer.Default);
            return differences.Any() ? differences.CopyToDataTable() : new DataTable();
        }
        public DataTable ReadDataExcel(string filepath)
        {
            FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTable dt = new DataTable();
            dt = result.Tables[0];
            stream.Close();
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lbPath1.Text = openFileDialog1.FileName;
                //DataTable dt = ReadDataExcel(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lbPath2.Text = openFileDialog1.FileName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbPath1.Text))
            {
                MessageBox.Show("เลือกไฟล์ 1");
                return;
            }
            if (string.IsNullOrEmpty(lbPath2.Text))
            {
                MessageBox.Show("เลือกไฟล์ 2");
                return;
            }

            DataTable dt1 = ReadDataExcel(lbPath1.Text);
            DataTable dt2 = ReadDataExcel(lbPath2.Text);
            DataTable dtDiff = new DataTable();

            List<string> listcolumn_1 = new List<string>();
            List<string> listcolumn_2 = new List<string>();
            Boolean checkColumn;

            foreach (DataColumn column in dt1.Columns)
            {
                listcolumn_1.Add(column.ColumnName);
            }

            foreach (DataColumn column in dt2.Columns)
            {
                listcolumn_2.Add(column.ColumnName);
            }

            if (listcolumn_1.Count == listcolumn_2.Count)
            {

                for (int i = 0; i < listcolumn_1.Count; i++)
                {
                    if (listcolumn_1[i] != listcolumn_2[i])
                    {

                        MessageBox.Show("Column ไม่ตรงกัน  " + listcolumn_1[i] + " , " + listcolumn_2[i]);
                        checkColumn = false;
                        return;
                    }
                    checkColumn = true;
                }

                if (checkColumn = true) {

                    if (dt1.Rows.Count > dt2.Rows.Count)
                    {
                        dtDiff = compareDatatable(dt1, dt2);
                    }
                    else
                    {
                        dtDiff = compareDatatable(dt2, dt1);
                    }
                }
            }
            dataGridView1.DataSource = dtDiff;

        }
    }
}
