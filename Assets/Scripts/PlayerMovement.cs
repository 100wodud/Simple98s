using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //�̵��ӵ�

    private bool _isMoveActive = true; // �̵� Ȱ��ȭ Ȯ��

    private enum MoveDirection { Left, Right, Up, Down } //�̵�����

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ű���� �Է¿� ���� �̵� ���� ����
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnMove(MoveDirection.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnMove(MoveDirection.Right);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            OnMove(MoveDirection.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            OnMove(MoveDirection.Down);
        }
    }

    // �̵����⿡ ���� ���� ��ȯ
    private Vector2 OnGetMoveDirection(MoveDirection direction)
    {
        Vector2 currentDirection = new Vector2();

        switch (direction)
        {
            case MoveDirection.Left:
                currentDirection = new Vector2(-1, 0);
                break;
            case MoveDirection.Right:
                currentDirection = new Vector2(1, 0);
                break;
            case MoveDirection.Up:
                currentDirection = new Vector2(0, 1);
                break;
            case MoveDirection.Down:
                currentDirection = new Vector2(0, -1);
                break;
        }

        return currentDirection;
    }

    //�÷��̾� �̵� �Լ�
    private void OnMove(MoveDirection moveDirection)
    {
        if (_isMoveActive == false)
            return;

        _isMoveActive = false; // �̵����� ���·� ����

        Vector2 currentMoveDirection = OnGetMoveDirection(moveDirection); //�̵����� ����

        _rigidbody2D.velocity = currentMoveDirection * _moveSpeed; // �ӵ� ����
    }

    // �浿 ���� �Լ�
    private void OnCollisionEnter2D(Collision2D other)
    {
        _isMoveActive = true; // �̵� Ȱ��ȭ ���·� ����
    }
}
