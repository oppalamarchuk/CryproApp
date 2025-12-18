using CryproApp.Stores;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproApp.ViewModels
{
    public class ConvertVeiwModel: ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
       
        private string _fromCurrency;
        public string FromCurrency 
        { 
            get => _fromCurrency;
            set
            {
                _fromCurrency = value;
                OnPropertyChanged();
                _ = UpdateToAmount();
            }
        }

        private string _toCurrency;
        public string ToCurrency 
        { 
            get => _toCurrency;
            set
            {
                _toCurrency = value;
                OnPropertyChanged();
                _ = UpdateFromAmount();
            }
        }
        
        private decimal _fromAmount;
        public decimal FromAmount 
        { 
            get => _fromAmount;
            set
            {
                _fromAmount = value;
                OnPropertyChanged();
                _ = UpdateToAmount();
            }
        }

        private decimal _toAmount;
        public decimal ToAmount 
        { 
            get => _toAmount;
            set
            {
                _toAmount = value;
                OnPropertyChanged();
                _ = UpdateFromAmount();
            }
        }
        
        private bool _isUpdated = false;

        public ConvertVeiwModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

        }

        public async Task UpdateToAmount()
        {
            if (_isUpdated) return;
            try
            {
                _isUpdated = true;
                var api = new API.CoingeckoApi();
                ToAmount = await api.ConvertCurrency(FromAmount, FromCurrency, ToCurrency);
            }
            finally 
            {
                _isUpdated = false;
            }
        }

        public async Task UpdateFromAmount()
        {
            if (_isUpdated) return;

            try
            {
                _isUpdated = true;
                var api = new API.CoingeckoApi();
                FromAmount = await api.ConvertCurrency(ToAmount, ToCurrency, FromCurrency);
            }
            finally 
            {
                _isUpdated = false; 
            }
        }
    }
}
