using Inventory.Client.BLL;
using Inventory.Client.DAL;
using Inventory.Client.Interface;
using Inventory.Client.WPF.ViewModels;
using Inventory.Client.WPF.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Inventory.Client.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<InventoryView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<OrderView, OrderViewModel>();
            containerRegistry.Register<Dispatcher>(() => Application.Current.Dispatcher);
            containerRegistry.Register<IStockDal, StockDal>();
            containerRegistry.Register<IOrderDal, OrderDal>();
            containerRegistry.Register<IStockService, StockService>();
            containerRegistry.Register<IOrderService, OrderService>();
            containerRegistry.RegisterSingleton<ILogHelper, LogHelper>();
        }
    }
}
