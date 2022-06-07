using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 공격 스크립트
public class PlayerFireCtrl : MonoBehaviour
{
    public Transform middlePos; // Ray 발사 좌표, 중앙 발사
    public Transform leftPos; // 공격 이펙트 좌표, 왼쪽 발사
    public Transform rightPos; // 공격 이펙트 좌표, 오른쪽 발사

    public GameObject fireEffect; // 공격 이펙트 프리팹을 받을 변수

    private RaycastHit hit; // 레이캐스트 결괏값을 저장하기 위한 구조체 선언

    public AudioClip shotClip; // 플레이어가 공격할 때의 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource audioSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Update()
    {
        Debug.DrawRay(middlePos.position, middlePos.forward * 10.0f, Color.green); // Ray를 시각적으로 표시하기 위해 사용

        audioSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.
    }

    public void Shot() // 공격 함수
    {
        audioSrc.PlayOneShot(shotClip, 0.1f); // 플레이어가 공격할 때의 사운드(shotClip)를 0.1 볼륨으로 출력한다.

        GameObject effectL = Instantiate(fireEffect, leftPos.position, leftPos.rotation); // 왼쪽 공격을 발사했을 때의 이펙트를 leftPos 위치에 생성한다.
        GameObject effectR = Instantiate(fireEffect, rightPos.position, rightPos.rotation); // 오른쪽 공격을 발사했을 때의 이펙트를 rightPos 위치에 생성한다.
        effectL.transform.Rotate(0, 180, 0); // 왼쪽 이펙트의 위치를 맞추기 위해 y축 180도 회전시킨다.

        Destroy(effectL, 1.5f); // 1.5초 후에 이펙트를 삭제한다.
        Destroy(effectR, 1.5f); // 1.5초 후에 이펙트를 삭제한다.

        if (Physics.Raycast(middlePos.position, middlePos.forward, out hit, 15.0f, 1 << 8 | 1 << 10)) // Ray를 발사한다. ray는 middlePos 원점에서 앞으로 15.0f 거리만큼 발사하고 8번 레이어(Enemy 레이어), 10번 레이어(Item 레이어)에서 ray에 맞은 결과를 hit에 받는다.
        {
            hit.transform.GetComponent<EnemyCtrl>()?.OnDamage(hit.point); // ray를 맞은, 레이캐스트의 결괏괎이 EnemyCtrl 스크립트를 가지고 있으면 적의 EnemyCtrl 스크립트의 OnDamage() 함수를 호출한다. 매개변수로 ray를 맞은 지점을 넣는다.
                                                                          // 레이캐스트의 결괏괎이 EnemyCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.

            hit.transform.GetComponent<BossCtrl>()?.OnDamage(hit.point); // ray를 맞은, 레이캐스트의 결괏괎이 BossCtrl 스크립트를 가지고 있으면 보스의 BossCtrl 스크립트의 OnDamage() 함수를 호출한다. 매개변수로 ray를 맞은 지점을 넣는다.
                                                                         // 레이캐스트의 결괏괎이 BossCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.

            hit.transform.GetComponent<MissileCtrl>()?.Explode(); // ray를 맞은, 레이캐스트의 결괏괎이 MissileCtrl 스크립트를 가지고 있으면 적의 미사일의  MissileCtrl 스크립트의 Explode() 함수를 호출한다
                                                                  // 레이캐스트의 결괏괎이 MissileCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.

            hit.transform.GetComponent<BossBulletCtrl>()?.Explode(); // ray를 맞은, 레이캐스트의 결괏괎이 BossBulletCtrl 스크립트를 가지고 있으면 보스의 총알의 BossBulletCtrl 스크립트의 Explode() 함수를 호출한다
                                                                     // 레이캐스트의 결괏괎이 BossBulletCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.

            hit.transform.GetComponent<ItemCtrl>()?.getItem(); // ray를 맞은, 레이캐스트의 결괏괎이 ItemCtrl 스크립트를 가지고 있으면 아이템의 ItemCtrl 스크립트의 getItem() 함수를 호출한다
                                                               // 레이캐스트의 결괏괎이 ItemCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.

            hit.transform.GetComponent<AsteroidCtrl>()?.Explode(); // ray를 맞은, 레이캐스트의 결괏괎이 AsteroidCtrl 스크립트를 가지고 있으면 아이템의 AsteroidCtrl 스크립트의 Explode() 함수를 호출한다
                                                                   // 레이캐스트의 결괏괎이 AsteroidCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.
        }
    }
}
