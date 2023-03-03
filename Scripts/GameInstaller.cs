using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller
{
    private IEnvirenmentSpawner envirenmentSpawner;

    [Inject]
    public void Construct(IEnvirenmentSpawner envirenmentSpawner) {
        this.envirenmentSpawner = envirenmentSpawner;
        Initialize();
    }

    private void Initialize() {
        envirenmentSpawner.SpawnEnvirenment();
    }
}
