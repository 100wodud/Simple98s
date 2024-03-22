using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using TMPro;

public class GameUIControll : MonoBehaviour
{
    [SerializeField] private int _coin = 0;
    private Health_UI _hp;
    private Popup_PauseBtn _pause;
    private CoinStar_UI coinStar_UI;


    public void Start()
    {
        SpawnHp();
        coinStar_UI = FindObjectOfType<CoinStar_UI>();
        CoinUI();
        SpawnPauseBtn();
    }
    private void CoinUI()
    {
        if (coinStar_UI != null)
        {
            return;
        }
        else
        {
            coinStar_UI = UIManager.Instance.ShowPopup<CoinStar_UI>();
            coinStar_UI.Initialize();
            coinStar_UI.UpdateCoin(_coin);
            coinStar_UI.UpdateStars();
        }
    }

    private void SpawnPauseBtn() //일시정지메뉴
    {
        if(_pause != null)
        {
            return;
        }
        else
        {
            _pause = UIManager.Instance.ShowPopup<Popup_PauseBtn>();
            _pause.Initialize();
        }
    }
            
    private void SpawnHp() //HpUI소환
    {
        if(_hp != null)
        {
            return;
        }
        else
        {
            _hp = UIManager.Instance.ShowPopup<Health_UI>();
            _hp.Initialize();
        }
    }
    public void HpPlus()
    {
        if (_hp == null)
        {
            Debug.LogWarning("hp is not initialized.");
            return;
        }
        PlayerHealth.health++;
        Debug.Log(PlayerHealth.health);
        _hp.Damage();
    }

    public void HpMinus()  //체력감소하면 Damage 불러오기
    {
        if (_hp == null)
        {
            Debug.LogWarning("hp is not initialized.");
            return;
        }
        _hp.Damage();
    }


}
