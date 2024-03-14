using Simple98;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UGS;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TestTileSpawn : MonoBehaviour
{
    public List<Stage1> stage1 = new List<Stage1>();
    // Start is called before the first frame update
    void Awake()
    { 
        UnityGoogleSheet.Load<Stage1>();
        UnityGoogleSheet.Load<Stage2>();
        UnityGoogleSheet.Load<Stage3>();
    }
    void Start()
    {
        DataManager.Instance.Initialize();

        foreach (var item in GetClassList(3))
        {
            InstantiateTile(item.tile, item.x, item.y);
        }
    }
    public List<MapStage> GetClassList(int choice)
    {
        List<MapStage> test = new List<MapStage>();
        MapStage a;
        switch (choice)
        {
            case 1:
                foreach(var item in Stage1.Stage1List)
                {
                    a = new MapStage(item.Row, item.Column, item.Tile);
                    test.Add(a);
                }
                return test;
            case 2:
                foreach (var item in Stage2.Stage2List)
                {
                    a = new MapStage(item.Row, item.Column, item.Tile);
                    test.Add(a);
                }
                return test;
            case 3:
                foreach (var item in Stage3.Stage3List)
                {
                    a = new MapStage(item.Row, item.Column, item.Tile);
                    test.Add(a);
                }
                return test;
            // case 4, 5에 대해서도 같은 방식으로 처리합니다.
            default:
                Console.WriteLine("Invalid choice");
                return null;
        }
    } 

    public void InstantiateTile(int index, int x, int y)
    {
        const string path = "Prefabs/";
        Tiles tile = DataManager.Instance.tileDataManager.GetTile(index);
        Instantiate(Resources.Load($"{path + tile.Type + "/" + tile.localeID}"), new Vector3(x, -y, 0), Quaternion.identity);
    }
}
