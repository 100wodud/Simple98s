using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using System;
using TMPro;

public class Health_UI : UIPopup
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private int _maxHp;

    private Color yellow = new Color32(255, 216, 85, 255);
    private Color orange = new Color32(255, 137, 62, 255);
    private Color red = new Color32(255, 90, 90, 255);

    public void Initialize() //�ʱ�ȭ �޼���
    {
        Refresh();
    }

    private void Refresh()
    {
        _maxHp = 5;
        PlayerHealth.health = _maxHp;
    }
    public void Damage()  //ü��Ǯ�̰ų� 0���ϸ� ����
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
    public void HpImage(int hp)  //ü�� ����� �̹��� ���
    {
        if(hp == 1)
        {
            _hpText.color = red;
        }
        else if(hp == 2)
        {
            _hpText.color = orange;
        }
        else if(hp == 3)
        {
            _hpText.color = yellow;
        }
        _hpText.text = hp.ToString();
        
    }

}

