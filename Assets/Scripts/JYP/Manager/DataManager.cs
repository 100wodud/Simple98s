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
    public MapDataManager Map;
    public List<Tiles> tiles = new List<Tiles>();
    public List<Maps> maps = new List<Maps>();

    
    public void Initialize()//�ʱ�ȭ
    {

        //Map = 
    }
    //void Awake()
    //{

    //    //���� ��Ʈ �� �ҷ�����
    //    UnityGoogleSheet.LoadAllData();//���� �Ŵ������� �ε�

    //    if (instance != null) //�̹� �����ϸ�
    //    {
    //        Destroy(gameObject); //�ΰ� �̻��̴� ����
    //        return;
    //    }
    //    instance = this; //�ڽ��� �ν��Ͻ���
    //    DontDestroyOnLoad(gameObject); //�� �̵��ص� ��������ʰ�
    //    Map=
    //}

    //public Data data = new Data();

    // Start is called before the first frame update
    //void Start()
    //{
    //    tiles = Simple98.Tiles.TilesList;
    //    maps = Simple98.Maps.MapsList;

    //}
}
