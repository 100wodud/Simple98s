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

    private StarManager starManager;

    private void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;

        starManager = StarManager.Instance;

        // ��Ų�� ��� �����Ǿ����� Ȯ��
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
        else if (isFreeSkin) // ���� ��Ų�� ���� ���� �� �ڵ����� ����
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
            PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1); // ��� ������ ������ ǥ��
        }
        else
        {
            buttonText.text = "Star : " + skinInfo._skinPrice;
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
            buttonText.text = "Star : " + skinInfo._skinPrice;
        }
    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            if (SkinManager.instance != null)
            {
                SkinManager.instance.EquipSkin(this);
            }
            else
            {
                Debug.LogError("SkinManager �ν��Ͻ��� null�Դϴ�.");
            }
        }
        else
        {
            // �� ���� ���� ��Ų ���ݺ��� ũ�ų� ������ Ȯ��
            if (starManager != null && starManager.starCount >= skinInfo._skinPrice)
            {
                // �� ���� ������ ��Ų ������ �����ϰ� ��Ų�� ��� ����
                starManager.starCount -= skinInfo._skinPrice;
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                PlayerPrefs.Save();
                isSkinUnlocked = true;
                buttonText.text = "Equip";
            }
        }
    }
}
