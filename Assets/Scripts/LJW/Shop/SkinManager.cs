using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static Sprite equippedSkin;

    public ShopItemSO[] allskins;

    public void Awake()
    {
        string lastSkinused = PlayerPrefs.GetString("skinPref", "");
        if (!string.IsNullOrEmpty(lastSkinused))
        {
            foreach (ShopItemSO item in allskins)
            {
                if (item.skinID.ToString() == lastSkinused)
                {
                    EquipSkin(item);
                    break;
                }
            }
        }
    }

    public void EquipSkin(ShopItemSO shopItemSO)
    {
        equippedSkin = shopItemSO.playerSkin;
    }
}
