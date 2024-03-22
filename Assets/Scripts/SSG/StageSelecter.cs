using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecter : MonoBehaviour
{
    [SerializeField] private int selectStageIndex = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        StageManager.Instance.stageindex =selectStageIndex;
        JsonDataManager.Instance.JsonSave(StageManager.Instance.stageindex,StageManager.Instance.star,
            StageManager.Instance.coin,StageManager.Instance.clearStage);
        SceneLoadManager.Instance.LoadScene("MapScene");
        //�������� �Ŵ������� ���� ��������
        //�̰� �������� ť�긶�� �ٸ��� �� �� �ִ� �ε�����...
        //���ϴ� ��: �������� ��ȣ���� ������ �ϰ� �������� �Ŵ�����
        //�� ���� ���� �����ϰ� �ϱ�
    }
}