using Inventory.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Project
{
    public class ServiceInit
    {
        public static void Process()
        {
            List<ServiceHost> hosts = new List<ServiceHost>()
            {
                new ServiceHost(typeof(InventoryAndOrderService)),
            };

            foreach (var host in hosts)
            {
                host.Opened += (s, e) => Console.WriteLine($"{host.GetType().Name} opened");
                host.Open();
            }
            Console.WriteLine("Enter and key to quit.");
            Console.Read();
            foreach (var host in hosts)
            {
                host.Close();
            }
        }
    }
}
