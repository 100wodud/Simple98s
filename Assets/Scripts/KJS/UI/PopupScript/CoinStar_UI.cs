using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CoinStar_UI : UIPopup
{
    [SerializeField] private Image[] _starImages;


    public void Initialize() //초기화 메서드
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
            _starImages[i].gameObject.SetActive(i < star); // 별 개수에 따라 이미지 활성화/비활성화
        }
    }
}

