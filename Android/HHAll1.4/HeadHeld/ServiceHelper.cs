using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace DoHome.HandHeld.Client
{
    class ServiceHelper
    {
        static MobileServiceClient mobileServices;
        public static MobileServiceClient MobileServices
        {

            get
            {
                if (mobileServices == null)
                {
                    var binding = MobileServiceClient.CreateDefaultBinding();

                    //string remoteAddress = MobileServiceClient.EndpointAddress.Uri.ToString();
                    string remoteAddress = GlobalContext.remoteAddress;
                    remoteAddress = remoteAddress.Replace("localhost", GlobalContext.ServerEndpointAddress);
                    EndpointAddress endpoint = new EndpointAddress(remoteAddress);
                    binding.OpenTimeout = TimeSpan.FromMinutes(15);
                    binding.ReceiveTimeout = TimeSpan.FromMinutes(15);
                    binding.SendTimeout = TimeSpan.FromMinutes(30);
                    MobileServiceClient client = new MobileServiceClient(binding, endpoint);
                    mobileServices = client;
                }
                return mobileServices;
            }
        }
        public static void MobileServicesDispose()
        {
            if (mobileServices != null)
                mobileServices = null;
        }

    }
}
