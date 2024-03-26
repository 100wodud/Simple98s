using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using UnityEngine;

public class CustomMapDatas
{
    private Dictionary<string, List<StageData>> customMaps = new();
    string filePath;
    public void Initialize()
    {
        filePath = Application.persistentDataPath;

        //JSON파일 로드 후 customMaps에 저장
        if (File.Exists($"{filePath}/CustomMapDatas.json"))
        {
            customMaps = JsonConvert.DeserializeObject<Dictionary<string, List<StageData>>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
        }
    }
    public void SaveCustomStage(string stageName)
    {
        if (File.Exists($"{filePath}/CustomMapDatas.json"))
        {
            customMaps = JsonConvert.DeserializeObject<Dictionary<string, List<StageData>>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
        }
        int num = customMaps.Count + 1;
        customMaps.Add(stageName, BuildingCreator.Instance.makeStage);
        string data = JsonConvert.SerializeObject(customMaps);
        File.WriteAllText($"{filePath}/CustomMapDatas.json", data);
        ScreenCapture.CaptureScreenshot($"{filePath}/{stageName}.png");
        SceneLoader.Instance.GotoCustomScene();
    }

    public List<StageData> GetCustomStage(string stageName)
    {
        return customMaps[stageName];
    }

    public Dictionary<string, List<StageData>> GetCustomStageList()
    {
        return customMaps;
    }
}
