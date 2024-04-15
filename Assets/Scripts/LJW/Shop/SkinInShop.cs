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
            buttonText.text = "Equip"; // ��Ų�� ��� �����Ǿ� ������ "����"���� �ؽ�Ʈ ����
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
        }
        else if (isFreeSkin)
        {
            buttonText.text = "Equip"; // ���� ��Ų�� "����"���� �ؽ�Ʈ ����
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
        }
        else
        {
            buttonText.text = "      : " + skinInfo._skinPrice; // �� �ܿ��� ���� ǥ��
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
                Debug.LogError("SkinManager �ν��Ͻ��� null�Դϴ�.");
            }
        }
        else
        {
            // �� ���� ���� ��Ų ���ݺ��� ũ�ų� ������ Ȯ��
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