using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameUIControll hpControll;
    private Popup_StageClear popup_StageClear;
    private CoinStar_UI coinStar_UI;

    private void Start()
    {
        hpControll = FindObjectOfType<GameUIControll>();
        coinStar_UI = FindObjectOfType<CoinStar_UI>();
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            PlayerHealth.health--;
            hpControll.HpMinus();
            Debug.Log("Player health: " + PlayerHealth.health);
            if (PlayerHealth.health <= 0)
            {
                Debug.Log("Gameover");
            }
        }
        else if(collision.transform.tag == "Clear")
        {
            Debug.Log("Clear");
            IsClear();
        }

        if (collision.tag == "Coin")
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Destroy(collision.gameObject);
            lv.coin++;
            coinStar_UI.UpdateCoin(lv.coin);
        }

        if (collision.tag == "Star")
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Destroy(collision.gameObject);
            lv.star++;
            coinStar_UI.SetStarsForStage(StageManager.Instance.stageindex-1, lv.star);
            coinStar_UI.UpdateStars();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            PlayerHealth.health--;
            hpControll.HpMinus();
            Debug.Log("Player health: " + PlayerHealth.health);
            if (PlayerHealth.health <= 0)
            {
                Debug.Log("Gameover");
            }
        }
    }

    private void IsClear()
    {
        if (popup_StageClear != null)
        {
            return;
        }
        else
        {
            popup_StageClear = UIManager.Instance.ShowPopup<Popup_StageClear>();
            popup_StageClear.Initialize();
            popup_StageClear.UpdateStar(StageManager.Instance.stageindex-1);
        }
    }
}
