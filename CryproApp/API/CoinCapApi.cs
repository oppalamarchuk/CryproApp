using System;
using System.Collections.Generic;
using System.Text;

namespace CryproApp.API
{
    internal class CoinCapApi
    {
        private const string BaseUrl = "https://rest.coincap.io/v3/";
        private readonly string _apiKey;

        public CoinCapApi(string apiKey)
        {
            _apiKey = apiKey;
        }


    }
}
