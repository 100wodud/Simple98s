using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInShop : MonoBehaviour
{
    [SerializeField] private ShopItemSO skinInfo;
    public ShopItemSO _skinInfo { get { return skinInfo; } }

    [SerializeField] private Image skinImage;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private bool isSkinUnlocked;
    [SerializeField] private bool isFreeSkin;

    private PlayerStar playerStar;

    private void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;

        // StarManager 인스턴스가 유효한지 확인합니다.
        if (StarManager.Instance != null)
        {
            if (isFreeSkin)
            {
                // PlayerStar 인스턴스가 유효한지 확인하고, TryRemoveStars(0)를 호출하기 전에 NullReferenceException을 피하기 위해 확인합니다.
                if (PlayerStar.instance != null && PlayerStar.instance.TryRemoveStars(0))
                {
                    PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                }
            }

            IsSkinUnlocked();
        }
        else
        {
            Debug.LogError("StarManager 인스턴스가 null입니다.");
        }
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else
        {
            buttonText.text = "Buy : " + skinInfo._skinPrice;
        }
    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            //equip
            if (SkinManager.instance != null)
            {
                SkinManager.instance.EquipSkin(this);
            }
            else
            {
                Debug.LogError("SkinManager 인스턴스가 null입니다.");
            }
        }
        else
        {
            //buy
            if (StarManager.Instance != null)
            {
                if (PlayerStar.instance != null && PlayerStar.instance.TryRemoveStars(skinInfo._skinPrice))
                {
                    PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                    IsSkinUnlocked();
                }
            }
            else
            {
                Debug.LogError("StarManager 인스턴스가 null입니다.");
            }
        }
    }
}
