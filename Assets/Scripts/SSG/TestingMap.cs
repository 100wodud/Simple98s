using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UGS;
using UnityEditor;
using UnityEngine;
public enum TileType
{
    Floor,
    Wall,
    enemy,
}
public class TestingMap : Singleton<TestingMap>
{
    [SerializeField] private GameObject floor;//지역변수    
    //지금은 오브젝트로 생성, 후에는 프리팹 데이터를 받아 생성하도록 구현
    private int[,] map = new int[,]
        {
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0}
        };
    //가로
    //세로
    //void MapData()
    //{
    //    var Map = new List<int[]>()
    //    {
    //        {0,0,0,0, }
    //    };       

    //}
    //void SpawnMap()//맵매니저에서 사용하라는 듯
    //{
    //    foreach(var map in MapManager.Instance.)
    //    {
    //        if(map.itemIndex==0)
    //        {
    //            Instantiate(floor);
    //            floor.transform.position = new Vector3(map.x, map.y);
    //            Debug.Log($"생성했다 x:{map.x}y:{map.y}");
    //        }
    //    }
    //}  
    private void Awake()
    {
        
        DataManager.Instance.Initialize();
    }
 
    //private void StartMap()
    //{        
    //    Vector3 vector;
    //    int ypos = map.GetLength(1);
    //    int xpos = map.GetLength(0) ;
    //    int startpos = xpos - 1;
    //    for(int i= 0;i< ypos; i++)//y
    //    {            
    //        for (int j=0;j< xpos; j++)//xypos
    //        {
    //            //생성 데이터로  맵 관리
    //            //if (map[startpos - j, i] == 0)
    //            //{
    //                //오브젝트 데이터를 어떻게 받아서 맵을 생성시킬까>
                    
    //                vector = new Vector3(i, j);
    //                Instantiate(floor);//오브젝트데이터를 받아서 생성시키게 하기
    //                floor.transform.position = vector;
    //                //Debug.Log($"{floor.transform.position}");
    //            //}
                
    //        }          
    //    }
    //}    
}
