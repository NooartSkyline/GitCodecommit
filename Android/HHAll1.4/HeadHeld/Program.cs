﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoHome.HandHeld.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //initializer mobile services.
            //var mobileServices = ServiceHelper.MobileServices;
            //MessageBox.Show(PlatformDetection.PlatformDetection.PlatformType(), "PlatformType");
            Utils.CompareUpdateVersion();            
             Application.Run(new LoginForm());
            
        }
    }
}