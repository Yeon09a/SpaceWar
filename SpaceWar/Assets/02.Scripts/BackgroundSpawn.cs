using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 배경 스크립트

public class BackgroundSpawn : MonoBehaviour
{
    public List<GameObject> objects; //배경 오브젝트 프리팹 리스트
    private GameObject[] spaceSpawnPoints; // 배경 오브젝트 스폰 위치 배열

    public int startNum; // 배경 배열 시작 정수. 배경을 랜덤으로 넣기 위해 spaceSpawnPoints의 시작 위치를 랜덤으로 한다.

    void Start()
    {
        spaceSpawnPoints = GameObject.FindGameObjectsWithTag("SpaceSpawnPoint"); // 적 스폰 위치 배열(spaceSpawnPoints) 설정. 태그가 SpaceSpawnPoint인 오브젝트들을 찾아 spaceSpawnPoints 배열에 넣는다.
        startNum = Random.Range(0, spaceSpawnPoints.Length); // 배경의 오브젝트를 랜덤으로 넣기 위해 시작 정수를 랜덤으로 구한다.

        // 원형제어 
        for (int i = 0; i < 4; i++) // 배경 오브젝트가 4개 이므로 4번 반복한다.
        {
            Transform spawnPoint = spaceSpawnPoints[startNum % spaceSpawnPoints.Length].transform; // 원형 제어를 하여 spaceSpawnPoints에서 startNum의 위치를 가져온다.
            int size = objects.Count; // 오브젝트 리스트의 크기를 구한다.
            int num = Random.Range(0, size); // 몇 번 오브젝트를 넣을 지 랜덤으로 선택한다.
            GameObject obj = objects[num];// 생성할 num번째 오브젝트를 리스트에서 선택한다.
            Instantiate(obj, obj.transform.position + spawnPoint.position, Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), Random.Range(-20, 20))); // 배경 오브젝트를 오브젝트의 position + spawnPoint 위치에 랜덤 각도로 생성한다.
            startNum += 4; // 오브젝트들이 겹치지 않기 위해 4칸 떨어져서 다음 오브젝트를 생성하도록 한다.
            objects.RemoveAt(num);// 이미 생성한 오브젝트는 오브젝트 리스트에서 제외한다.
        }
    }
}
