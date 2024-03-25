using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_StageSelect : UIPopup
{
    [SerializeField]private Image[] _starImages; // 스테이지 선택 화면 UI에서 별을 표시할 이미지 배열
    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {
        StarManager.Instance.StarArrayLoad();
    }

    public void StageSceneMove()
    {
        SceneLoader.Instance.GotoStageScene();
    }

    public void UpdateStarImage(int s)
    {
        UpdateStarsUI(s); // 스테이지 1에 대한 별 정보를 가져와서 UI에 표시
    }

    // 스테이지 선택 화면 UI에 별을 표시하는 함수
    private void UpdateStarsUI(int stageIndex)
    {
        int stars = StarManager.Instance.GetStarsForStage(stageIndex); // 스테이지 별 정보 가져오기

        for (int i = 0; i < _starImages.Length; i++)
        {
            _starImages[i].gameObject.SetActive(i < stars); // 별 개수에 따라 이미지 활성화/비활성화
        }
    }
}
