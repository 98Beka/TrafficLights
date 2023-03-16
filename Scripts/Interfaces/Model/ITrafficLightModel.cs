using System;

public interface ITrafficLightModel {
    public event Action SwitchX;
    public event Action SwitchY;
    public bool IsXGreen { get; }
    public bool IsYGreen { get; }
    public void SwitchLightX();
    public void SwitchLightY();
}

