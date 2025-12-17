using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryproApp.DTO.CoingeckoApi;
using CryproApp.API;
using CryproApp.Models;
using CryproApp.Stores;
using System.Windows.Input;
using CryproApp.Commands;

namespace CryproApp.ViewModels
{
    public class CoinDetailsViewModel : ViewModelBase
    {
        private CoinDetailsDto _coinDetails;
        public CoinDetailsDto CoinDetails { 
            get => _coinDetails;
            set
            {
                _coinDetails = value;
                OnPropertyChanged();
            } 
        }
        public ICommand OpenCoinsCommand { get; }
        private readonly NavigationStore _navigationStore;

        public CoinDetailsViewModel(Coin coin,NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            OpenCoinsCommand = new NavigateCoinsCommand(_navigationStore);

            LoadCoinDetails(coin.Id);
        }

        public async void LoadCoinDetails(string id, string currency = "usd")
        {
            var api = new CoingeckoApi();
            CoinDetails = await api.GetCoinDetailsAsync(id, currency);
        }
    }
}
