public class TrafficLightPresenter {
    private ITrafficLightView _trafficLightView;
    private ITrafficLightModel _trafficLightModel;

    public TrafficLightPresenter(ITrafficLightView view, ITrafficLightModel model) {
        _trafficLightView = view;
        _trafficLightModel = model;
        Enable();
    }

    public void Enable() {
        _trafficLightModel.SwitchX += _trafficLightView.SwitchX;
        _trafficLightModel.SwitchY += _trafficLightView.SwitchY;
    }

    public void Disable() {
        _trafficLightModel.SwitchX -= _trafficLightView.SwitchX;
        _trafficLightModel.SwitchY -= _trafficLightView.SwitchY;
    }
}
