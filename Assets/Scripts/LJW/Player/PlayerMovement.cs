using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //이동속도

    private bool _isMoveActive = true; // 이동 활성화 확인

    private enum MoveDirection { Left, Right, Up, Down } //이동방향

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 키보도 입력에 따른 이동 방향 결정
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

    // 이동방향에 따른 벡터 변환
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

    //플레이어 이동 함수
    private void OnMove(MoveDirection moveDirection)
    {
        if (_isMoveActive == false)
            return;

        _isMoveActive = false; // 이동중인 상태로 변경

        Vector2 currentMoveDirection = OnGetMoveDirection(moveDirection); //이동방향 결정

        _rigidbody2D.velocity = currentMoveDirection * _moveSpeed; // 속도 적용
    }

    // 충동 감지 함수
    private void OnCollisionEnter2D(Collision2D other)
    {
        _isMoveActive = true; // 이동 활성화 상태로 변경
    }
}
