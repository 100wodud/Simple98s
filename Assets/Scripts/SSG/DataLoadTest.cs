using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class DataLoadTest : MonoBehaviour
{
    int[,] map;
    private void Awake()
    {
        UnityGoogleSheet.LoadAllData();
    }
    private void Start()
    {
        foreach(var value in DefaultTable.Map.MapList)
        {                               
            Debug.Log(value.x+","+value.y);         
            
        }
        var dataFromMap = DefaultTable.Map.MapMap[0];
        Debug.Log("dataFromMap : "+dataFromMap.index + dataFromMap.x+ ", " + dataFromMap.y);
    }
}
