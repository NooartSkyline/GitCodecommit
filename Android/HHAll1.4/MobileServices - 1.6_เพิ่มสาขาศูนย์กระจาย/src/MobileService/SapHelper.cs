using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;
using System.Configuration;

namespace DoHome.MobileService
{
    public class SapHelper
    {
        private static RfcDestination _destination = null;

        public static RfcDestination Destination
        {
            get
            {
                if (_destination == null)
                {
                    var sapName = ConfigurationManager.AppSettings["SapName"];
                    RfcDestinationManager.RegisterDestinationConfiguration(new MyBackendConfig());
                    _destination = RfcDestinationManager.GetDestination(sapName);
                }

                return _destination;
            }
        }
    }

    public class MyBackendConfig : IDestinationConfiguration
    {
        public RfcConfigParameters GetParameters(String destinationName)
        {
            if ("DEV".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.AppServerHost, ConfigurationManager.AppSettings["AppServerHost"]);
                parms.Add(RfcConfigParameters.SystemNumber, ConfigurationManager.AppSettings["SystemNumber"]);
                parms.Add(RfcConfigParameters.User, "INTERFACE");
                parms.Add(RfcConfigParameters.Password, "stable");
                parms.Add(RfcConfigParameters.Client, ConfigurationManager.AppSettings["SapClient"]);
                parms.Add(RfcConfigParameters.Language, "TH");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.PeakConnectionsLimit, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "600");

                return parms;
            }
            else if ("QAS".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.AppServerHost, ConfigurationManager.AppSettings["AppServerHost"]);
                parms.Add(RfcConfigParameters.SystemNumber, ConfigurationManager.AppSettings["SystemNumber"]);
                parms.Add(RfcConfigParameters.User, "INTERFACE");
                parms.Add(RfcConfigParameters.Password, "stable");
                parms.Add(RfcConfigParameters.Client, ConfigurationManager.AppSettings["SapClient"]);
                parms.Add(RfcConfigParameters.Language, "TH");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.PeakConnectionsLimit, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "600");
                return parms;
            }
            else if ("PRD".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.AppServerHost, ConfigurationManager.AppSettings["AppServerHost"]);
                parms.Add(RfcConfigParameters.SystemNumber, ConfigurationManager.AppSettings["SystemNumber"]);
                parms.Add(RfcConfigParameters.User, "INTERFACE");
                parms.Add(RfcConfigParameters.Password, "stable");
                parms.Add(RfcConfigParameters.Client, ConfigurationManager.AppSettings["SapClient"]);
                parms.Add(RfcConfigParameters.Language, "TH");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.PeakConnectionsLimit, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "600");
                return parms;
            }
            else return null;
        }

        // The following two are not used in this example:
        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
    }

}