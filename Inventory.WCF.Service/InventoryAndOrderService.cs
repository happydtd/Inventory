using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class InventoryAndOrderService : IInventoryAndOrderService
    {
        OrderDataService _orderDataService;
        StockDataService _stockDataService;
        private static Dictionary<Guid, IInventoryAndOrderServiceCallBack> clients = new Dictionary<Guid, IInventoryAndOrderServiceCallBack>();
        public InventoryAndOrderService()
        {
            _orderDataService = new OrderDataService();
            _stockDataService = new StockDataService();
        }


        public bool CreateOrder(Guid stockid, string productname, int quantity)
        {
            Thread.Sleep(1500);
            //add new order to order list
            var orderUpdateResult = _orderDataService.Add(new Order() { Id = Guid.NewGuid(), ProductName = productname, Quantity = quantity });
            var stock = GetStockById(stockid);
            var newQuantity = stock.Quantity - quantity;
            stock.Quantity = newQuantity;
            //update stock list
            var stockUpdateResult = _stockDataService.Update(stock).Where(i => i.Id == stock.Id).FirstOrDefault().Quantity == newQuantity ? true : false;
            //send notic to all clients
            BroadcastMessage();
            //callBack.StockQuantityChanged();
            return orderUpdateResult && stockUpdateResult;
        }

        private void BroadcastMessage()
        {
            // Call each client's callback method
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (clients)
                    {
                        List<Guid> disconnectedClientGuids = new List<Guid>();
                        foreach (KeyValuePair<Guid, IInventoryAndOrderServiceCallBack> client in clients)
                        {
                            try
                            {
                                client.Value.StockQuantityChanged();
                            }
                            catch (Exception)
                            {
                                // TODO: Better to catch specific exception types.                     
                                // If a timeout exception occurred, it means that the server
                                // can't connect to the client. It might be because of a network
                                // error, or the client was closed  prematurely due to an exception or
                                // and was unable to unregister from the server. In any case, we 
                                // must remove the client from the list of clients.
                                // Another type of exception that might occur is that the communication
                                // object is aborted, or is closed.
                                // Mark the key for deletion. We will delete the client after the 
                                // for-loop because using foreach construct makes the clients collection
                                // non-modifiable while in the loop.
                                disconnectedClientGuids.Add(client.Key);
                            }
                        }
                        foreach (Guid clientGuid in disconnectedClientGuids)
                        {
                            clients.Remove(clientGuid);
                        }
                    }
                }
            );
        }


        public IEnumerable<Order> GetOrders()
        {
            Thread.Sleep(1500);
            return _orderDataService.Get();
        }

        public Stock GetStockById(Guid id)
        {
            Thread.Sleep(1500);
            return _stockDataService.Get(id);
        }

        public IEnumerable<Stock> GetStocks()
        {
            Thread.Sleep(1500);
            //notice client to update stock and order list
            IInventoryAndOrderServiceCallBack callBack = OperationContext.Current.GetCallbackChannel<IInventoryAndOrderServiceCallBack>();
            if (callBack != null)
            {
                lock (clients)
                {
                    clients.Add(Guid.NewGuid(), callBack);
                }
            }
            return _stockDataService.Get();
        }
    }
}
