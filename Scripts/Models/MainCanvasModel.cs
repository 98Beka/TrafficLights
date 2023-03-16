using System;

public class MainCanvasModel : IMainCanvasModel {
    public event Action AddOnePoint;
    public event Action ActivateEvent;
    public event Action DisactivateEvent;
    public event Action XButtonClickEvent;
    public event Action YButtonClickEvent;
    public event Action WinEvent;
    public event IMainCanvasModel.UpdatePointDelegate UpdatePointEvent;
    public MainCanvasModel() { }
    public MainCanvasModel(int points) {
        _points = points;
    }
    private int _points = 0;
    public void OnClickX() => XButtonClickEvent?.Invoke();
    public void OnClickY() => YButtonClickEvent?.Invoke();
    public void AddPoint() {
        if (_points + 1 < 20) {
            _points++;
            UpdatePointEvent(_points);
        } else
            WinEvent?.Invoke();
    }

    public int GetPoints() => _points;
    public void Activate() {
        ActivateEvent?.Invoke();
    }

    public void Disactivate() {
        DisactivateEvent?.Invoke();
    }
}