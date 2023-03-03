using static UnityEngine.UI.Button;

public interface ITrafficLightController
{
    public TrafficLightsModel TrafficLights { get; set; }
    public ButtonClickedEvent XButtonClickEvent { get; set; }
    public ButtonClickedEvent YButtonClickEvent { get; set; }
    public void SwitchX();
    public void SwitchY();
}
