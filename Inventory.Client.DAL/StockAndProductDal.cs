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
    public class StockAndProductDal :IStockAndProductDal
    {
        public async Task<IEnumerable<StockAndProduct>> GetAll()
        {
            InstanceContext instanceContext = new InstanceContext(new ServerDataUpdated());
            InventoryAndOrderServiceClient client = null;
            try
            {
                client = new InventoryAndOrderServiceClient(instanceContext);
                return await client.GetStockAndProductsAsync();
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
