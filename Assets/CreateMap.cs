using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateMap : MonoBehaviour
{    
    void Start()
    {
        JsonDataManager.Instance.JsonLoad();
        MapManager.Instance.MakeStage(StageManager.Instance.stageindex);
        //���� ������ ���
        //�������� Ŭ���� ���
        //�������� �� ���
    }
}
