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

        int row = DataManager.instance.maps[1].Row;
        int column = DataManager.instance.maps[1].Column;
        int[,] array = new int[row, column];
        int row1 = 0;
        int column1 = 0;
        int i = 0;
        foreach (int item in DataManager.instance.maps[1].Map)
        {
            row1 = i % row;
            column1 = i / column;
            array[column1, row1] = item;
            Debug.Log(item);
            i++;
        }

        float x = 0;
        float y = 0;
        const string path = "Prefabs/Tiles/";

        for (int k = 0;  k < row; k++)
        {
            x = 0;
            for(int l = 0; l < column; l++)
            {
                Instantiate(Resources.Load($"{path + DataManager.instance.tiles[array[k, l]].localeID}"), new Vector3(x, y, 0), Quaternion.identity);
                x += 1;
            }
            y -= 1;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
