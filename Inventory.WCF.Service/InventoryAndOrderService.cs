using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    public class InventoryAndOrderService : IInventoryAndOrderService
    {
        ProductService _productService = ProductService.Instance;
        UserService _userService = UserService.Instance;
        StockService _stockService = StockService.Instance;
        OrderService _orderService = OrderService.Instance;
        public InventoryAndOrderService()
        {
            _userService.InitializeList();
            _productService.InitializeList();
            _stockService.InitializeList();
            _orderService.InitializeList();
        }

        //public void DeleteProduct(int id)
        //{
        //    _productService.Products = _productService.Delete<Product>(_productService.Products, id).ToList();

        //    ICallBack callBack = OperationContext.Current.GetCallbackChannel<ICallBack>(); //获取客户端实现的ICallBack接口的实例；
        //    callBack.InventoryUpdated();
        //}

        public List<Product> GetProducts()
        {
            return _productService.Products;
        }

        public List<User> GetUsers()
        {
            return _userService.Users;
        }

        public List<Stock> GetStocks()
        {
            return _stockService.Stocks;
        }

        public List<Stock> UpdateStock(Stock stock)
        {
           return _stockService.Update<Stock>(_stockService.Stocks, stock).ToList();
        }

        public List<Order> GetOrders()
        {
            return _orderService.Orders;
        }

        public List<Order> AddOrders(Order order)
        {
            return _orderService.Insert(_orderService.Orders, order).ToList();
        }

        public List<StockAndProduct> GetStockAndProducts()
        {
            var stocks = _stockService.Stocks;
            var products = _productService.Products;

            if (stocks!= null && products != null && stocks.Count>0 && products.Count >0)
            {
                return stocks.Join(products, s => s.ProductId, p => p.Id, (Stock, Product) => new { Stock, Product })
                    .Select(i=>new StockAndProduct() {Id = i.Stock.Id, ProductId = i.Stock.ProductId, ProductName=i.Product.ProductName, Quantity = i.Stock.Quantity }).ToList();
            }
            return null;
        }

        public List<OrderAndProductAndUser> GetOrderAndProductAndUsers(User user)
        {
            var orders = _orderService.Orders;
            var products = _productService.Products;

            if (orders != null && products != null && orders.Count > 0 && products.Count > 0)
            {
                return orders.Where(o=>o.UserId == user.Id)?.Join(products, o => o.ProductId, p => p.Id, (Order, Product) => new { Order, Product })
                    .Select(i => new OrderAndProductAndUser() { Id = i.Order.Id, ProductId = i.Order.ProductId, ProductName = i.Product.ProductName, Quantity = i.Order.Quantity, UserId = user.Id, Timestamp = i.Order.Timestamp }).ToList();
            }
            return null;
        }
    }
}
