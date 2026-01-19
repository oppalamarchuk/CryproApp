using System.Text.Json.Serialization;

namespace CryproApp.DTO.CoingeckoApi
{
    public class MarketDataDTO
    {
        [JsonPropertyName("current_price")]
        public Dictionary<string, decimal>? CurrentPrice { get; set; }

        [JsonPropertyName("total_volume")]
        public Dictionary<string, decimal>? TotalVolume { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public decimal PriceChangePercentage24h { get; set; }
    }

}
