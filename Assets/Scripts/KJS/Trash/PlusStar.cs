using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusStar : MonoBehaviour
{

    private StageSelectionUI stageSelectionUI;

    private StageStarData stage1StarData; // 스테이지 1의 별 정보를 저장할 변수

    private int stageLevel = 0;

    private void Start()
    {
        stage1StarData = StarManager.Instance.stageStarDataArray[stageLevel]; // 스테이지 1의 별 정보 가져오기
        stageSelectionUI = GetComponent<StageSelectionUI>();
    }

    public void setZeroStar()
    {
        StarManager.Instance.SetStarsForStage(stageLevel, 0);
        stageSelectionUI.UpdateStar(stageLevel);
    }

    public void setOneStar()
    {
        StarManager.Instance.SetStarsForStage(stageLevel, 1);
        stageSelectionUI.UpdateStar(stageLevel);
    }
    public void setTwoStar()
    {
        StarManager.Instance.SetStarsForStage(stageLevel, 2);
        stageSelectionUI.UpdateStar(stageLevel);
    }
    public void setThreeStar()
    {
        StarManager.Instance.SetStarsForStage(stageLevel, 3);
        stageSelectionUI.UpdateStar(stageLevel);
    }
    public void AddStar()
    {
        stage1StarData.starsEarned++;
        Debug.Log("+1");
        StarManager.Instance.SetStarsForStage(0, stage1StarData.starsEarned);
        stageSelectionUI.UpdateStar(stageLevel);
    }

    public void MinuStar()
    {
        stage1StarData.starsEarned--;
        Debug.Log("-1");
        StarManager.Instance.SetStarsForStage(0, stage1StarData.starsEarned);
        stageSelectionUI.UpdateStar(stageLevel);
    }

    
}


