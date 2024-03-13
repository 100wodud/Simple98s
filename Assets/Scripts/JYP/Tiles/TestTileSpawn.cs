using Simple98;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEngine;

public class TestTileSpawn : MonoBehaviour
{
    public List<Stage1> stage1 = new List<Stage1>();
    // Start is called before the first frame update
    void Awake()
    { 
        UnityGoogleSheet.Load<Stage1>();
        stage1 = Stage1.Stage1List;
    }
    void Start()
    {
        DataManager.Instance.Initialize();

        foreach (var item in stage1)
        {
            TileDataManager.Instance.InstantiateTile(item.Tile, item.Row, item.Column);
        }
    }
}
