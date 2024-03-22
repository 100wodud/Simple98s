using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusStar : MonoBehaviour
{

    private Popup_StageSelect popup_StageSelect;
    private Popup_StageClear popup_StageClear;
    private CoinStar_UI coinStar_UI;

    private StageStarData stageStarData; // 스테이지 별 정보를 저장할 변수
    [SerializeField] private int _coin = 0;
    private int _stageLevel = 0;

    

    private void Start()
    {
        popup_StageSelect = FindObjectOfType<Popup_StageSelect>();
        coinStar_UI = FindObjectOfType<CoinStar_UI>();
    }

    private void CoinUI()
    {
        if (coinStar_UI != null)
        {
            return;
        }
        else
        {
            coinStar_UI = UIManager.Instance.ShowPopup<CoinStar_UI>();
            coinStar_UI.Initialize();
            coinStar_UI.UpdateCoin(_coin);
            coinStar_UI.UpdateStars();
        }
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
    public void OnClickClear()
    {
        if (popup_StageClear != null)
        {
            return;
        }
        else
        {
            popup_StageClear = UIManager.Instance.ShowPopup<Popup_StageClear>();
            popup_StageClear.Initialize();
            popup_StageClear.UpdateStar(_stageLevel);
        }
    }
    public void PlusCoin()
    {
        _coin++;
        coinStar_UI.UpdateCoin(_coin);
    }
    public void MinusCoin()
    {
        _coin--;
        coinStar_UI.UpdateCoin(_coin);
    }
    public void ExitBtn()
    {
        popup_StageClear.Destroy();
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
    public void SpawnStageInfo()
    {

    }
    public void SetZeroStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 0);
        popup_StageSelect.UpdateStar(_stageLevel);
        coinStar_UI.UpdateStars();
    }

    public void SetOneStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 1);
        popup_StageSelect.UpdateStar(_stageLevel);
        coinStar_UI.UpdateStars();
    }
    public void SetTwoStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 2);
        popup_StageSelect.UpdateStar(_stageLevel);
        coinStar_UI.UpdateStars();
    }
    public void SetThreeStar()
    {
        popup_StageSelect.SetStarsForStage(_stageLevel, 3);
        popup_StageSelect.UpdateStar(_stageLevel);
        coinStar_UI.UpdateStars();
    }
    
}


