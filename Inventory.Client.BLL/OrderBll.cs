using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class OrderBll : IOrderBll
    {
        IOrderDal _orderDal;

        public OrderBll(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<IEnumerable<Order>> AddOrder(Order order)
        {
            return await _orderDal.AddOrder(order);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderDal.GetAll();
        }
    }
}
