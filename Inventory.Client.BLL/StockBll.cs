using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class StockBll : IStockBll
    {
        IStockDal _stockDal;

        public StockBll(IStockDal stockDal)
        {
            _stockDal = stockDal;

        }
        public async Task<IEnumerable<Stock>> GetAll()
        {
            return await _stockDal.GetAll();
        }

        public async Task<IEnumerable<Stock>> Update(Stock stock)
        {
            return await _stockDal.Update(stock);
        }

    }
}
