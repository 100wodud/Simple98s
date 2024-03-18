using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTiles : MonoBehaviour
{
    public GameObject Needle;
    Vector3 pos; //������ġ
    float delta = 0.25f; // ��(��)�� �̵������� (y)�ִ밪
    float speed = 1.0f; // �̵��ӵ�
    private float yStartPosition; // ������ġ




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
