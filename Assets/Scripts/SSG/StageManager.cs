using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{    
    //스테이지 매니저가 하는일:
    //스테이지 번호를 받아 게임매니저에서 적용시키기
    //스테이지에서 무슨일이 일어나야 될까
    //스테이지 맵을 생성하는 일?
    public int stageindex;
    public int coin = 10;
    public bool clearStage = true;
    public int star = 2;
}
