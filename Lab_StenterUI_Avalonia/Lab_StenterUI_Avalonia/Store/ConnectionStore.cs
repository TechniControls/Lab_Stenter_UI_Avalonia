using Lab_StenterUI_Avalonia.ViewModels;

namespace Lab_StenterUI_Avalonia.Store;

public class ConnectionStore :ViewModelBase
{
    public string SelectedCpuType { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string SelectedRack { get; set; } = string.Empty;
    public string SelectedSlot { get; set; } = string.Empty;
    public bool IsConnected
    {
        get => field;
        set
        {
            if (field == value)
                return;

            field = value;
            OnPropertyChanged();
        }
    }
}