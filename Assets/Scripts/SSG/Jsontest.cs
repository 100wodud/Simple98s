using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.데이터(코드 = 클래스)를 만들어야함. => 저장할 데이터 생성
//2.그 데이터를 json으로 변환.(택배상자로 포장)
//==============================================
//1.json(택배)-> 조립도->클래스(포장)

class Data
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill;
    //기타 등등
}
[Serializable]
public class Jsontest:MonoBehaviour
{
    Data player = new Data()
    {nickname="오늘코딩",level=50,coin=200,skill=false };

    private void Start()
    {
        //22. json으로 변환
        string jsonData=JsonUtility.ToJson(player);

        Debug.Log($"{jsonData}");

       Data Player2= JsonUtility.FromJson<Data>(jsonData);

        Debug.Log(Player2.nickname);
        Debug.Log(Player2.level);
        Debug.Log(Player2.coin);
        Debug.Log(Player2.skill);
    }
}
