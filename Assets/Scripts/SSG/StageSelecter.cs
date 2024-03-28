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
        OnSelectStage();
        JsonDataManager.Instance.IndexSave(StageManager.Instance.stageindex);
        SaveStageJson.Instance.LoadStageData(StageManager.Instance.stageindex, StarManager.Instance.stageStarDataArray[StageManager.Instance.stageindex - 1]);
        popup_StageSelect.UpdateStarImage(selectStageIndex - 1);
        //�������� �Ŵ������� ���� ��������
        //�̰� �������� ť�긶�� �ٸ��� �� �� �ִ� �ε�����...
        //���ϴ� ��: �������� ��ȣ���� ������ �ϰ� �������� �Ŵ�����
        //�� ���� ���� �����ϰ� �ϱ�
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
        popup_StageSelect.Destroy();
    }

}
