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
    [SerializeField] private GameObject floor;//��������    
    //������ ������Ʈ�� ����, �Ŀ��� ������ �����͸� �޾� �����ϵ��� ����
    private int[,] map = new int[,]
        {
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0}
        };
    //����
    //����
    //void MapData()
    //{
    //    var Map = new List<int[]>()
    //    {
    //        {0,0,0,0, }
    //    };       

    //}
    //void SpawnMap()//�ʸŴ������� ����϶�� ��
    //{
    //    foreach(var map in MapManager.Instance.)
    //    {
    //        if(map.itemIndex==0)
    //        {
    //            Instantiate(floor);
    //            floor.transform.position = new Vector3(map.x, map.y);
    //            Debug.Log($"�����ߴ� x:{map.x}y:{map.y}");
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
    //            //���� �����ͷ�  �� ����
    //            //if (map[startpos - j, i] == 0)
    //            //{
    //                //������Ʈ �����͸� ��� �޾Ƽ� ���� ������ų��>
                    
    //                vector = new Vector3(i, j);
    //                Instantiate(floor);//������Ʈ�����͸� �޾Ƽ� ������Ű�� �ϱ�
    //                floor.transform.position = vector;
    //                //Debug.Log($"{floor.transform.position}");
    //            //}
                
    //        }          
    //    }
    //}    
}
