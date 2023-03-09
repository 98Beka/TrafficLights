using System;

public interface ICarView {
    public event Action Crash;
    public event Action Finish;
    public float AdditaionSpeedForStarting { get; set; }
    public float MaxMagnitudeForAdditionalSpeed { get; set; }
    public float RayLong { get; set; }
    public float Speed { get; set; }
    public void EnableMoving();
    public void DisableMoving();
}

