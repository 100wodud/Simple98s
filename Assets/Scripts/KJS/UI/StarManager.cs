using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager
{
    private static StarManager _instance;
    public int starCount;
    public StageStarData[] stageStarDataArray;
    private string _path = "StarData";
    public static StarManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new StarManager();
            }
            return _instance;
        }
    }
    public void StarArrayLoad()
    {
        stageStarDataArray = Resources.LoadAll<StageStarData>(_path);
    }
    // 스테이지에서 얻은 별 개수를 설정하는 함수
    public void SetStarsForStage(int stageIndex, int stars)
    {
        if(stars > stageStarDataArray[stageIndex].bestStar)
        {
            stageStarDataArray[stageIndex].bestStar = stars;
            // 얻은 별 개수 저장
            stageStarDataArray[stageIndex].starsEarned = Mathf.Clamp(stars, 0, stageStarDataArray[stageIndex].maxStars);
            // 저장
            SaveStars();
        }
        else
        {
            return;
        }
    }

    // 스테이지에서 얻은 별 개수를 불러오는 함수
    public int GetStarsForStage(int stageIndex)
    {
        return stageStarDataArray[stageIndex].starsEarned;
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
    public void GetAllStars()
    {
        starCount = 0;
        for (int i = 0; i < stageStarDataArray.Length; i++)
        {
            starCount += stageStarDataArray[i].starsEarned;
        }
    }
}
