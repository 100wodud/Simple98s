using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup_StageSelect : UIPopup
{
    [SerializeField]private Image[] _starImages; // �������� ���� ȭ�� UI���� ���� ǥ���� �̹��� �迭
    [SerializeField] private TextMeshProUGUI _stageName;
    [SerializeField] private TextMeshProUGUI _stageInfo;
    public void Initialize() //�ʱ�ȭ �޼���
    {
        Refresh();
    }
    private void Refresh()
    {
        _stageName.text = "Stage: " + StageSelecter.selectStageIndex;
        _stageInfo.text = StarManager.Instance.stageStarDataArray[StageSelecter.selectStageIndex - 1].stageInfo;
    }

    public void StageSceneMove()
    {
        SceneLoader.Instance.GotoStageScene();
    }

    public void UpdateStarImage(int s)
    {
        UpdateStarsUI(s); // �������� 1�� ���� �� ������ �����ͼ� UI�� ǥ��
    }

    // �������� ���� ȭ�� UI�� ���� ǥ���ϴ� �Լ�
    private void UpdateStarsUI(int stageIndex)
    {
        int stars = StarManager.Instance.GetStarsForStage(stageIndex); // �������� �� ���� ��������

        for (int i = 0; i < _starImages.Length; i++)
        {
            _starImages[i].gameObject.SetActive(i < stars); // �� ������ ���� �̹��� Ȱ��ȭ/��Ȱ��ȭ
        }
    }
}
