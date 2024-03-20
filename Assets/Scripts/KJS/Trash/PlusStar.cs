using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusStar : MonoBehaviour
{

    private Popup_StageSelect popup_StageSelect;

    private StageStarData stageStarData; // �������� �� ������ ������ ����

    private int _stageLevel = 0;

    private void Start()
    {
        popup_StageSelect = FindObjectOfType<Popup_StageSelect>();
    }
    public void OnClickStage()
    {
        if (popup_StageSelect != null)
        {
            popup_StageSelect.Destroy();
            popup_StageSelect = UIManager.Instance.ShowPopup<Popup_StageSelect>();
            popup_StageSelect.Initialize();
            popup_StageSelect.UpdateStar(_stageLevel);
        }
        else
        {
            popup_StageSelect = UIManager.Instance.ShowPopup<Popup_StageSelect>();
            popup_StageSelect.Initialize();
            popup_StageSelect.UpdateStar(_stageLevel);
        }

    }
    public void SelectStageOne()
    {
        _stageLevel = 0;
        //GetStageStar();
        Debug.Log((_stageLevel + 1) + "level");
        //Debug.Log(stageStarData.starsEarned + "star");
    }

    public void SelectStageTwo()
    {
        _stageLevel = 1;
        //GetStageStar();
        Debug.Log((_stageLevel + 1) + "level");
        //Debug.Log(stageStarData.starsEarned + "star");
    }
    private void GetStageStar()
    {
        stageStarData = popup_StageSelect.stageStarDataArray [_stageLevel]; // �������� �� ���� ��������
    }

    public void SpawnStageInfo()
    {

    }
    public void SetZeroStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 0);
        popup_StageSelect.UpdateStar(_stageLevel);
    }

    public void SetOneStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 1);
        popup_StageSelect.UpdateStar(_stageLevel);
    }
    public void SetTwoStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 2);
        popup_StageSelect.UpdateStar(_stageLevel);
    }
    public void SetThreeStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 3);
        popup_StageSelect.UpdateStar(_stageLevel);
    }
    
}


