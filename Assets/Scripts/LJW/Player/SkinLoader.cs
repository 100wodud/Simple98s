using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSR;

    private void Awake()
    {
        if (SkinManager.equippedSkin == null)
            return;

        playerSR.sprite = SkinManager.equippedSkin;
    }
}
