using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HpControll hpControll;

    private void Start()
    {
        hpControll = FindObjectOfType<HpControll>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            PlayerHealth.health--;
            hpControll.HpMinus();
            Debug.Log("Player health: " + PlayerHealth.health);
            if (PlayerHealth.health < 0)
            {
                Debug.Log("Gameover");
            }
        }
    }

}
