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
using Prism.Services.Dialogs;
using System.Windows;
using System.Windows.Threading;
using Unity;

namespace Inventory.Client.WPF.ViewModels
{
    public class InventoryViewModel: BindableBase, ICloseWindows
    {
        private IDialogService _dialogService;
        private IStockService _stockService;
        private IStockDal _stockDal;
        private ILogHelper _logHelper;
        private Dispatcher _dispatcher;

        #region property
        private bool _isEnable;
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }

        private ObservableCollection<Stock> _stocks;
        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set 
            {
                SetProperty(ref _stocks, value);
            }
        }

        private Stock _selectedStock;
        public Stock SelectedStock
        {
            get { return _selectedStock; }
            set
            {
                SetProperty(ref _selectedStock, value);
                if (_selectedStock != null)
                {
                    IsEnable = true;
                }
                else
                {
                    IsEnable = false;
                }
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }
        #endregion

        public DelegateCommand OpenOrderCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        public Action Close { get; set; }

        public InventoryViewModel(IDialogService dialogService, IStockService stockService, IStockDal stockDal, ILogHelper logHelper, IUnityContainer unityContainer)
        {
            _dialogService = dialogService;
            _stockDal = stockDal;
            _stockService = stockService;
            _logHelper = logHelper;
            _dispatcher = unityContainer.Resolve<Dispatcher>();

            IsEnable = false;
            Message = "Welcome!";
            //call back from WCF
            ServerDataUpdated.RequestRefresh += ()=> Task.Run(Update);

            OpenOrderCommand = new DelegateCommand(OpenOrder).ObservesCanExecute(()=>IsEnable);
            ExitCommand = new DelegateCommand(Exit);

            Update();
        }

        private void Exit()
        {
            Close?.Invoke();
        }

        private void OpenOrder()
        {
            _logHelper.Debug(this, "Pop up Order form");
            var parameters = new DialogParameters
            {
                { "SelectedStock", SelectedStock },
                { "Stocks", Stocks.ToList()}
            };

            _dialogService.Show("OrderView", parameters, async r =>
            {
                //if (r.Result == ButtonResult.OK)
                //{
                //    IsEnable = false;
                //    await Update();
                //}
            });

        }

        private async Task Update()
        {
            IEnumerable<Stock> stocks;
            _dispatcher.Invoke(() =>
            {
                Message = "Loading data from server......";
                IsEnable = false;
                _logHelper.Debug(this, Message);
            });

            try
            {
                stocks = await _stockService.GetAll();
                _logHelper.Debug(this, "Get all stocks from server");
            }
            catch(Exception ex)
            {
                _logHelper.Error(this, "Error occur: " + ex.Message);
                Message = "Can't load data from server, please restart application!";
                return;
            }

            _dispatcher.Invoke(() =>
            {
                if (stocks != null)
                {
                    Stocks = new ObservableCollection<Stock>(stocks);
                    SelectedStock = stocks.First();
                    Message = "Data updated";
                    _logHelper.Debug(this, "Data updated");
                }
            });

        }
    }
    public interface ICloseWindows
    {
        Action Close { get; set; }
    }
}
