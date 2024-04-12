using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;
using static ShopItemSO;

public class SkinInShop : MonoBehaviour
{
    [SerializeField] private ShopItemSO skinInfo;
    public ShopItemSO _skinInfo { get { return skinInfo; } }

    [SerializeField] private Image staricon;
    [SerializeField] private Image skinImage;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private bool isSkinUnlocked;
    [SerializeField] private bool isFreeSkin;

    private StarManager starManager;

    int skinIndex;

    private void Awake()
    {
        starManager = StarManager.Instance;
        skinIndex = (int)skinInfo._skinID;
        skinImage.sprite = skinInfo._skinSprite;
        SkinDataHandler.instance.LoadShopSkinData((int)skinInfo._skinID, skinInfo);

        if (SkinDataHandler.instance.IsSkinUnlocked(skinIndex))
        {
            isSkinUnlocked = true;
            UpdateButtonText();
        }
        else if (isFreeSkin)
        {
            isSkinUnlocked = true;
            UpdateButtonText();
            SkinDataHandler.instance.SaveShopSkinData(skinIndex, skinInfo);
        }
        else
        {
            buttonText.text = ": " + skinInfo._skinPrice;
        }
    }

    private void UpdateButtonText()
    {
        isSkinUnlocked = true;
        buttonText.text = "Equip"; // 잠금 해제된 스킨의 버튼 텍스트를 "Equip"으로 설정
        buttonText.color = new Color32(60, 155, 165, 255);
        staricon.gameObject.SetActive(false);
    }

    public void OnButtonPress()
    {
        if (starManager == null || staricon == null)
        {
            Debug.LogError("starManager 또는 staricon이 null입니다.");
            return;
        }
        if (isSkinUnlocked)
        {
            if (SkinManager.instance != null)
            {
                SkinManager.instance.EquipSkin(this);
                staricon.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("SkinManager 인스턴스가 null입니다.");
            }
        }
        else
        {
            // 총 별의 수가 스킨 가격보다 크거나 같은지 확인
            if (starManager != null && starManager.starCount >= skinInfo._skinPrice && staricon != null)
            {
                staricon.gameObject.SetActive(false);

                isSkinUnlocked = true;
                UpdateButtonText(); // 잠금 해제 후 버튼 텍스트 업데이트
                SkinDataHandler.instance.SaveShopSkinData(skinIndex, skinInfo);
            }
            else
            {
                Debug.LogError("starManager 또는 staricon이 null입니다.");
            }
        }
    }
}