using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //Sheet에 있는 Data 저장
    public List<Tiles> tiles = new List<Tiles>();
    public List<Maps> maps = new List<Maps>();

    public static DataManager instance;
    void Awake()
    {
        //구글 시트 맵 불러오기
        UnityGoogleSheet.LoadAllData();

        if (instance != null) //이미 존재하면
        {
            Destroy(gameObject); //두개 이상이니 삭제
            return;
        }
        instance = this; //자신을 인스턴스로
        DontDestroyOnLoad(gameObject); //씬 이동해도 사라지지않게
    }

    //public Data data = new Data();

    // Start is called before the first frame update
    void Start()
    {
        tiles = Simple98.Tiles.TilesList;
        maps = Simple98.Maps.MapsList;
        
    }
}
