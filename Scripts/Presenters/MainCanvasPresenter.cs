public class MainCanvasPresenter {
    private IMainCanvasView _view;
    private IMainCanvasModel _model;

    public MainCanvasPresenter(IMainCanvasView view, IMainCanvasModel model) {
        _model = model;
        _view = view;
        Enable();
        _view.UpdatePoints(_model.GetPoints());
    }
    public void Enable() {
        _view.ClickButtonX += _model.ClickX;
        _view.ClickButtonY += _model.ClickY;
        _model.UpdatePointEvent += _view.UpdatePoints;
        _model.ActivateEvent += _view.OnActivate;
        _model.DisactivateEvent += _view.OnDisactivate;
    }
    public void Disable() {
        _view.ClickButtonX -= _model.ClickX;
        _view.ClickButtonY -= _model.ClickY;
        _model.UpdatePointEvent -= _view.UpdatePoints;
        _model.ActivateEvent -= _view.OnActivate;
        _model.DisactivateEvent -= _view.OnDisactivate;
    }
}
