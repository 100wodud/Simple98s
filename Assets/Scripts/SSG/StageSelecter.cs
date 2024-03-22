using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecter : MonoBehaviour
{
    [SerializeField] private int selectStageIndex = 0;
    private Popup_StageSelect popup_StageSelect;

    private void Start()
    {
        popup_StageSelect = FindObjectOfType<Popup_StageSelect>();
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {       
        StageManager.Instance.stageindex = selectStageIndex;
        JsonDataManager.Instance.JsonSave(StageManager.Instance.stageindex,StageManager.Instance.star,
        StageManager.Instance.coin,StageManager.Instance.clearStage);
        OnSelectStage();
        //스테이지 매니저에서 값을 가져가고
        //이걸 스테이지 큐브마다 다르게 할 수 있는 인덱스라...
        //원하는 것: 스테이지 번호값을 가지게 하고 스테이지 매니저가
        //그 다음 씬을 변경하게 하기
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ExitSelectStage();
    }
    private void OnSelectStage()
    {
        if (popup_StageSelect != null)
        {
            popup_StageSelect.Destroy();
            popup_StageSelect = UIManager.Instance.ShowPopup<Popup_StageSelect>();
            popup_StageSelect.Initialize();
            popup_StageSelect.UpdateStar(selectStageIndex-1);
        }
        else
        {
            popup_StageSelect = UIManager.Instance.ShowPopup<Popup_StageSelect>();
            popup_StageSelect.Initialize();
            popup_StageSelect.UpdateStar(selectStageIndex-1);
        }

    }
    private void ExitSelectStage()
    {
        popup_StageSelect.Destroy();
    }
}
