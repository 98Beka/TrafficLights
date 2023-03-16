using System;
using UnityEngine;

public class StartButtonPresenter : MonoBehaviour {
    private IButtonView _view;
    private IStartButtonModel _model;

    public StartButtonPresenter(IButtonView view, IStartButtonModel model) {
        _view = view;
        _model = model;
        Enable();
    }
    public void Enable() {
        _view.ClickEvent += _model.OnButtonClick;
        _model.ActivateEvent += _view.OnActivate;
        _model.DisactivateEvent += _view.OnDisactivate;
    }
    public void Disable() {
        _view.ClickEvent -= _model.OnButtonClick;
        _model.ActivateEvent += _view.OnActivate;
        _model.DisactivateEvent += _view.OnDisactivate;
    }
}