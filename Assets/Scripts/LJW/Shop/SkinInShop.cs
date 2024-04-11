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

        // ��Ų�� ��� �����Ǿ����� Ȯ��
        if (IsSkinUnlocked(skinInfo._skinID.ToString()))
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
        }
        else if (isFreeSkin) // ���� ��Ų�� ���� ���� �� �ڵ����� ����
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
        SaveSkinData(""); // �ʱ�ȭ �����͸� �����մϴ�.
    }

    private void SaveSkinData(string skinID)
    {
        // �� ��Ų �����͸� �߰��Ͽ� �����մϴ�.
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
                Debug.LogError("SkinManager �ν��Ͻ��� null�Դϴ�.");
            }
        }
        else
        {
            // �� ���� ���� ��Ų ���ݺ��� ũ�ų� ������ Ȯ��
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