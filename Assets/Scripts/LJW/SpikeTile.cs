using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("플레이어 스파이크 닿음");
        if (other.CompareTag("Player"))
        {
            HealthSystem playerHealth = other.GetComponent<HealthSystem>();

            if (playerHealth != null)
            {
                playerHealth.health--;
                Debug.Log("Player health: " + playerHealth.health);
                if (playerHealth.health <= 0)
                {
                    Debug.Log("gameover");
                }
            }
        }
    }
}
