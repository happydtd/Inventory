using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Interface
{
    [ServiceContract(CallbackContract = typeof(IInventoryAndOrderServiceCallBack))]
    public interface IInventoryAndOrderService
    {
        [OperationContract]
        bool CreateOrder(Guid stockid, string productname, int quantity);

        [OperationContract]
        IEnumerable<Stock> GetStocks();

        [OperationContract]
        Stock GetStockById(Guid id);


        [OperationContract]
        IEnumerable<Order> GetOrders();
    }
}
