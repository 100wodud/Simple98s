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

    void Start()
    {
        //PlayerPrefs.DeleteKey("YourSkinID");
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
            if (coins >= shopItemsSO[i]._skinPrice)
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
        if(coins >= shopItemsSO[btnNO]._skinPrice)
        {
            coins = coins - shopItemsSO[btnNO]._skinPrice;
            coinUI.text = "Coins : " + coins.ToString();
            CheckPurchaseable();
        }
    }

    public void LoadPanels() // 판넬 불러오기
    {
        for (int i = 0;i < shopItemsSO.Length; i++)
        {
            //shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            //shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i]._skinPrice.ToString();
            shopPanels[i].SetPlayerSkin(shopItemsSO[i]._skinSprite);
        }
    }
}
