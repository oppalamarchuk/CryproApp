using System.Text.Json.Serialization;

namespace CryproApp.DTO.CoingeckoApi
{
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

}
