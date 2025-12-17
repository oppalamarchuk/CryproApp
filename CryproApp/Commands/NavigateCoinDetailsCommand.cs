using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using CryproApp.Stores;
using CryproApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproApp.Commands
{
    class NavigateCoinDetailsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateCoinDetailsCommand(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            if(parameter is Coin coin)
            {
                _navigationStore.CurrentViewModel =
                    new CoinDetailsViewModel(coin , _navigationStore);
            }
            else if (parameter is CoinListItemDto coinL)
            {
                _navigationStore.CurrentViewModel =
                  new CoinDetailsViewModel(coinL.Id, _navigationStore);

            }
        }
    }
}
