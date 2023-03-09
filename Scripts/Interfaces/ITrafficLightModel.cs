using System;

public interface ITrafficLightModel {
    public event Action SwitchX;
    public event Action SwitchY;
    public void SwitchLightX();
    public void SwitchLightY();
}

