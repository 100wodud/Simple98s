using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    Transform player;

    public float CameraSpeed = 5.0f;
    public Vector2 cameraLimit = new Vector2(26f, 3.3f);

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 targetPos;

        float clampedX = Mathf.Clamp(player.position.x, -cameraLimit.x, cameraLimit.x);
        float clampedY = Mathf.Clamp(player.position.y, -cameraLimit.y, cameraLimit.y);

        targetPos = new Vector3(clampedX, clampedY, -10f);

        transform.position = targetPos;
    }

}
