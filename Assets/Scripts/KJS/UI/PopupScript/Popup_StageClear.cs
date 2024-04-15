using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popup_StageClear : UIPopup
{
    [SerializeField] private Image[] _starImages; // 스테이지 선택 화면 UI에서 별을 표시할 이미지 배열
    [SerializeField] private GameObject stars;
    [SerializeField] private GameObject stageBtn1;
    [SerializeField] private GameObject stageBtn2;
    [SerializeField] private GameObject reBtn1;
    [SerializeField] private GameObject nextBtn;
    [SerializeField] private GameObject noNext;
    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {
        if(SceneManager.GetActiveScene().name == "CustomStageScene")
        {
            stars.SetActive(false);
            stageBtn1.SetActive(false);
            reBtn1.SetActive(false);
            stageBtn2.SetActive(true);
            nextBtn.SetActive(false);
        }
        else
        {
            stars.SetActive(true);
            stageBtn1.SetActive(true);
            reBtn1.SetActive(true);
            stageBtn2.SetActive(false);
        }
    }
    public void UpdateStar(int s)
    {
        UpdateStarsUI(s); // 스테이지 1에 대한 별 정보를 가져와서 UI에 표시
    }

    // 스테이지 선택 화면 UI에 별을 표시하는 함수
    private void UpdateStarsUI(int stars)
    {
        for (int i = 0; i < _starImages.Length; i++)
        {
            _starImages[i].gameObject.SetActive(i < stars); // 별 개수에 따라 이미지 활성화/비활성화
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

    public void NextBtn()
    {
        if(StarManager.Instance.starCount >= StarManager.Instance.stageStarDataArray[StageSelecter.selectStageIndex].unlockStar)
        {
            StageSelecter.selectStageIndex++;
            Debug.Log(StageSelecter.selectStageIndex);
            SceneLoader.Instance.SceneReload();
        }
        else
        {
            StartCoroutine(ErrorMassage(0.5f, noNext));
        }
    }

    IEnumerator ErrorMassage(float delay, GameObject obj)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(delay);

        obj.SetActive(false);
    }
}
