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
            //ServiceHost对象
            //既然是把一个服务要寄宿到主机中去的，主机要运行服务，必要要主机配置新；至少要为这个主机配置端口号；
            List<ServiceHost> hosts = new List<ServiceHost>()
            {
                new ServiceHost(typeof(InventoryAndOrderService)),
            };

            foreach (var host in hosts)
            {
                host.Opening += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备打开");
                host.Opened += (s, e) => Console.WriteLine($"{host.GetType().Name} 已经正常打开");
                host.Closing += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备关闭");
                host.Closed += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备关闭");
                host.Open();
            }
            Console.WriteLine("输入任何字符，就停止");
            Console.Read();
            foreach (var host in hosts)
            {
                host.Close();
            }
            Console.Read();
        }
    }
}
