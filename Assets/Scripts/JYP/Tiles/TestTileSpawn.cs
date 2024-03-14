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
    void Start()
    {
        //타일 사용
        DataManager.Instance.Initialize();
        MapManager.Instance.MakeStage(3);
    }
}
