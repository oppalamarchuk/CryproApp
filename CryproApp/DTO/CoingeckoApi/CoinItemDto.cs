namespace CryproApp.DTO.CoingeckoApi
{
    public class CoinItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public CoinDataDto Data { get; set; }
    }

}
