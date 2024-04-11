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

        // skinsInShopPanelsParent ������ Transform�� �Ҵ�
        if (skinsInShopPanelsParent == null)
        {
            Debug.LogError("skinsInShopPanelsParent�� �Ҵ���� �ʾҽ��ϴ�.");
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

            // SkinData�� ���������� ������ ��Ų ID�� �����ϴ� lastEquippedSkinID�� ���� �ʵ尡 �ִٰ� ����
            string lastSkinused = loadedData.lastEquippedSkinID;
            SkinInShop skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinused);
            EquipSkin(skinEquippedPanel);
        }
        else
        {
            Debug.LogWarning("��Ų ������ ������ ã�� �� �����ϴ�.");
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

        // ���� ������ ��Ų�� ID�� JSON ���Ͽ� ����
        SaveSkinData(skinInfoInShop._skinInfo._skinID.ToString());
    }

    private void SaveSkinData(string skinID)
    {
        // SkinData�� ���������� ������ ��Ų ID�� �����ϴ� lastEquippedSkinID�� ���� �ʵ尡 �ִٰ� ����
        SkinData skinData = new SkinData();
        skinData.lastEquippedSkinID = skinID;

        string filePath = Application.persistentDataPath + "/" + skinsDataPath;
        string jsonData = JsonUtility.ToJson(skinData);
        System.IO.File.WriteAllText(filePath, jsonData);
    }
}
