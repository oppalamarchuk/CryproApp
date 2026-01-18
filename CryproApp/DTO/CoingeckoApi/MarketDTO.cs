using System.Text.Json.Serialization;

namespace CryproApp.DTO.CoingeckoApi
{
    public class MarketDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}