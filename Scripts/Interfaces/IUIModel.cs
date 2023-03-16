using System;

public interface IUIModel {
    public event Action ActivateEvent;
    public event Action DisactivateEvent;
    public void Activate();
    public void Disactivate();
}