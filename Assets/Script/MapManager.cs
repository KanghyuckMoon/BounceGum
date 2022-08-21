using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Map
{
    public int level;
    public List<GameObject> objects;
}

public class MapManager : MonoBehaviour
{
    public Map map;
    
    [ContextMenu("To Json Data")]
    void SaveMapDatatoJson()
    {
        string jsonData = JsonUtility.ToJson(map);
        string path = Path.Combine(Application.dataPath, "mapdata.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("From Json Data")]
    void LoadMapDatatoJson()
    {
        string path = Path.Combine(Application.dataPath, "mapdata.json");
        string jsonData = File.ReadAllText(path);
        map = JsonUtility.FromJson<Map>(jsonData);
    }
}
