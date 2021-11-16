using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Inventory.Client.BLL;
using Inventory.Client.DAL;
using Inventory.Client.Interface;
using Inventory.Client.WCF.CallBacks;
using Inventory.Client.WCF.WCFService;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Unity;

namespace Inventory.Client.WPF.ViewModels
{
    public class OrderViewModel: BindableBase, IDialogAware
    {
        private IStockService _stockService;
        private IStockDal _stockDal;
        private IOrderDal _orderDal;
        private IOrderService _orderService;
        private ILogHelper _logHelper;
        private Dispatcher _dispatcher;

        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }

        private bool _isEnable;
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }

        private string _selectedProductName;
        public string SelectedProductName
        {
            get { return _selectedProductName; }
            set
            {
                SetProperty(ref _selectedProductName, value);
            }
        }

        private ObservableCollection<string> _productNames;
        public ObservableCollection<string> ProductNames
        {
            get { return _productNames; }
            set
            {
                SetProperty(ref _productNames, value);
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            { 
                SetProperty(ref _quantity, value);
                if (_quantity >0)
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

        public string Title => "Order";

        private List<Stock> _stocks;
        private Stock _selectedStock;

        public OrderViewModel(IStockService stockService, IStockDal stockDal, IOrderDal orderDal, IOrderService orderService, ILogHelper logHelper, IUnityContainer unityContainer)
        {
            _stockDal = stockDal;
            _stockService = stockService;
            _orderDal = orderDal;
            _orderService = orderService;
            _dispatcher = unityContainer.Resolve<Dispatcher>();
            _logHelper = logHelper;

            PlaceOrderCommand = new DelegateCommand(PlaceOrder).ObservesCanExecute(()=>IsEnable);
            CloseCommand = new DelegateCommand(Close);
        }

        private void Close()
        {
            ButtonResult result = ButtonResult.Cancel;
            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        private async void PlaceOrder()
        {
            Stock stock;

            _dispatcher.Invoke(() =>
            {
                Message = "Sending order to server, please wait ......";
                _logHelper.Debug(this, "Start send order to server");
            });

            IsEnable = false;
            //get selected product stock id 
            var stockid = _stocks.Where(i => i.ProductName == SelectedProductName).FirstOrDefault().Id;
            
            try
            {
                //get stock by id from server
                stock = await _stockService.GetById(stockid);
                _logHelper.Debug(this, $"get stock date by id {stockid} from server");
            }
            catch (Exception ex)
            {
                _logHelper.Error(this, "Error occur: " + ex.Message);
                Message = "Can't send order to server, please restart application!";
                return;
            }


            //if quantity is bigger than stock quantity, then ask client enter a smaller number
            if (Quantity > stock.Quantity)
            {
                _dispatcher.Invoke(() =>
                {
                    Message = $"Please enter a quantity of {stock.Quantity} or less.";
                });
            }
            else
            {
                bool placeOrderResult;
                try
                {
                    //create order
                    placeOrderResult = await _orderService.CreateOrder(stockid, SelectedProductName, Quantity);
                    _logHelper.Debug(this, $"Create order of production {SelectedProductName} quantity {Quantity} function return {placeOrderResult}");
                }
                catch (Exception ex)
                {
                    _logHelper.Error(this, "Error occur: " + ex.Message);
                    Message = "Can't send order to server, please restart application!";
                    return;
                }
            
                if (placeOrderResult)
                {
                    _dispatcher.Invoke(() =>
                    {
                        Message = $"Submitted order of product {SelectedProductName}, quantity is {Quantity} to server, Thank you!";
                        _logHelper.Debug(this, $"Create order of production {SelectedProductName} quantity {Quantity}");
                        Quantity = 0;
                    });
                }
                else
                {
                    _dispatcher.Invoke(() =>
                    {
                        Message = "Can't send order to server, please restart application!";
                        _logHelper.Debug(this, Message);
                    });
                }
            }
        }

        public event Action<IDialogResult> RequestClose;


        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            _selectedStock = parameters.GetValue<Stock>("SelectedStock");
            SelectedProductName = _selectedStock.ProductName;
            _stocks = parameters.GetValue<List<Stock>>("Stocks");
            ProductNames = new ObservableCollection<string>(_stocks.Select(i=>i.ProductName).ToList());
        }
    }
}
