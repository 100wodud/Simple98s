using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecter : MonoBehaviour
{
    [SerializeField] private int stageIndex = 1;
    public static int selectStageIndex;
    private Popup_StageSelect popup_StageSelect;
    
    private void Start()
    {
        popup_StageSelect = FindObjectOfType<Popup_StageSelect>();
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        selectStageIndex = stageIndex;
        OnSelectStage();
        //JsonDataManager.Instance.IndexSave(StageIndex.Instance.stageindex);
        //SaveStageJson.Instance.LoadStageData(StageIndex.stageindex, StarManager.Instance.stageStarDataArray[StageIndex.stageindex - 1]);
        popup_StageSelect.UpdateStarImage(selectStageIndex - 1);
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
        }
        else
        {
            popup_StageSelect = UIManager.Instance.ShowPopup<Popup_StageSelect>();
            popup_StageSelect.Initialize();
        }

    }
    private void ExitSelectStage()
    {
        if (popup_StageSelect != null)
        {
            popup_StageSelect.Destroy();
            popup_StageSelect = null;
        } 
    }

}
