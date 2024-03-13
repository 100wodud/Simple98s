using DefaultTable;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    //맵을 생성하는 기능을 담당하는 매니저
    //데이터 매니저에 데이터를 저장시켜주기
    //
    List<Map> map = new List<Map>();
    //Dictionary<int,Stage1> stage1= new Dictionary<int,Stage1>();
    public List<Stage1> stage1 = new List<Stage1>();
    List<Stage2> stage2= new List<Stage2>();

    void TestStart()
    {
        foreach (var manager in map)
        {
            Debug.Log("맵 아이디" + manager.mapId);            
        }
        //foreach(var stage in stage1)
        //{
        //    Debug.Log($"스테이지1 아이디 :{stage.Key}좌표 x:{stage.Value.x}y:{stage.Value.y}");
        //}
    }
    private void Awake()
    {
        UnityGoogleSheet.LoadAllData();
        map = Map.MapList;
        stage1 = Stage1.Stage1List;
    }
    private void Start()
    {
        
        //stage1 = Stage1.Stage1Map;
       

        TestStart();
    }

}
