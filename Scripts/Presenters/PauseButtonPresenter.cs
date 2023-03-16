using System;
using UnityEngine;

public class PauseButtonPresenter : MonoBehaviour {
    private IButtonView _view;
    private IPauseButtonModel _model;

    public PauseButtonPresenter(IButtonView view, IPauseButtonModel model) {
        _view = view;
        _model = model;
        Enable();
    }
    public void Enable() {
        _view.ClickEvent += _model.OnButtonClick;
        _model.DisactivateEvent += _view.OnDisactivate;
        _model.ActivateEvent += _view.OnActivate;
    }
    public void Disable() {
        _view.ClickEvent -= _model.OnButtonClick;
        _model.DisactivateEvent -= _view.OnDisactivate;
        _model.ActivateEvent -= _view.OnActivate;
    }
}