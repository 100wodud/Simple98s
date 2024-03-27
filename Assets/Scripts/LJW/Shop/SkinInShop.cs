using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInShop : MonoBehaviour
{
    [SerializeField] private ShopItemSO skinInfo;
    //public ShopItemSO _skinInfo { get { return skinInfo; } }

    [SerializeField] private Image skinImage;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private bool isSkinUnlocked;
    [SerializeField] private bool isFreeSkin;

    private void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;

        //if (isFreeSkin)
        //{
        //    if (PlayerMoney.instance.TryRemoveMoney(0))
        //    {
        //        PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
        //    }
        //}

        IsSkinUnlocked();
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
            SkinManager.instance.EquipSkin(skinInfo);
        }
        else
        {
            //buy
            if (PlayerMoney.instance.TryRemoveMoney(skinInfo._skinPrice))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
}
