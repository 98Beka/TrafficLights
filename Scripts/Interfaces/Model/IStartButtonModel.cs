using System;

public interface IStartButtonModel : IUIModel {
    public event Action GameStartEvent;
    public void OnButtonClick();
}