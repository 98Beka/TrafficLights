using System;

public interface IMainCanvasModel : IUIModel {
    public delegate void UpdatePointDelegate(int points);
    public event Action XButtonClickEvent;
    public event Action YButtonClickEvent;
    public event Action WinEvent;
    public event UpdatePointDelegate UpdatePointEvent;
    public void OnClickX();
    public void OnClickY();
    public void AddPoint();
    public int GetPoints();
}