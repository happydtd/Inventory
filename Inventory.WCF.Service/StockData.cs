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
    public class StockData :BaseService
    {
        private StockData() { }

        private static StockData instance = null;

        public static StockData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StockData();
                }
                return instance;
            }
        }

        public List<Model.Stock> Stocks { get; set; }

        public void InitializeList()
        {
            if (Stocks == null)
            {
                Stocks = new List<Model.Stock>() { 
                    new Model.Stock(){ Id= Guid.NewGuid(), ProductName = "Toyota Camry", Quantity=1000 },
                    new Model.Stock(){ Id= Guid.NewGuid(), ProductName = "Ford Falcon", Quantity=900 },
                    new Model.Stock(){ Id= Guid.NewGuid(), ProductName = "Audi A5", Quantity=800 },
                    new Model.Stock(){ Id= Guid.NewGuid(), ProductName = "BMW X3", Quantity=700 },
                    new Model.Stock(){ Id= Guid.NewGuid(), ProductName = "Tesla Model X", Quantity=600 }
                };
            }
        }
    }
}
