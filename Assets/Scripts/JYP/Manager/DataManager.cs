using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;

public class DataManager : Singleton<DataManager>
{
    public TileDatas tileDataManager = new();
    public MapDatas MapData = new ();
    
    public void Initialize()
    {
        tileDataManager.Initialize();
        MapData.Initialize();
    }           
}
