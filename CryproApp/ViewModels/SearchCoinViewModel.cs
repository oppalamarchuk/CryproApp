using CryproApp.DTO.CoingeckoApi;
using CryproApp.Models;
using CryproApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproApp.ViewModels
{
    class SearchCoinViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private string _searchText;
        public string SearchText 
        { 
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterCoins();
            }
        }

        private readonly List<CoinListItemDto> _allCoins = new();
        private ObservableCollection<CoinListItemDto> _coins = new();
        public ObservableCollection<CoinListItemDto> Coins
        {
            get => _coins;
            set
            {
                _coins = value;
                OnPropertyChanged();
            }
        }
        private async Task LoadCoins()
        {
            var api = new API.CoingeckoApi();
            var coins = await api.GetAllCoins();

            _allCoins.AddRange(coins);
        }

        public SearchCoinViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            LoadCoins();
        }
      
        public void FilterCoins()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Coins.Clear();
                return;
            }

            IEnumerable<CoinListItemDto> filtered;
            if (SearchText.Length < 3)
            {
                filtered = _allCoins.Where(c => c.Name.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                filtered = _allCoins.Where(c => c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            }

            filtered = filtered.OrderBy(c => c.Name.Length).Take(20);

            Coins = new ObservableCollection<CoinListItemDto>(filtered.ToList());
        }
    }
}