using UnityEngine;
using Zenject;

public class TrafficLightControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<TrafficLightController>().AsSingle();
    }
}