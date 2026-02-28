namespace Lab_StenterUI_Avalonia.Model;

public class TemperatureModel
{
    public double Time { get; set; } // OADate
    public float ProcessFirstPt100 { get; set; } // PV of PT100-1
    public float ProcessSecondPt100 { get; set; } // PV of PT100-2
    public float SetPoint { get; set; } // SP
}