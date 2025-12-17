using CryproApp.API;
using CryproApp.Commands;
using CryproApp.Models;
using CryproApp.Stores;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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
            OpenSearchCommand = new NavigateSearchCommand(_navigationStore);
        }

        public ICommand OpenSearchCommand { get; }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
   }
}
