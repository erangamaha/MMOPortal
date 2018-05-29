using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MMOPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost;
            NetTcpBinding netTcpBinding = new NetTcpBinding();

            serviceHost = new ServiceHost(typeof(MMOPortalController));
            serviceHost.AddServiceEndpoint(typeof(IMMOPortalController), netTcpBinding, "net.tcp://localhost:50002/MMOPortal");
            netTcpBinding.MaxReceivedMessageSize = Int32.MaxValue;
            netTcpBinding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;

            serviceHost.Open();
            Console.WriteLine("Press any key to Exit...");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
