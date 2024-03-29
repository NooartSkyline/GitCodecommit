﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DoHome.MobileService
{
    public class GlobalContext
    {
        static SAP.Connector.Destination _sapDestination;
        //static short _sapClient;

        public static SAP.Connector.Destination SapDestination
        {
            get
            {
                //if (_sapDestination == null || _sapClient != Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]))
                if (_sapDestination == null)
                {
                    //_sapClient = Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]);
                    var SID = ConfigurationManager.AppSettings["SapName"];
                    _sapDestination = new SAP.Connector.Destination();
                    //_sapDestination.Client = _sapClient;

                    switch (SID)
                    {
                        case "DEV":
                            _sapDestination.AppServerHost = ConfigurationManager.AppSettings["AppServerHost"];
                            _sapDestination.SystemNumber = Convert.ToInt16(ConfigurationManager.AppSettings["SystemNumber"]);
                            _sapDestination.Username = "INTERFACE";
                            _sapDestination.Password = "stable";
                            _sapDestination.Client = Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]);
                            break;
                        case "QAS":
                            _sapDestination.AppServerHost = ConfigurationManager.AppSettings["AppServerHost"];
                            _sapDestination.SystemNumber = Convert.ToInt16(ConfigurationManager.AppSettings["SystemNumber"]);
                            _sapDestination.Username = "INTERFACE";
                            _sapDestination.Password = "stable";
                            _sapDestination.Client = Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]);
                            break;
                        case "PRD":
                            _sapDestination.AppServerHost = ConfigurationManager.AppSettings["AppServerHost"];
                            _sapDestination.SystemNumber = Convert.ToInt16(ConfigurationManager.AppSettings["SystemNumber"]);
                            _sapDestination.Username = "INTERFACE";
                            _sapDestination.Password = "stable";
                            _sapDestination.Client = Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]);
                            break;
                        default:
                            break;
                    }

                }

                return _sapDestination;
            }
        }

        //SAP.Connector.Destination sapDestination = new SAP.Connector.Destination();
        //    sapDestination.AppServerHost = ConfigurationManager.AppSettings["SapAppServerHost"];
        //    sapDestination.Client = Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]);
        //    sapDestination.SystemNumber = Convert.ToInt16(ConfigurationManager.AppSettings["SapSystemNumber"]);
        //    sapDestination.Username = ConfigurationManager.AppSettings["SapUsername"];
        //    sapDestination.Password = ConfigurationManager.AppSettings["SapPassword"];

        //    return sapDestination;

        public static string AccountingYear { get { return DateTime.Now.Year.ToString (); } }

    }
}