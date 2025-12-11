namespace CryproApp.DTO.CoingeckoApi
{
    public class Market
    {
        public string Name { get; set; }
        public string TradeUrl { get; set; }
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        public override string ToString() => $" Market: {Name} - {TradeUrl} - {Volume} - {Price}";
    }
}