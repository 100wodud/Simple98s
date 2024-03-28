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
        //코인 데이터 사용
        //스테이지 클리어 사용
        //스테이지 별 사용
    }
}
