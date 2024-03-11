using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //Sheet�� �ִ� Data ����
    public List<Tiles> tiles = new List<Tiles>();
    public List<Maps> maps = new List<Maps>();

    public static DataManager instance;
    void Awake()
    {
        //���� ��Ʈ �� �ҷ�����
        UnityGoogleSheet.LoadAllData();

        if (instance != null) //�̹� �����ϸ�
        {
            Destroy(gameObject); //�ΰ� �̻��̴� ����
            return;
        }
        instance = this; //�ڽ��� �ν��Ͻ���
        DontDestroyOnLoad(gameObject); //�� �̵��ص� ��������ʰ�
    }

    //public Data data = new Data();

    // Start is called before the first frame update
    void Start()
    {
        tiles = Simple98.Tiles.TilesList;
        maps = Simple98.Maps.MapsList;
        
    }
}
