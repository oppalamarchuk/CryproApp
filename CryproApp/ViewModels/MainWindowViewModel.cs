using CryproApp.Commands;
using CryproApp.Stores;
using System.Windows.Input;

namespace CryproApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            
            OpenCoinsCommand  = new NavigateCoinsCommand(_navigationStore);
            OpenConvertCommand = new NavigateConvertCommand(_navigationStore);
            OpenSearchCommand = new NavigateSearchCommand(_navigationStore);
        }

        public ICommand OpenCoinsCommand { get; init; }

        public ICommand OpenConvertCommand { get; init; }

        public ICommand OpenSearchCommand { get; init; }

        
        public ViewModelBase CurrentViewModel
        {
            get => _navigationStore.CurrentViewModel;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
