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
    private Dictionary<int, List<StageValue>> stageDct=new();
    //private List<Maps> maps=Maps.MapsList;
    public void Initialize()
    {
        //UnityGoogleSheet.Load<Maps>();
        UnityGoogleSheet.Load<Stage1>();
        UnityGoogleSheet.Load<Stage2>();
        UnityGoogleSheet.Load<Stage3>();        
        LoadStage();   
    }
    public void LoadStage()
    {
        StageValue stage;
        List<StageValue> stage1 = new List<StageValue>();        
        foreach (var item in Stage1.Stage1List)
        {
            stage = new StageValue(item.Row, item.Column, item.Tile);
            stage1.Add(stage);           
        }
        stageDct.Add(1, stage1);        
        List<StageValue> stage2 = new List<StageValue>();
        foreach (var item in Stage2.Stage2List)
        {
            stage = new StageValue(item.Row, item.Column, item.Tile);
            stage2.Add(stage);
        }
        stageDct.Add(2, stage2);
        List<StageValue> stage3 = new List<StageValue>();
        foreach (var item in Stage3.Stage3List)
        {
            stage = new StageValue(item.Row, item.Column, item.Tile);
            stage3.Add(stage);
        }
        stageDct.Add(3, stage3);
    }
    public List<StageValue> GetStageList(int StageIndex)
    {
        return stageDct[StageIndex];
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
