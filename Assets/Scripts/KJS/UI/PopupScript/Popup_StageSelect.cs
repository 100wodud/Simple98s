using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Popup_StageSelect : UIPopup
{
    [SerializeField]private Image[] _starImages; // 스테이지 선택 화면 UI에서 별을 표시할 이미지 배열
    [SerializeField] private TextMeshProUGUI _stageName;
    [SerializeField] private TextMeshProUGUI _stageInfo;
    private string[] stageInfo = new string[7] {"슬라임을 이동시켜 보자!           이동: WASD, 재시작: 스페이스", "좀 더 복잡해진 길을 나아가자!", "불덩이를 조심해!", "번개구름은 아프다!", ""
    , "꽃은 피해 범위가 넓으니 조심!","가끔은 손해를 감수해야한다.     즉사 블랙홀을 주의!"};
    public void Initialize() //초기화 메서드
    {
        Refresh();
    }
    private void Refresh()
    {
        _stageName.text = "Stage: " + StageSelecter.selectStageIndex;
        _stageInfo.text = stageInfo[StageSelecter.selectStageIndex - 1];
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

    public override void Destroy()
    {
        if(SceneManager.GetActiveScene().name == "StageScene")
        {
            StageSelecter.selectStageIndex--;
        }
        Destroy(gameObject);
    }
}
