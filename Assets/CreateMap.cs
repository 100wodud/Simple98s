using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{    
    void Awake()
    {
        MapManager.Instance.MakeStage(StageManager.Instance.stageindex);
    }
}
