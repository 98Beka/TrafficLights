public class CarPresenter {
    private ICarView _view;
    private ICarModel _model;

    public CarPresenter(ICarView view, ICarModel model) {
        _model = model;
        _view = view;
        _view.RayLong = model.RayLong;
        _view.MaxMagnitudeForAdditionalSpeed = model.MaxMagnitudeForAdditionalSpeed;
        _view.AdditaionSpeedForStarting = model.AdditaionSpeedForStarting;
        _view.DestroyMinY = model.DestroyMinY;
        _view.Speed = model.Speed;
        Enable();
    }
    public void Enable() {
        _view.Crash += _model.InvokeCrashEevent;
        _view.Finish += _model.InvokeFinishEvent;
        _model.ShotInfoEvent += _view.ShotInfo;
        _view.SetCarData += _model.SetCarData;
        _model.ActivateEvent += _view.Activate;
        _model.ActivateEngineEvent += _view.OnActivateEngine;
        _model.DisactivateEngineEvent += _view.OnDisactivateEngine;
    }
    public void Disable() {
        _view.Crash -= _model.InvokeCrashEevent;
        _view.Finish -= _model.InvokeFinishEvent;
        _model.ShotInfoEvent -= _view.ShotInfo;
        _view.SetCarData -= _model.SetCarData;
        _model.ActivateEvent -= _view.Activate;
        _model.ActivateEngineEvent -= _view.OnActivateEngine;
        _model.DisactivateEngineEvent -= _view.OnDisactivateEngine;
    }
}
