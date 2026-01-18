namespace CryproApp.DTO.CoingeckoApi
{
    public class CoinItemDTO
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Symbol { get; set; }

        public CoinDataDTO? Data { get; set; }
    }
}
