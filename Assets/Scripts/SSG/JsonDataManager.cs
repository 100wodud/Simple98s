using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDataManager:Singleton<JsonDataManager>
{
    //SaveStageData stageData;
    //string path;

    //string filename = "save";
    //void Awake()
    //{
    //    path = Application.persistentDataPath;
    //}
    //public void IndexSave(int stageIndex)//���� ����
    //{
        
    //    stageData = new SaveStageData(stageIndex);
    //    string data = JsonUtility.ToJson(stageData);       
    //    File.WriteAllText(path + "/" + filename, data);//���̽��� ����δ� ��
       
    //    //���̽����� ����?
    //}

    //public void IndexLoad()//�ε� ����
    //{
    //    string data= File.ReadAllText(path+ "/" + filename);//�ش� ��ο� ����� ���̽��� ��� �ҷ�����
    //    stageData= JsonUtility.FromJson<SaveStageData>(data);
    //    //���̽����� �ε�?
    //    StageIndex.stageindex = stageData.stageIndex;
    //}
}
