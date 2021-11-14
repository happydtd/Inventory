using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Client.WPF.Views;
using Prism.Mvvm;
using System.Windows.Input;
using Prism.Commands;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Inventory.Client.WCF.CallBacks;
using Inventory.Client.WCF.WCFService;
using Inventory.Client.Interface;
using Inventory.Client.BLL;
using Inventory.Client.DAL;

namespace Inventory.Client.WPF.ViewModels
{
    public class InventoryViewModel: BindableBase
    {
        private IStockAndProductBll _stockAndProductBll;
        private IStockAndProductDal _stockAndProductDal;
        private ObservableCollection<StockAndProduct> _stocks;
        public ObservableCollection<StockAndProduct> Stocks
        {
            get { return _stocks; }
            set { SetProperty(ref _stocks, value); }
        }

        public ICommand ShowCommand
        {
            get;
            private set;
        }
        public InventoryViewModel()
        {
            _stockAndProductDal = new StockAndProductDal();
            _stockAndProductBll = new StockAndProductBll(_stockAndProductDal);

            ServerDataUpdated.RequestRefresh += ()=> Task.Run(Update);

            ShowCommand = new DelegateCommand(ShowMethod);

            Task.Run(Update);
        }
        private void ShowMethod()
        {
            OrderView objOrderWindow = new OrderView();
            objOrderWindow.Show();
        }

        private async Task Update()
        {
            var stockAndProducts = await _stockAndProductBll.GetAll();
            if (stockAndProducts != null)
            {
                Stocks = new ObservableCollection<StockAndProduct>(stockAndProducts);
            }
            //InstanceContext instanceContext = new InstanceContext(new ServerDataUpdated());

            //try
            //{
            //    InventoryAndOrderServiceClient client = new InventoryAndOrderServiceClient(instanceContext);

            //    var products = await client.GetProductsAsync();
            //    //Products = new ObservableCollection<Product>(products);
            //    var stocks = await client.GetStocksAsync();
            //}
            //catch(Exception ex)
            //{

            //}




        }
    }
}
