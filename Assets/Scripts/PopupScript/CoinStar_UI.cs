using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CoinStar_UI : UIPopup
{
    [SerializeField] private Image[] _starImages;


    public void Initialize() //�ʱ�ȭ �޼���
    {
        Refresh();
    }
    private void Refresh()
    {
        //StarManager.Instance.StarArrayLoad();
        //StarManager.Instance.GetAllStars();
    }

    public void UpdateAllStars()
    {
        StarManager.Instance.GetAllStars();
    }
    public void UpdateStageStar(int star)
    {
        RefreshStarsIcon(star);
    }
    private void RefreshStarsIcon(int star)
    {
        for (int i = 0; i < _starImages.Length; i++)
        {
            _starImages[i].gameObject.SetActive(i < star); // �� ������ ���� �̹��� Ȱ��ȭ/��Ȱ��ȭ
        }
    }
}

