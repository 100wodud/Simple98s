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
        //JSON���� �ε� �� customMaps�� ����
        if (File.Exists($"{filePath}/CustomMapDatas.json"))
        {
            customMaps = JsonConvert.DeserializeObject<Dictionary<int, List<StageData>>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
        }
    }
    public void SaveCustomStage()
    {
        bool canSave = true;
        int playerTile = BuildingCreator.Instance.makeStage.FindAll(item => item.tile == 48).Count;

        if (playerTile == 0 ){
            Debug.Log("�÷��̾� Ÿ���� �ϳ� �̻� �����ÿ�");
            canSave = false;
        } else if (playerTile > 1)
        {
            Debug.Log("�÷��̾� Ÿ���� �ϳ��� �����ÿ�");
            canSave = false;
        }

        if (canSave)
        {
            if (File.Exists($"{filePath}/CustomMapDatas.json"))
            {
                customMaps = JsonConvert.DeserializeObject<Dictionary<int, List<StageData>>>(File.ReadAllText($"{filePath}/CustomMapDatas.json"));
            }
            int num = customMaps.Count + 1;
            customMaps.Add(num, BuildingCreator.Instance.makeStage);
            string data = JsonConvert.SerializeObject(customMaps);
            File.WriteAllText($"{filePath}/CustomMapDatas.json", data);
        }
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
