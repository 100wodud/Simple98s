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
    // ������������ ���� �� ������ �����ϴ� �Լ�
    public void SetStarsForStage(int stageIndex, int stars)
    {
        if(stars > stageStarDataArray[stageIndex].bestStar)
        {
            stageStarDataArray[stageIndex].bestStar = stars;
            // ���� �� ���� ����
            stageStarDataArray[stageIndex].starsEarned = Mathf.Clamp(stars, 0, stageStarDataArray[stageIndex].maxStars);
            // ����
            SaveStars();
        }
        else
        {
            return;
        }
    }

    // ������������ ���� �� ������ �ҷ����� �Լ�
    public int GetStarsForStage(int stageIndex)
    {
        return stageStarDataArray[stageIndex].starsEarned;
    }

    // ����� �� ������ �ҷ����� �Լ�
    private void SaveStars()
    {
        for (int i = 0; i < stageStarDataArray.Length; i++)
        {
            PlayerPrefs.SetInt("StarsForStage_" + i, stageStarDataArray[i].starsEarned);
        }
        PlayerPrefs.Save(); // ���� ���� ����
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
