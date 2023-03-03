using UnityEngine;
using Zenject;

public class CarSpawnerInstaller : MonoInstaller
{
    [SerializeField] CarSpawner carSpawner;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<CarSpawner>().FromInstance(carSpawner).AsSingle();
    }
}