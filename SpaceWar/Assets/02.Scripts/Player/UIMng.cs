using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UIManager 스크립트
public class UIMng : MonoBehaviour
{
    public GameObject playPanel; // UI의 PlayPanel을 받아올 변수로 후에 Pause 버튼을 눌렀을 때 playPanel이 안보이게 하기 위해 필요하다.
    public GameObject PausePanel; // UI의 PausePanel을 받아올 변수로 Pause 버튼을 눌렀을 때 등장하는 메뉴이다.
    public GameObject ClearPanel; // UI의 ClearPanel을 받아올 변수로 플레이어가 보스를 해치우면 등장한다.
    public GameObject OverPanel; // UI의 OverPanel을 받아올 변수로 플레이어가 죽으면 등장한다.
    public GameObject startPanel; // UI의 StartPanel을 받아올 변수로 처음 게임이 시작하면 등장한다.

    public AudioClip clickClip; // 버튼을 누를 때의 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource BtnSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        BtnSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.

        StartCoroutine(ShowPlay()); ; // ShowPlay()을 호출하여 PlayPanel을 보여주고 levelPanel을 안보이게 한다.
    }

    IEnumerator ShowPlay() // 게임을 시작하면 PlayPanel을 보여주고 levelPanel을 안보이게 하는 함수
    {
        yield return new WaitForSeconds(1); // 2초 딜레이를 한다.

        GameMng.instance.StartText(startPanel, playPanel); // GameMng에서 Pause()을 호출한다. PlayPanel을 비활성화하고, PausePanel을 활성화해야 하므로 매개변수로 각각 넣는다.
    }
    
    public void OnClickPause() // PauseBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        GameMng.instance.Pause(playPanel, PausePanel); // GameMng에서 Pause()을 호출한다. PlayPanel을 비활성화하고, PausePanel을 활성화해야 하므로 매개변수로 각각 넣는다.
    }

    public void OnClickContinue() // ContinueBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        GameMng.instance.Continue(PausePanel, playPanel); // GameMng에서 Continue()을 호출한다. PausePanel 비활성화하고, playPanel 활성화해야 하므로 매개변수로 각각 넣는다.
    }

    public void OnClickRetry() // RetryBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        GameMng.instance.Retry(); // GameMng에서 Retry()을 호출한다.
    }

    public void OnClickExit() // ExitBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        GameMng.instance.Exit(); // GameMng에서 Exit()을 호출한다.
    }

    public void OnClickNextLevel() // NextBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        GameMng.instance.NextLevel(); // GameMng에서 NextLevel()을 호출한다.
    }

    void AudioPlay() // 버튼을 누르는 사운드를 출력하는 함수
    {
        BtnSrc.PlayOneShot(clickClip, 0.2f); // 버튼을 누를 때의 사운드(clickClip)를 0.2 볼륨으로 출력한다.
    }
}
