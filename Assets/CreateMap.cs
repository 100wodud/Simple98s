using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateMap : MonoBehaviour
{    
    void Start()
    {
        Debug.Log(StageSelecter.selectStageIndex);
        //JsonDataManager.Instance.IndexLoad();
        MapManager.Instance.MakeStage(StageSelecter.selectStageIndex);
        //���� ������ ���
        //�������� Ŭ���� ���
        //�������� �� ���
    }
}
