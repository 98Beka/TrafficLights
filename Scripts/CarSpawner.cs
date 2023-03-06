using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarSpawner : MonoBehaviour, ICarSpawner {
    [SerializeField] Transform startPointX;
    [SerializeField] Transform startPointY;
    [SerializeField] GameObject _carPrefabX;
    [SerializeField] GameObject _carPrefabY;
    private bool isSpawnOn = false;
    private float spawnTime = 5;

    //public void Start() {
    //    StartCoroutine(HealthIncrease());
    //}
    private float time;
    private void Start() {
        time = spawnTime;
    }
    private void Update() {
        time += Time.deltaTime;
        if(time > spawnTime && isSpawnOn) {
            float x = Random.Range(0, 5);
            Spawn(startPointX.position + new Vector3(x, 0, 0), _carPrefabX);
            
            float y = Random.Range(0, 5);
            Spawn(startPointY.position + new Vector3(0, 0, y), _carPrefabY);
            time = 0;
        }
    }

    private GameObject Spawn(Vector3 position, GameObject _carPrefab) {
        var _carModel = new CarModel();
        var carObject = GameObject.Instantiate(_carPrefab);
        var carView = carObject.GetComponent<CarView>();
        carObject.transform.position = position;
        var _carPresenter = new CarPresenter(carView, _carModel);
        return carObject;
    }

    public void StartSpawn() {
        isSpawnOn = true;
    }

    public void StopSpawn() {
        isSpawnOn = false;
    }

}
