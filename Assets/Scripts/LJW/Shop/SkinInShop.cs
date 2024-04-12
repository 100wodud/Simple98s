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
        buttonText.text = "Equip"; // ��� ������ ��Ų�� ��ư �ؽ�Ʈ�� "Equip"���� ����
        buttonText.color = new Color32(60, 155, 165, 255);
        staricon.gameObject.SetActive(false);
    }

    public void OnButtonPress()
    {
        if (starManager == null || staricon == null)
        {
            Debug.LogError("starManager �Ǵ� staricon�� null�Դϴ�.");
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
                Debug.LogError("SkinManager �ν��Ͻ��� null�Դϴ�.");
            }
        }
        else
        {
            // �� ���� ���� ��Ų ���ݺ��� ũ�ų� ������ Ȯ��
            if (starManager != null && starManager.starCount >= skinInfo._skinPrice && staricon != null)
            {
                staricon.gameObject.SetActive(false);

                isSkinUnlocked = true;
                UpdateButtonText(); // ��� ���� �� ��ư �ؽ�Ʈ ������Ʈ
                SkinDataHandler.instance.SaveShopSkinData(skinIndex, skinInfo);
            }
            else
            {
                Debug.LogError("starManager �Ǵ� staricon�� null�Դϴ�.");
            }
        }
    }
}