using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
using System.Xml;

namespace DoHome.MobileService
{
    class Server
    {
        static void Main(string[] args)
        {

            Uri address = new Uri(string.Format(@"http://{0}:8000/MobileService", ConfigurationManager.AppSettings["MobileServiceServer"]));
            ServiceHost serviceHost = new ServiceHost(typeof(MobileService), address);
            try
            {
                var binding = new BasicHttpBinding
                {
                    MaxBufferPoolSize = int.MaxValue,
                    MaxBufferSize = int.MaxValue,
                    MaxReceivedMessageSize = int.MaxValue,
                    TransferMode = TransferMode.Buffered
                };
                XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();
                readerQuotas.MaxArrayLength = int.MaxValue;
                readerQuotas.MaxDepth = 32;
                readerQuotas.MaxStringContentLength = int.MaxValue;
                readerQuotas.MaxBytesPerRead = int.MaxValue;
                readerQuotas.MaxNameTableCharCount = int.MaxValue;
                binding.ReaderQuotas = readerQuotas;



                // Add a service endpoint
                serviceHost.AddServiceEndpoint(
                    typeof(IMobileService),
                    binding,
                    "MobileService");

                // Enable metadata exchange - this is needed for NetCfSvcUtil to discover us
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                serviceHost.Description.Behaviors.Add(smb);

                serviceHost.Open();

                Console.WriteLine("MobileService is running at " + address.ToString());
            Confirm:
                Console.Write("Press <ENTER> \"q\" to terminate");
                if ("q".Equals(Console.ReadLine()))
                {
                    // Close the ServiceHostBase to shutdown the service.
                    serviceHost.Close();
                }
                else
                {
                    goto Confirm;
                }
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occured: {0}", ce.Message);
                serviceHost.Abort();
            }
            finally
            {

            }
        }

    }
}
