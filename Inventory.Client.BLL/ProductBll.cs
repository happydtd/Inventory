using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class ProductBll:IProductBll
    {
        IProductDal _productDal;

        public ProductBll(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productDal.GetAll();
        }
    }
}
