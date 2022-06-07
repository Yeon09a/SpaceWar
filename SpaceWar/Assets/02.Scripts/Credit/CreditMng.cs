using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 크레딧 매니저 스크립트
public class CreditMng : MonoBehaviour
{
    public GameObject creditPanel; // CreditPanel UI을 받을 변수
    public GameObject exitPanel; // ExitPanel UI을 받을 변수
    public GameObject pausePanel; // PausePanel UI을 받을 변수

    public AudioClip clickClip; // 버튼을 누를 때의 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource BtnSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        BtnSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.

        Invoke("creditPanelOff", 20); // 20초 뒤에 creditPanelOff() 을 호출하여 CreditPanel을 비활성화한다.
    }

    public void creditPanelOff() // CreditPanel을 비활성화하는 함수
    {
        creditPanel.SetActive(false); // CreditPanel을 비활성화하여 화면에서 보이지 않도록 한다.
        exitPanel.SetActive(true); // ExitPanel을 활성화하여 화면에서 보이도록 한다.

    }
    public void OnClickPause() // PauseBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        Time.timeScale = 0; // Time.timeScale은 실제 시간에 대한 게임 시간으로 0으로 두면 실제 시간이 멈추어 게임이 정지된다.
        
        exitPanel.SetActive(false); // ExitPanel 비활성화하여 화면에서 보이지 않도록 한다.
        pausePanel.SetActive(true); // PausePanel 활성화하여 화면에서 보이도록 한다.
    }

    public void OnClickExit() // ExitBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        SceneManager.LoadScene("Main"); // "Main" 씬으로 돌아간다.
    }

    public void OnClickContinue() // ContinueBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        Time.timeScale = 1; // Time.timeScale은 실제 시간에 대한 게임 시간으로 기본값이 1이므로 1로 두면 실제 시간과 같다.

        exitPanel.SetActive(true); // playPanel을 활성화하여 화면에서 보이도록 한다.
        pausePanel.SetActive(false); // PausePanel 비활성화하여 화면에서 보이지 않도록 한다.
    }

    void AudioPlay() // 버튼을 누르는 사운드를 출력하는 함수
    {
        BtnSrc.PlayOneShot(clickClip, 0.2f); // 버튼을 누를 때의 사운드(clickClip)를 0.2 볼륨으로 출력한다.
    }
}
