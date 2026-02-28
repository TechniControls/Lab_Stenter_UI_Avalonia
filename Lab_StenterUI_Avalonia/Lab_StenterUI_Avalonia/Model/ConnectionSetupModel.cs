using System.Collections.ObjectModel;

namespace Lab_StenterUI_Avalonia.Model;

public class ConnectionSetupModel
{
    public ObservableCollection<string> CpuType { get; } = new ObservableCollection<string>
    {
        "S71200",
        "S71500",
        "LogoOBA8"
    };

    public ObservableCollection<int> Rack { get; } = new ObservableCollection<int>
    {
        0, 1, 2, 3, 4, 5, 6, 7
    };

    public ObservableCollection<int> Slot { get; } = new ObservableCollection<int>
    {
        0, 1, 2, 3, 4, 5, 6, 7
    };
}