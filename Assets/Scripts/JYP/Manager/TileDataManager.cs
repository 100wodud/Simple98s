using Simple98;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDataManager : Singleton<TileDataManager>
{
    const string path = "Prefabs/";

    //타일 생성(인덱스값,x,y축 필요)
    public void InstantiateTile(int index, int x, int y)
    {
        Instantiate(Resources.Load($"{path + DataManager.Instance.tiles[index].Type + "/" + DataManager.Instance.tiles[index].localeID}"), new Vector3(x, -y, 0), Quaternion.identity);
    }

    //타입 별 타일 나누기(type 입력 / 출력 list)
    public List<Tiles> FindTypeTiles(string type)
    {
        List<Tiles> typeTiles = new List<Tiles>();
        foreach(var item in DataManager.Instance.tiles)
        {
            if(type == item.Type)
            {
                typeTiles.Add(item);
            }
        }
        return typeTiles;
    }
}
