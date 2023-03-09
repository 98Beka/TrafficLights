using System;
using UnityEngine;

public class BarierModel : MonoBehaviour, IBarierModel {
    public event Action Active;
    public void SwitchActive() => Active?.Invoke();
}