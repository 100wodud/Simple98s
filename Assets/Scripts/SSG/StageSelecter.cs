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
