using System;

public class TrafficLightModel : ITrafficLightModel {
    public event Action SwitchX;
    public event Action SwitchY;
    public void SwitchLightX() => SwitchX?.Invoke();
    public void SwitchLightY() => SwitchY?.Invoke();
}