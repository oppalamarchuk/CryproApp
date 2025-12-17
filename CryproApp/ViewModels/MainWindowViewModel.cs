using CryproApp.API;
using CryproApp.Models;
using CryproApp.Stores;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryproApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel 
        { 
            get => _navigationStore.CurrentViewModel;
        }

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
   }
}
