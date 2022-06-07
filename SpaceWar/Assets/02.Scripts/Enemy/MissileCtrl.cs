using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCtrl : MonoBehaviour
{
    public float speed; // 미사일 발사 속도
    
    public Vector3 moveDir; // 미사일의 이동치 변수

    public GameObject explodeEffect; // 미사일 폭발 이펙트를 받는 변수

    public AudioClip expClip; // 폭발할 때 때 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource audioSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.

        // 미사일의 모양이 기본으로 위를 향하고 있기 때문에 회전을 하면 transform.up이 앞을 향하게 된다.
        moveDir = transform.up * speed * Time.deltaTime; // 미사일이 앞으로 speed 속도로 이동하도록 한다.
    }

    void Update()
    {
        transform.Translate(moveDir, Space.World); // moveDir만큼 이동한다.
    }

    public void Explode() // 미사일이 폭발하는 함수 (플레이어가 미사일에 공격을 하거나 미사일이 플레이어에 맞으면 폭발한다.)
    {
        audioSrc.PlayOneShot(expClip, 0.2f); // 폭발할 때의 사운드(damageClip)를 0.2 볼륨으로 출력한다.

        Instantiate(explodeEffect, gameObject.transform); // 미사일의 위치에 폭발하는 이펙트를 생성한다.

        Destroy(gameObject, 1.0f); // 1.0초 위에 미사일을 제거한다.

        gameObject.GetComponent<MeshRenderer>().enabled = false; // 미사일의 MeshRenderer를 비활성화하여 화면에 미사일의 모습이 보이지 않도록 한다.
        gameObject.GetComponent<CapsuleCollider>().enabled = false; // 미사일의 CapsuleColliderr를 비활성화한다.

    }
}
