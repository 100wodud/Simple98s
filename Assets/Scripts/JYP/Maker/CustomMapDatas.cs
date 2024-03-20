using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CustomMapDatas
{
    private Dictionary<int, List<StageData>> customMaps = new();
    string filePath = Directory.GetCurrentDirectory();
    public void Initialize()
    {
        //JSON파일 로드 후 customMaps에 저장
        if (File.Exists($"{filePath}/CustomMapDatas.json"))
        {
            customMaps = JsonConvert.DeserializeObject<Dictionary<int, List<StageData>>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
        }
    }
    public void SaveCustomStage()
    {
        if (File.Exists($"{filePath}/CustomMapDatas.json"))
        {
            customMaps = JsonConvert.DeserializeObject<Dictionary<int, List<StageData>>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
        }
        int num = customMaps.Count+1;
        customMaps.Add(num, BuildingCreator.Instance.makeStage);
        Debug.Log(customMaps);
        string data = JsonConvert.SerializeObject(customMaps);
        File.WriteAllText($"{filePath}/CustomMapDatas.json", data);
    }

    public List<StageData> GetCustomStage(int StageIndex)
    {
        return customMaps[StageIndex];
    }

    public Dictionary<int, List<StageData>> GetCustomStageList()
    {
        return customMaps;
    }
}
