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
    
    public List<Tiles> tiles = new List<Tiles>();
    public Dictionary<int, Maps> Map = new Dictionary<int, Maps>();
    public void Initialize()//초기화
    {
        UnityGoogleSheet.Load<Maps>();
        UnityGoogleSheet.Load<Tiles>();
        Map = Maps.MapsMap;
        tiles = Tiles.TilesList;
    }   
}
