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
    public void JsonSave(int stageIndex,int star,int coin,bool stageClear)//���� ����
    {
        
        stageData = new SaveStageData(stageIndex ,star, coin, stageClear);
        string data = JsonUtility.ToJson(stageData);       
        File.WriteAllText(path + "/" + filename, data);//���̽��� ����δ� ��
       
        //���̽����� ����?
    }

    public void JsonLoad()//�ε� ����
    {
        string data= File.ReadAllText(path+ "/" + filename);//�ش� ��ο� ����� ���̽��� ��� �ҷ�����
        stageData= JsonUtility.FromJson<SaveStageData>(data);
        //���̽����� �ε�?
        StageManager.Instance.stageindex = stageData.stageIndex;
        StageManager.Instance.coin = stageData.coin;
        StageManager.Instance.clearStage = stageData.clearStage;
        StageManager.Instance.star = stageData.star;
    }
}
