using System;

public interface IPauseButtonModel : IUIModel {
    public event Action GamePauseEvent;
    public void OnButtonClick();
}