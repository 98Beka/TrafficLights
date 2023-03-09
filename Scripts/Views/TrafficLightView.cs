using System;
using UnityEngine;

public class TrafficLightView : MonoBehaviour, ITrafficLightView {
    [SerializeField] TrafficBallsMaterials Left;
    [SerializeField] TrafficBallsMaterials Right;
    [SerializeField] TrafficBallsMaterials Front;
    [SerializeField] TrafficBallsMaterials Back;

    void Start() {
        Switch(Left);
        Switch(Right);
        Switch(Front);
        Switch(Back);
    }

    public void SwitchX() {
        Switch(Left);
        Switch(Right);
    }
    public void SwitchY() {
        Switch(Front);
        Switch(Back);
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

[Serializable]
public class TrafficBallsMaterials {
    public Renderer topLight;
    public Renderer bottomLight;
}