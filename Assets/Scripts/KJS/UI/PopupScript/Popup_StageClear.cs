using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popup_StageClear : UIPopup
{
    [SerializeField] private Image[] _starImages; // �������� ���� ȭ�� UI���� ���� ǥ���� �̹��� �迭
    [SerializeField] private GameObject stars;
    [SerializeField] private GameObject nextBtn1;
    [SerializeField] private GameObject nextBtn2;
    [SerializeField] private GameObject reBtn1;
    //public StageStarData[] stageStarDataArray; // �� ���������� �� ������ ���� �迭
    public void Initialize() //�ʱ�ȭ �޼���
    {
        Refresh();
    }
    private void Refresh()
    {
        if(SceneManager.GetActiveScene().name == "CustomStageScene")
        {
            stars.SetActive(false);
            nextBtn1.SetActive(false);
            reBtn1.SetActive(false);
            nextBtn2.SetActive(true);
        }
        else
        {
            stars.SetActive(true);
            nextBtn1.SetActive(true);
            reBtn1.SetActive(true);
            nextBtn2.SetActive(false);
        }
    }
    //public void SetStarsForStage(int stageIndex, int stars)
    //{
    //    stageStarDataArray[stageIndex].starsEarned = Mathf.Clamp(stars, 0, stageStarDataArray[stageIndex].maxStars); // �ִ� �� ������ �ʰ����� �ʵ��� ����
    //    SaveStars(); // ����
    //}

    //// ������������ ���� �� ������ �ҷ����� �Լ�
    //public int GetStarsForStage(int stageIndex)
    //{
    //    return stageStarDataArray[stageIndex].starsEarned;
    //}

    //// ����� �� ������ �ҷ����� �Լ�
    //private void SaveStars()
    //{
    //    for (int i = 0; i < stageStarDataArray.Length; i++)
    //    {
    //        PlayerPrefs.SetInt("StarsForStage_" + i, stageStarDataArray[i].starsEarned);
    //    }
    //    PlayerPrefs.Save(); // ���� ���� ����
    //}
    public void UpdateStar(int s)
    {
        UpdateStarsUI(s); // �������� 1�� ���� �� ������ �����ͼ� UI�� ǥ��
    }

    // �������� ���� ȭ�� UI�� ���� ǥ���ϴ� �Լ�
    private void UpdateStarsUI(int stars)
    {
        for (int i = 0; i < _starImages.Length; i++)
        {
            _starImages[i].gameObject.SetActive(i < stars); // �� ������ ���� �̹��� Ȱ��ȭ/��Ȱ��ȭ
        }
    }

    public void BackStage()
    {
        if (SceneManager.GetActiveScene().name == "CustomStageScene")
        {
            SceneLoader.Instance.GotoCustomMapListScene();
        }
        else
        {
            SceneLoader.Instance.GotoStoryScene();
        }
    }

    public void RetryBtn()
    {
        SceneLoader.Instance.SceneReload();
    }
}
