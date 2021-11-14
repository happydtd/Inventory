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
    public class ProductService : BaseService
    {
        private ProductService() { }

        private static ProductService instance = null;

        public static ProductService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductService();
                }
                return instance;
            }
        }

        public List<Product> Products { get; set; }

        public override void InitializeList()
        {
            if (Products == null)
            {
                Products = new List<Product>() { 
                    new Product(){Id=1, ProductName="Apple phone"},
                    new Product(){Id=2, ProductName="Samsung phone"},
                    new Product(){Id=3, ProductName="Xiaomi phone"},
                    new Product(){Id=4, ProductName="Nokia phone"},
                    new Product(){Id=5, ProductName="Sony phone"},
                };
            }
        }
    }
}
