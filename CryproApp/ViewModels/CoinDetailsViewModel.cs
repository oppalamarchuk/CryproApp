using CryproApp.API;
using CryproApp.Commands;
using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using LiveCharts;
using System.Windows.Input;

namespace CryproApp.ViewModels
{
    public class CoinDetailsViewModel : ViewModelBase
    {
        private CoinDetailsDTO _coinDetails;

        public CoinDetailsViewModel(Coin coin) : this(coin.Id)
        {
        }

        public CoinDetailsViewModel(string coinId)
        {
            OpenMarketCommand = new NavigateMarketCommand();

            LoadCoinDetails(coinId);
        }

        public ICommand OpenMarketCommand { get; init; }

        public List<string> TimeLabels { get; set; } = new();

        public ChartValues<decimal> Prices { get; set; } = new();

        public CoinDetailsDTO CoinDetails
        {
            get => _coinDetails;
            set
            {
                _coinDetails = value;
                OnPropertyChanged();
            }
        }

        private async void LoadCoinDetails(string id, string currency = "usd")
        {
            var api = new CoingeckoApi();
            CoinDetails = await api.GetCoinDetailsAsync(id, currency);

            var pricePoints = await api.GetCoinChartDataAsync(id, currency);
            
            Prices.Clear();
            foreach (var p in pricePoints)
            {
                Prices.Add(p.Price);
                TimeLabels.Add(p.Time.ToString("dd MMM HH:mm"));
            }
        }
    }
}
