using System;
using UnityEngine;

public class WinWindowPresenter : MonoBehaviour {
    private IUIView _view;
    private IButtonView _view2;
    private IWinWindowModel _model;
    public WinWindowPresenter(IUIView view, IButtonView view2, IWinWindowModel model) {
        _view = view;
        _view2 = view2;
        _model = model;
        Enable();
    }
    public void Enable() {
        _model.ActivateEvent += _view.OnActivate;
        _model.DisactivateEvent += _view.OnDisactivate;
        _view2.ClickEvent += _model.OnButtonClick;
    }
    public void Disable() {
        _model.ActivateEvent -= _view.OnActivate;
        _model.DisactivateEvent -= _view.OnDisactivate;
        _view2.ClickEvent -= _model.OnButtonClick;
    }
}