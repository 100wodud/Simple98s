using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private GameUIControll hpControll;
    private Popup_StageClear popup_StageClear;
    private CoinStar_UI coinStar_UI;
    [SerializeField] private AudioSource star;
    [SerializeField] private AudioSource clear;
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
                IsGameOver();
            }
        } 
        if(collision.transform.tag == "Clear")
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Debug.Log("Clear");
            IsClear();
            StarManager.Instance.SetStarsForStage(StageSelecter.selectStageIndex - 1, lv.star);
            StarManager.Instance.stageStarDataArray[StageSelecter.selectStageIndex - 1].isClear = true;
            popup_StageClear.UpdateStar(lv.star);
            coinStar_UI.UpdateAllStars();
            SaveStageJson.Instance.SaveStageData(StageSelecter.selectStageIndex, StarManager.Instance.stageStarDataArray[StageSelecter.selectStageIndex - 1]);
        }

        if (collision.tag == "Coin")
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Star")
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Destroy(collision.gameObject);
            star.Play();
            Debug.Log("star");
            lv.star++;
            coinStar_UI.UpdateStageStar(lv.star);
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
                IsGameOver();
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
            clear.Play();
            popup_StageClear = UIManager.Instance.ShowPopup<Popup_StageClear>();
            popup_StageClear.Initialize();
            popup_StageClear.UpdateStar(StageSelecter.selectStageIndex -1);
        }
    }

    private void IsGameOver()
    {
        if(SceneManager.GetActiveScene().name != "CustomStageScene")
        {
            PlayerHealth.health = 5;
            StarManager.Instance.SetStarsForStage(StageSelecter.selectStageIndex - 1, 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else
        {
            SceneLoader.Instance.GotoCustomMapListScene();
        }
    }
}