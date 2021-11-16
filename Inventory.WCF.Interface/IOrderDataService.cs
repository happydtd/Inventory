using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Interface
{
    public interface IOrderDataService
    {
        IEnumerable<Order> Get();

        bool Add(Order order);
    }
}
