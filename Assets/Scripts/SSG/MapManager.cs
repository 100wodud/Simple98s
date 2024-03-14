using System;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private GameObject Tile;
    [SerializeField] private string mapId;
    
    //맵을 생성하는 기능을 담당하는 매니저
    //데이터 매니저에 데이터를 저장시켜주기

    
    private void Start()
    {
        //MakeStage("Stage1");      1.스테이지 아이디 값을 받음 ,2.스테이지 만들기 위해서 스테이지에 대한 데이터를 받음
        //                          3.데이터에서 해당 아이디 값과 동일한 데이터 테이블을 가지고 옴
        //                          4.가져온 데이터를 바탕으로 맵의 타일아이디와 동일한 아이디에 오브젝트를 불러옴
        //                          5.그 데이터로 생성한후 받은 데이터로 좌표값을 맞춤
        
    }
    
    public void MakeStage(string mapId)
    {
        foreach(var map in DataManager.Instance.MapData.stage1)
        {
            Instantiate(Tile);
            Tile.transform.position = new Vector3(map.Value.Row, map.Value.Column);
        }
    }
}
