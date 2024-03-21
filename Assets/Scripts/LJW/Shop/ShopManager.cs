using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO;
    public Button[] myPurchaseBtns;
    public SkinManager skinManager;


    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        coinUI.text = "Coins : " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void AddCoins()
    {
        coins++;
        coinUI.text = "Coins : " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable() //���� ������ ������ ����
    {
        for (int i = 0; i < shopItemsSO.Length;i++)
        {
            // �ش� ��Ų�� �̹� ���ŵǾ����� Ȯ���մϴ�.
            bool isPurchased = PlayerPrefs.GetInt(shopItemsSO[i].skinID.ToString(), 0) == 1;

            if (!isPurchased && coins >= shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNO) //������ ����
    {
        if(coins >= shopItemsSO[btnNO].baseCost)
        {
            coins = coins - shopItemsSO[btnNO].baseCost;
            PlayerPrefs.SetInt(shopItemsSO[btnNO].skinID.ToString(), 1); // ��Ų ��� ����
            PlayerPrefs.Save();// �÷��̾� ȯ�漳�� ����
            coinUI.text = "Coins : " + coins.ToString();
            myPurchaseBtns[btnNO].GetComponentInChildren<TMP_Text>().text = "Equip";
            myPurchaseBtns[btnNO].interactable = false; // �̹� ������ �������� �� �̻� ������ �� ������ ��ư ��Ȱ��ȭ
            EquipSkin(btnNO); // ��Ų�� ������ �� �ٷ� ����
            CheckPurchaseable();
        }
    }

    public void LoadPanels() // �ǳ� �ҷ�����
    {
        for (int i = 0;i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
            shopPanels[i].SetPlayerSkin(shopItemsSO[i].playerSkin);
        }
    }

    private void UpdateButtonText(int btnNO)
    {
        if (PlayerPrefs.GetInt(shopItemsSO[btnNO].skinID.ToString()) == 1)
        {
            myPurchaseBtns[btnNO].GetComponentInChildren<TMP_Text>().text = "Equip";
            myPurchaseBtns[btnNO].interactable = false; // �̹� ������ �������� �� �̻� ������ �� ������ ��ư ��Ȱ��ȭ
        }
    }

    private void EquipSkin(int btnNO)
    {
        // SkinManager�� EquipSkin �޼��带 ȣ���Ͽ� ��Ų�� ����
        if (skinManager != null)
        {
            skinManager.EquipSkin(shopItemsSO[btnNO]);
        }
    }
}
