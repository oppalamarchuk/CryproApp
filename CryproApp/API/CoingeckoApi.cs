using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
namespace CryproApp.API
{
    public class CoingeckoApi
    {
        private static readonly HttpClient _http = new HttpClient();

        static CoingeckoApi()
        {
            string apiKey = App.Configuration["ApiKeys:CoinGecko"];
            string baseUrl = "https://api.coingecko.com/api/v3/";

            _http.BaseAddress = new Uri(baseUrl);
            _http.DefaultRequestHeaders.Add("x-cg-demo-api-key", apiKey);
            _http.Timeout = TimeSpan.FromSeconds(30);
        }

        public CoingeckoApi()
        {
            
        }

        public async Task<decimal> ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            string mediumCurrency = "usd";

            var root = await _http.GetFromJsonAsync<JsonElement>(
                $"simple/price?vs_currencies={mediumCurrency}&ids={fromCurrency}%2C{toCurrency}");

            decimal priceFrom = root
                .GetProperty(fromCurrency)
                .GetProperty(mediumCurrency)
                .GetDecimal();

            decimal priceTo = root
                .GetProperty(toCurrency)
                .GetProperty(mediumCurrency)
                .GetDecimal();

            decimal rate = priceFrom / priceTo;
            
            return amount * rate;
        }

        public async Task<List<CoinListItemDTO>> GetAllCoinsAsync()
        {
            var coins = await _http.GetFromJsonAsync<List<CoinListItemDTO>>("coins/list");

            return coins ?? new List<CoinListItemDTO>();
        }

        public async Task<CoinDetailsDTO> GetCoinDetailsAsync(string id)
        {
            var coinDetails = await _http.GetFromJsonAsync<CoinDetailsDTO>($"coins/{id}");

            return coinDetails;
        }

        public async Task<List<PricePointDTO>> GetCoinChartDataAsync(string id, string currency)
        {
            var root = await _http.GetFromJsonAsync<JsonElement>(
                    $"coins/{id}/market_chart?vs_currency={currency}&days=7");
            var prices = root.GetProperty("prices").EnumerateArray();

            List<PricePointDTO> pricePoints = prices
                .Select(item => new PricePointDTO
                {
                    Time = DateTimeOffset.FromUnixTimeMilliseconds(item[0].GetInt64()).DateTime,
                    Price = item[1].GetDecimal()
                }).ToList();
                
            return pricePoints;
        }

        public async Task<IEnumerable<Coin>> GetTopCoinsAsync()
        {
            var root = await _http.GetFromJsonAsync<RootDTO>(
                    "search/trending");

            var coins = root?.Coins.Select(c => new Coin
            {
                Id = c.Item.Id,
                Name = c.Item.Name,
                Symbol = c.Item.Symbol,
                Price = c.Item.Data.Price
            });

            return coins ?? Enumerable.Empty<Coin>();
        }
    }
}
