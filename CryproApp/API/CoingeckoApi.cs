using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Linq;
namespace CryproApp.API
{
    internal class CoingeckoApi
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        private static HttpClient _http;
        private readonly string _apiKey;
        public CoingeckoApi()
        {
            _apiKey = App.Configuration["ApiKeys:CoinGecko"];

            _http = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl),

                DefaultRequestHeaders =
                {
                    { "x-cg-demo-api-key", _apiKey }
                }
            };

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

        public async Task<List<CoinListItemDto>> GetAllCoinsAsync()
        {
            var coins = await _http.GetFromJsonAsync<List<CoinListItemDto>>("coins/list");

            return coins ?? new List<CoinListItemDto>();
        }

        public async Task<CoinDetailsDto> GetCoinDetailsAsync(string id , string currency)
        {
            JsonElement root = await _http.GetFromJsonAsync<JsonElement>(
                $"coins/{id}");

            string name   = root.GetProperty("name").GetString();
            string symbol = root.GetProperty("symbol").GetString();
            decimal price = root.GetProperty("market_data")
                    .GetProperty("current_price")
                    .GetProperty(currency)
                    .GetDecimal();
            decimal volume = root.GetProperty("market_data")
                    .GetProperty("total_volume")
                    .GetProperty(currency)
                    .GetDecimal();
            decimal priceChange = root
                    .GetProperty("market_data")
                    .GetProperty("price_change_percentage_24h")
                    .GetDecimal();

            JsonElement tickers = root.GetProperty("tickers");
            List<Market> markets = tickers
                .EnumerateArray()
                .Select(item => new Market()
                {
                    Name = item.GetProperty("market")
                                .GetProperty("name").GetString(),
                    Volume = item.GetProperty("volume").GetDecimal(),
                    TradeUrl = item.GetProperty("trade_url").GetString(),
                    Price = item.GetProperty("last").GetDecimal(),
                })
                .ToList();

            CoinDetailsDto coin = new CoinDetailsDto()
            {
                Id = id,
                Name = name,
                Symbol = symbol,
                Data = new CoinDataDto()
                {
                    Price = price
                },
                Volume = volume,
                PriceChange = priceChange,
                Markets = markets
            };

            return coin;
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
            var root = await _http.GetFromJsonAsync<RootDto>(
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
