using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CarSpawner : MonoBehaviour, ICarSpawner {
    public Action OnLoose { get; set; }
    public Action OnAddPoint { get; set; }

    [SerializeField] Transform _startPointX;
    [SerializeField] Transform _startPointY;
    [SerializeField] AssetReference _carPrefabX;
    [SerializeField] AssetReference _carPrefabY;
    private List<ICarModel> _cars = new List<ICarModel>();
    private bool _isSpawnOn;
    private float _delayBetweenSpawns = 1;
    private const float _delayForStartLoading = 1;
    private float _rayLongForValidation = 30;
    private bool _isPlaceValidForSpawn;
    private GameObject _point;
    private EnvirenmentInitializer _initializer;

    public List<ICarModel> Cars => _cars;
    private void Awake() {
        _point = new GameObject();
        _point.transform.position = _startPointX.position;
        _initializer = GetComponent<EnvirenmentInitializer>();
    }
    private void Start() {
        StartCoroutine(Load());
    }
    public void StartSpawn() {
        _isSpawnOn = true;        
        StartCoroutine(StartSpawner());
    }
    public void StopSpawn() {
        _isSpawnOn = false;
    }
    private void GetFromBoferOrSpawn(Transform transform, AssetReference prefab, string tag) {
        var booferCar = _cars.Where(s => s.IsFinished == true && s.Tag == tag).FirstOrDefault();
        if(booferCar == null)
            Spawn(transform.position, prefab);
        else {
            booferCar.SetCarData(
                new CarData() {
                    Position = transform.position,
                    EulerAngles = transform.eulerAngles
                });
            booferCar.Activate();

        }
    }
    IEnumerator StartSpawner() {
        while (_isSpawnOn) {
            yield return new WaitForSeconds(_delayBetweenSpawns);
            float x = UnityEngine.Random.Range(0, 200);
            _point.transform.position = _startPointX.position + new Vector3(x, 0, 0) ;
            _point.transform.eulerAngles = new Vector3(0, 90, 0);
            IsValidPlace();
            if (_isPlaceValidForSpawn == true)
                GetFromBoferOrSpawn(_point.transform, _carPrefabX, "carX");

            float z = UnityEngine.Random.Range(0, 200);
            _point.transform.eulerAngles = Vector3.zero;
            _point.transform.position = _startPointY.position + new Vector3(0, 0, z) ;
            IsValidPlace();
            if (_isPlaceValidForSpawn == true)
                GetFromBoferOrSpawn(_point.transform, _carPrefabY, "carY");
        }
    }
    private void FixedUpdate() {
        IsValidPlace();
    }
    
    private void IsValidPlace() {
        _isPlaceValidForSpawn = false;
        Debug.DrawRay(_point.transform.position - _point.transform.forward * (_rayLongForValidation / 2), _point.transform.forward * _rayLongForValidation, Color.red);
        if (!Physics.Raycast(_point.transform.position - _point.transform.forward * (_rayLongForValidation / 2), _point.transform.forward, _rayLongForValidation)) {
            _isPlaceValidForSpawn = true;
        }
    }
    private async void Spawn(Vector3 position, AssetReference prefab) {
        var handlerTmp = Addressables.LoadAssetAsync<GameObject>(prefab);
        await handlerTmp.Task;
        if (handlerTmp.Status == AsyncOperationStatus.Succeeded) {

            var carObject = Instantiate(handlerTmp.Result);
            carObject.transform.position = position;
            var carView = carObject.GetComponent<ICarView>();

            var _carModel = new CarModel(_cars.Count, carObject.tag);
            _carModel.CrashEvent += () =>  OnLoose();
            _carModel.FinishEvent += () => OnAddPoint();

            new CarPresenter(carView, _carModel);
            _cars.Add(_carModel);
        }
        Addressables.Release(handlerTmp);
    }
    private async void Spawn(CarDataForSave carData) {
        AssetReference prefab = carData.tag == "carX" ? _carPrefabX : _carPrefabY;
        var handlerTmp = Addressables.LoadAssetAsync<GameObject>(prefab);
        await handlerTmp.Task;
        if (handlerTmp.Status == AsyncOperationStatus.Succeeded) {

            var carObject = Instantiate(handlerTmp.Result);
            carObject.transform.position = new Vector3(carData.position[0], carData.position[1], carData.position[2]);
            var carView = carObject.GetComponent<ICarView>();

            var _carModel = new CarModel(carData);
            _carModel.CrashEvent += () => OnLoose();
            _carModel.FinishEvent += () => OnAddPoint();

            new CarPresenter(carView, _carModel);
            _cars.Add(_carModel);
        }
        Addressables.Release(handlerTmp);
    }

    public void StopCars() {
        foreach (var item in _cars)
            item.DisactivateEngine();
    }
    public void StartCars() {
        foreach (var item in _cars)
            item.ActivateEngine();
    }
IEnumerator Load() {
        yield return new WaitForSeconds(_delayForStartLoading);
        var carsIds = SaveSystem.Load<CarsIdsForSave>("carsIds");
        if (carsIds != null) {
            foreach(var Id in carsIds.Ids) {
                var car = SaveSystem.Load<CarDataForSave>(Id.ToString());
                Spawn(car);
            }
            SaveSystem.Save(new CarsIdsForSave(new List<ICarModel>()), "carsIds");
        }
    }
}
