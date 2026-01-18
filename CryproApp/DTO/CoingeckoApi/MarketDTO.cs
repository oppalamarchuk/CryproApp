namespace CryproApp.DTO.CoingeckoApi
{
    public class MarketDTO
    {
        public string? Name { get; set; }

        public string? TradeUrl { get; set; }

        public decimal Volume { get; set; }

        public decimal Price { get; set; }
    }
}