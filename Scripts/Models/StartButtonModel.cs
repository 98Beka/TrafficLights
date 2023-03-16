using System;
using UnityEngine;

public class StartButtonModel : MonoBehaviour, IStartButtonModel {
    public event Action GameStartEvent;
    public event Action ActivateEvent;
    public event Action DisactivateEvent;
    public StartButtonModel() { }
    public StartButtonModel(bool isActive) {
        if(!isActive)
            DisactivateEvent?.Invoke();
    }
    public void OnButtonClick() {
        GameStartEvent?.Invoke();
    }

    public void Activate() {
        ActivateEvent?.Invoke();
    }

    public void Disactivate() {
        DisactivateEvent?.Invoke();
    }
}