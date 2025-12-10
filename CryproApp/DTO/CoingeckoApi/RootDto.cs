using System;
using System.Collections.Generic;
using System.Text;

namespace CryproApp.DTO.CoingeckoApi
{
    public class RootDto
    {
        public List<CoinWrapperDto> Coins { get; set; }
    }
}
