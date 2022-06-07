using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 적 공격 스크립트
public class EnemyFire : MonoBehaviour
{
    public GameObject missile; // 미사일 프리팹을 받을 변수

    public Transform leftPos; // 미사일 발사 좌표, 왼쪽 발사
    public Transform rightPos; // 미사일 발사 좌표, 오른쪽 발사

    public GameObject missileL; // 왼쪽 미사일
    public GameObject missileR; // 오른쪽 미사일

    void Start()
    {
        InvokeRepeating("shot", 1, 10.0f); // 1초 뒤에 shot() 함수를 10초 간격으로 호출한다.(10초 간격으로 미사일을 생성한다.)
    }

    private void Update()
    {
        Debug.DrawRay(leftPos.position, leftPos.up * 10.0f, Color.green); // Ray를 시각적으로 표시하기 위해 사용
        Debug.DrawRay(rightPos.position, rightPos.up * 10.0f, Color.green); // Ray를 시각적으로 표시하기 위해 사용
    }

    void shot() // 미사일을 발사하는 함수.
    {
        missileL = Instantiate(missile, leftPos.position, leftPos.rotation); // 왼쪽 미사일을 leftPos 위치에 생성한다.
        missileL.transform.SetParent(leftPos); // leftPos을 왼쪽 미사일(missileL)의 부모 오브젝트로 설정한다.
        missileR = Instantiate(missile, rightPos.position, rightPos.rotation); // 오른쪽 미사일을 rightPos 위치에 생성한다.
        missileR.transform.SetParent(rightPos); // rightPos 오른쪽 미사일(missileR)의 부모 오브젝트로 설정한다.

        Destroy(missileL, 20); // 20초 뒤에 미사일 제거
        Destroy(missileR, 20); // 20초 뒤에 미사일 제거
    }
}
