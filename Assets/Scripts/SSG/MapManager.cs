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
        
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneController.Instance.LoadScene("StageScene");
        }
    }
    public void MakeStage(int mapStage)
    {
        GameObject Map = new GameObject("Map");
        //플레이어 생성 함수
        //부모오브젝트맵
        const string path = "Prefabs/Player/Player";
        foreach (var item in DataManager.Instance.MapData.GetStageList(mapStage))
        {
            InstantiateTile(item.tile, item.x, item.y, Map);
        }
        Vector3 playerPos = DataManager.Instance.MapData.GetStageData(mapStage).PlayerPos;
        Instantiate(Resources.Load(path), playerPos, Quaternion.identity);
    }

    private void InstantiateTile(int index, int x, int y, GameObject ParentMap)
    {
        //부모오브젝트로 감싸기
        const string path = "Prefabs/";       
        Tiles tile = DataManager.Instance.TileData.GetTile(index);
        Instantiate(Resources.Load($"{path + tile.Type + "/" + tile.localeID}"), new Vector3(x, -y, 0), Quaternion.identity,ParentMap.transform);
    }
}
