using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryproApp.DTO.CoingeckoApi
{
    public class CoinListItemDto
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public decimal hoe { get; set; }

        public string Name { get; set; }
    }

}
