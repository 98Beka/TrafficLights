using System;

public interface IBarierModel {
    public event Action Active;
    public void SwitchActive();
}