using System;

public interface IMainCanvasView {
    public event Action StartGame;
    public event Action PauseGame;
    public event Action ClickButtonX;
    public event Action ClickButtonY;
    public void OpenLoosePanel();
    public void AddPoint();
    public void OpenMainPanel();
}