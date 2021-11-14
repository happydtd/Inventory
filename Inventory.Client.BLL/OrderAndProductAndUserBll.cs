using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class OrderAndProductAndUserBll : IOrderAndProductAndUserBll
    {
        IOrderAndProductAndUserDal _orderAndProductAndUserDal;

        public OrderAndProductAndUserBll(IOrderAndProductAndUserDal orderAndProductAndUserDal)
        {
            _orderAndProductAndUserDal = orderAndProductAndUserDal;

        }
        public Task<IEnumerable<OrderAndProductAndUser>> Query(User user)
        {
            return _orderAndProductAndUserDal.Query(user);
        }
    }
}
