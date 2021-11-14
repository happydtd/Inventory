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
    public class OrderAndProductAndUserDal : IOrderAndProductAndUserDal
    {
        InstanceContext instanceContext = new InstanceContext(new ServerDataUpdated());
        public async Task<IEnumerable<OrderAndProductAndUser>> Query(User user)
        {
            InventoryAndOrderServiceClient client = null;
            try
            {
                client = new InventoryAndOrderServiceClient(instanceContext);
                return await client.GetOrderAndProductAndUsersAsync(user);
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
