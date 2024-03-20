using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.������(�ڵ� = Ŭ����)�� ��������. => ������ ������ ����
//2.�� �����͸� json���� ��ȯ.(�ù���ڷ� ����)
//==============================================
//1.json(�ù�)-> ������->Ŭ����(����)

class Data
{
    public string nickname;
    public int level;
    public int coin;
    public bool skill;
    //��Ÿ ���
}
[Serializable]
public class Jsontest:MonoBehaviour
{
    Data player = new Data()
    {nickname="�����ڵ�",level=50,coin=200,skill=false };

    private void Start()
    {
        //22. json���� ��ȯ
        string jsonData=JsonUtility.ToJson(player);

        Debug.Log($"{jsonData}");

       Data Player2= JsonUtility.FromJson<Data>(jsonData);

        Debug.Log(Player2.nickname);
        Debug.Log(Player2.level);
        Debug.Log(Player2.coin);
        Debug.Log(Player2.skill);
    }
}
