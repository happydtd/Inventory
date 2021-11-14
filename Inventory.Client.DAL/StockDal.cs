using Inventory.Client.Interface;
using Inventory.Client.WCF.CallBacks;
using Inventory.Client.WCF.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.DAL
{
    public class StockDal : IStockDal
    {
        InstanceContext instanceContext = new InstanceContext(new ServerDataUpdated());

        public async Task<IEnumerable<Stock>> GetAll()
        {
            InventoryAndOrderServiceClient client = null;
            try
            {
                client = new InventoryAndOrderServiceClient(instanceContext);
                return await client.GetStocksAsync();
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    client.Abort();
                }

                throw;
            }
        }

        public async Task<IEnumerable<Stock>> Update(Stock stock)
        {
            InventoryAndOrderServiceClient client = null;
            try
            {
                client = new InventoryAndOrderServiceClient(instanceContext);
                return await client.UpdateStockAsync(stock);
            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    client.Abort();
                }

                throw;
            }
        }
    }
}
