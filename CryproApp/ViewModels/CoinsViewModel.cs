    using CryproApp.API;
    using CryproApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace CryproApp.ViewModels
    {
        public class CoinsViewModel: ViewModelBase
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

            public CoinsViewModel()
            {
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
