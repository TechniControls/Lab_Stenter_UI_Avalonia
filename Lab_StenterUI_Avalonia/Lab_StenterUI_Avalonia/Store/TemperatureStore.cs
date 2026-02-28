using System;
using System.Collections.Generic;
using Lab_StenterUI_Avalonia.Model;
using Lab_StenterUI_Avalonia.ViewModels;

namespace Lab_StenterUI_Avalonia.Store;

public class TemperatureStore : ViewModelBase
{
    public List<TemperatureModel> HistoricalData { get; } = new();
    public event Action<double, float, float, float>? NewSample;
    public float FirstPt100
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
    public float SecondPt100
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

    public void AddSample(float processFirstPt100, float processSecondPt100, float setPoint)
    {
        double time = DateTime.Now.ToOADate();

        HistoricalData.Add(new TemperatureModel
        {
            Time = time,
            ProcessFirstPt100 = processFirstPt100,
            ProcessSecondPt100 = processSecondPt100,
            SetPoint = setPoint
        });

        NewSample?.Invoke(time, processFirstPt100, processSecondPt100, setPoint);

        FirstPt100 = processFirstPt100;
        SecondPt100 = processSecondPt100;

    }
}