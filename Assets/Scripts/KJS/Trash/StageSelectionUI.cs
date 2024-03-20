using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectionUI : MonoBehaviour
{
    public Image[] starImages; // �������� ���� ȭ�� UI���� ���� ǥ���� �̹��� �迭

    
    public void UpdateStar(int s)
    {
        UpdateStarsUI(s); // �������� 1�� ���� �� ������ �����ͼ� UI�� ǥ��
    }

    // �������� ���� ȭ�� UI�� ���� ǥ���ϴ� �Լ�
    private void UpdateStarsUI(int stageIndex)
    {
        int stars = StarManager.Instance.GetStarsForStage(stageIndex); // �������� �� ���� ��������

        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].gameObject.SetActive(i < stars); // �� ������ ���� �̹��� Ȱ��ȭ/��Ȱ��ȭ
        }
    }
}

