using System;
using UnityEngine;

public class BarierPresenter : MonoBehaviour {
    private IBarierView _barierView;
    private IBarierModel _barierModel;

    public BarierPresenter(IBarierView view, IBarierModel model) {
        _barierView = view;
        _barierModel = model;
        Enable();
    }

    public void Enable() {
        _barierModel.Active += _barierView.SwitchActive;
    }

    public void Disable() {
        _barierModel.Active -= _barierView.SwitchActive;
    }
}