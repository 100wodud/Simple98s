using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStageData 
{
    //�÷��̾� �� ����
    //���� ���� 
    //�������� Ŭ���� ����
    public int stageIndex;
    public int star;
    public int coin;
    public bool clearStage;

    public SaveStageData(int stageIndex,int star, int coin, bool clearStage)
    {
        this.stageIndex = stageIndex;
        this.star = star;
        this.coin = coin;
        this.clearStage = clearStage;
    }   
}
