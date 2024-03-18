using GoogleSheet;
using Simple98;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UGS;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEditor.Progress;

public class MapDatas
{
    
    private Dictionary<int, List<StageData>> stageDct=new();
    private Dictionary<int, Maps> maps= new();
    public void Initialize()
    {
        UnityGoogleSheet.Load<Maps>();
        UnityGoogleSheet.Load<Stage1>();
        UnityGoogleSheet.Load<Stage2>();
        UnityGoogleSheet.Load<Stage3>();        
        LoadStage();              
    }

    public void LoadStage()
    {
        StageData stage;

        maps = Maps.MapsMap;
        List<StageData> stage1 = new List<StageData>();        
        foreach (var item in Stage1.Stage1List)
        {
            stage = new StageData(item.Row, item.Column, item.Tile);
            stage1.Add(stage);           
        }
        stageDct.Add(maps[1].index, stage1);        
        List<StageData> stage2 = new List<StageData>();
        foreach (var item in Stage2.Stage2List)
        {
            stage = new StageData(item.Row, item.Column, item.Tile);
            stage2.Add(stage);
        }
        stageDct.Add(maps[2].index, stage2);
        List<StageData> stage3 = new List<StageData>();
        foreach (var item in Stage3.Stage3List)
        {
            stage = new StageData(item.Row, item.Column, item.Tile);
            stage3.Add(stage);
        }
        stageDct.Add(maps[3].index, stage3);
    }
    public List<StageData> GetStageList(int StageIndex)
    {
        return stageDct[StageIndex];
    }

    public Maps GetStageData(int StageIndex)
    {
        return maps[StageIndex];
    }

    //private void SetStage<T>(int stageId,List<T> stageList)
    //{
    //    List<Stages> stage = new List<Stages>();
    //    Stages stageValue;
    //    int row;
    //    int column;
    //    int tile;
    //    foreach(var item in stageList)
    //    {
    //        stage1 = new Stages(item.Row, item.Column, item.Tile);
    //        stage.Add(stage1);
    //    }
    //    stages.Add(stageId, stage);
    //}




}
