using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;

public class DataManager : Singleton<DataManager>
{
    public TileDatas TileData = new();
    public MapDatas MapData = new();
    public CustomMapDatas CustomMapData = new();
    //제이슨 데이터

    public void Initialize()
    {
        TileData.Initialize();
        MapData.Initialize();
        CustomMapData.Initialize();
    }           
}
