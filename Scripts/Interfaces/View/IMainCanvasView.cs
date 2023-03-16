using System;

public interface IMainCanvasView : IUIView {
    public event Action ClickButtonX;
    public event Action ClickButtonY;
    public void UpdatePoints(int points);
}