using UnityEngine;
using Zenject;

public class GameInstallerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameInstaller>().AsSingle().NonLazy();
    }
}