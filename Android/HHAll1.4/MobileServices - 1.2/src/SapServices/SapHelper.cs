using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Configuration;

namespace SapServices
{
    public class SapHelper
    {
        private static RfcDestination _destination = null;

        public static RfcDestination Destination
        {
            get
            {
                //return RfcDestinationManager.GetDestination("DEV");

                if (_destination == null)
                {
                    var sapName = ConfigurationManager.AppSettings["SapName"];
                    var config = new MyBackendConfig();
                    _destination = RfcDestinationManager.GetDestination(config.GetParameters(sapName));
                }

                return _destination;

            }
        }

    }

    internal class MyBackendConfig : IDestinationConfiguration
    {
        public RfcConfigParameters GetParameters(String destinationName)
        {
            if ("DEV".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                //parms.Add(RfcConfigParameters.MessageServerHost, "some.ABAP.host");
                //parms.Add(RfcConfigParameters.LogonGroup, "PUBLIC");
                parms.Add(RfcConfigParameters.AppServerHost, "192.168.0.55");
                parms.Add(RfcConfigParameters.SystemNumber, "0");
                parms.Add(RfcConfigParameters.User, "TOMMY");
                parms.Add(RfcConfigParameters.Password, "123456789");
                parms.Add(RfcConfigParameters.Client, "300");
                parms.Add(RfcConfigParameters.Language, "TH");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "600");
                return parms;
            }
            else if ("QAS".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                //parms.Add(RfcConfigParameters.MessageServerHost, "some.ABAP.host");
                //parms.Add(RfcConfigParameters.LogonGroup, "PUBLIC");
                parms.Add(RfcConfigParameters.AppServerHost, "192.168.0.54");
                parms.Add(RfcConfigParameters.SystemNumber, "0");
                parms.Add(RfcConfigParameters.User, "INTERFACE");
                parms.Add(RfcConfigParameters.Password, "stable");
                parms.Add(RfcConfigParameters.Client, "500");
                parms.Add(RfcConfigParameters.Language, "TH");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "600");
                return parms;
            }
            else if ("PRD".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                //parms.Add(RfcConfigParameters.MessageServerHost, "some.ABAP.host");
                //parms.Add(RfcConfigParameters.LogonGroup, "PUBLIC");
                parms.Add(RfcConfigParameters.AppServerHost, "192.168.0.52");
                parms.Add(RfcConfigParameters.SystemNumber, "0");
                parms.Add(RfcConfigParameters.User, "INTERFACE");
                parms.Add(RfcConfigParameters.Password, "stable");
                parms.Add(RfcConfigParameters.Client, "900");
                parms.Add(RfcConfigParameters.Language, "TH");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.MaxPoolSize, "10");
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
