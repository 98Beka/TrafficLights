using System;
using UnityEngine;

public class BarierPresenter : MonoBehaviour {
    private IBarierView _view;
    private IBarierModel _model;

    public BarierPresenter(IBarierView view, IBarierModel model) {
        _view = view;
        _model = model;
        Enable();
    }
    public void Enable() {
        _model.Active += _view.SwitchActive;
    }
    public void Disable() {
        _model.Active -= _view.SwitchActive;
    }
}