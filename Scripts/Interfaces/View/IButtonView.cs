using System;

public interface IButtonView : IUIView {
    public event Action ClickEvent;
}