using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public StageStarData[] stageStarDataArray;
    // 스테이지에서 얻은 별 개수를 설정하는 함수
    public void SetStarsForStage(int stageIndex, int stars)
    {
        stageStarDataArray[stageIndex].starsEarned = Mathf.Clamp(stars, 0, stageStarDataArray[stageIndex].maxStars); // 최대 별 개수를 초과하지 않도록 제한
        SaveStars(); // 저장
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
}
