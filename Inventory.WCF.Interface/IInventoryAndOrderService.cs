using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Interface
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IInventoryAndOrderService
    {
        [OperationContract]
        List<Product> GetProducts();

        ////for testing
        //[OperationContract]
        //void DeleteProduct(int id);

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        List<Stock> GetStocks();

        [OperationContract]
        List<Stock> UpdateStock(Stock stock);

        [OperationContract]
        List<Order> GetOrders();

        [OperationContract]
        List<Order> AddOrders(Order order);

        [OperationContract]
        List<StockAndProduct> GetStockAndProducts();

        [OperationContract]
        List<OrderAndProductAndUser> GetOrderAndProductAndUsers(User user);
    }
}
