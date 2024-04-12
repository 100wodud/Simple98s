using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SkinDataHandler : MonoBehaviour
{
    public static SkinDataHandler instance;

    private string basePath = Application.persistentDataPath;
    private string fileExtension = ".json";

    private Dictionary<int, ShopItemSO> skinDictionary = new Dictionary<int, ShopItemSO>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveShopSkinData(int skinIndex, ShopItemSO skinData)
    {
        skinDictionary[skinIndex] = skinData;

        string fileName = "ShopSkinData" + skinIndex.ToString() + fileExtension;

        string json = JsonUtility.ToJson(skinData);
        File.WriteAllText(basePath + fileName, json);
    }

    public void LoadShopSkinData(int skinIndex, ShopItemSO skinData)
    {
        string fileName = "ShopSkinData" + skinIndex.ToString() + fileExtension;

        if (File.Exists(basePath + fileName))
        {
            string json = File.ReadAllText(basePath + fileName);
            JsonUtility.FromJsonOverwrite(json, skinData);
        }
        else
        {
            Debug.Log("File not Found: " + fileName);
        }
    }

    public bool IsSkinUnlocked(int skinIndex)
    {
        return skinDictionary.ContainsKey(skinIndex) && skinDictionary[skinIndex].isUnlocked;
    }
}
