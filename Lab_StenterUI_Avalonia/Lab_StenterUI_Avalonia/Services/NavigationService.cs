using System;
using Lab_StenterUI_Avalonia.ViewModels;

namespace Lab_StenterUI_Avalonia.Services;

public class NavigationService
{
    private ViewModelBase _currentViewModel;

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }

    public event Action? CurrentViewModelChanged;

    public void Navigate(ViewModelBase viewModel)
    {
        CurrentViewModel = viewModel;
    }
}