using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    public float CameraSpeed = 5.0f;

    private void Update()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, -10f);
        transform.position = targetPos;
    }

}
