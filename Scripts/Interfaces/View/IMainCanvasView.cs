using System;

public interface IMainCanvasView : IUIView {
    public event Action XButtonClickEvent;
    public event Action YButtonClickEvent;
    public void UpdatePoints(int points);
}