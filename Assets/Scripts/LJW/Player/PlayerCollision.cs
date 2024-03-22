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

        if (collision.tag == "Star")
        {
            LevelVariable lv = GameObject.FindGameObjectWithTag("LvGen").GetComponent<LevelVariable>();
            Destroy(collision.gameObject);
            lv.star++;
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
