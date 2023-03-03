using UnityEngine;
using Zenject;
using static UnityEngine.UI.Button;

public class TrafficLightController : ITrafficLightController, IInitializable {
    public TrafficLightsModel TrafficLights { get; set; }
    private ButtonClickedEvent yButtonClickEvent;
    public ButtonClickedEvent YButtonClickEvent {
        get { return yButtonClickEvent; }
        set {
            if (yButtonClickEvent == null)
                yButtonClickEvent = value;
        }
    }
    private ButtonClickedEvent xButtonClickEvent;
    public ButtonClickedEvent XButtonClickEvent { 
        get { return xButtonClickEvent; } 
        set {
            if (xButtonClickEvent == null)
                xButtonClickEvent = value;
        }
    }

    public void Initialize() {
        XButtonClickEvent.AddListener(SwitchX);
        YButtonClickEvent.AddListener(SwitchY);
        Switch(TrafficLights.Left);
        Switch(TrafficLights.Right);
        Switch(TrafficLights.Front);
        Switch(TrafficLights.Back);
    }

    public void SwitchX() {
        Switch(TrafficLights.Left);
        Switch(TrafficLights.Right);
    }
    public void SwitchY() {
        Switch(TrafficLights.Front);
        Switch(TrafficLights.Back);
    }

    private void Switch(TrafficBallsMaterials lightMaterials) {
        if (lightMaterials.bottomLight.material.color == Color.green) {
            lightMaterials.topLight.material.color = Color.red;
            lightMaterials.bottomLight.material.color = Color.gray;
        } else {
            lightMaterials.topLight.material.color = Color.gray;
            lightMaterials.bottomLight.material.color = Color.green;
        }
    }
}
