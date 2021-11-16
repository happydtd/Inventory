using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.Interface
{
    public interface IOrderDal
    {
        Task<IEnumerable<Order>> GetAll();

        Task<bool> CreateOrder(Guid stockid, string productname, int quantity);
    }
}
