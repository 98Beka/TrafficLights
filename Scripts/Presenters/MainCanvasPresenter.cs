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
        _view.XButtonClickEvent += _model.OnClickX;
        _view.YButtonClickEvent += _model.OnClickY;
        _model.UpdatePointEvent += _view.UpdatePoints;
        _model.ActivateEvent += _view.OnActivate;
        _model.DisactivateEvent += _view.OnDisactivate;
    }
    public void Disable() {
        _view.XButtonClickEvent -= _model.OnClickX;
        _view.YButtonClickEvent -= _model.OnClickY;
        _model.UpdatePointEvent -= _view.UpdatePoints;
        _model.ActivateEvent -= _view.OnActivate;
        _model.DisactivateEvent -= _view.OnDisactivate;
    }
}
