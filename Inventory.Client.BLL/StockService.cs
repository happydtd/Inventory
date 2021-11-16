using Inventory.Client.Interface;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.BLL
{
    public class StockService : IStockService
    {
        IStockDal _stockDal;

        public StockService(IStockDal stockDal)
        {
            _stockDal = stockDal;

        }
        public async Task<IEnumerable<Stock>> GetAll()
        {
            return await _stockDal.GetAll();
        }

        public async Task<Stock> GetById(Guid id)
        {
            return await _stockDal.GetById(id);
        }

    }
}
