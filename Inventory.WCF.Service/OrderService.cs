using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    public class OrderService : BaseService
    {
        private OrderService() { }

        private static OrderService instance = null;

        public static OrderService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderService();
                }
                return instance;
            }
        }

        public List<Order> Orders { get; set; }

        public override void InitializeList()
        {
            if (Orders == null)
            {
                Orders = new List<Order>() { };
            }
        }
    }
}
