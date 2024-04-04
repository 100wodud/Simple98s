
using Simple98;
using System.Collections.Generic;
using UGS;

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
        UnityGoogleSheet.Load<Stage4>();
        UnityGoogleSheet.Load<Stage5>();
        UnityGoogleSheet.Load<Stage6>();
        UnityGoogleSheet.Load<Stage7>();
        LoadStage();              
    }

    private void LoadStage()
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
        List<StageData> stage4 = new List<StageData>();
        foreach (var item in Stage4.Stage4List)
        {
            stage = new StageData(item.Row, item.Column, item.Tile);
            stage4.Add(stage);
        }
        stageDct.Add(maps[4].index, stage4);
        List<StageData> stage5 = new List<StageData>();
        foreach (var item in Stage5.Stage5List)
        {
            stage = new StageData(item.Row, item.Column, item.Tile);
            stage5.Add(stage);
        }
        stageDct.Add(maps[5].index, stage5);
        List<StageData> stage6 = new List<StageData>();
        foreach (var item in Stage6.Stage6List)
        {
            stage = new StageData(item.Row, item.Column, item.Tile);
            stage6.Add(stage);
        }
        stageDct.Add(maps[6].index, stage6);
        List<StageData> stage7 = new List<StageData>();
        foreach (var item in Stage7.Stage7List)
        {
            stage = new StageData(item.Row, item.Column, item.Tile);
            stage7.Add(stage);
        }
        stageDct.Add(maps[7].index, stage7);
    }
    public List<StageData> GetStageList(int StageIndex)//저장된 데이터를 얻을 수 있는시스템
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
