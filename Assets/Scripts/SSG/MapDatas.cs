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
    private Dictionary<int, Stages> stage = new Dictionary<int, Stages>();
    public Dictionary<int, Stage1> stage1;
    public Dictionary<int, Stage2> stage2;
    public void Initialize()
    {   
        UnityGoogleSheet.Load<Stage1>();
        UnityGoogleSheet.Load<Stage2>();
        stage1 = Stage1.Stage1Map;
        stage2 = Stage2.Stage2Map;
        //���ϰ� ������ ��� �� ��ųʸ��� �׳� �����߱� ���� ������ ���� ���� ���� �Է� ������ �׿��ſ� �´� �� ���̵�� ����Ʈ ���̺��� ������ �Ͷ�?
        //��� �� ������ �´� ���̺��� ������ ����
        
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
        //�ʿ� �������� ���̵�
    }
    //public List<T> GetMapData<T>()//���̵��� �޾ƿ��� ����Ʈ ���� ��������
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
    //���ϴ� �������� �����͸� �ε��ϱ�
    //public Dictionary<int, Stage1> FindTypeStage(string type)//�������� �����ϱ��� ���� �Ҵ�
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
