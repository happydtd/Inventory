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
    public class InventoryAndOrderService : IInventoryAndOrderService
    {
        int sleep = 5000;
        OrderDataService _orderDataService;
        StockDataService _stockDataService;
        public InventoryAndOrderService()
        {
            _orderDataService = new OrderDataService();
            _stockDataService = new StockDataService();
        }


        public bool CreateOrder(Guid stockid, string productname, int quantity)
        {
            Thread.Sleep(5000);
            //add new order to order list
            var orderUpdateResult = _orderDataService.Add(new Order() { Id = Guid.NewGuid(), ProductName = productname, Quantity = quantity });
            var stock = GetStockById(stockid);
            var newQuantity = stock.Quantity - quantity;
            stock.Quantity = newQuantity;
            //update stock list
            var stockUpdateResult = _stockDataService.Update(stock).Where(i => i.Id == stock.Id).FirstOrDefault().Quantity == newQuantity ? true : false;

            //notice client to update stock and order list
            IInventoryAndOrderServiceCallBack callBack = OperationContext.Current.GetCallbackChannel<IInventoryAndOrderServiceCallBack>();
            callBack.StockQuantityChanged();
            return orderUpdateResult && stockUpdateResult;
        }

        public IEnumerable<Order> GetOrders()
        {
            Thread.Sleep(5000);
            return _orderDataService.Get();
        }

        public Stock GetStockById(Guid id)
        {
            Thread.Sleep(5000);
            return _stockDataService.Get(id);
        }

        public IEnumerable<Stock> GetStocks()
        {
            Thread.Sleep(5000);
            return _stockDataService.Get();
        }
    }
}
