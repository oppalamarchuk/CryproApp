using CryproApp.Stores;
using CryproApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproApp.Commands
{
    class NavigateSearchCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateSearchCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SearchCoinViewModel(_navigationStore);
        }
    }
}
