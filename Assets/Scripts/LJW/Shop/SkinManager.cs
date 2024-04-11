using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;
    private const string skinsDataPath = "skinsData.json";
    public static Sprite equippedSkin { get; private set; }

    [SerializeField] private ShopItemSO[] allskins;
    private List<SkinInShop> skinsInShopPanels = new List<SkinInShop>();

    private Button currentlyEquippedSkinButton;
    [SerializeField] private Transform skinsInShopPanelsParent;

    private void Awake()
    {
        instance = this;

        // skinsInShopPanelsParent 변수에 Transform을 할당
        if (skinsInShopPanelsParent == null)
        {
            Debug.LogError("skinsInShopPanelsParent가 할당되지 않았습니다.");
            return;
        }

        foreach (Transform s in skinsInShopPanelsParent)
        {
            if (s.TryGetComponent(out SkinInShop skinInShop))
                skinsInShopPanels.Add(skinInShop);
        }

        LoadSkinData();

        SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinSprite == equippedSkin);
        currentlyEquippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }

    private void LoadSkinData()
    {
        string filePath = Application.persistentDataPath + "/" + skinsDataPath;
        if (System.IO.File.Exists(filePath))
        {
            string jsonData = System.IO.File.ReadAllText(filePath);
            SkinData loadedData = JsonUtility.FromJson<SkinData>(jsonData);

            // SkinData에 마지막으로 장착된 스킨 ID를 저장하는 lastEquippedSkinID와 같은 필드가 있다고 가정
            string lastSkinused = loadedData.lastEquippedSkinID;
            SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinused);
            EquipSkin(skinEquippedPanel);
        }
        else
        {
            Debug.LogWarning("스킨 데이터 파일을 찾을 수 없습니다.");
        }
    }

    //private void EquipPreviousSkin()
    //{
    //    string lastSkinused = PlayerPrefs.GetString(skinPref, ShopItemSO.SkinIDs.red.ToString());
    //    SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinused);
    //    EquipSkin(skinEquippedPanel);
    //}

    public void EquipSkin(SkinInShop skinInfoInShop)
    {
        equippedSkin = skinInfoInShop._skinInfo._skinSprite;

        if (currentlyEquippedSkinButton != null)
            currentlyEquippedSkinButton.interactable = true;
        currentlyEquippedSkinButton = skinInfoInShop.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;

        // 현재 장착된 스킨의 ID를 JSON 파일에 저장
        SaveSkinData(skinInfoInShop._skinInfo._skinID.ToString());
    }

    private void SaveSkinData(string skinID)
    {
        // SkinData에 마지막으로 장착된 스킨 ID를 저장하는 lastEquippedSkinID와 같은 필드가 있다고 가정
        SkinData skinData = new SkinData();
        skinData.lastEquippedSkinID = skinID;

        string filePath = Application.persistentDataPath + "/" + skinsDataPath;
        string jsonData = JsonUtility.ToJson(skinData);
        System.IO.File.WriteAllText(filePath, jsonData);
    }
}
