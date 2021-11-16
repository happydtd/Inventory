using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Interface
{
    public interface IInventoryAndOrderServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void StockQuantityChanged();
    }
}
