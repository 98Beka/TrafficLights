using UnityEngine;
using Zenject;

public class EnvirenmentSpawnerInstaller : MonoInstaller
{
    [SerializeField] EnvirenmentSpawner envirenmentSpawner;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EnvirenmentSpawner>().FromInstance(envirenmentSpawner).AsSingle();
    }
}