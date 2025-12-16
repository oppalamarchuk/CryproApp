using CryproApp.API;
using CryproApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryproApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        { 
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            } 
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = new CoinsViewModel();
        }
    }
}
