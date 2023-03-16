using System;

public interface IMainCanvasModel : IUIModel {
    public delegate void UpdatePointDelegate(int points);
    public event Action ClickButtonX;
    public event Action ClickButtonY;
    public event UpdatePointDelegate UpdatePointEvent;
    public void ClickX();
    public void ClickY();
    public void AddPoint();
    public int GetPoints();
}