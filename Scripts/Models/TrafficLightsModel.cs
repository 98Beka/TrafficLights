using UnityEngine;

public class TrafficLightsModel
{
    public TrafficBallsMaterials Left { get; set; }
    public TrafficBallsMaterials Right { get; set; }
    public TrafficBallsMaterials Front { get; set; }
    public TrafficBallsMaterials Back { get; set; }
}
public class TrafficBallsMaterials {
    public Renderer topLight;
    public Renderer bottomLight;
}