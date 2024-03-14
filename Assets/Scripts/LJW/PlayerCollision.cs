using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            HealthSystem.health--;
            if(HealthSystem.health < 0)
            {
                Debug.Log("Gameover");
            }
        }
    }

}
