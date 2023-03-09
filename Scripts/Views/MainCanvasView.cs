using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainCanvasView : MonoBehaviour, IMainCanvasView {
    [SerializeField] GameObject _startButton;
    [SerializeField] GameObject _pauseButton;
    [SerializeField] GameObject _restartButton;
    [SerializeField] GameObject _restartButton2;
    [SerializeField] GameObject _xButton;
    [SerializeField] GameObject _yButton;
    [SerializeField] GameObject _loosePanel;
    [SerializeField] GameObject _mainPanel;
    [SerializeField] GameObject _winPanel;
    [SerializeField] Text pointUI;
    public event Action StartGame;
    public event Action PauseGame;
    public event Action ClickButtonX;
    public event Action ClickButtonY;
    private int _points = 0;
    private const int MAX_POINTS = 20;
    private void Start() {
        _startButton.GetComponent<Button>().onClick.AddListener(() => {
            _startButton.SetActive(false);
            _pauseButton.SetActive(true);
            _xButton.SetActive(true);
            _yButton.SetActive(true);
            Time.timeScale = 1;
            StartGame?.Invoke();
            });
        _pauseButton.GetComponent<Button>().onClick.AddListener(() => {
            _startButton.SetActive(true);
            _pauseButton.SetActive(false);
            _xButton.SetActive(false);
            _yButton.SetActive(false);
            Time.timeScale = 0;
            PauseGame?.Invoke();
        });
        _restartButton.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(0));
        _restartButton2.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(0));
        _xButton.GetComponent<Button>().onClick.AddListener(() => ClickButtonX?.Invoke());
        _yButton.GetComponent<Button>().onClick.AddListener(() => ClickButtonY?.Invoke());
        _pauseButton.SetActive(false);
        _xButton.SetActive(false);
        _yButton.SetActive(false);
        OpenMainPanel();

    }
    public void AddPoint() {
        if (_points + 1 <= MAX_POINTS) {
            _points++;
            pointUI.text = _points.ToString();
        } else {
            OpenWinPanel();
        }
    }
    public void OpenLoosePanel() {
        _mainPanel.SetActive(false);
        _loosePanel.SetActive(true);
        _winPanel.SetActive(false);
    }
    public void OpenWinPanel() {
        _winPanel.SetActive(true);
        _loosePanel.SetActive(false);
        _mainPanel.SetActive(false);
    }
    public void OpenMainPanel() {
        _mainPanel.SetActive(true);
        _loosePanel.SetActive(false);
        _winPanel.SetActive(false);
    }
}