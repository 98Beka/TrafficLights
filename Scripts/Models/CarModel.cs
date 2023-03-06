using System;

public class CarModel : ICarModel {
    private const float _maxSpeed = 15;
    private const float _minSpeed = 15;
    private const float _rayLong = 7;
    private const float _additaionSpeedForStarting = 10;
    private const float _maxMagnitudeForAdditionalSpeed = 10;
    public event Action StartMoving;
    public event Action StartStoping;
    public event Action Crash;

    public float AdditaionSpeedForStarting { get { return _additaionSpeedForStarting; } }
    public float MaxMagnitudeForAdditionalSpeed { get { return _maxMagnitudeForAdditionalSpeed; } }
    public float RayLong { get { return _rayLong; } }
    public float Speed { get; set; }

    public CarModel() {
        Speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
    }
    public void Start() {
        StartMoving?.Invoke();
    }
    public void InvokeCrashEevent() {
        Crash?.Invoke();
    }

}