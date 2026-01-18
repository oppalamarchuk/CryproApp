using CryproApp.Stores;
using CryproApp.ViewModels;

namespace CryproApp.Commands
{
    public class NavigateCoinsCommand : CommandBase
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
