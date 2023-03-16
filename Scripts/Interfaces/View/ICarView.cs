using System;
using UnityEngine;

public interface ICarView {
    public delegate void SetInfo(CarData carData);
    public event Action Crash;
    public event Action Finish;
    public event SetInfo SetCarData;
    public float AdditaionSpeedForStarting { get; set; }
    public float MaxMagnitudeForAdditionalSpeed { get; set; }
    public float RayLong { get; set; }
    public float Speed { get; set; }
    public float DestroyMinY { get; set; }
    public void ShotInfo();
    public void Activate(CarData carData);
    public void OnActivateEngine();
    public void OnDisactivateEngine();
}

