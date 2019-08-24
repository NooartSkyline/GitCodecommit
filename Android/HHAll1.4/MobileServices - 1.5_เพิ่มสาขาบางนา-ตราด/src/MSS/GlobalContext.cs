using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DoHome.MobileService
{
    public class GlobalContext
    {
        static SAP.Connector.Destination _sapDestination;
        static short _sapClient;

        public static SAP.Connector.Destination SapDestination
        {
            get
            {
                if (_sapDestination == null || _sapClient != Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]))
                {
                    _sapClient = Convert.ToInt16(ConfigurationManager.AppSettings["SapClient"]);
                    _sapDestination = new SAP.Connector.Destination();
                    _sapDestination.Client = _sapClient;

                    switch (_sapClient)
                    {
                        case 300:
                            break;
                        case 500:
                            _sapDestination.AppServerHost = "192.168.0.54";
                            _sapDestination.SystemNumber = 0;
                            _sapDestination.Username = "INTERFACE";
                            _sapDestination.Password = "stable";
                            break;
                        case 900:
                            _sapDestination.AppServerHost = "192.168.0.52";
                            _sapDestination.SystemNumber = 0;
                            _sapDestination.Username = "INTERFACE";
                            _sapDestination.Password = "stable";
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

        public static string AccountingYear { get { return ConfigurationManager.AppSettings["AccountingYear"].ToString(); } }

    }
}