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

    public class TickerDTO
    {
        [JsonPropertyName("market")]
        public MarketDTO Market { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("trade_url")]
        public string? TradeUrl { get; set; }

        [JsonPropertyName("last")]
        public decimal Price { get; set; }
    }

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
