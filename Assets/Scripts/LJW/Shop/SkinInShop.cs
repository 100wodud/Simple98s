using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

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

    private void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;

        starManager = StarManager.Instance;
        LoadSkinData();
        IsSkinUnlocked();
    }

    private void IsSkinUnlocked()
    {
        if (isSkinUnlocked)
        {
            buttonText.text = "Equip"; // 스킨이 잠금 해제되어 있으면 "장착"으로 텍스트 설정
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
        }
        else if (isFreeSkin)
        {
            buttonText.text = "Equip"; // 무료 스킨은 "장착"으로 텍스트 설정
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
        }
        else
        {
            buttonText.text = "      : " + skinInfo._skinPrice; // 그 외에는 가격 표시
        }
    }

    public void OnButtonPress()
    {
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
            if (starManager != null && starManager.starCount >= skinInfo._skinPrice)
            {
                staricon.gameObject.SetActive(false);
                isSkinUnlocked = true;
                buttonText.text = "Equip";

                SaveSkinData();

                IsSkinUnlocked();
            }
        }
    }
    private void SaveSkinData()
    {
        string fileName = "SkinData" + skinInfo._skinID.ToString() + ".json";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        SkinData data = new SkinData();
        data.isSkinUnlocked = isSkinUnlocked;
        data.skinID = skinInfo._skinID;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    private void LoadSkinData()
    {
        string fileName = "SkinData" + skinInfo._skinID.ToString() + ".json";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SkinData data = JsonUtility.FromJson<SkinData>(json);

            isSkinUnlocked = data.isSkinUnlocked;
            if (isSkinUnlocked)
            {
                buttonText.text = "Equip";
                buttonText.color = new Color32(60, 155, 165, 255);
                staricon.gameObject.SetActive(false);
            }
        }
    }
}

[System.Serializable]
public class SkinData
{
    public bool isSkinUnlocked;
    public ShopItemSO.SkinIDs skinID;
}