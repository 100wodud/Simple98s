using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecter : MonoBehaviour
{
    [SerializeField] private int selectStageIndex = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        StageManager.Instance.stageindex =selectStageIndex;
        SceneController.Instance.LoadScene("MapScene");
        //�������� �Ŵ������� ���� ��������
        //�̰� �������� ť�긶�� �ٸ��� �� �� �ִ� �ε�����...
        //���ϴ� ��: �������� ��ȣ���� ������ �ϰ� �������� �Ŵ�����
        //�� ���� ���� �����ϰ� �ϱ�
    }
}
