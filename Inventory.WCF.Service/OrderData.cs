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
    public class OrderData : BaseService
    {
        private OrderData() { }

        private static OrderData instance = null;

        public static OrderData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderData();
                }
                return instance;
            }
        }

        public List<Order> Orders { get; set; }

        public void InitializeList()
        {
            if (Orders == null)
            {
                Orders = new List<Order>() { };
            }
        }
    }
}
