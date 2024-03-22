using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinStar_UI : UIPopup
{
    [SerializeField] private StageStarData[] stageStarDataArray;
    [SerializeField] private TextMeshProUGUI _coinTxt;
    [SerializeField] private TextMeshProUGUI _starTxt;
    private int _star;
    

    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {
        GetAllStars();
    }

    public void UpdateCoin(int c)
    {
        RefreshCoin(c);
    }
    public void UpdateStars()
    {
        GetAllStars();
        RefreshStars(_star);
    }
    private void RefreshCoin(int coin)
    {
        _coinTxt.text = coin.ToString();
    }
    private void RefreshStars(int star)
    {
        _starTxt.text = star.ToString();
    }
    // 스테이지에서 얻은 별 개수를 불러오는 함수
    public int GetStarsForStage(int stageIndex)
    {
        return stageStarDataArray[stageIndex].starsEarned;
    }
    public void SetStarsForStage(int stageIndex, int stars)
    {
        stageStarDataArray[stageIndex].starsEarned = Mathf.Clamp(stars, 0, stageStarDataArray[stageIndex].maxStars); // 최대 별 개수를 초과하지 않도록 제한
        SaveStars(); // 저장
    }
    // 저장된 별 개수를 불러오는 함수
    private void SaveStars()
    {
        for (int i = 0; i < stageStarDataArray.Length; i++)
        {
            PlayerPrefs.SetInt("StarsForStage_" + i, stageStarDataArray[i].starsEarned);
        }
        PlayerPrefs.Save(); // 변경 사항 저장
    }
    private void GetAllStars()
    {
        _star = 0;
        for(int i = 0; i < stageStarDataArray.Length; i++)
        {
            _star += stageStarDataArray[i].starsEarned;
        }
    }

}

