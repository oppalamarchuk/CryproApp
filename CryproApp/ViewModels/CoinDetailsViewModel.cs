using CryproApp.API;
using CryproApp.Commands;
using CryproApp.Models.UI;
using CryproApp.Models;
using LiveCharts;
using System.Windows.Input;

namespace CryproApp.ViewModels
{
    public class CoinDetailsViewModel : ViewModelBase
    {
        private readonly CoingeckoApi _api;
        private CoinDetailsUI _coinDetails;

        public CoinDetailsViewModel(string coinId)
        {
            _api = new CoingeckoApi();
            OpenMarketCommand = new NavigateMarketCommand();

            _ = InitializeAsync(coinId);
        }

        public CoinDetailsViewModel(Coin coin) : this(coin.Id)
        {
        }

        public ICommand OpenMarketCommand { get; init; }
        public ChartValues<decimal> Prices { get; set; } = new ChartValues<decimal>();
        public List<string> TimeLabels { get; set; } = new List<string>();

        public CoinDetailsUI CoinDetails
        {
            get => _coinDetails;
            set
            {
                _coinDetails = value;
                OnPropertyChanged();
            }
        }

        private async Task InitializeAsync(string coinId, string currency = "usd")
        {
            var coins = await _api.GetCoinDetailsAsync(coinId);
            var pricePoints = await _api.GetCoinChartDataAsync(coinId, currency);

            Prices.Clear();
            foreach (var p in pricePoints)
            {
                Prices.Add(p.Price);
                TimeLabels.Add(p.Time.ToString("dd MMM HH:mm"));
            }

            CoinDetails = new CoinDetailsUI()
            {
                Id = coins.Id,
                Name = coins.Name,
                Symbol = coins.Symbol,
                Price = coins.MarketData.CurrentPrice[currency],
                Volume = coins.MarketData.TotalVolume[currency],
                PriceChangePercentage24h = coins.MarketData.PriceChangePercentage24h,
                Markets = coins.Tickers.Select(t => new MarketUI
                {
                    Name = t.Market.Name,
                    Volume = t.Volume,
                    TradeUrl = t.TradeUrl,
                    Price = t.Price
                })
            };
        }
    }
}
