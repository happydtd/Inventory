using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class OrderService : IOrderService
    {
        IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<bool> CreateOrder(Guid stockid, string productname, int quantity)
        {
            return await _orderDal.CreateOrder(stockid, productname, quantity);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderDal.GetAll();
        }
    }
}
