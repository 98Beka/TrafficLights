using System;
using UnityEngine;

public class LooseWindowPresenter : MonoBehaviour {
    private IUIView _view;
    private IButtonView _view2;
    private ILooseWindowModel _model;

    public LooseWindowPresenter(IUIView view,IButtonView view2, ILooseWindowModel model) {
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