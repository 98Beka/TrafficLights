public class MainCanvasPresenter {
    private IMainCanvasView _canvasView;
    private IMainCanvasModel _canvasModel;

    public MainCanvasPresenter(IMainCanvasView view, IMainCanvasModel model) {
        _canvasModel = model;
        _canvasView = view;
        Enable();
    }

    public void Enable() {
        _canvasView.StartGame += _canvasModel.StartGame;
        _canvasView.PauseGame += _canvasModel.PauseGame;
        _canvasView.ClickButtonX += _canvasModel.ClickX;
        _canvasView.ClickButtonY += _canvasModel.ClickY;
        _canvasModel.ActivateLoosePanel += _canvasView.OpenLoosePanel;
        _canvasModel.ActivateMainPanel += _canvasView.OpenMainPanel;
        _canvasModel.AddOnePoint += _canvasView.AddPoint;
    }

    public void Disable() {
        _canvasView.StartGame -= _canvasModel.StartGame;
        _canvasView.PauseGame -= _canvasModel.PauseGame;
        _canvasView.ClickButtonX -= _canvasModel.ClickX;
        _canvasView.ClickButtonY -= _canvasModel.ClickY;
        _canvasModel.ActivateLoosePanel -= _canvasView.OpenLoosePanel;
        _canvasModel.ActivateMainPanel -= _canvasView.OpenMainPanel;
        _canvasModel.AddOnePoint -= _canvasView.AddPoint;
    }
}
