using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적 스폰 스크립트
public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies; // 적 프리팹 배열
    public GameObject boss; // 보스 프리팹을 받는 변수

    public GameObject portal; // 포탈 프리팹
    public GameObject bossPortal; // 보스 포탈 프리팹

    private int count; // 적 종류 수

    private Transform playertr; // 플레이어 Transform을 받는 변수

    private GameObject[] enemySpawnPoints; // 적 스폰 위치 배열

    public int countEnemy = 15; // 생성해야하는 적의 수
    


    void Start()
    {
        count = enemies.Length; // 적 종류 수 초기화

        enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint"); // 적 스폰 위치 배열(enemySpawnPoints) 설정. 태그가 EnemySpawnPoint인 오브젝트들을 찾아 enemySpawnPoints 배열에 넣는다.
        playertr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // 태그 Player로 Player 오브젝트를 찾아 Transform을 얻어온다.

        InvokeRepeating("ShowSpawn", 1.0f, 7.0f); // 1초 후 ShowSpawn() 함수를 7초마다 호출한다. (적을 7초마다 생성한다.)
    }


    // 적 스폰 함수
    IEnumerator Spawn() // 적 스폰 함수
    {
        if (countEnemy > 0) // 생성해야 할 적이 남은 경우 (countEnemy이 0보다 클 경우)
        {
            GameObject portalObj = Instantiate(portal); // 포탈을 생성한다.

            int size = enemySpawnPoints.Length; // 적 스폰 위치 배열(enemySpawnPoints)의 길이를 구해 size에 넣는다.
            Vector3 randPos = enemySpawnPoints[Random.Range(1, size)].transform.position; // 적 생성 위치 변수. 적 스폰 위치 배열(enemySpawnPoints) 중 1번 부터 한 위치를 랜덤으로 골라 randPos에 넣는다
            randPos.y = Random.Range(-6.0f, 6.0f); // 적 생성 위치의 y 범위를 -6.0f ~ 6.0f로 설정한다.

            portalObj.transform.position = playertr.position + randPos; // 플레이어가 있는 위치를 기준으로 하여 포탈 생성 위치를 더해 포탈의 위치를 설정한다. 플레이어를 기준으로 상대적인 위치로 두어 항상 플레이어 주변에서 포탈이 생성되도록 한다. 

            yield return new WaitForSeconds(1.0f); // 1초 delay를 한다.

            Destroy(portalObj, 3.0f); // 3초 뒤 포탈을 삭제한다.

            GameObject obj = Instantiate(enemies[Random.Range(0, count)]); // 적 생성. 적 배열(enemies)의 적 중 하나를 랜덤으로 생성한다.

            obj.transform.position = playertr.position + randPos; // 플레이어가 있는 위치를 기준으로 하여 적 생성 위치를 더해 적의 위치를 설정한다. 플레이어를 기준으로 상대적인 위치로 두어 항상 플레이어 주변에서 적이 생성되도록 한다. 

            countEnemy--; // 적을 하나 생성했으므로 countEnemy--을 하여 생성할 적의 수를 하나 줄인다.
        }
        else // 적을 모두 생성하면(countEnemy이 0일 경우)
        {
            // 보스 생성
            GameObject bossPortalObj = Instantiate(bossPortal); // 포탈을 생성한다.

            Vector3 randPos = enemySpawnPoints[0].transform.position; // 보스 생성 위치 변수. 적 스폰 위치 배열(enemySpawnPoints) 중 0번 위치에서 randPos에 넣는다.
            randPos.y += 0.5f; // y위치를 0.5 올려준다.

            bossPortalObj.transform.position = playertr.position + randPos; // 플레이어가 있는 위치를 기준으로 하여 포탈 생성 위치를 더해 포탈의 위치를 설정한다. 플레이어를 기준으로 상대적인 위치로 두어 항상 플레이어 주변에서 포탈이 생성되도록 한다. 

            yield return new WaitForSeconds(1.0f); // 1초 delay를 한다.

            Destroy(bossPortalObj, 3.0f); // 3초 뒤 포탈을 삭제한다.

            GameObject obj = Instantiate(boss); // 보스를 생성한다.

            obj.transform.position = playertr.position + randPos; // 플레이어가 있는 위치를 기준으로 하여 적 생성 위치를 더해 적의 위치를 설정한다. 플레이어를 기준으로 상대적인 위치로 두어 항상 플레이어 주변에서 적이 생성되도록 한다. 

            CancelInvoke(); // 모든 invoke 함수 호출을 취소한다.
        }
        
    }

    void ShowSpawn() // 스폰한 포탈과 적을 보여주는 함수.
    {
        StartCoroutine(Spawn()); // 코루틴 함수 Spawn()을 호출한다.
    }
}
