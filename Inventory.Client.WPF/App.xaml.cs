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
            containerRegistry.Register<OrderView>();


            //containerRegistry.RegisterSingleton<IAppSettings, AppSettingsFromConfig>();
            //containerRegistry.RegisterSingleton<IMolemaxRepository, SqlMolemaxRepository>();
        }
    }
}
