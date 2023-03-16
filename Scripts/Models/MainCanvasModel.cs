using System;

public class MainCanvasModel : IMainCanvasModel {
    public event Action ClickButtonX;
    public event Action ClickButtonY;
    public event Action AddOnePoint;
    public event Action ActivateEvent;
    public event Action DisactivateEvent;
    public event IMainCanvasModel.UpdatePointDelegate UpdatePointEvent;
    public MainCanvasModel() { }
    public MainCanvasModel(int points) {
        _points = points;
    }
    public Action onWin;
    private int _points = 0;
    public void ClickX() => ClickButtonX?.Invoke();
    public void ClickY() => ClickButtonY?.Invoke();
    public void AddPoint() {
        if (_points + 1 < 20) {
            _points++;
            UpdatePointEvent(_points);
        } else
            onWin();
    }

    public int GetPoints() => _points;
    public void Activate() {
        ActivateEvent?.Invoke();
    }

    public void Disactivate() {
        DisactivateEvent?.Invoke();
    }
}