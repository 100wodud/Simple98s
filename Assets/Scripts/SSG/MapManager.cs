using Simple98;
using System;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{             
    //맵을 생성하는 기능을 담당하는 매니저
    //데이터 매니저에 데이터를 저장시켜주기
    
    private void Start()
    {
        //;      1.스테이지 아이디 값을 받음 ,2.스테이지 만들기 위해서 스테이지에 대한 데이터를 받음
        //                          3.데이터에서 해당 아이디 값과 동일한 데이터 테이블을 가지고 옴
        //                          4.가져온 데이터를 바탕으로 맵의 타일아이디와 동일한 아이디에 오브젝트를 불러옴
        //                          5.그 데이터로 생성한후 받은 데이터로 좌표값을 맞춤        
    }
    
    public void MakeStage(int mapStage)
    {
        //플레이어 생성 함수
        //부모오브젝트맵
        foreach (var item in DataManager.Instance.MapData.GetStageList(mapStage))
        {
            InstantiateTile(item.tile, item.x, item.y);
        }
        Vector3 playerPos = DataManager.Instance.MapData.GetStageData(mapStage).PlayerPos;
        Instantiate(Resources.Load("Prefabs/Player/Player"), playerPos, Quaternion.identity);
    }

    private void InstantiateTile(int index, int x, int y)
    {
        //부모오브젝트로 감싸기
        const string path = "Prefabs/";       
        Tiles tile = DataManager.Instance.TileData.GetTile(index);
        Instantiate(Resources.Load($"{path + tile.Type + "/" + tile.localeID}"), new Vector3(x, -y, 0), Quaternion.identity);
    }
}
