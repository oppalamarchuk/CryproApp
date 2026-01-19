using CryproApp.API;
using CryproApp.Commands;
using CryproApp.Models;
using CryproApp.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CryproApp.ViewModels
{
    public class CoinsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        private ObservableCollection<Coin> _coins = new();

        public CoinsViewModel(NavigationStore store)
        {
            _navigationStore = store;
            OpenDetailsCommand = new NavigateCoinDetailsCommand(_navigationStore);

            LoadCoins();
        }

        public ICommand OpenDetailsCommand { get; init; }

        public ObservableCollection<Coin> Coins
        {
            get => _coins;
            set
            {
                _coins = value;
                OnPropertyChanged();
            }
        }

        private async void LoadCoins()
        {
            var api = new CoingeckoApi();
            var coins = await api.GetTopCoinsAsync();

            Coins = new ObservableCollection<Coin>(coins);
        }
    }
}
