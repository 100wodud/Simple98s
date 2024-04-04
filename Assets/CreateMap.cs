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
        //코인 데이터 사용
        //스테이지 클리어 사용
        //스테이지 별 사용
    }
}
