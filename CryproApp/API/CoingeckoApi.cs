using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace CryproApp.API
{
    internal class CoingeckoApi
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        private static HttpClient HttpClient = new HttpClient() 
        { 
            BaseAddress = new Uri(BaseUrl)
        };

        public async Task<CoinDetailsDto> GetCoinDetailsAsync(string id , string currency)
        {
            JsonElement root = await HttpClient.GetFromJsonAsync<JsonElement>(
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

        public async Task<IEnumerable<Coin>> GetTopCoinsAsync()
        {
            var root = await HttpClient.GetFromJsonAsync<RootDto>(
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
