using GoogleSheet;
using Simple98;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UGS;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MapDatas//MapDatas
{
    //여기서 데이터를 할당을 안시키고도 그 데이터 값을 사용할 수 있는 방법이 뭐가 있을까
    //바로 그 
    //스테이지 데이터? 상속
    private Dictionary<int, Stages> stage = new Dictionary<int, Stages>();
    public Dictionary<int, Stage1> stage1;
    public Dictionary<int, Stage2> stage2;
    public void Initialize()
    {   
        UnityGoogleSheet.Load<Stage1>();
        UnityGoogleSheet.Load<Stage2>();
        stage1 = Stage1.Stage1Map;
        stage2 = Stage2.Stage2Map;
        //값하고 벨류가 모두 들어간 딕셔너리를 그냥 저장했기 때문 하지만 이젠 열거 값을 입력 받으면 그열거에 맞는 맵 아이디와 리스트 테이블을 가지고 와라?
        //사실 그 벨류에 맞는 테이블값만 가지고 오게
        
        //for (int i = 0; i < Maps.MapsList.Count; i++)
        //{
        //    switch(Maps.MapsList[i].MapName)
        //    {
        //        case "Stage1":
        //            stage.Add(Maps.MapsList[i].index,(List<ITable>)Stage1.Stage1List);
        //            break;
        //        case "Stage2":
        //            break;
        //    }
        //}
        //맵에 스테이지 아이디
    }
    //public List<T> GetMapData<T>()//아이디값을 받아오고 리스트 값을 가져가기
    //{        
    //    switch(T)
    //    {
    //        case "Stage1":
    //            return Stage1.Stage1List.Cast<ITable>().ToList();
    //        default:
    //            break;                
    //    }
    //    return null;
        
    //}
    //Stage1.Stage1List.Cast<ITable>().ToList();

    //public Dictionary<int,Stages> GetMapType()
    //{
    //}

    //public List<Stage1> GetStage(string type)
    //{

    //}
    //원하는 스테이지 데이터를 로드하기
    //public Dictionary<int, Stage1> FindTypeStage(string type)//스테이지 생성하기전 생성 할당
    //{
    //    Dictionary<int, ITable> typeStages = new Dictionary<int, ITable>();
    //    switch (type)
    //    {
    //        case "Stage1":
    //            typeStages.Add(Stage1.Stage1Map.Keys, Stage1.Stage1Map[1].index);

    //            break;
    //        case ""
    //    }


    //}


}
