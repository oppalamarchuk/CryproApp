using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryproApp.DTO.CoingeckoApi;
using CryproApp.API;
using CryproApp.Models;
using CryproApp.Stores;

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
        private readonly NavigationStore _navigationStore;
        public CoinDetailsViewModel(Coin coin,NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _ = LoadCoinDetails(coin.Id);
        }

        public async Task LoadCoinDetails(string id, string currency = "usd")
        {
            var api = new CoingeckoApi();
            CoinDetails = await api.GetCoinDetailsAsync(id, currency);
        }
    }
}
