using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnvirenmentInitializer : MonoBehaviour {
    [SerializeField] List<AssetReference> _otherPrefabs;
    [SerializeField] AssetReference _canvasPrefab;
    [SerializeField] AssetReference _trafficLightPrefab;
    [SerializeField] AssetReference _xBarier;
    [SerializeField] AssetReference _yBarier;
    private ICarSpawner _carSpawner;
    public IMainCanvasModel mainCanvasModel { get; private set; }


    private async void Start() {
        var canvasModel = await CanvasInit(_canvasPrefab);
        mainCanvasModel = canvasModel; 
        var trafficLightModel = await TrafficLightInit(_trafficLightPrefab);
        var barierX = await BarierInit(_xBarier);
        var barierY = await BarierInit(_yBarier);
        canvasModel.Start += () => _carSpawner.StartSpawn();
        canvasModel.ClickButtonX += trafficLightModel.SwitchLightX;
        canvasModel.ClickButtonY += trafficLightModel.SwitchLightY;
        trafficLightModel.SwitchX += barierX.SwitchActive;
        trafficLightModel.SwitchY += barierY.SwitchActive;
        _carSpawner = GetComponent<ICarSpawner>();
        foreach(var asset in _otherPrefabs)
            Init(asset);
    }

    private async void Init(AssetReference prefab) {
        var handlerTmp = Addressables.LoadAssetAsync<GameObject>(prefab);
        await handlerTmp.Task;
        if (handlerTmp.Status == AsyncOperationStatus.Succeeded) {
            Instantiate(handlerTmp.Result);
        }
        Addressables.Release(handlerTmp);
    }

    private async Task<MainCanvasModel> CanvasInit(AssetReference prefab) {
        var model = new MainCanvasModel();
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
    private async Task<TrafficLightModel> TrafficLightInit(AssetReference prefab) {
        var model = new TrafficLightModel();
        var obj = await GetObjFromAddressable(prefab);
        var view = obj.GetComponent<ITrafficLightView>();
        new TrafficLightPresenter(view, model);
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
