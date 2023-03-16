using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnvirenmentInitializer : MonoBehaviour {
    [SerializeField] List<AssetReference> _otherPrefabs;
    [SerializeField] AssetReference _mainCanvasPrefab;
    [SerializeField] AssetReference _trafficLightPrefab;
    [SerializeField] AssetReference _xBarierPrefab;
    [SerializeField] AssetReference _yBarierPrefab;
    [SerializeField] AssetReference _StartBtnPrefab;
    [SerializeField] AssetReference _PuaseBtnPrefab;
    [SerializeField] AssetReference _winWindowPrefab;
    [SerializeField] AssetReference _looseWindowPrefab;
    private ICarSpawner _carSpawner;
    public IMainCanvasModel MainCanvasModel { get; set; }
    public TrafficLightModel TrafficLightModel { get; set; }


    private async void Start() {
        var mainCanvasModel = await MainCanvasInit(_mainCanvasPrefab);
        var trafficLightModel = await TrafficLightInit(_trafficLightPrefab);
        var startBtnModel = await StartButtonInit(_StartBtnPrefab);
        var pauseBtnModel = await PauseButtonInit(_PuaseBtnPrefab);
        var winWindowModel = await WinWindowInit(_winWindowPrefab);
        var looseWindowModel = await LooseWindowInit(_looseWindowPrefab);

        winWindowModel.Disactivate();
        looseWindowModel.Disactivate();
        pauseBtnModel.Disactivate();
        mainCanvasModel.Disactivate();

        _carSpawner = GetComponent<ICarSpawner>();
        _carSpawner.OnLoose = () => {
            mainCanvasModel.Disactivate();
            looseWindowModel.Activate();
            pauseBtnModel.Disactivate();
        };

        startBtnModel.GameStartEvent += () => {
            _carSpawner.StartSpawn();
            startBtnModel.Disactivate();
            pauseBtnModel.Activate();
            mainCanvasModel.Activate();
            _carSpawner.StartCars();
        };

        pauseBtnModel.GamePauseEvent += () => {
            _carSpawner.StopSpawn();
            startBtnModel.Activate();
            pauseBtnModel.Disactivate();
            mainCanvasModel.Disactivate();
            _carSpawner.StopCars();
        };
        pauseBtnModel.OnButtonClick();


        mainCanvasModel.WinEvent += () => winWindowModel.Activate();

        mainCanvasModel.XButtonClickEvent += trafficLightModel.SwitchLightX;
        mainCanvasModel.YButtonClickEvent += trafficLightModel.SwitchLightY;

        _carSpawner.OnAddPoint = () => mainCanvasModel.AddPoint();

        foreach(var asset in _otherPrefabs)
            Init(asset);


        MainCanvasModel = mainCanvasModel;
    }

    private async void Init(AssetReference prefab) {
        var handlerTmp = Addressables.LoadAssetAsync<GameObject>(prefab);
        await handlerTmp.Task;
        if (handlerTmp.Status == AsyncOperationStatus.Succeeded) {
            Instantiate(handlerTmp.Result);
        }
        Addressables.Release(handlerTmp);
    }

    private async Task<MainCanvasModel> MainCanvasInit(AssetReference prefab) {
        var pointsData = SaveSystem.Load<PointsDataForSave>("points");
        MainCanvasModel model = pointsData != null ? new MainCanvasModel(pointsData.points) : new MainCanvasModel();
        var handlerTmp = Addressables.LoadAssetAsync<GameObject>(prefab);
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<IMainCanvasView>();
        new MainCanvasPresenter(view, model);
        return model;
    }
    private async Task<BarierModel> BarierInit(AssetReference prefab) {
        var model = new BarierModel();
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<IBarierView>();
        new BarierPresenter(view, model);       
        return model;
    }
    private async Task<StartButtonModel> StartButtonInit(AssetReference prefab) {
        var model = new StartButtonModel();
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<IButtonView>();
        new StartButtonPresenter(view, model);
        return model;
    }
    private async Task<PauseButtonModel> PauseButtonInit(AssetReference prefab) {
        var model = new PauseButtonModel();
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<IButtonView>();
        new PauseButtonPresenter(view, model);
        return model;
    }
    private async Task<LooseWindowModel> LooseWindowInit(AssetReference prefab) {
        var model = new LooseWindowModel();
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<IUIView> ();
        var view2 = obj.GetComponent<IButtonView>();
        new LooseWindowPresenter(view, view2, model);
        return model;
    }
    private async Task<WinWindowModel> WinWindowInit(AssetReference prefab) {
        var model = new WinWindowModel();
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<IUIView> ();
        var view2 = obj.GetComponent<IButtonView>();
        new WinWindowPresenter(view, view2, model);
        return model;
    }
    private async Task<TrafficLightModel> TrafficLightInit(AssetReference prefab) {
        var trf = SaveSystem.Load<TrafficLightDataForSave>("trafficLight");
        TrafficLightModel model = new TrafficLightModel();
        TrafficLightModel = model;
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<ITrafficLightView>();
        new TrafficLightPresenter(view, model);
        var barierX = await BarierInit(_xBarierPrefab);
        var barierY = await BarierInit(_yBarierPrefab);
        model.SwitchX += barierX.SwitchActive;
        model.SwitchY += barierY.SwitchActive;
        if (trf != null) {
            if (!trf.isYGreen)
                model.SwitchLightY();
            if (!trf.isXGreen)
                model.SwitchLightX();
        }
        return model;
    }
    private async Task<GameObject> GetObjFromAddressable(AssetReference prefab) {
        var handlerTmp = Addressables.LoadAssetAsync<GameObject>(prefab);
        await handlerTmp.Task;
        if (handlerTmp.Status == AsyncOperationStatus.Succeeded) {
            return GameObject.Instantiate(handlerTmp.Result);
        }
        return default;
    }

}
