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

namespace WindowsForms_Coppy
{
    public partial class Form1 : Form
    {
        List<Model_formart_input> listmodellist_number = new List<Model_formart_input>();
        public Form1()
        {
            InitializeComponent();
        }
        public void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            // Copy all files.
            FileInfo[] files = source.GetFiles();
            foreach (Modellist item in Get_file_name())
            {            
                foreach (FileInfo file in files)
                {
                    lb_status.Text = item.name_file + " <----> " + file.Name;

                    if (file.Name == item.name_file.Trim())
                    {
                        file.CopyTo(Path.Combine(destination.FullName, file.Name));
                    }
                }
            }
            MessageBox.Show("คัดลอกเรียบร้อย");

            // Process subdirectories.
            //DirectoryInfo[] dirs = source.GetDirectories();
            //foreach (DirectoryInfo dir in dirs)
            //{
            //    // Get destination directory.
            //    string destinationDir = Path.Combine(destination.FullName, dir.Name);

            //    // Call CopyDirectory() recursively.
            //    CopyDirectory(dir, new DirectoryInfo(destinationDir));
            //}
        }
        private void Btn_kod_Click_1(object sender, EventArgs e)
        {
            if (lb_position_from.Text == "คลิกเลือกตำแหน่งที่จะคัดลอก" || lb_position_to.Text == "คลิกเลือกตำแหน่งที่จะวาง")
            {
                if (lb_position_from.Text == "คลิกเลือกตำแหน่งที่จะคัดลอก")
                {
                    MessageBox.Show("กรุณาเลือกโฟลเดอร์ที่จะคัดลอก");
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกโฟลเดอร์ที่จะวาง");
                }
            }
            else
            {
                if (txt_file_name.Text.Trim().Length > 0)
                {
                    DirectoryInfo sourceDir = new DirectoryInfo(@"D:\poy\100CANON");
                    DirectoryInfo destinationDir = new DirectoryInfo(@"D:\poy\skyline");
                    Get_file_name();
                    CopyDirectory(sourceDir, destinationDir);
                }
                else
                {
                    MessageBox.Show("คุณยังไม่ได้จัดรูปแบบชื่อไฟล์");
                }
            }
        }
        public List<Modellist> Get_file_name()
        {
            string get_file_name;
            Modellist modellist;
            List<Modellist> listmodellist = new List<Modellist>();

            get_file_name = txt_file_name.Text.Trim();
            string[] authorsList = get_file_name.Split(',');

            foreach (string author in authorsList)
            {
                if (author != "")
                {
                    modellist = new Modellist();
                    modellist.name_file = author.Trim();

                    listmodellist.Add(modellist);
                }
            }
            return listmodellist;
        }
        public List<Model_formart_input> add_file_name_number()
        {
            string name_input;
            Model_formart_input modellist;

            name_input = txt_input_name.Text.Trim();
            string[] authorsList = name_input.Split(',');
            listmodellist_number = new List<Model_formart_input>();
            foreach (string author in authorsList)
            {
                if (author != "")
                {
                    modellist = new Model_formart_input();

                    modellist.name_file_input = author.Trim();

                    listmodellist_number.Add(modellist);
                }
            }           
            return listmodellist_number;
        }
        private void Btn_format_file_Name_Click(object sender, EventArgs e)
        {            
            int o = txt_input_name.Text.Trim().Length;
            int p = txt_name.Text.Trim().Length;
            if (p < 1 || o < 1)
            {
                if (o < 1)
                {                    
                    txt_input_name.Focus();
                }
                else
                {
                    txt_name.Focus();
                }
            }
            else
            {
                List<Model_formart_input> model_Formart_Inputs = new List<Model_formart_input>();
                model_Formart_Inputs = add_file_name_number();
                lb_Countfile.Text = "จำนวน " + model_Formart_Inputs.Count.ToString() + " ไฟล์";
                txt_file_name.Text = "";

                    foreach (Model_formart_input item in model_Formart_Inputs)
                    {
                        txt_file_name.Text += txt_name.Text + item.name_file_input + cbb_Dos.Text + ",";
                    }                
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbb_Dos.Text = ".CR2";
        }

        private void Lb_position_from_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "เลือกโฟลเดอร์ที่คุณจะคัดลอก";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                lb_position_from.Text = sSelectedPath;
            }
        }

        private void Lb_position_to_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "เลือกโฟลเดอร์ที่คุณจะวาง";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                lb_position_to.Text = sSelectedPath;
            }
        }
    }
    public class Modellist
    {
        public string name_file { get; set; }
    }
    public class Model_formart_input
    {
        public string name_file_input { get; set; }
    }
}
