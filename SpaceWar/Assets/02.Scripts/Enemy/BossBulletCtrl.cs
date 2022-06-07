using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 보스 총알 스크립트
public class BossBulletCtrl : MonoBehaviour
{
    public float speed; // 공격 속도

    public Vector3 moveDir; // 공격의 이동치 변수

    public GameObject explodeEffect; // 공격 폭발 이펙트를 받는 변수

    private GameObject player; // 플레이어를 가져오기 위한 변수. 가져온 플레이어를 넣기 위해 생성

    public AudioClip expClip; // 폭발할 때 때 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource audioSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.

        player = GameObject.FindGameObjectWithTag("Player"); // 태그 "Player"를 사용하여 player를 얻어온다.

        // 공격이 생성되면 처음에
        moveDir = player.transform.position - transform.position; // 플레이어의 위치(가고자하는 목표 지점)에서 자신(적)의 위치를 빼 방향 벡터를 구한다.

        transform.LookAt(player.transform.position); // 공격이 플레이어를 향하도록 한다.
    }

    void Update()
    {
        Vector3 deltaPos = moveDir.normalized * speed * Time.deltaTime; // 한 프레임 공격이 이동할 수 있는 이동치를 구한다. 모든 기기에서 동일한 속도로 이동하도록 Time.deltaTime을 곱한다.
        transform.Translate(deltaPos, Space.World); // 월드 좌표계에서 deltaPos만큼 이동한다.
    }

    public void Explode() // 공격이 폭발하는 함수 (플레이어가 총알에 공격을 하거나 총알이 플레이어에 맞으면 폭발한다.)
    {
        audioSrc.PlayOneShot(expClip, 0.2f); // 폭발할 때의 사운드(damageClip)를 0.2 볼륨으로 출력한다.

        Instantiate(explodeEffect, gameObject.transform); // 총알 위치에 폭발하는 이펙트를 생성한다.

        Destroy(gameObject, 1.0f); // 1.0초 위에 미사일을 제거한다.

        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false; // 미사일의 MeshRenderer를 비활성화하여 화면에 미사일의 모습이 보이지 않도록 한다.
        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false; // 미사일의 CapsuleColliderr를 비활성화한다.
    }
}
