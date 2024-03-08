using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private enum MoveDirection { Left, Right, Up, Down }

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private Vector2 OnGetMoveDirection(MoveDirection direction)
    {
        Vector2 currentDirection = new Vector2();

        switch (direction)
        {
            case MoveDirection.Left:
                currentDirection = new Vector2(1, 0);
                break;
            case MoveDirection.Right:
                currentDirection = new Vector2(0, 1);
                break;
            case MoveDirection.Up:
                currentDirection = new Vector2(1, 0);
                break;
            case MoveDirection.Down:
                currentDirection = new Vector2(0, 1);
                break;
        }

        return currentDirection;
    }

    private void OnMove(MoveDirection moveDirection)
    {
        Vector2 currentMoveDirection = OnGetMoveDirection(moveDirection);

        _rigidbody2D.velocity = currentMoveDirection * _moveSpeed;
    }
}
