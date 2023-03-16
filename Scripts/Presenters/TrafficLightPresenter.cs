public class TrafficLightPresenter {
    private ITrafficLightView _view;
    private ITrafficLightModel _model;

    public TrafficLightPresenter(ITrafficLightView view, ITrafficLightModel model) {
        _view = view;
        _model = model;
        Enable();
    }
    public void Enable() {
        _model.SwitchX += _view.SwitchX;
        _model.SwitchY += _view.SwitchY;
    }
    public void Disable() {
        _model.SwitchX -= _view.SwitchX;
        _model.SwitchY -= _view.SwitchY;
    }
}
