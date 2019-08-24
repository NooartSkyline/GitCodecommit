using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPort_Test
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            sp.PortName = "COM9";
            sp.BaudRate = 115200;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Parity = Parity.None;

            sp.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            sp.Open();
        }

        //The use of proxy data reception
        private delegate void myDelegate(string s);

        private void SetText(string s)
        {

            listBox1.Items.Add(s);

        }


        //Serial data arrive event
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //The key agent
            myDelegate md = new myDelegate(SetText);

            try
            {
                if (sp.IsOpen == true)
                {
                    byte[] readBuffer = new byte[sp.ReadBufferSize];
                    sp.Read(readBuffer, 0, readBuffer.Length);
                    string readstr = Encoding.UTF8.GetString(readBuffer);

                    Invoke(md, readstr);
                }
            }
            catch (Exception err)
            {
                throw err;
            }


        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                string st1 = textBox1.Text;
                sp.WriteLine(st1);
                textBox1.Text = "";
            }
        }
    }
}