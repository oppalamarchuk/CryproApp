namespace CryproApp.Models.UI
{
    public class CoinDetailsUI
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }
        public IEnumerable<MarketUI> Markets { get; set; }
    }
}