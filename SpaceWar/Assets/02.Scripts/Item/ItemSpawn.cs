using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 스폰 스크립트
public class ItemSpawn : MonoBehaviour
{
    public GameObject item; // 아이템 프리팹을 받는 변수 

    public GameObject portal; // 포탈 프리팹

    private GameObject[] itemSpawnPoints; // 아이템 스폰 위치 배열

    private Transform playertr; // 플레이어 Transform을 받는 변수

    void Start()
    {
        itemSpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint"); // 아이템 스폰 위치 배열(itemSpawnPoints) 설정. 태그가 EnemySpawnPoint인 오브젝트들을 찾아 itemSpawnPoints 배열에 넣는다.
        playertr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // 태그 Player로 Player 오브젝트를 찾아 Transform을 얻어온다.

        InvokeRepeating("ShowSpawn", 10.0f, 10.0f); // 10초 후 ShowSpawn() 함수를 10초마다 호출한다. (아이템을 10초마다 생성한다.)
    }

    // 아이템 스폰 함수
    IEnumerator Spawn() // 아이템 스폰 함수
    {
        GameObject portalObj = Instantiate(portal); // 포탈을 생성한다.

        int size = itemSpawnPoints.Length; // 아이템 스폰 위치 배열(itemSpawnPoints)의 길이를 구해 size에 넣는다.
        Vector3 randPos = itemSpawnPoints[Random.Range(0, size)].transform.position; // 아이템 생성 위치 변수. 아이템 스폰 위치 배열(itemSpawnPoints) 중 한 위치를 랜덤으로 골라 randPos에 넣는다
        randPos.y = Random.Range(-3.0f, 3.0f); // 적 생성 위치의 y 범위를 -3.0f ~ 3.0f로 설정한다.

        portalObj.transform.position = playertr.position + randPos; // 플레이어가 있는 위치를 기준으로 하여 포탈 생성 위치를 더해 포탈의 위치를 설정한다. 플레이어를 기준으로 상대적인 위치로 두어 항상 플레이어 주변에서 포탈이 생성되도록 한다. 

        yield return new WaitForSeconds(1.0f); // 1초 delay를 한다.

        Destroy(portalObj, 3.0f); // 3초 뒤 포탈을 삭제한다.

        GameObject obj = Instantiate(item); // 아이템을 생성한다.

        obj.transform.position = playertr.position + randPos; // 플레이어가 있는 위치를 기준으로 하여 아이템 생성 위치를 더해 아이템의 위치를 설정한다. 플레이어를 기준으로 상대적인 위치로 두어 항상 플레이어 주변에서 아이템이 생성되도록 한다. 

        Destroy(obj, 10.0f); // 10초 뒤 아이템을 삭제한다.
    }

    void ShowSpawn() // 스폰한 포탈과 적을 보여주는 함수.
    {
        StartCoroutine(Spawn()); // 코루틴 함수 Spawn()을 호출한다.
    }
}
