using CryproApp.Stores;
using CryproApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproApp.Commands
{
    public class NavigateConvertCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateConvertCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ConvertVeiwModel(_navigationStore);
        }
    }
}
