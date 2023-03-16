using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private ICarSpawner _carSpawner;
    private EnvirenmentInitializer _envirenmentInitializer;
    private const float _delayForSaving = 3;
    void Start()
    {
        StartCoroutine(Save());
    }
    IEnumerator Save() {
        yield return new WaitForSeconds(1);
        _carSpawner = FindAnyObjectByType<CarSpawner>();
        _envirenmentInitializer = FindAnyObjectByType<EnvirenmentInitializer>();
        while (true) {
            yield return new WaitForSeconds(_delayForSaving);
            SaveCars();
            SaveTrafficLight();
            SaveScore();
        }
    }

    private void SaveCars() {
        foreach (var car in _carSpawner.Cars) {
            car.ActualizateInfo();
            SaveSystem.Save(new CarDataForSave(car), car.UnitCarId.ToString());
        }
        SaveSystem.Save(new CarsIdsForSave(_carSpawner.Cars), "carsIds");
    }
    private void SaveTrafficLight() {
        var trf = new TrafficLightDataForSave() {
            isXGreen = _envirenmentInitializer.TrafficLightModel.IsXGreen,
            isYGreen = _envirenmentInitializer.TrafficLightModel.IsYGreen
        };
        SaveSystem.Save(trf, "trafficLight");
    }
    private void SaveScore() {
        var pointsData = new PointsDataForSave();
        pointsData.points = _envirenmentInitializer.MainCanvasModel.GetPoints();
        SaveSystem.Save(pointsData, "points");
    }
}
