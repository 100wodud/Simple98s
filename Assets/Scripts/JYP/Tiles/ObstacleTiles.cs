using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTiles : MonoBehaviour
{
    public GameObject Needle;
    Vector3 pos; //현재위치
    float delta = 0.25f; // 좌(우)로 이동가능한 (y)최대값
    float speed = 1.0f; // 이동속도
    private float yStartPosition; // 시작위치




    void Awake()
    {
        pos = transform.position;
        yStartPosition = Needle.transform.position.y;
    }

    void Update()
    {
        Vector3 vector = pos;
        vector.y = yStartPosition + delta * Mathf.Sin(Time.time * speed);
        Needle.transform.position = vector;
    }
}
