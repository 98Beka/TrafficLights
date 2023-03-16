using System;
using UnityEngine;
using static ICarView;

public class CarModel : ICarModel {
    public event Action CrashEvent;
    public event Action FinishEvent;
    public event Action ShotInfoEvent;
    public event SetInfo ActivateEvent;
    public event Action ActivateEngineEvent;
    public event Action DisactivateEngineEvent;
    private const float _maxSpeed = 50;
    private const float _minSpeed = 10;
    private const float _rayLong = 10;
    private const float _destroyMinY = -5;
    private const float _additaionSpeedForStarting = 20;
    private const float _maxMagnitudeForAdditionalSpeed = 10;
    private int _unicCarId;
    private float _speed;
    private string _tag;
    private bool _isFinished;

    public CarModel(CarDataForSave carData) {
        _unicCarId = carData.unicCarId;
        _speed = carData.speed;
        _tag = carData.tag;
        _speed = carData.speed;
        if (carData.isFinished)
            InvokeFinishEvent();
    }
    public CarModel(int unicCarId, string tag) {
        _unicCarId = unicCarId;
        _speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
        _tag = tag;
    }
    public CarData CarData { get; set; } = new CarData();
    public float AdditaionSpeedForStarting => _additaionSpeedForStarting;
    public float MaxMagnitudeForAdditionalSpeed => _maxMagnitudeForAdditionalSpeed;
    public float DestroyMinY => _destroyMinY;
    public float RayLong => _rayLong;
    public float Speed => _speed;
    public string Tag => _tag;
    public int UnitCarId => _unicCarId;
    public bool IsFinished => _isFinished;
    public void InvokeCrashEevent() => CrashEvent?.Invoke();
    public void InvokeFinishEvent() {
        _isFinished = true;
        FinishEvent?.Invoke();
    }
    public void Activate() {
        _isFinished = false;
        ActivateEvent?.Invoke(CarData);
    }
    public void SetCarData(CarData carData) => CarData = carData;
    public void ActualizateInfo() => ShotInfoEvent?.Invoke();
    public void ActivateEngine() => ActivateEngineEvent?.Invoke();
    public void DisactivateEngine() => DisactivateEngineEvent?.Invoke();
}

public class CarData {
    public Vector3 Position { get; set; } = Vector3.zero;
    public Vector3 EulerAngles { get; set; } = Vector3.zero;
}