using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Security.Cryptography.X509Certificates;
using UGS;
using UnityEngine;

public class CustomMapDatas
{
    private Dictionary<string, CustomData> customMaps = new();
    string filePath;
    public void Initialize()
    {
        filePath = Application.persistentDataPath;

        //JSON파일 로드 후 customMaps에 저장
        if (File.Exists($"{filePath}/CustomMapDatas.json"))
        {
            customMaps = JsonConvert.DeserializeObject<Dictionary<string, CustomData>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
        }
    }
    public void SaveCustomStage(string stageName)
    {
        if (File.Exists($"{filePath}/CustomMapDatas.json"))
        {
            customMaps = JsonConvert.DeserializeObject<Dictionary<string, CustomData>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
        }
        CustomData data = new CustomData(stageName);
        customMaps.Add(stageName, data);
        string customDatas = JsonConvert.SerializeObject(customMaps);
        string custom = JsonConvert.SerializeObject(BuildingCreator.Instance.makeStage);
        File.WriteAllText($"{filePath}/CustomMapDatas.json", customDatas);
        Directory.CreateDirectory($"{filePath}/{stageName}");
        File.WriteAllText($"{filePath}/{stageName}/{stageName}.json", custom);
        ScreenCapture.CaptureScreenshot($"{filePath}/{stageName}/{stageName}.png");
        SceneLoader.Instance.GotoCustomScene();
    }


    public void SaveDevStage()
    {
        string path = Application.dataPath+ "/DevStage";
        string custom = JsonConvert.SerializeObject(BuildingCreator.Instance.makeStage);
        File.WriteAllText($"{path}/DevStage.json", custom);
    }

    public List<StageData> GetCustomStage(string stageName)
    {
        return JsonConvert.DeserializeObject<List<StageData>>(File.ReadAllText($"{filePath}/{stageName}/{stageName}.json"));
    }

    public Dictionary<string, CustomData> GetCustomStageList()
    {
        return customMaps;
    }
}
