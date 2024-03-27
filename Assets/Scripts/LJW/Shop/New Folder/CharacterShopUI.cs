using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopUI : MonoBehaviour
{
    [Header("Layout Settings")]
    [SerializeField] float itemSpacing = .5f;
    float itemWidth;


    [Header("UI Elements")]

    [SerializeField] Transform ShopMenu;
    [SerializeField] Transform ShopItemsContainer;
    [SerializeField] GameObject itemPrefab;
    [Space(20)]
    [SerializeField] CharacterShopDatabase characterDB;

    [Header("Shop Events")]
    [SerializeField] GameObject shopUI;
    [SerializeField] Button closeShopButton;


    void Start()
    {
        AddShopEvents();
        GenerateShopItemsUI();
    }

    void GenerateShopItemsUI()
    {
        itemWidth = ShopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        Destroy(ShopItemsContainer.GetChild(0).gameObject);
        ShopItemsContainer.DetachChildren();

        for(int i = 0; i < characterDB.CharactersCount; i++)
        {
            Character character = characterDB.GetCharacter(i);
            CharacterItemUI uiItem = Instantiate (itemPrefab, ShopItemsContainer).GetComponent <CharacterItemUI>();

            uiItem.SetItemPosition (Vector2.right * i * (itemWidth + itemSpacing));

            uiItem.gameObject.name = "Item" + "-" + character.name;

            uiItem.SetCharacterName (character.name);
            uiItem.SetCharacterImage(character.image);
            uiItem.SetCharacterSpeed(character.speed);
            uiItem.SetCharacterPrice(character.price);

            if(character.isPurchased)
            {
                uiItem.SetCharacterAsPurchased();
                uiItem.OnItemSelect(i, OnItemSelected);
            }
            else
            {
                uiItem.SetCharacterPrice (character.price);
                uiItem.OnItemPurchase(i, OnItemPurchased);
            }

            ShopItemsContainer.GetComponent<RectTransform>().sizeDelta = Vector2.left * (itemWidth + itemSpacing) * characterDB.CharactersCount;
        }
    }
    void OnItemSelected(int index)
    {
        Debug.Log("select " + index );
    }
    void OnItemPurchased(int index)
    {
        Debug.Log("purchase " + index);
    }

    void AddShopEvents()
    {
        closeShopButton.onClick.RemoveAllListeners();
        closeShopButton.onClick.AddListener(CloseShop);
    }


    void CloseShop()
    {
        shopUI.SetActive(false);
    }

}
