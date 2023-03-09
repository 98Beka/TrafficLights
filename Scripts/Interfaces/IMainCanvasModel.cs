using System;

public interface IMainCanvasModel {
    public event Action Start;
    public event Action Pause;
    public event Action ClickButtonX;
    public event Action ClickButtonY;
    public event Action ActivateMainPanel;
    public event Action ActivateLoosePanel;
    public event Action AddOnePoint;
    public void OpenMainPanel();
    public void OpenLoosePanel();
    public void StartGame();
    public void PauseGame();
    public void ClickX();
    public void ClickY();
    public void AddPoint();
}