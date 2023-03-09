using System;

public class MainCanvasModel : IMainCanvasModel {
    public event Action Start;
    public event Action Pause;
    public event Action ClickButtonX;
    public event Action ClickButtonY;
    public event Action ActivateMainPanel;
    public event Action ActivateLoosePanel;
    public event Action AddOnePoint;
    public void OpenMainPanel() => ActivateMainPanel?.Invoke();
    public void OpenLoosePanel() => ActivateLoosePanel?.Invoke();
    public void StartGame() => Start?.Invoke();
    public void PauseGame() => Pause?.Invoke();
    public void ClickX() => ClickButtonX?.Invoke();
    public void ClickY() => ClickButtonY?.Invoke();
    public void AddPoint() => AddOnePoint?.Invoke();
}