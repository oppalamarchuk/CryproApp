using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using CryproApp.Stores;
using CryproApp.ViewModels;

namespace CryproApp.Commands
{
    public class NavigateCoinDetailsCommand : CommandBase
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
                    new CoinDetailsViewModel(coin.Id);
            }
            else if (parameter is CoinListItemDTO coinL)
            {
                _navigationStore.CurrentViewModel =
                  new CoinDetailsViewModel(coinL.Id);

            }
        }
    }
}
