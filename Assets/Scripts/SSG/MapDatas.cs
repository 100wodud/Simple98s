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
    //���⼭ �����͸� �Ҵ��� �Ƚ�Ű�� �� ������ ���� ����� �� �ִ� ����� ���� ������
    //�ٷ� �� 
    //�������� ������? ���
    
    public void Initialize()
    {
        UnityGoogleSheet.Load<Stage1>();
        UnityGoogleSheet.Load<Stage2>();
        UnityGoogleSheet.Load<Stage3>();
    }
    public List<MapStage> GetStageList(int choice)
    {
        List<MapStage> test = new List<MapStage>();
        MapStage a;
        switch (choice)
        {
            case 1:
                foreach (var item in Stage1.Stage1List)
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
            // case 4, 5�� ���ؼ��� ���� ������� ó���մϴ�.
            default:
                Console.WriteLine("Invalid choice");
                return null;
        }
    }


}
