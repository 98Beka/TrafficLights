using UnityEngine;
using Zenject;

public class EnvirenmentInitializerInstaller : MonoInstaller
{
    [SerializeField] EnvirenmentInitializer envirenmentInitializer;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EnvirenmentInitializer>().FromInstance(envirenmentInitializer).AsSingle();
    }
}