using System;
using UnityEngine;
using static ICarView;

public interface ICarModel {
    public event Action CrashEvent;
    public event Action FinishEvent;
    public event Action ShotInfoEvent;
    public event SetInfo ActivateEvent;
    public event Action ActivateEngineEvent;
    public event Action DisactivateEngineEvent;
    public CarData CarData { get; set; }
    public float AdditaionSpeedForStarting { get; }
    public float MaxMagnitudeForAdditionalSpeed { get; }
    public float DestroyMinY { get; }
    public float RayLong { get; }
    public float Speed { get; }
    public int UnitCarId { get; }
    public string Tag { get; }
    public bool IsFinished { get; }
    public void InvokeCrashEevent();
    public void InvokeFinishEvent();
    public void SetCarData(CarData carData);
    public void Activate();
    public void ActualizateInfo();
    public void ActivateEngine();
    public void DisactivateEngine();
}

