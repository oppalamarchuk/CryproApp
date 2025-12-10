using CryproApp.API;
using CryproApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryproApp.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
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

        public MainWindowViewModel()
        {
            LoadCoins();
        }

        private async void LoadCoins()
        {
            var api = new CoingeckoApi();
            var coins = await api.GetTopCoinsAsync();

            Coins = new ObservableCollection<Coin>(coins);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
