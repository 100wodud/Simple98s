using Simple98;
using System;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
     
    
    //���� �����ϴ� ����� ����ϴ� �Ŵ���
    //������ �Ŵ����� �����͸� ��������ֱ�

    
    private void Start()
    {
        //MakeStage("Stage1");      1.�������� ���̵� ���� ���� ,2.�������� ����� ���ؼ� ���������� ���� �����͸� ����
        //                          3.�����Ϳ��� �ش� ���̵� ���� ������ ������ ���̺��� ������ ��
        //                          4.������ �����͸� �������� ���� Ÿ�Ͼ��̵�� ������ ���̵� ������Ʈ�� �ҷ���
        //                          5.�� �����ͷ� �������� ���� �����ͷ� ��ǥ���� ����
        MakeStage(3);
    }
    
    public void MakeStage(int mapStage)
    {
        foreach (var item in DataManager.Instance.MapData.GetStageList(mapStage))
        {
            InstantiateTile(item.tile, item.x, item.y);
        }
    }

    private void InstantiateTile(int index, int x, int y)
    {
        const string path = "Prefabs/";
        Tiles tile = DataManager.Instance.TileData.GetTile(index);
        Instantiate(Resources.Load($"{path + tile.Type + "/" + tile.localeID}"), new Vector3(x, -y, 0), Quaternion.identity);
    }
}
