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

    public void CheckPurchaseable() //구매 가능한 아이템 구분
    {
        for (int i = 0; i < shopItemsSO.Length;i++)
        {
            // 해당 스킨이 이미 구매되었는지 확인합니다.
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

    public void PurchaseItem(int btnNO) //아이템 구매
    {
        if(coins >= shopItemsSO[btnNO].baseCost)
        {
            coins = coins - shopItemsSO[btnNO].baseCost;
            PlayerPrefs.SetInt(shopItemsSO[btnNO].skinID.ToString(), 1); // 스킨 잠금 해제
            PlayerPrefs.Save();// 플레이어 환경설정 저장
            coinUI.text = "Coins : " + coins.ToString();
            myPurchaseBtns[btnNO].GetComponentInChildren<TMP_Text>().text = "Equip";
            myPurchaseBtns[btnNO].interactable = false; // 이미 구매한 아이템은 더 이상 구매할 수 없도록 버튼 비활성화
            EquipSkin(btnNO); // 스킨을 구매한 후 바로 장착
            CheckPurchaseable();
        }
    }

    public void LoadPanels() // 판넬 불러오기
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
            myPurchaseBtns[btnNO].interactable = false; // 이미 구매한 아이템은 더 이상 구매할 수 없도록 버튼 비활성화
        }
    }

    private void EquipSkin(int btnNO)
    {
        // SkinManager의 EquipSkin 메서드를 호출하여 스킨을 장착
        if (skinManager != null)
        {
            skinManager.EquipSkin(shopItemsSO[btnNO]);
        }
    }
}
