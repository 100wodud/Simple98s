using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObsCollision : MonoBehaviour
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
        if (collision.transform.tag == "RandomObstacle")
        {
            int num = Random.Range(-1, 1);
            PlayerHealth.health += num;
            Debug.Log("Player health: " + PlayerHealth.health);
            Debug.Log(num);

            switch (num)
            {
                case -1:
                    hpControll.HpMinus();
                    if (PlayerHealth.health <= 0)
                    {
                        IsGameOver();
                    }
                    break;
                case 0:
                    break;
            }

        } else if (collision.transform.tag == "DeathObstacle")
        {
            IsGameOver();
        } else if(collision.transform.tag == "StopObstacle")
        {
            PlayerHealth.health--;
            hpControll.HpMinus();
            Debug.Log("Player health: " + PlayerHealth.health);
            if (PlayerHealth.health <= 0)
            {
                IsGameOver();
            }
        }

    }

    private void IsGameOver()
    {
        PlayerHealth.health = 5;
        StarManager.Instance.SetStarsForStage(StageSelecter.selectStageIndex - 1, 0);
        coinStar_UI.UpdateCoin(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}