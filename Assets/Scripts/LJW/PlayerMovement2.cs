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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (movingHorizontally)
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1, obstacleMask))
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
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1, obstacleMask))
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
