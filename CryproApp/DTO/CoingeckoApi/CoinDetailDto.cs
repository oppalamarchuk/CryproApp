namespace CryproApp.DTO.CoingeckoApi
{
    public class CoinDetailsDto : CoinItemDto
    {
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }
        public List<Market> Markets { get; set; } = new List<Market>();

        public override string ToString() => $"CoinDetatilsDto: {Id} - {Name} - {Symbol} - {PriceChange}";
    }
}
