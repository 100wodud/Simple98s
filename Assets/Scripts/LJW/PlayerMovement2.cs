using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up, Down, Left, Right
}

public class PlayerMovement2 : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public Direction movingDir;
    [SerializeField] bool movingHorizontally = false, canCheck = false;
    [SerializeField] LayerMask obstacleMask;
    public Transform surface;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (movingHorizontally)
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 2, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 2, obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
            }
        }
        else
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 2, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 2, obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
            }
        }
        if (canCheck)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    movingDir = Direction.Right;
                }
                else
                {
                    movingDir = Direction.Left;
                }
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                movingHorizontally = false;

                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    movingDir = Direction.Up;
                }
                else
                {
                    movingDir = Direction.Down;
                }
            }
        }
        RotateSurface();
    }

    private void RotateSurface()
    {
        switch (movingDir)
        {
            case Direction.Up:
                surface.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.Down:
                surface.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case Direction.Right:
                surface.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case Direction.Left:
                surface.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (movingDir)
        {
            case Direction.Up:
                rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                break;
            case Direction.Down:
                rb.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
                break;
            case Direction.Right:
                rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
                break;
            case Direction.Left:
                rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                break;
        }
    }
}
