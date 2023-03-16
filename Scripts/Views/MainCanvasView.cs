using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainCanvasView : MonoBehaviour, IMainCanvasView {
    [SerializeField] Button _xButton;
    [SerializeField] Button _yButton;
    [SerializeField] Text _pointsUI;
    [SerializeField] GameObject _panel;
    public event Action XButtonClickEvent;
    public event Action YButtonClickEvent;
    private void Start() {
        _xButton.onClick.AddListener(() => XButtonClickEvent?.Invoke());
        _yButton.onClick.AddListener(() => YButtonClickEvent?.Invoke());
    }
    public void UpdatePoints(int points) {
        _pointsUI.text = points.ToString();
    }

    public void OnActivate() {
        _panel.SetActive(true);
    }

    public void OnDisactivate() {
        _panel.SetActive(false);
    }
}