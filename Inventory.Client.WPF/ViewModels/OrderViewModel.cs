using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Inventory.Client.WCF.CallBacks;
using Prism.Commands;
using Prism.Mvvm;

namespace Inventory.Client.WPF.ViewModels
{
    public class OrderViewModel: BindableBase
    {
        public DelegateCommand GetProductCommand { get; set; }

        public OrderViewModel()
        {
            GetProductCommand = new DelegateCommand(()=> Task.Run(GetProduct));
        }

        private async Task GetProduct()
        {
            //InstanceContext instanceContext = new InstanceContext(new ServerDataUpdated());
            //using (WCFInventoryAndOrderService.InventoryAndOrderServiceClient client = new WCFInventoryAndOrderService.InventoryAndOrderServiceClient(instanceContext))
            //{
            //    var products = await client.GetProductsAsync();
            //    //await client.DeleteProductAsync(1);
            //    products = await client.GetProductsAsync();
            //}
        }
    }
}
