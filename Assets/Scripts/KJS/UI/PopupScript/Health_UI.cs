using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Health_UI : UIPopup
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private int _maxHp;
    [SerializeField] private SpriteAtlas _heartSprite;

    public void Initialize() //초기화 메서드
    {
        Refresh();
    }

    private void Refresh()
    {
        _heartSprite = Resources.Load<SpriteAtlas>("Sprites/HP");
        _maxHp = hearts.Length;
        PlayerHealth.health = _maxHp;
    }
    public void Damage()  //체력풀이거나 0이하면 고정
    {
        if (PlayerHealth.health > _maxHp)
        {
            PlayerHealth.health = _maxHp;
        }
        if(PlayerHealth.health < 0)
        {
            PlayerHealth.health = 0;
        }

        HpImage(PlayerHealth.health);
    }
    public void HpImage(int hp)  //체력 계산후 이미지 출력
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < PlayerHealth.health)
            {
                hearts[i].sprite = GetSprite("Heart_Full");
            }
            else
            {
                hearts[i].sprite = GetSprite("Heart_Empty");
            }
            if (i < _maxHp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private Sprite GetSprite(string name)
    {
        return _heartSprite.GetSprite(name);
    }
}

