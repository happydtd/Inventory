using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    public class StockService : BaseService
    {
        private StockService() { }

        private static StockService instance = null;

        public static StockService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StockService();
                }
                return instance;
            }
        }

        public List<Stock> Stocks { get; set; }

        public override void InitializeList()
        {
            if (Stocks == null)
            {
                Stocks = new List<Stock>() { 
                    new Stock(){Id=1, ProductId = 1, Quantity=1000 },
                    new Stock(){Id=2, ProductId = 2, Quantity=900 },
                    new Stock(){Id=3, ProductId = 3, Quantity=800 },
                    new Stock(){Id=4, ProductId = 4, Quantity=700 },
                    new Stock(){Id=5, ProductId = 5, Quantity=600 }
                };
            }
        }
    }
}
