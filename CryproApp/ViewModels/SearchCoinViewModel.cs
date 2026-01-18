using CryproApp.API;
using CryproApp.Commands;
using CryproApp.DTO.CoingeckoApi;
using CryproApp.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CryproApp.ViewModels
{
    class SearchCoinViewModel : ViewModelBase
    {
        private List<CoinListItemDTO> _allCoins = new();
        private readonly NavigationStore _navigationStore;
        private string _searchText = string.Empty;

        public SearchCoinViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            OpenDetailsCommand = new NavigateCoinDetailsCommand(_navigationStore);
            Coins = new ObservableCollection<CoinListItemDTO>();

            LoadCoins();
        }

        public ICommand OpenDetailsCommand { get; init; }

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

        public ObservableCollection<CoinListItemDTO> Coins{ get; init; }

        private async void LoadCoins()
        {
            var api = new CoingeckoApi();
            var coins = await api.GetAllCoinsAsync();

            _allCoins.AddRange(coins);
        }

        private void FilterCoins()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Coins.Clear();
                return;
            }

            IEnumerable<CoinListItemDTO> filtered;
            if (SearchText.Length < 3)
            {
                filtered = _allCoins.Where(c => c.Name.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                filtered = _allCoins.Where(c => c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            }

            filtered = filtered.OrderBy(c => c.Name.Length).Take(20);

            Coins.Clear();
            foreach (var coin in filtered)
                Coins.Add(coin);
        }
    }
}