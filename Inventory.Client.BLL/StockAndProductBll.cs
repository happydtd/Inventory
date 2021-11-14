using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class StockAndProductBll : IStockAndProductBll
    {
        IStockAndProductDal _stockAndProductDal;

        public StockAndProductBll(IStockAndProductDal stockAndProductDal)
        {
            _stockAndProductDal = stockAndProductDal;

        }
        public Task<IEnumerable<StockAndProduct>> GetAll()
        {
            return _stockAndProductDal.GetAll();
        }
    }
}
