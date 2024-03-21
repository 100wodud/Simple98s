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
    private int _coin = 0;
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

    private void GetAllStars()
    {
        _star = 0;
        for(int i = 0; i < stageStarDataArray.Length; i++)
        {
            _star += stageStarDataArray[i].starsEarned;
        }
    }

}

