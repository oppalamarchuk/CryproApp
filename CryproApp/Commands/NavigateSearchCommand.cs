using CryproApp.Stores;
using CryproApp.ViewModels;

namespace CryproApp.Commands
{
    public class NavigateSearchCommand : CommandBase
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
