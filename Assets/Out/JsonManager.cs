using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonManager : MonoBehaviour
{
    private string ItemPath = Path.Combine(Application.streamingAssetsPath, "ItemData.json"); //파일 경로
    
    public List<T> LoadJsonData<T>(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<T>>(json);
    }
}
