using System;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private GameObject Tile;
    [SerializeField] private string mapId;
    
    //���� �����ϴ� ����� ����ϴ� �Ŵ���
    //������ �Ŵ����� �����͸� ��������ֱ�

    
    private void Start()
    {
        //MakeStage("Stage1");      1.�������� ���̵� ���� ���� ,2.�������� ����� ���ؼ� ���������� ���� �����͸� ����
        //                          3.�����Ϳ��� �ش� ���̵� ���� ������ ������ ���̺��� ������ ��
        //                          4.������ �����͸� �������� ���� Ÿ�Ͼ��̵�� ������ ���̵� ������Ʈ�� �ҷ���
        //                          5.�� �����ͷ� �������� ���� �����ͷ� ��ǥ���� ����
        
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
