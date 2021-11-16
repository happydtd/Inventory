using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    public class OrderDataService: IOrderDataService
    {
        OrderData _orderData = OrderData.Instance;
        public OrderDataService()
        {
            _orderData.InitializeList();
        }

        public IEnumerable<Order> Get()
        {
            return _orderData.Orders;
        }

        public bool Add(Order order)
        {
            var orders = _orderData.Add(_orderData.Orders, order);
            if (orders.Where(i => i.Id == order.Id).Count() > 0)
                return true;
            else
                return false;
        }
    }
}
