using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어 컨트롤 스크립트
public class PlayerCtrl : MonoBehaviour
{
    public Image hpBar; // 플레이어의 체력바

    public GameObject playPanel; // UI의 PlayPanel을 받아올 변수로 후에 Pause 버튼을 눌렀을 때 playPanel이 안보이게 하기 위해 필요하다.
    public GameObject OverPanel; // UI의 OverPanel을 받아올 변수로 플레이어가 죽으면 등장한다.

    public AudioClip dieClip; // 플레이어가 죽었을 때의 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource audioSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    private void Start()
    {
        // 비활성화된 오브젝트를 UI Panel을 찾기 위해
        playPanel = GameObject.Find("Canvas").transform.GetChild(0).gameObject; // Canvas를 먼저 찾고 getChild를 사용하여 playPanel을 찾는다.
        OverPanel = GameObject.Find("Canvas").transform.GetChild(3).gameObject; // Canvas를 먼저 찾고 getChild를 사용하여 OverPanel을 찾는다.

        audioSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.
    }

    public void getHp(float recoveryRate) // 체력을 회복하는 함수. 매개변수로 얼마만큼을 회복할지 받는다.
    {
        hpBar.fillAmount += recoveryRate; // 플레이어의 hp를 recoveryRate만큼 증가시킨다.
    }
    
    private void OnTriggerEnter(Collider other) // 충돌처리
    {
        if(other.CompareTag("EnemyMissile")) // 적 미사일과 충돌했을 때
        {
            hpBar.fillAmount -= 0.1f; // 플레이어의 hp를 0.1만큼 감소시킨다.

            other.transform.GetComponent<MissileCtrl>()?.Explode(); // 충돌한 오브젝트가 MissileCtrl 스크립트를 가지고 있으면 적의 MissileCtrl 스크립트의 Explode() 함수를 호출한다
                                                                    // 충돌한 오브젝트가 MissileCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.
        }
        else if(other.CompareTag("BossBullet")) // 보스의 공격와 충돌했을 때
        {
            hpBar.fillAmount -= 0.2f; // 플레이어의 hp를 0.2만큼 감소시킨다.

            other.transform.GetComponent<BossBulletCtrl>()?.Explode(); // 충돌한 오브젝트가 BossBulletCtrl 스크립트를 가지고 있으면 적의 BossBulletCtrl 스크립트의 Explode() 함수를 호출한다
                                                                       // 충돌한 오브젝트가 BossBulletCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.
        }
        else if (other.CompareTag("Asteroid")) // 소행성과 충돌했을 때
        {
            hpBar.fillAmount -= 0.05f; // 플레이어의 hp를 0.05만큼 감소시킨다.

            other.transform.GetComponent<AsteroidCtrl>()?.Explode(); // 충돌한 오브젝트가 AsteroidCtrl 스크립트를 가지고 있으면 적의 AsteroidCtrl 스크립트의 Explode() 함수를 호출한다
                                                                     // 충돌한 오브젝트가 AsteroidCtrl 스크립트를 가지고 있지 않으면 NULL이므로 NULL로 처리한다.
        }

        // 플레이어의 사망 처리
        if (hpBar.fillAmount < 0.001f) // 플레이어의 hp가 0.001f 미만일 때(플레이어의 hp가 다 닳았을 때) * fillAmount가 0이 되지 않고, 0에 근접한 값이 될 수 있어 0.001정도로 한다.
        {
            Invoke("PlayerOver", 1); // 1초 뒤에 PlayerOver() 함수를 호출한다.
        }
    }

    void PlayerOver() // 플레이어가 죽었을 시 호출되는 함수
    {
        audioSrc.PlayOneShot(dieClip, 0.05f); // 플레이어가 죽었을 때의 사운드(clickClip)를 0.05 볼륨으로 출력한다.
        audioSrc.loop = true; // loop를 true로 하여 사운드가 계속 들리도록 한다.

        GameMng.instance.Over(playPanel, OverPanel); // GameMng의 Over() 함수를 호출한다.
    }
}
