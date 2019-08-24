using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;

namespace DoHome.HandHeld.Client
{
    public class Utils
    {
        public static void FormSetCenterSceen(System.Windows.Forms.Form form)
        {
            form.Location = new Point(
               (Screen.PrimaryScreen.WorkingArea.Width / 2) - (form.Width / 2),
               (Screen.PrimaryScreen.WorkingArea.Height / 2) - (form.Height / 2));
        }

        public static decimal DecimalParse(string expression)
        {
            double number;
            IsNumeric(expression, out number);

            return Convert.ToDecimal(number);
        }

        public static double DoubleParse(string expression)
        {
            double number;
            IsNumeric(expression, out number);

            return number;
        }

        public static int Int32Parse(string expression)
        {
            double number;
            IsNumeric(expression, out number);

            return Convert.ToInt32(number);
        }

        private static bool IsNumeric(object expression, out double number)
        {
            bool isNumeric = false;
            if (expression == null)
            {
                number = 0;
                isNumeric = false;
            }
            else
            {
                try
                {
                    number = Convert.ToDouble(expression);
                    isNumeric = true;
                }
                catch
                {
                    number = 0;
                    isNumeric = false;
                }
            }

            return isNumeric;
        }

        //public static int GetPubLeveByLocationCode(string locationCode)
        //{
        //    int _putLevel = 0;
        //    if (locationCode.Length == 10)
        //    {
        //        _putLevel = Int32Parse(locationCode.Substring(7, 2));
        //    }
        //    return _putLevel;
        //}

        public static string GetLocationTypeByLocationCode(string locationCode)
        {
            string locationType = string.Empty;
            if (locationCode.Length == 10)
            {
                locationType = locationCode.Substring(9, 1).ToUpper();
            }
            return locationType;
        }

        public static bool CheckLocationIsTopLevel(string locationCode)
        {
            if (locationCode.Length == 10)
            {
                if ("T".Equals(locationCode.Substring(9, 1).ToUpper()))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool CheckLocationIsLocation(string locationCode)
        {
            if (!string.IsNullOrEmpty(locationCode))
            {
                var prefix = locationCode.Substring(0, 1);
                return Int32Parse(prefix) == 0;
            }
            else
                return false;
        }

        public static bool CheckIsDigitOnly(string value)
        {
            bool isDigit = true;
            foreach (char c in value)
            {
                if (!Char.IsDigit(c))
                {
                    isDigit = false;
                    break;
                }
            }

            return isDigit;
        }

        public static string ProductVersion
        {
            get
            {
                //return string.Format("DPDA v.{0} Released 2012.01.06", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3));
                return string.Format("DPDA v.{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3));
            }
        }

        public static void CompareUpdateVersion()
        {
            string url = string.Format(@"http://{0}/update.xml", GlobalContext.ServerEndpointAddress);
            var callingAssembly = System.Reflection.Assembly.GetCallingAssembly();
            Version currentVersion = callingAssembly.GetName().Version;
            Version newVersion;
            XmlNodeList versions;
            XmlNodeList messages;
            WebRequest wr = WebRequest.Create(url);
            wr.ContentType = "text/xml";
            try
            {
                using (WebResponse response = wr.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(responseStream);
                        versions = xDoc.GetElementsByTagName("version");
                        messages = xDoc.GetElementsByTagName("message");
                    }
                }

                newVersion = new Version(
                int.Parse(versions[0].Attributes["maj"].Value),
                int.Parse(versions[0].Attributes["min"].Value),
                int.Parse(versions[0].Attributes["bld"].Value));

                if (currentVersion.CompareTo(newVersion) < 0)
                {
                    //new version available.
                    MessageBox.Show(messages[0].InnerText, "แจ้งเตือนการอัพเดทโปรแกรม");
                }

            }
            catch (WebException wex)
            {
                Console.WriteLine(wex);
            }

        }
    }
}
