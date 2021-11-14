using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Client.WCF.CallBacks
{
    [CallbackBehaviorAttribute(UseSynchronizationContext = false)]
    public class ServerDataUpdated: WCFService.IInventoryAndOrderServiceCallback
    {
        public static Action RequestRefresh;

        public void InventoryUpdated()
        {
            RequestRefresh?.Invoke();
        }
    }
}
