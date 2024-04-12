using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveStageJson
{
    public StageStarData stageStarData;

    private static SaveStageJson _instance;

    public static SaveStageJson Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = new SaveStageJson();
            }
            return _instance;
        }
    }
    private string basePath = Application.persistentDataPath; // 저장경로: C:\Users\[user name]\AppData\LocalLow\[company name]\[product name]
    private string fileExtension = ".json";
    //"Assets/Data/"; 에디터전용 세이브 경로
    //path = Application.persistentDataPath; 나중에 경로 바꿀용
    public void SaveStageData(int stageIndex, StageStarData stageData)
    {
        string fileName = "StageStarData" + stageIndex.ToString() + fileExtension;

        string json = JsonUtility.ToJson(stageData);
        File.WriteAllText(basePath + fileName, json);
    }
    public void LoadStageData(int stageIndex, StageStarData stageData)
    {
        string fileName = "StageStarData" + stageIndex.ToString() + fileExtension;

        if(File.Exists(basePath + fileName))
        {
            string json = File.ReadAllText(basePath + fileName);
            JsonUtility.FromJsonOverwrite(json,stageData);
        }
        else
        {
            Debug.Log("File not Found" + fileName);
        }
    }
    //public void SaveToJson(int index)
    //{
    //    string fileName = "StageStarData" + index.ToString()+".json";

    //    string filePath = basePath + fileName;

    //    string json = JsonUtility.ToJson(filePath);

    //    File.WriteAllText(filePath, json);

    //    Debug.Log("Save to Json file" + filePath);
    //}

    //public void LosatToJson(int index)
    //{
    //    string fileName = "StageStarData" + index.ToString() + ".json";

    //    string filePath = basePath + fileName;

    //    //예외처리
    //    if(!File.Exists(filePath))
    //    {
    //        Debug.Log("Json File NO");
    //        return;
    //    }

    //    string json = File.ReadAllText(filePath);

    //    JsonUtility.FromJsonOverwrite(json, stageStarData);

    //    Debug.Log("Load to Json file"+filePath);
    //}
}
