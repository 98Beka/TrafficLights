using System;
using UnityEngine;
using UnityEngine.UI;

public class LooseWindowView : MonoBehaviour, IUIView, IButtonView {
    public event Action ClickEvent;
    [SerializeField] GameObject _panel;
    [SerializeField] Button _button;

    private void Start() {
        _button.onClick.AddListener(() => ClickEvent?.Invoke());
    }

    public void OnActivate() {
        _panel.SetActive(true);
    }
    public void OnDisactivate() {
        _panel.SetActive(false);
    }
}