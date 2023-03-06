public class CarPresenter {
    private ICarView _carView;
    private ICarModel _carModel;

    public CarPresenter(ICarView view, ICarModel model) {
        _carModel = model;
        _carView = view;
        _carView.Speed = model.Speed;
        _carView.RayLong = model.RayLong;
        _carView.MaxMagnitudeForAdditionalSpeed = model.MaxMagnitudeForAdditionalSpeed;
        _carView.AdditaionSpeedForStarting = model.AdditaionSpeedForStarting;
        Enable();
    }

    public void Enable() {
        _carModel.StartMoving += _carView.EnableMoving;
        _carModel.StartStoping += _carView.DisableMoving;
        _carView.Crash += _carModel.InvokeCrashEevent;
    }

    public void Disable() {
        _carModel.StartMoving -= _carView.EnableMoving;
        _carModel.StartStoping -= _carView.DisableMoving;
        _carView.Crash -= _carModel.InvokeCrashEevent;
    }
}
