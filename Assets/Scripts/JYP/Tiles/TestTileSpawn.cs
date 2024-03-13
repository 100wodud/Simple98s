using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;
using static UnityEditor.Progress;

public class TestTileSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityGoogleSheet.LoadAllData();
        tiles = Simple98.Tiles.TilesList;
        /*
        foreach (var data in Simple98.Tiles.TilesList)
        {
            newObject(data.localeID);

        }
        // 구글 시트 맵 데이터 둘러보기
        foreach (var data in Simple98.Maps.MapsList)
        {
            newObject(data.);

        }
        */
        DataManager.Instance.Initialize();

        const string path = "Prefabs/";

        foreach (var item in DataManager.instance.stage1)
        {
            Instantiate(Resources.Load($"{path + DataManager.instance.tiles[item.Tile].Type + "/" + DataManager.instance.tiles[item.Tile].localeID}"), new Vector3(item.Row, -item.Column, 0), Quaternion.identity);
        }

    }
}
