using System.Text.Json.Serialization;

namespace CryproApp.DTO.CoingeckoApi
{
    public class CoinDetailsDTO
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("market_data")]
        public MarketDataDTO? MarketData{ get; set; }

        [JsonPropertyName("tickers")]
        public List<TickerDTO>? Tickers { get; set; }
    }
}
