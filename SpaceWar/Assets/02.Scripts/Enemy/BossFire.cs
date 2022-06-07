using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 보스 공격 스크립트
public class BossFire : MonoBehaviour
{
    public GameObject bullet; // 공격 프리팹을 받을 변수

    public Transform leftPos; // 공격 발사 좌표, 왼쪽 발사
    public Transform middlePos; // 공격 발사 좌표, 중앙 발사
    public Transform rightPos; // 공격 발사 좌표, 오른쪽 발사



    void Start()
    {
        InvokeRepeating("shot", 0, 5.0f); // 1초 뒤에 shot() 함수를 5초 간격으로 호출한다.(5초 간격으로 미사일을 생성한다.)
    }

    void shot() // 공격을 발사하는 함수.
    {
        GameObject bulletM = Instantiate(bullet, middlePos); // 중앙 공격을 middlePos 위치에 생성한다.
        bulletM.transform.SetParent(middlePos); // middlePos 중앙 공격(bulletM)의 부모 오브젝트로 설정한다.
        GameObject bulletL = Instantiate(bullet, leftPos); // 왼쪽 공격을 leftPos 위치에 생성한다.
        bulletL.transform.SetParent(leftPos); // leftPos을 왼쪽 공격(bulletL)의 부모 오브젝트로 설정한다.
        GameObject bulletR = Instantiate(bullet, rightPos); // 오른쪽 공격을 rightPos 위치에 생성한다.
        bulletR.transform.SetParent(rightPos); // rightPos 오른쪽 공격(bulletR)의 부모 오브젝트로 설정한다.

        Destroy(bulletM, 15); // 15초 뒤에 미사일 제거
        Destroy(bulletL, 15); // 15초 뒤에 미사일 제거
        Destroy(bulletR, 15); // 15초 뒤에 미사일 제거
    }

    public void StopShot() // 보스가 죽었을 때 공격을 멈추는 함수
    {
        CancelInvoke(); // 모든 invoke 함수 호출을 취소한다.
    }
}
