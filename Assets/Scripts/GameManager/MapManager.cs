using Simple98;
using System;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public int maxX = -33;
    //���� �����ϴ� ����� ����ϴ� �Ŵ���
    //������ �Ŵ����� �����͸� ��������ֱ�

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneLoader.Instance.GotoStageScene();
        }
    }
    public void MakeStage(int mapStage)
    {
        GameObject Map = new GameObject("Map");
        //�÷��̾� ���� �Լ�
        //�θ������Ʈ��
        const string path = "Prefabs/Player/Player";
        foreach (var item in DataManager.Instance.MapData.GetStageList(mapStage))
        {
            if(maxX < item.x)
            {
                maxX = item.x;
            }
            InstantiateTile(item.tile, item.x, item.y, Map);
        }
        Vector3 playerPos = DataManager.Instance.MapData.GetStageData(mapStage).PlayerPos;
        Instantiate(Resources.Load(path), playerPos, Quaternion.identity);
    }

    private void InstantiateTile(int index, int x, int y, GameObject ParentMap)
    {
        //�θ������Ʈ�� ���α�
        const string path = "Prefabs/";       
        Tiles tile = DataManager.Instance.TileData.GetTile(index);
        Instantiate(Resources.Load($"{path + tile.Type + "/" + tile.localeID}"), new Vector3(x, y, 0), Quaternion.identity,ParentMap.transform);
    }
}