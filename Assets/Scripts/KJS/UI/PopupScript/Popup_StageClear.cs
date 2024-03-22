using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_StageClear : UIPopup
{
    [SerializeField] private Image[] _starImages; // �������� ���� ȭ�� UI���� ���� ǥ���� �̹��� �迭
    public StageStarData[] stageStarDataArray; // �� ���������� �� ������ ���� �迭
    public void Initialize() //�ʱ�ȭ �޼���
    {
        Refresh();
    }
    private void Refresh()
    {

    }
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
    public void UpdateStar(int s)
    {
        UpdateStarsUI(s); // �������� 1�� ���� �� ������ �����ͼ� UI�� ǥ��
    }

    // �������� ���� ȭ�� UI�� ���� ǥ���ϴ� �Լ�
    private void UpdateStarsUI(int stageIndex)
    {
        int stars = GetStarsForStage(stageIndex); // �������� �� ���� ��������

        for (int i = 0; i < _starImages.Length; i++)
        {
            _starImages[i].gameObject.SetActive(i < stars); // �� ������ ���� �̹��� Ȱ��ȭ/��Ȱ��ȭ
        }
    }

    public void BackStage()
    {
        SceneLoader.Instance.GotoStoryScene();
    }
}
