using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OfficeExcel = Microsoft.Office.Interop.Excel;
using System.Configuration;

namespace ExportToExcel
{
    public partial class frmExcelExport : Form
    {
        static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        public frmExcelExport()
        {
            InitializeComponent();
        }

        //private DataSet GetDataSet()
        //{
        //    DataSet ds = new DataSet();
        //    DataTable dtbl = new DataTable();
        //    dtbl.Columns.Add("Sl No");//Define Columns
        //    dtbl.Columns.Add("Novel Name");
        //    dtbl.Columns.Add("Author");
        //    dtbl.Columns.Add("Genres");
        //    dtbl.Columns.Add("Published Date");
        //    dtbl.Columns.Add("Price");
        //    dtbl.Columns.Add("Rating");

        //    dtbl.Rows.Add("1", "In Search of Lost Time", "Marcel Proust", "Literary modernism", "01-01-1913", "348", "4.3");//Adding Rows
        //    dtbl.Rows.Add("2", "Ulysses", "James Joyce", "Modernism", "22-02-1922", "58", "3.7");
        //    dtbl.Rows.Add("3", "Moby Dick", "Herman Melville", "Adventure fiction", "18-10-1851", "131", "3.4");
        //    dtbl.Rows.Add("4", "Hamlet", "William Shakespeare", "Tragedy", "01-01-1603", "225", "3.9");
        //    dtbl.Rows.Add("5", "War and Peace", "Leo Tolstoy", "Historical fiction", "01-01-1869", "133.95", "4.1");
        //    dtbl.TableName = "Table1";
        //    ds.Tables.Add(dtbl);

        //    DataTable dtbl2 = dtbl.Copy();//Created copies of first table
        //    dtbl2.TableName = "Table2";
        //    ds.Tables.Add(dtbl2);
        //    DataTable dtbl3 = dtbl.Copy();//Created copies of first table
        //    dtbl3.TableName = "Table3";
        //    ds.Tables.Add(dtbl3);

        //    return ds;
        //}

        private void ExportDataSetToExcel(DataSet ds, string strPath)
        {
            int inHeaderLength = 3, inColumn = 0, inRow = 0;
            System.Reflection.Missing Default = System.Reflection.Missing.Value;
            //Create Excel File
            //strPath += @"\Excel_" + DateTime.Now.ToString().Replace(':', '-') + ".xlsx";
            OfficeExcel.Application excelApp = new OfficeExcel.Application();
            OfficeExcel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
            foreach (DataTable dtbl in ds.Tables)
            {
                //Create Excel WorkSheet
                OfficeExcel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
                excelWorkSheet.Name = dtbl.TableName;//Name worksheet

                //Write Column Name
                for (int i = 0; i < dtbl.Columns.Count; i++)
                    excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = dtbl.Columns[i].ColumnName.ToUpper();

                //Write Rows
                for (int m = 0; m < dtbl.Rows.Count; m++)
                {
                    for (int n = 0; n < dtbl.Columns.Count; n++)
                    {
                        inColumn = n + 1;
                        inRow = inHeaderLength + 2 + m;
                        excelWorkSheet.Cells[inRow, inColumn] = dtbl.Rows[m].ItemArray[n].ToString();
                        if (m % 2 == 0)
                            excelWorkSheet.get_Range("A" + inRow.ToString(), "G" + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");
                    }
                }

                //Excel Header
                OfficeExcel.Range cellRang = excelWorkSheet.get_Range("A1", "G3");
                cellRang.Merge(false);
                cellRang.Interior.Color = System.Drawing.Color.White;
                cellRang.Font.Color = System.Drawing.Color.Gray;
                cellRang.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
                cellRang.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
                cellRang.Font.Size = 26;
                excelWorkSheet.Cells[1, 1] = "Greate Novels Of All Time";

                //Style table column names
                cellRang = excelWorkSheet.get_Range("A4", "G4");
                cellRang.Font.Bold = true;
                cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
                excelWorkSheet.get_Range("F4").EntireColumn.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignRight;
                //Formate price column
                excelWorkSheet.get_Range("F5").EntireColumn.NumberFormat = "0.00";
                //Auto fit columns
                excelWorkSheet.Columns.AutoFit();
            }

            //Delete First Page
            excelApp.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet lastWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkBook.Worksheets[1];
            lastWorkSheet.Delete();
            excelApp.DisplayAlerts = true;

            //Set Defualt Page
            (excelWorkBook.Sheets[1] as OfficeExcel._Worksheet).Activate();

            excelWorkBook.SaveAs(strPath, Default, Default, Default, false, Default, OfficeExcel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
            excelWorkBook.Close();
            excelApp.Quit();

            MessageBox.Show("Excel generated successfully \n As " + strPath);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            //DataSet dsData = GetDataSet();
            //ExportDataSetToExcel(dsData, file.FileName);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx" + "|" +
                                //"Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                                "All Files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Enabled = false;//optional, better target a panel or specific controls
                    this.UseWaitCursor = true;//from the Form/Window instance
                    Application.DoEvents();//messages pumped to update controls

                    DataSet set = OnSearchByDocNo();
                    ExportDataSetToExcel(set, saveDialog.FileName);

                }
                finally
                {
                    this.Enabled = true;//optional
                    this.UseWaitCursor = false;
                }
            }

        }
        public DataSet OnSearchByDocNo()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            con.Open();

            string strsq = "TBREQUESTCONVERT_SP_Get_User_Level";

            SqlCommand command = new SqlCommand(strsq, con);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@SITE", "UB11");
            command.Parameters.Add("@LEVEL", "1");
            SqlDataReader reader = command.ExecuteReader();

            dt.Load(reader);
            dt.TableName = "TBREQUESTCONVERT_HD";
            ds.Tables.Add(dt);


            string strsql = "Select * from TBREQUESTCONVERT_DT";

            SqlCommand command1 = new SqlCommand(strsql, con);
            SqlDataReader reader1 = command1.ExecuteReader();
            dt1.Load(reader1);
            dt1.TableName = "TBREQUESTCONVERT_DT";
            ds.Tables.Add(dt1);


            string strsq2 = "Select * from TBREQUESTCONVERT_DT_RAWMAT";

            SqlCommand command2 = new SqlCommand(strsq2, con);
            SqlDataReader reader2 = command1.ExecuteReader();
            dt2.Load(reader2);
            dt2.TableName = "TBREQUESTCONVERT_DT_RAWMAT";
            ds.Tables.Add(dt2);

            con.Close();
            return ds;
        }
    }
}
