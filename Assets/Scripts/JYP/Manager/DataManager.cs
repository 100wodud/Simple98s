using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    //��� ������ �Ŵ����� �����͸� ������ �ִ� �Ŵ���
    //�����ʹ� ������ �Ŵ����� ���ؼ� �ҷ�����
    //Sheet�� �ִ� Data ����
    //�� �����͸Ŵ���, Ÿ�� ������ �Ŵ���
    //��,
    //�̱��� ����
    //�� �����͸Ŵ���
    
    public List<Tiles> tiles = new List<Tiles>();
    public Dictionary<int, Maps> Map = new Dictionary<int, Maps>();
    public void Initialize()//�ʱ�ȭ
    {
        UnityGoogleSheet.Load<Maps>();
        UnityGoogleSheet.Load<Tiles>();
        Map = Maps.MapsMap;
        tiles = Tiles.TilesList;
    }   
}
