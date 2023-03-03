using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnvirenmentSpawner : MonoBehaviour, IEnvirenmentSpawner
{
    [SerializeField] List<GameObject> roads;
    [SerializeField] TrafficLight trafficLight;
    [SerializeField] MainCanvas mainCanvas;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject directaionLight;
    private ITrafficLightController trafficLightController;
    private ICarSpawner carSpawner;

    [Inject]
    public void Construct(ITrafficLightController trafficLightController, ICarSpawner carSpawner) {
        this.trafficLightController = trafficLightController;
        this.carSpawner = carSpawner;
    }
    // Start is called before the first frame update
    public void SpawnEnvirenment() {
        SpawnTrafficLight();
        SpawnCamera();
        SpawnLights();
        SpawnMainCanvas();
        SpawnRoads();
    }
    private void SpawnTrafficLight() {
        var box = Instantiate(trafficLight.lightsBox);
        box.transform.localPosition = trafficLight.lightsBox.transform.localPosition;
        box.transform.rotation = trafficLight.lightsBox.transform.rotation;
        trafficLightController.TrafficLights = new TrafficLightsModel() {
            Left = SpawnTrafficLight(trafficLight.leftLights, box.transform),
            Front = SpawnTrafficLight(trafficLight.frontLights, box.transform),
            Right = SpawnTrafficLight(trafficLight.rightLights, box.transform),
            Back = SpawnTrafficLight(trafficLight.backLights, box.transform)
        };
    }

    private TrafficBallsMaterials SpawnTrafficLight(TrafficBallsPos trafficBallsPos, Transform paretn) {
        var tmpTop = Instantiate(trafficLight.lightBall, paretn);
        tmpTop.transform.localPosition = trafficBallsPos.topLight.position;
        tmpTop.transform.localScale = trafficBallsPos.topLight.localScale;
        var tmpBottom = Instantiate(trafficLight.lightBall, paretn);
        tmpBottom.transform.localPosition = trafficBallsPos.bottomLight.position;
        tmpBottom.transform.localScale = trafficBallsPos.bottomLight.localScale;

        return new TrafficBallsMaterials() {
            topLight = tmpTop.GetComponent<Renderer>(),
            bottomLight = tmpBottom.GetComponent<Renderer>()
        };
    }
    private void SpawnRoads() {
        var barieer = Instantiate(roads[0]).transform.GetChild(0);
        barieer.gameObject.SetActive(!barieer.gameObject.activeSelf);
        trafficLightController.XButtonClickEvent.AddListener(() => {
            barieer.gameObject.SetActive(!barieer.gameObject.activeSelf);
        });
        var barieer2 = Instantiate(roads[1]).transform.GetChild(0);
        barieer2.gameObject.SetActive(!barieer2.gameObject.activeSelf);
        trafficLightController.YButtonClickEvent.AddListener(() => {
            barieer2.gameObject.SetActive(!barieer2.gameObject.activeSelf);
        });
    }
    private void SpawnCamera() {
        Instantiate(camera);
    }
    private void SpawnLights() {
        Instantiate(directaionLight);
    }
    private void SpawnMainCanvas() {
        Instantiate(mainCanvas.eventSistem);
        var canvas = Instantiate(mainCanvas.canvas);
        var xBtn = Instantiate(mainCanvas.xButton, canvas.transform);
        var yBtn = Instantiate(mainCanvas.yButton, canvas.transform);
        var startBtn = Instantiate(mainCanvas.startButton, canvas.transform);
        var pauseBtn = Instantiate(mainCanvas.pauseButton, canvas.transform);

        trafficLightController.XButtonClickEvent = xBtn.GetComponent<Button>().onClick;
        trafficLightController.YButtonClickEvent = yBtn.GetComponent<Button>().onClick;

        pauseBtn.GetComponent<Button>().onClick.AddListener(() => {
            pauseBtn.SetActive(false);
            xBtn.SetActive(false);
            yBtn.SetActive(false);
            startBtn.SetActive(true);
            startBtn.transform.GetComponentInChildren<Text>().text = "continue";
            carSpawner?.StopSpawn();
            Time.timeScale = 0;
        });

        startBtn.GetComponent<Button>().onClick.AddListener(() => {
            startBtn.SetActive(false);
            xBtn.SetActive(true);
            yBtn.SetActive(true);
            pauseBtn.SetActive(true);
            carSpawner?.StartSpawn();
            Time.timeScale = 1;
        });

        xBtn.SetActive(false);
        yBtn.SetActive(false);
        pauseBtn.SetActive(false);
    }
}
