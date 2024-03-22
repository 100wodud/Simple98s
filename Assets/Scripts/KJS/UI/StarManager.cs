using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public StageStarData[] stageStarDataArray;
    // ������������ ���� �� ������ �����ϴ� �Լ�
    public void SetStarsForStage(int stageIndex, int stars)
    {
        stageStarDataArray[stageIndex].starsEarned = Mathf.Clamp(stars, 0, stageStarDataArray[stageIndex].maxStars); // �ִ� �� ������ �ʰ����� �ʵ��� ����
        SaveStars(); // ����
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
}
