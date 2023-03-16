using System;
using System.Collections.Generic;

[Serializable]
public class CarsIdsForSave : IDataForSave {
    public CarsIdsForSave(List<ICarModel> cars) {
        int i = 0;
        Ids = new int[cars.Count];
        foreach(var car in cars) {
            Ids[i] = car.UnitCarId;
            i++;
        }
    }
    public int[] Ids;
}
