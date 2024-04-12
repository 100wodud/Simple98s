using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using TMPro;
public class StageSelecter : MonoBehaviour
{
    [SerializeField] private int stageIndex = 1;
    [SerializeField] private TextMeshProUGUI unlockStar;
    public static int selectStageIndex;
    private Popup_StageSelect popup_StageSelect;
    
    
    private void Start()
    {
        popup_StageSelect = FindObjectOfType<Popup_StageSelect>();
        if(unlockStar != null)
        {
            unlockStar.text = StarManager.Instance.stageStarDataArray[stageIndex-1].unlockStar.ToString();
        }
    }

    public void OnClickStage()
    {
        selectStageIndex = stageIndex;
        if (StarManager.Instance.stageStarDataArray[stageIndex-1].unlockStar > StarManager.Instance.starCount)
        {
            return;
        }
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
