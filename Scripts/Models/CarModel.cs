using System;

public class CarModel : ICarModel {
    private const float _maxSpeed = 100;
    private const float _minSpeed = 10;
    private const float _rayLong = 10;
    private const float _additaionSpeedForStarting = 20;
    private const float _maxMagnitudeForAdditionalSpeed = 10;
    public event Action StartMoving;
    public event Action StartStoping;
    public event Action Crash;
    public event Action Finish;

    public float AdditaionSpeedForStarting => _additaionSpeedForStarting;
    public float MaxMagnitudeForAdditionalSpeed => _maxMagnitudeForAdditionalSpeed;
    public float RayLong => _rayLong;
    public float Speed { get; set; }

    public CarModel() => Speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
    public void Start() => StartMoving?.Invoke();
    public void InvokeCrashEevent() => Crash?.Invoke();
    public void InvokeFinishEvent() => Finish?.Invoke();

}