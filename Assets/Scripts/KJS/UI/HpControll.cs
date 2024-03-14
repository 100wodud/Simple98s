using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpControll : MonoBehaviour
{
    private Health_UI hp;

    public void Start()
    {
        SommonHp();
    }
    private void SommonHp()
    {
        if(hp != null)
        {
            return;
        }
        else
        {
            hp = UIManager.Instance.ShowPopup<Health_UI>();
            hp.Initialize();
        }
    }
    public void HpPlus()
    {
        if (hp == null)
        {
            Debug.LogWarning("hp is not initialized.");
            return;
        }
        PlayerHealth.health++;
        Debug.Log(PlayerHealth.health);
        hp.Damage();
    }

    public void HpMinus()
    {
        if (hp == null)
        {
            Debug.LogWarning("hp is not initialized.");
            return;
        }
        hp.Damage();
    }


}
