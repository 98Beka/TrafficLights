using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarSpawner : MonoBehaviour, ICarSpawner {
    [SerializeField] Transform startPointX;
    [SerializeField] Transform startPointY;
    [SerializeField] GameObject car;
    private bool isSpawnOn = false;
    private float spawnTime = 2;

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
            float x = Random.RandomRange(0, 500);
            Spawn(startPointX.position + new Vector3(x, 0, 0), new Vector3(0, 90, 0)).tag = "carX";

            float y = Random.RandomRange(0, 500);
            Spawn(startPointY.position + new Vector3(0, 0, y), new Vector3(0, 0, 0)).tag = "carY";
            time = 0;
        }
    }

    private GameObject Spawn(Vector3 position, Vector3 euler) {
        var carCopy = GameObject.Instantiate(car);
        carCopy.transform.rotation = Quaternion.Euler(euler);
        carCopy.GetComponent<Rigidbody>().velocity = carCopy.transform.forward * 100;
        carCopy.transform.position = position;
        return carCopy;
    }

    public void StartSpawn() {
        isSpawnOn = true;
    }

    public void StopSpawn() {
        isSpawnOn = false;
    }

}
