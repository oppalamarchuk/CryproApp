using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CryproApp.API
{
    internal class CoingeckoApi
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";
        private readonly string _apiKey;
        private static HttpClient HttpClient = new HttpClient() 
        { 
            BaseAddress = new Uri(BaseUrl)
        };

        public CoingeckoApi(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<IEnumerable<Coin>> GetTopCoinsAsync()
        {
            var responce = await HttpClient.GetAsync("search/trending");
            responce.EnsureSuccessStatusCode();
            
            string json = await responce.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var root = JsonSerializer.Deserialize<RootDto>(json, options);

            if (root?.Coins == null)
                return Enumerable.Empty<Coin>();

            var coins = root.Coins.Select(c => new Coin
            {
                Id = c.Item.Id,
                Name = c.Item.Name,
                Symbol = c.Item.Symbol,
                Price = c.Item.Data.Price
            });


            return coins;
        }
    }
}
