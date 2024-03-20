using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameUIControll hpControll;

    private void Start()
    {
        hpControll = FindObjectOfType<GameUIControll>();
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
        }

        if (collision.tag == "Coin")
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Destroy(collision.gameObject);
            lv.coin++;
        }

        if (collision.CompareTag("Star1") || collision.CompareTag("Star2") || collision.CompareTag("Star3"))
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Destroy(collision.gameObject);
            lv.coin += 10;
            if (collision.CompareTag("Star1"))
                lv.star1 = true;
            else if (collision.CompareTag("Star2"))
                lv.star2 = true;
            else if (collision.CompareTag("Star3"))
                lv.star3 = true;
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
}
