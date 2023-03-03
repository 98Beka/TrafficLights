using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Traffic light", menuName = "Traffic light")]
public class TrafficLight : ScriptableObject
{
    public GameObject lightsBox;
    public GameObject lightBall;
    public TrafficBallsPos leftLights;
    public TrafficBallsPos rightLights;
    public TrafficBallsPos frontLights;
    public TrafficBallsPos backLights;
}

[Serializable]
public class TrafficBallsPos {
    public Transform topLight;
    public Transform bottomLight;
}