using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    public class StockDataService: IStockDataService
    {
        StockData _stockData = StockData.Instance;
        public StockDataService()
        {
            _stockData.InitializeList();
        }

        public IEnumerable<Stock> Get()
        {
            return _stockData.Stocks;
        }

        public Stock Get(Guid id)
        {
            return _stockData.Find(_stockData.Stocks, id);
        }

        public IEnumerable<Stock> Update(Stock stock)
        {
            return _stockData.Update(_stockData.Stocks, stock);
        }
    }
}
