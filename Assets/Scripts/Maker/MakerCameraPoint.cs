using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerCameraPoint : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * speed * Time.deltaTime;
    }
}
