using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    Transform player;

    public float CameraSpeed = 5.0f;
    public Vector2 cameraLimit = new Vector2(26f, 3.3f);
    private Vector2 cameraLimit2;

    private void Start()
    {
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 targetPos;
        float clampedX = Mathf.Clamp(player.position.x, -cameraLimit.x, cameraLimit.x);
        float clampedY = Mathf.Clamp(player.position.y, -cameraLimit.y, cameraLimit.y);
        if (MapManager.Instance.maxX != -33)
        {
            cameraLimit2 = new Vector2(MapManager.Instance.maxX - 9, 3.3f);
            clampedX = Mathf.Clamp(player.position.x, -cameraLimit.x, cameraLimit2.x);
        }

        targetPos = new Vector3(clampedX, clampedY, -10f);

        transform.position = targetPos;
    }

}
