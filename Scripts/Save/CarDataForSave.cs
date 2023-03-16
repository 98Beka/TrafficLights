using System;

[Serializable]
public class CarDataForSave : IDataForSave {
    public float[] position;
    public float speed;
    public int unicCarId;
    public string tag;
    public bool isFinished;
    public CarDataForSave(ICarModel carModel) {
        speed = carModel.Speed;
        unicCarId = carModel.UnitCarId;
        tag = carModel.Tag;
        isFinished = carModel.IsFinished;
        position = new float[3];
        position[0] = carModel.CarData.Position.x;
        position[1] = carModel.CarData.Position.y;
        position[2] = carModel.CarData.Position.z;
    }
}

