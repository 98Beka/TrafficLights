using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CarSpawner : MonoBehaviour, ICarSpawner {
    [SerializeField] Transform _startPointX;
    [SerializeField] Transform _startPointY;
    [SerializeField] AssetReference _carPrefabX;
    [SerializeField] AssetReference _carPrefabY;

    private bool isSpawnOn;
    private float delayBetweenSpawns = 0.1f;
    private float rayLong = 30;
    private bool isPlaceValidForSpawn = false;
    private GameObject point;
    private IMainCanvasModel mainCnavas;
    private void Awake() {
        point = new GameObject();
        point.transform.position = _startPointX.position;
    }
    public void StartSpawn() {
        if(mainCnavas == null)
            mainCnavas = GetComponent<EnvirenmentInitializer>().mainCanvasModel;
        isSpawnOn = true;        
        StartCoroutine(StartSpawner());
    }

    public void StopSpawn() {
        isSpawnOn = false;
    }

    IEnumerator StartSpawner() {
        while (isSpawnOn) {
            yield return new WaitForSeconds(delayBetweenSpawns);
            float x = Random.Range(0, 200);
            point.transform.position = _startPointX.position + new Vector3(x, 0, 0) ;
            point.transform.eulerAngles = new Vector3(0, 90, 0);
            IsValidPlace();
            if (isPlaceValidForSpawn == true)
                Spawn(_startPointX.position + new Vector3(x, 0, 0), _carPrefabX);

            yield return new WaitForSeconds(delayBetweenSpawns);
            float z = Random.Range(0, 200);
            point.transform.eulerAngles = Vector3.zero;
            point.transform.position = _startPointY.position + new Vector3(0, 0, z) ;
            IsValidPlace();
            if (isPlaceValidForSpawn == true)
                Spawn(_startPointY.position + new Vector3(0, 0, z), _carPrefabY);
        }
    }
    private void FixedUpdate() {
        IsValidPlace();
    }
    
    private void IsValidPlace() {
        isPlaceValidForSpawn = false;
        Debug.DrawRay(point.transform.position - point.transform.forward * (rayLong / 2), point.transform.forward * rayLong, Color.red);
        if (!Physics.Raycast(point.transform.position - point.transform.forward * (rayLong / 2), point.transform.forward, rayLong)) {
                isPlaceValidForSpawn = true;
        }
    }
    private async void Spawn(Vector3 position, AssetReference handler) {
        var _carModel = new CarModel();
        _carModel.Crash += () => mainCnavas.OpenLoosePanel();
        _carModel.Finish += () => mainCnavas.AddPoint();
        var handlerTmp = Addressables.LoadAssetAsync<GameObject>(handler);
        await handlerTmp.Task;
        if (handlerTmp.Status == AsyncOperationStatus.Succeeded) {
            var carObject = Instantiate(handlerTmp.Result);
            carObject.transform.position = position;
            var carView = carObject.GetComponent<ICarView>();
            new CarPresenter(carView, _carModel);
        }
        Addressables.Release(handlerTmp);
    }


}
