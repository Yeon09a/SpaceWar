using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 소행성 스폰 스크립트
public class AsteroidSpawn : MonoBehaviour
{
    public GameObject[] asteroids; // 소행성 배열 프리팹을 받는 변수 

    private GameObject[] asteroidSpawnPoints; // 소행성 스폰 위치 배열

    private Transform playertr; // 플레이어 Transform을 받는 변수

    void Start()
    {
        asteroidSpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint"); // 소행성 스폰 위치 배열(asteroidSpawnPoints) 설정. 태그가 EnemySpawnPoint 오브젝트들을 찾아 asteroidSpawnPoints 배열에 넣는다.
        playertr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // 태그 Player로 Player 오브젝트를 찾아 Transform을 얻어온다.

        InvokeRepeating("Spawn", 1.0f, 7.0f); // 1초 후 ShowSpawn() 함수를 7초마다 호출한다. (소행성을 7초마다 생성한다.)
    }

    // 소행성 스폰 함수
    void Spawn() // 소행성 스폰 함수
    {
        int size = asteroidSpawnPoints.Length; // 소행성 스폰 위치 배열(asteroidSpawnPoints)의 길이를 구해 size에 넣는다.
        Vector3 randPos = asteroidSpawnPoints[Random.Range(0, size)].transform.position; // 소행성 생성 위치 변수. 소행성 스폰 위치 배열(asteroidSpawnPoints) 중 한 위치를 랜덤으로 골라 randPos에 넣는다
        randPos.y = Random.Range(-5.0f, 3.0f); // 적 생성 위치의 y 범위를 -5.0f ~ 5.0f로 설정한다.

        GameObject obj = Instantiate(asteroids[Random.Range(0, asteroids.Length)]); // 소행성 배열 중 하나를 랜덤으로 생성한다.

        obj.transform.position = playertr.position + randPos; // 플레이어가 있는 위치를 기준으로 하여 소행성 생성 위치를 더해 소행성의 위치를 설정한다. 플레이어를 기준으로 상대적인 위치로 두어 항상 플레이어 주변에서 소행성이 생성되도록 한다. 

        Destroy(obj, 15.0f); // 15초 뒤 소행성을 삭제한다.
    }
}
