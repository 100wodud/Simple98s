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

    public void OnClickStage()
    {
        selectStageIndex = stageIndex;
        isSelectStage();
        popup_StageSelect.UpdateStarImage(selectStageIndex - 1);
    }

    private void isSelectStage()
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

}
