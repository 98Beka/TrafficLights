using System;
using UnityEngine;

public class PauseButtonModel : IPauseButtonModel {

    public event Action GamePauseEvent;
    public event Action ActivateEvent;
    public event Action DisactivateEvent;
    public PauseButtonModel() { }
    public PauseButtonModel(bool isActive) {
        if (!isActive)
            DisactivateEvent?.Invoke();
    }
    public void OnButtonClick() {
        GamePauseEvent?.Invoke();
    }

    public void Activate() {
        ActivateEvent?.Invoke();
    }

    public void Disactivate() {
        DisactivateEvent?.Invoke();
    }
}