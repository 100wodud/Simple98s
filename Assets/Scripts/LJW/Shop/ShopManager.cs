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

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length;i++)
        {
            if(coins >= shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNO)
    {
        if(coins >= shopItemsSO[btnNO].baseCost)
        {
            coins = coins - shopItemsSO[btnNO].baseCost;
            coinUI.text = "Coins : " + coins.ToString();
            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0;i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }
}
