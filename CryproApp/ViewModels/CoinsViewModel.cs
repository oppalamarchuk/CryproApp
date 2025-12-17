using CryproApp.API;
using CryproApp.Commands;
using CryproApp.Models;
using CryproApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryproApp.ViewModels
{
    public class CoinsViewModel : ViewModelBase
    {
        private ObservableCollection<Coin> _coins = new ObservableCollection<Coin>();
        public ObservableCollection<Coin> Coins
        {
            get => _coins;
            set
            {
                _coins = value;
                OnPropertyChanged();
            }
        }
        public Coin SelectedCoin { get; set; }
        private readonly NavigationStore _navigationStore;
        public ICommand OpenDetailsCommand { get; }

        public CoinsViewModel(NavigationStore store)
        {
            _navigationStore = store;
            OpenDetailsCommand = new NavigateCoinDetailsCommand(_navigationStore);

            LoadCoins();
        }

        private async void LoadCoins()
        {
            var api = new CoingeckoApi();
            var coins = await api.GetTopCoinsAsync();

            Coins = new ObservableCollection<Coin>(coins);
        }
    }
}
