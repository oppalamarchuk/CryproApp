using CryproApp.Stores;
using CryproApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproApp.Commands
{
    class NavigateCoinsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateCoinsCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new CoinsViewModel(_navigationStore);
        }
    }
}
