using System.Windows.Input;
using Lab_StenterUI_Avalonia.Services;
using Lab_StenterUI_Avalonia.Command;

namespace Lab_StenterUI_Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly NavigationService _navigation;
    private readonly HomeViewModel _homeVM;
    private readonly ProcessControlViewModel _processControlVM;

    public ViewModelBase CurrentViewModel => _navigation.CurrentViewModel;

    public ICommand GoHomeCommand { get; }
    public ICommand GoProcessControlCommand { get; }

    public MainWindowViewModel(
        NavigationService navigation,
        HomeViewModel homeVM,
        ProcessControlViewModel processControlVM)
    {
        _navigation = navigation;
        _homeVM = homeVM;
        _processControlVM = processControlVM;

        _navigation.CurrentViewModelChanged += () =>
            OnPropertyChanged(nameof(CurrentViewModel));

        GoHomeCommand = new RelayCommand(_ => _navigation.Navigate(_homeVM));
        GoProcessControlCommand = new RelayCommand(_ => _navigation.Navigate(_processControlVM));

        // Default view
        _navigation.Navigate(_homeVM);
    } 
}