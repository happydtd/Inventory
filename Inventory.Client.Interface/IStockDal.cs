using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.Interface
{
    public interface IStockDal
    {
        Task<IEnumerable<Stock>> GetAll();

        Task<IEnumerable<Stock>> Update(Stock stock);
    }
}
