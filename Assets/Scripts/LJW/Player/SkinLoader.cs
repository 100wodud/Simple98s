using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSR;

    private void Awake()
    {
        playerSR.sprite = SkinManager.equippedSkin;
    }
}
