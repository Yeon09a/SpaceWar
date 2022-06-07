using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 컨트롤 스크립트
public class ItemCtrl : MonoBehaviour
{
    public float speed; // 아이템 속도

    public Vector3 moveDir; // 아이템의 이동치 변수
    public float moveDis; // 아이템의 이동 한계 거리

    public GameObject getEffect; // 아이템 획득 이펙트를 받는 변수

    private GameObject player; // 플레이어를 가져오기 위한 변수. 가져온 플레이어를 넣기 위해 생성

    public AudioClip getClip; // 아이템을 얻을 때 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource audioSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // 태그 "Player"를 사용하여 player를 얻어온다.

        audioSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.

        // 아이템이 생성되면 처음에
        moveDir = player.transform.position - transform.position; // 플레이어의 위치(가고자하는 목표 지점)에서 자신(아이템)의 위치를 빼 방향 벡터를 구한다.
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > moveDis) // 플레이어와 아이템의 거리가 moveDis보다 클 때
        {
            Vector3 deltaPos = moveDir.normalized * speed * Time.deltaTime; // 한 프레임 아이템이 이동할 수 있는 이동치를 구한다. 모든 기기에서 동일한 속도로 이동하도록 Time.deltaTime을 곱한다.
            transform.Translate(deltaPos, Space.World); // 월드 좌표계에서 deltaPos만큼 이동한다.
        }
    }

    public void getItem() // 아이템을 획득하는 함수
    {
        audioSrc.PlayOneShot(getClip, 0.2f); // 아이템을 얻을 때의 사운드(getClip)를 0.2 볼륨으로 출력한다.

        Instantiate(getEffect, gameObject.transform); // 아이템의 위치에 폭발하는 이펙트를 생성한다.

        player.GetComponent<PlayerCtrl>().getHp(0.3f); // 플레이어의 PlayerCtrl 스크립트를 불러와 getHp을 호출하여 플레이어의 hp를 0.3 증가시킨다.

        Destroy(gameObject, 1.0f); // 1.0초 뒤에 아이템을 제거한다.

        gameObject.GetComponentsInChildren<MeshRenderer>()[0].enabled = false; // 아이템의 MeshRenderer를 비활성화하여 화면에 미사일의 모습이 보이지 않도록 한다.
        gameObject.GetComponentsInChildren<MeshRenderer>()[1].enabled = false; // 아이템의 MeshRenderer를 비활성화하여 화면에 미사일의 모습이 보이지 않도록 한다.
        gameObject.GetComponentInChildren<SphereCollider>().enabled = false; // 아이템의 SphereCollider를 비활성화한다.
    }
}
