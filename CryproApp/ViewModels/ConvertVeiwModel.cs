namespace CryproApp.ViewModels
{
    public class ConvertVeiwModel: ViewModelBase
    {       
        private string _fromCurrency;
        private string _toCurrency;
        private decimal _fromAmount;
        private decimal _toAmount;
        private bool _isUpdated = false;

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
