using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    Transform player;

    public float CameraSpeed = 5.0f;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 targetPos;
        if (player.position.y >= 3)
        {
            targetPos = new Vector3(player.position.x, 3f, -10f);
        } else if(player.position.y <= -3)
        {
            targetPos = new Vector3(player.position.x, -3f, -10f);
        } else
        {
            targetPos = new Vector3(player.position.x, player.position.y, -10f);
        }

        transform.position = targetPos;
    }

}
