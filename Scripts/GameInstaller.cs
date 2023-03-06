using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller
{
    private IEnvirenmentInitializer envirenmentInitializer;

    [Inject]
    public void Construct(IEnvirenmentInitializer envirenmentInitializer) {
        this.envirenmentInitializer = envirenmentInitializer;
        Initialize();
    }

    private void Initialize() {
        envirenmentInitializer.EnvirenmentInitialize();
    }
}
