using System;

public class TrafficLightModel : ITrafficLightModel {
    public event Action SwitchX;
    public event Action SwitchY;
    public TrafficLightModel() {}
    public bool IsXGreen { get; private set; } = true;
    public bool IsYGreen { get; private set; } = true;
    public void SwitchLightX() {
        IsXGreen = !IsXGreen;
        SwitchX?.Invoke();
    }
    public void SwitchLightY() {
        IsYGreen = !IsYGreen;
        SwitchY?.Invoke();
    }
}