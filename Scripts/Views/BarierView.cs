using System;
using UnityEngine;

public class BarierView : MonoBehaviour, IBarierView {
    [SerializeField] GameObject child;
    private void Start() {
        child.SetActive(false);
    }
    public void SwitchActive() {
        if (child != null)
            child.SetActive(!child.activeSelf);
    }
}