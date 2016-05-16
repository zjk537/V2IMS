using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Vogue2_IMS.DataService;

namespace Vogue2_IMS.Servict.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(DataService.DataService));

            host.Open();

            Console.WriteLine("Service Opened");

            Console.ReadLine();
        }
    }
}
