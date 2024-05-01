using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIControll : MonoBehaviour
{
    private Health_UI _hp;
    private Popup_PauseBtn _pause;
    private CoinStar_UI coinStar_UI;
    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogWarning("Animator component not found on the GameObject.");
        }
        if (SceneManager.GetActiveScene().name == "StageScene")
        {
            SpawnHp();
            coinStar_UI = FindObjectOfType<CoinStar_UI>();
            CoinUI();
            SpawnPauseBtn();
        }
        else if (SceneManager.GetActiveScene().name == "CustomStageScene")
        {
            SpawnHp();
            SpawnPauseBtn();
        }
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
            coinStar_UI.UpdateAllStars();
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

    [SerializeField] private AudioSource player_Hit;
    public void HpMinus()  //체력감소하면 Damage 불러오기
    {
        if (_hp == null)
        {
            Debug.LogWarning("hp is not initialized.");
            return;
        }

        _hp.Damage();
        
        if (anim != null)
        {
            anim.SetBool("isDamaged", true);
            player_Hit.Play();
            StartCoroutine(ResetDamageAnimation());
        }
    }

    private IEnumerator ResetDamageAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isDamaged", false);
    }

}
