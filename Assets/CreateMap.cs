using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateMap : MonoBehaviour
{    
    void Start()
    {
        JsonDataManager.Instance.IndexLoad();
        MapManager.Instance.MakeStage(StageManager.Instance.stageindex);
        //���� ������ ���
        //�������� Ŭ���� ���
        //�������� �� ���
    }
}
