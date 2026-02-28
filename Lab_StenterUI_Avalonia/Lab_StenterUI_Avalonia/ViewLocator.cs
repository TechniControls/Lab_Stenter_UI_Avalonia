using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Lab_StenterUI_Avalonia.ViewModels;
using Lab_StenterUI_Avalonia.Views;

namespace Lab_StenterUI_Avalonia;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        return data switch
        {
            HomeViewModel => new HomeView(),
            ProcessControlViewModel => new ProcessControlView(),
            _ => new TextBlock { Text = "Not Found" }
        };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}