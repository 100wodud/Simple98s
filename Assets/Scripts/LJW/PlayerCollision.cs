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
    }
}
