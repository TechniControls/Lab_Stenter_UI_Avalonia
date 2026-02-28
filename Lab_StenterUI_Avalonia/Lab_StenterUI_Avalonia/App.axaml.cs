using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Lab_StenterUI_Avalonia.Services;
using Lab_StenterUI_Avalonia.Store;
using Lab_StenterUI_Avalonia.ViewModels;
using Lab_StenterUI_Avalonia.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Lab_StenterUI_Avalonia;

public partial class App : Application
{
    public static ServiceProvider Services { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        
        var collection = new ServiceCollection();

        // STORES (persistencia)
        collection.AddSingleton<ConnectionStore>();
        collection.AddSingleton<CustomRecipeStore>();
        collection.AddSingleton<TemperatureStore>();
        // Services
        collection.AddSingleton<NavigationService>();
        collection.AddSingleton<ConnectionService>();

        // ViewModels
        collection.AddSingleton<NavigationBarViewModel>();
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<TemperatureTrendViewModel>();
        collection.AddTransient<ProcessControlViewModel>();
        collection.AddTransient<ConnectionWindowViewModel>();
        collection.AddTransient<HomeViewModel>();

        // Views
        collection.AddSingleton<MainWindow>();
        collection.AddTransient<ProcessControlView>();
        collection.AddTransient<TemperatureTrendView>();
        collection.AddTransient<ConnectionWindow>();
        collection.AddTransient<HomeView>();
        // collection.AddSingleton<NavigationBar>();

        Services = collection.BuildServiceProvider();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = Services.GetRequiredService<MainWindow>();
            window.DataContext = Services.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow = window;
        }

        base.OnFrameworkInitializationCompleted();
    }
}