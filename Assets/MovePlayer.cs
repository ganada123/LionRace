using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;  // 이동 속도
    public float xLimit = 7.5f;   // x좌표 이동 제한

    private void Update()
    {
        // 방향키나 WASD로 이동
        float moveX = Input.GetAxis("Horizontal");  // A/D 또는 방향키로 x축 이동
        Vector3 moveDirection = new Vector3(moveX, 0, 0) * moveSpeed * Time.deltaTime;
        
        // 현재 위치 계산
        Vector3 newPosition = transform.position + moveDirection;

        // x 좌표 범위 제한
        if (newPosition.x < -xLimit)
        {
            newPosition.x = -xLimit;  // x 좌표가 -7.5보다 작으면 -7.5로 설정
        }
        else if (newPosition.x > xLimit)
        {
            newPosition.x = xLimit;  // x 좌표가 7.5보다 크면 7.5로 설정
        }

        // 새로운 위치로 이동
        transform.position = newPosition;
    }
}
