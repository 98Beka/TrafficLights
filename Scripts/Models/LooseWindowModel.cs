using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseWindowModel : MonoBehaviour, ILooseWindowModel {
    public event Action ActivateEvent;
    public event Action DisactivateEvent;

    public void Activate() {
        ActivateEvent?.Invoke();
    }

    public void Disactivate() {
        DisactivateEvent?.Invoke();
    }

    public void OnButtonClick() {
        SceneManager.LoadScene(0);
        SaveSystem.Clear();
    }
}