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
    private string basePath = "Assets/Data/";
    private string fileName = "ShopSkinData.json";
    private List<SkinData> skinDataList = new List<SkinData>();


    private void Awake()
    {
        LoadSkinData();
        skinImage.sprite = skinInfo._skinSprite;

        starManager = StarManager.Instance;

        // 스킨이 잠금 해제되었는지 확인
        if (IsSkinUnlocked(skinInfo._skinID.ToString()))
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
        }
        else if (isFreeSkin) // 무료 스킨은 게임 시작 시 자동으로 장착
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
            SaveSkinData(skinInfo._skinID.ToString());
        }
        else
        {
            buttonText.text = ": " + skinInfo._skinPrice;
        }
    }

    private void LoadSkinData()
    {
        string filePath = Path.Combine(basePath, fileName);
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            skinDataList = JsonUtility.FromJson<List<SkinData>>(jsonData);
        }
        else
        {
            CreateNewSkinDataFile();
        }
    }
    private void CreateNewSkinDataFile()
    {
        skinDataList = new List<SkinData>();
        SaveSkinData(""); // 초기화 데이터를 저장합니다.
    }

    private void SaveSkinData(string skinID)
    {
        // 새 스킨 데이터를 추가하여 저장합니다.
        skinDataList.Add(new SkinData
        {
            skinID = skinID,
            isUnlocked = true
        });

        string filePath = Path.Combine(basePath, fileName);
        string json = JsonUtility.ToJson(skinDataList);
        File.WriteAllText(filePath, json);
    }
    
    private bool IsSkinUnlocked(string skinID)
    {
        foreach (SkinData data in skinDataList)
        {
            if (data.skinID == skinID && data.isUnlocked)
            {
                return true;
            }
        }
        return false;
    }

    public void OnButtonPress()
    {
        if (starManager == null || staricon == null)
        {
            Debug.LogError("starManager or staricon is null.");
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
                Debug.LogError("SkinManager 인스턴스가 null입니다.");
            }
        }
        else
        {
            // 총 별의 수가 스킨 가격보다 크거나 같은지 확인
            if (starManager != null && starManager.starCount >= skinInfo._skinPrice && staricon != null)
            {
                staricon.gameObject.SetActive(false);
                skinDataList.Find(data => data.skinID == skinInfo._skinID.ToString()).isUnlocked = true;

                isSkinUnlocked = true;
                buttonText.text = "Equip";
                SaveSkinData(skinInfo._skinID.ToString());
            }
            else
            {
                Debug.LogError("starManager or staricon is null.");
            }
        }
    }
}