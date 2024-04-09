using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        PlayerPrefs.DeleteAll(); //PlayerPrefs 초기화 메서드 ( 상점 구매 정보 Json으로 변경하기)
        // 스킨이 잠금 해제되었는지 확인
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
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
            PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1); // 잠금 해제된 것으로 표시
        }
        else
        {
            buttonText.text = ": " + skinInfo._skinPrice;
        }
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
            buttonText.color = new Color32(60, 155, 165, 255);
            staricon.gameObject.SetActive(false);
        }
        else
        {
            buttonText.text = "Star : " + skinInfo._skinPrice;
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
                // 총 별의 수에서 스킨 가격을 차감하고 스킨을 잠금 해제
                starManager.starCount -= skinInfo._skinPrice;
                staricon.gameObject.SetActive(false);
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                PlayerPrefs.Save();
                isSkinUnlocked = true;
                buttonText.text = "Equip";
            }
        }
    }
}
