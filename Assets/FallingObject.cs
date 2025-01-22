using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 5f; // 떨어지는 속도
    public float destroyZ = -16f; // Z 좌표 기준으로 오브젝트 삭제

    void Update()
    {
        // Z축 방향으로 이동
        transform.Translate(0, 0, -fallSpeed * Time.deltaTime);

        // Z좌표가 destroyZ보다 작으면 오브젝트 삭제
        if (transform.position.z <= destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
