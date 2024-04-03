//using Simple98;
using System.Collections;
using System.Collections.Generic;
//using UGS;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create new SKin")]
public class ShopItemSO : ScriptableObject
{
    //public void Initialize()
    //{
    //    UnityGoogleSheet.Load<Shop>();
    //}
    public enum SkinIDs { red, blue, green, orange, purple }
    [SerializeField] private SkinIDs skinID;
    public SkinIDs _skinID { get { return skinID; } }

    [SerializeField] private Sprite skinSprite;
    public Sprite _skinSprite { get { return skinSprite; } }

    [SerializeField] private int skinPrice;
    public int _skinPrice { get { return skinPrice; } }
}
