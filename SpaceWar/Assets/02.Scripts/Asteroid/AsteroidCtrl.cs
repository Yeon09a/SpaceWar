using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 소행성 컨트롤 스크립트
public class AsteroidCtrl : MonoBehaviour
{
    public float speed; // 소행성 속도

    public GameObject getEffect; // 소행성 파괴 이펙트를 받는 변수

    public AudioClip expClip; // 폭발할 때 때 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource audioSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Update()
    {
        audioSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.

        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World); // 월드 좌표계에서 transform.forward * speed * Time.delta만큼 이동한다.
    }

    public void Explode() // 소행성이 폭발하는 함수 (플레이어가 소행성에 공격을 하거나 소행성이 플레이어에 맞으면 폭발한다.)
    {
        audioSrc.PlayOneShot(expClip, 0.2f); // 폭발할 때의 사운드(damageClip)를 0.2 볼륨으로 출력한다.

        getEffect.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f); // getEffect가 그냥 생성되면 크기가 커지므로 localScale을 0.02, 0.02, 0.02로 설정한다.

        Instantiate(getEffect, gameObject.transform); // 소행성 위치에 폭발하는 이펙트를 생성한다.

        Destroy(gameObject, 1.0f); // 1.0초 위에 소행성을 제거한다.

        gameObject.GetComponent<MeshRenderer>().enabled = false; // 소행성의 MeshRenderer를 비활성화하여 화면에 미사일의 모습이 보이지 않도록 한다.
        gameObject.GetComponent<SphereCollider>().enabled = false; // 소행성의 CapsuleColliderr를 비활성화한다.
    }
}
