using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDataManager:Singleton<JsonDataManager>
{
    SaveStageData stageData;
    string path;

    string filename = "save";
    void Awake()
    {
        path = Application.persistentDataPath;
    }
    public void JsonSave(int stageIndex,int star,int coin,bool stageClear)//저장 실험
    {
        
        stageData = new SaveStageData(stageIndex ,star, coin, stageClear);
        string data = JsonUtility.ToJson(stageData);       
        File.WriteAllText(path + "/" + filename, data);//제이슨을 적어두는 것
       
        //제이슨으로 저장?
    }

    public void JsonLoad()//로드 실험
    {
        string data= File.ReadAllText(path+ "/" + filename);//해당 경로에 적어둔 제이슨을 모두 불러오기
        stageData= JsonUtility.FromJson<SaveStageData>(data);
        //제이슨으로 로드?
        StageManager.Instance.stageindex = stageData.stageIndex;
        StageManager.Instance.coin = stageData.coin;
        StageManager.Instance.clearStage = stageData.clearStage;
        StageManager.Instance.star = stageData.star;
    }
}
