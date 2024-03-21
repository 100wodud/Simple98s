using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStageData 
{
    //플레이어 별 개수
    //코인 개수 
    //스테이지 클리어 정보
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
