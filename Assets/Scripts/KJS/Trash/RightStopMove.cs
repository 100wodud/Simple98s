using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine;

public class RightStopMove : MonoBehaviour
{
    private Collider2D myCollider;
    [SerializeField] private bool isColliding = false;
    private bool isCall = true;
    private Transform playerTransform;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isCall == false)
        {
            if (transform.position.x < playerTransform.position.x && isColliding == false)
            {
                StartCollider();
                isColliding = true;
            }
            else if (transform.position.x > playerTransform.position.x && isColliding == true)
            {
                StartCollider();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.x < playerTransform.position.x)
        {
            StopCollider();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            StopCollider();
            isColliding = false;
        }
    }

    private void StartCollider()
    {
        Debug.Log("오른벽 콜라이더 활성화");
        myCollider.enabled = true;
        isCall = true;
    }

    private void StopCollider()
    {
        Debug.Log("오른벽 콜라이더 비활성화");
        myCollider.enabled = false;
        isCall = false;
    }
}
