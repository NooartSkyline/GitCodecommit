using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text;

namespace PlatformDetection
{
    internal partial class PInvoke
    {
        [DllImport("Coredll.dll", EntryPoint = "SystemParametersInfoW", CharSet = CharSet.Unicode)]
        static extern int SystemParametersInfo4Strings(uint uiAction, uint uiParam, StringBuilder pvParam, uint fWinIni);

        public enum SystemParametersInfoActions : uint
        {
            SPI_GETPLATFORMTYPE = 257, // this is used elsewhere for Smartphone/PocketPC detection
            SPI_GETOEMINFO = 258,
        }

        public static string GetPlatformType()
        {
            StringBuilder platformType = new StringBuilder(50);
            if (SystemParametersInfo4Strings((uint)SystemParametersInfoActions.SPI_GETPLATFORMTYPE,
                (uint)platformType.Capacity, platformType, 0) == 0)
                throw new Exception("Error getting platform type.");
            return platformType.ToString();
        }
    }

    internal partial class PlatformDetection
    {
        public static bool IsSmartphone()
        {
            return PInvoke.GetPlatformType() == "SmartPhone";
        }

        public static bool IsPocketPC()
        {
            return PInvoke.GetPlatformType() == "PocketPC";
        }

        public static string PlatformType()
        { 
         return PInvoke.GetPlatformType();
        }
    }

    //class PlatformProgram
    //{
    //    static void Main(string[] args)
    //    {
    //        string platform;
    //        if (PlatformDetection.IsSmartphone())
    //            platform = "Smartphone";
    //        else if (PlatformDetection.IsPocketPC())
    //            platform = "Pocket PC";
    //        else
    //            platform = "Other WinCE";
    //        MessageBox.Show("Platform: " + platform);
    //    }
    //}

}