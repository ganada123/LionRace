using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // 생성할 오브젝트 프리팹 배열
    public Transform spawnPoint;       // 생성 위치
    public float spawnInterval = 2f;   // 생성 간격 (초)
    public float fallSpeed = 5f;       // 떨어지는 속도

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval); // 일정 시간 대기
        }
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], spawnPoint.position, Quaternion.identity);

        if (spawnedObject.GetComponent<FallingObject>() == null)
        {
            FallingObject fallingScript = spawnedObject.AddComponent<FallingObject>();
            fallingScript.fallSpeed = fallSpeed;
        }
    }
}
