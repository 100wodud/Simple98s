using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_StageSelect : UIPopup
{
    [SerializeField]private Image[] _starImages; // 스테이지 선택 화면 UI에서 별을 표시할 이미지 배열
    public StageStarData[] stageStarDataArray; // 각 스테이지의 별 정보를 담을 배열

    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {

    }

    public void StageSceneMove()
    {
        SceneLoader.Instance.GotoStageScene();
    }
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

    public void UpdateStar(int s)
    {
        UpdateStarsUI(s); // 스테이지 1에 대한 별 정보를 가져와서 UI에 표시
    }

    // 스테이지 선택 화면 UI에 별을 표시하는 함수
    private void UpdateStarsUI(int stageIndex)
    {
        int stars = GetStarsForStage(stageIndex); // 스테이지 별 정보 가져오기

        for (int i = 0; i < _starImages.Length; i++)
        {
            _starImages[i].gameObject.SetActive(i < stars); // 별 개수에 따라 이미지 활성화/비활성화
        }
    }
}
