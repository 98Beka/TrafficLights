using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICarSpawner {
    public void StartSpawn();
    public void StopSpawn();
    public void StopCars();
    public void StartCars();
    public Action OnLoose { get; set; }
    public Action OnAddPoint { get; set; }
    public List<ICarModel> Cars { get; }
}
