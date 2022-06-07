using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCtrl : MonoBehaviour
{
    public float speed; // 보스가 이동하는 속도
    public Vector3 moveDir; // 보스의 이동 방향
    public float moveDis = 18; // 보스의 이동 한계 거리
    private int updownMove = 0; // 보스의 위아래 이동 한계 거리
    private bool isUp = true; // 보스의 위아래 이동 제어 변수

    public GameObject damageEffect; // 데미지를 받았을 때의 이펙트 프리팹을 받는 변수
    public GameObject deadEffect; // 보스가 사망할 때의 이펙트 프리팹을 받는 변수

    public Transform expPos; // 사망할 때의 이펙트 좌표

    public Image hpBar; // 보스의 체력바
    public float damageRate; // hp를 얼마의 비율로 깎을지에 대한 변수

    private GameObject player; // 플레이어를 가져오기 위한 변수. 가져온 플레이어를 넣기 위해 생성

    public GameObject playPanel; // UI의 PlayPanel을 받아올 변수로 후에 Pause 버튼을 눌렀을 때 playPanel이 안보이게 하기 위해 필요하다.
    public GameObject ClearPanel; // UI의 ClearPanel을 받아올 변수로 플레이어가 보스를 해치우면 등장한다.

    public AudioClip damageClip; // 공격 받을 때 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    public AudioClip expClip; // 폭발할 때 때 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource audioSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.

        player = GameObject.FindGameObjectWithTag("Player"); // 태그 "Player"를 사용하여 player를 얻어온다.

        // 비활성화된 오브젝트를 UI Panel을 찾기 위해
        playPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject; // Canvas를 먼저 찾고 getChild를 사용하여 playPanel을 찾는다.
        ClearPanel = GameObject.Find("Canvas").transform.GetChild(2).gameObject; // Canvas를 먼저 찾고 getChild를 사용하여 ClearPanel을 찾는다.

        // 적이 생성되면 처음에
        moveDir = player.transform.position - transform.position; // 플레이어의 위치(가고자하는 목표 지점)에서 자신(보스)의 위치를 빼 방향 벡터를 구한다.

        transform.LookAt(player.transform.position); // 보스가 플레이어를 향하도록 한다.
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > moveDis) // 플레이어와 보스의 거리가 moveDis보다 클 때
        {
            Vector3 deltaPos = moveDir.normalized * speed * Time.deltaTime; // 한 프레임 적이 이동할 수 있는 이동치를 구한다. 모든 기기에서 동일한 속도로 이동하도록 Time.deltaTime을 곱한다.
            transform.Translate(deltaPos, Space.World); // 월드 좌표계에서 deltaPos만큼 이동한다.
        }
        else // 플레이어와 보스의 거리가 10.0f보다 크지 않을 때, 보스가 위아래로 움직이도록 한다.
        {
            if (isUp) // isUp가 true일 경우
            {
                transform.Translate(Vector3.up * 0.1f * Time.deltaTime, Space.World); // 월드 좌표계에서 위로 0.1 속도로 이동한다.
                updownMove += 1; // updownMove을 1씩 증가한다.

                if (updownMove >= 70) // updownMove이 5이상이 되면
                {
                    isUp = false; // isUp을 false로 바꾼다.
                }
            }
            else // isUp가 false일 경우
            {
                transform.Translate(Vector3.up * -0.1f * Time.deltaTime, Space.World); // 월드 좌표계에서 아래로 0.1 속도로 이동한다.
                updownMove -= 1; // updownMove을 1씩 감소한다.

                if (updownMove <= 0) // updownMove이 0이하가 되면
                {
                    isUp = true; // isUp을 true로 바꾼다.
                }
            }
        }
    }

    public void OnDamage(Vector3 pos) // 데미지를 얻는(입는) 함수로 매개변수로 데미지를 입은 위치(pos)를 받는다.
    {
        audioSrc.PlayOneShot(damageClip, 0.1f); // 데미지를 얻을 때의 사운드(damageClip)를 0.1 볼륨으로 출력한다.

        GameObject effect = Instantiate(damageEffect); // 데미지를 받았을 때의 이펙트를 생성한다.
        effect.transform.position = pos; // 이펙트의 위치를 데미지를 입은 위치로 설정한다.

        Destroy(effect, 2); // 2초 뒤에 이펙트 삭제

        hpBar.fillAmount -= damageRate; // 보스의 hp를 damageRate만큼 감소시킨다.

        // 적 사망 처리
        if (hpBar.fillAmount < 0.001f) // 보스의 hp가 0.001f 미만일 때(적의 hp가 다 닳았을 때) * fillAmount가 0이 되지 않고, 0에 근접한 값이 될 수 있어 0.001정도로 한다.
        {
            audioSrc.PlayOneShot(expClip, 0.2f); // 폭발할 때의 사운드(damageClip)를 0.2 볼륨으로 출력한다.

            Instantiate(deadEffect, expPos); // expPos 위치에 적이 사망할 때의 이펙트를 생성한다.

            gameObject.GetComponent<MeshRenderer>().enabled = false; // 보스의 MeshRenderer를 비활성화하여 화면에 보스의 모습이 보이지 않도록 한다.
            gameObject.GetComponentInChildren<Canvas>().enabled = false; // 보스의 자식 오브젝트에서 Canvas 컴포넌트를 찾아 비활성화 하여 화면에 hp바가 보이지 않도록 한다.

            gameObject.GetComponent<BossFire>().StopShot(); // 보스의 BossFire 스크립트에서 StopShot을 호출하여 공격을 멈춘다.

            Invoke("BossClear", 1); // 1초 뒤에 BossClear() 함수를 호출한다.
        }
    }

    void BossClear() // 보스를 죽였을 시 호출되는 함수
    {
        GameMng.instance.Clear(playPanel, ClearPanel); // GameMng의 Clear() 함수를 호출한다. PlayPanel을 비활성화하고, ClearPane을 활성화해야 하므로 매개변수로 각각 넣는다.
    }
}
