using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    //모든 데이터 매니저의 데이터를 가지고 있는 매니저
    //데이터는 데이터 매니저를 통해서 불러오기
    //Sheet에 있는 Data 저장
    //맵 데이터매니저, 타일 데이터 매니저
    //맵,
    //싱글톤 투입
    //맵 데이터매니저
    public MapDataManager Map;
    public List<Tiles> tiles = new List<Tiles>();
    public List<Maps> maps = new List<Maps>();

    
    public void Initialize()//초기화
    {

        //Map = 
    }
    //void Awake()
    //{

    //    //구글 시트 맵 불러오기
    //    UnityGoogleSheet.LoadAllData();//각각 매니저에서 로드

    //    if (instance != null) //이미 존재하면
    //    {
    //        Destroy(gameObject); //두개 이상이니 삭제
    //        return;
    //    }
    //    instance = this; //자신을 인스턴스로
    //    DontDestroyOnLoad(gameObject); //씬 이동해도 사라지지않게
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
