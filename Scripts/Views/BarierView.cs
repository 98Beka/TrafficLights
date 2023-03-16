using System;
using UnityEngine;

public class BarierView : MonoBehaviour, IBarierView {
    [SerializeField] GameObject child;
    public void SwitchActive() {
        if (child != null)
            child.SetActive(!child.activeSelf);
    }
}