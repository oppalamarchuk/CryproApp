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
