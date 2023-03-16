using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonView : MonoBehaviour, IButtonView {
    [SerializeField] Button _button;
    public event Action ClickEvent; 
    private void Start() {
        _button.onClick.AddListener(() => ClickEvent?.Invoke());
    }
    public void OnActivate() {
        _button.gameObject.SetActive(true);
    }
    public void OnDisactivate() {
        _button.gameObject.SetActive(false);
    }
}