using System;

public interface ICarModel {
    public event Action StartMoving;
    public event Action StartStoping;
    public event Action Crash;
    public event Action Finish;
    public float AdditaionSpeedForStarting { get; }
    public float MaxMagnitudeForAdditionalSpeed { get; }
    public float RayLong { get; }
    public float Speed { get; set; }
    public void Start();
    public void InvokeCrashEevent();
    public void InvokeFinishEvent();

}

