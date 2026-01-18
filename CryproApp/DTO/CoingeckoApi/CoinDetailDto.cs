namespace CryproApp.DTO.CoingeckoApi
{
    public class CoinDetailsDTO : CoinItemDTO
    {
        public decimal Volume { get; set; }

        public decimal PriceChange { get; set; }

        public List<MarketDTO> Markets { get; set; } = new List<MarketDTO>();
    }
}
