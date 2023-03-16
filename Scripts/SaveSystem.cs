using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem {
    public static void Save<T>(T ojb, string name) where T : IDataForSave{
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, $"{name}.fun");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, ojb);
        stream.Close();
    }
    public static T Load<T>(string name) where T : class {
        string path = Application.persistentDataPath + $"/{name}.fun";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            var res = formatter.Deserialize(stream);
            stream.Close();
            return res as T;
            
        } else {
            Debug.LogWarning("Save title not found in " + path);
            return default;
        }
    }
    public static void Clear() {
        string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath, "*.fun", SearchOption.AllDirectories);

        foreach (string filepath in files) {
            File.Delete(filepath);
        }
    }
}