using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 튜토리얼 매니저 스크립트
public class TutorialMng : MonoBehaviour
{
    public GameObject explPanel; // ExplanationPanel을 받아올 변수로 후에 OK 버튼을 눌렀을 때 ExplanationPanel이 안보이게 하기 위해 필요하다.
    public GameObject playPanel; // UI의 PlayPanel을 받아올 변수로 후에 Pause 버튼을 눌렀을 때 playPanel이 안보이게 하기 위해 필요하다.
    public GameObject PausePanel; // UI의 PausePanel을 받아올 변수로 Pause 버튼을 눌렀을 때 등장하는 메뉴이다.
    public GameObject finishPanel; // FinishPanel 받아올 변수

    public AudioClip clickClip; // 버튼을 누를 때의 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource BtnSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        BtnSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.
    }

    public void OnClickOk() // Okay 버튼을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        explPanel.SetActive(false); // playPanel 비활성화하여 화면에서 보이지 않도록 한다.
        finishPanel.SetActive(true); // finishPanel 활성화하여 화면에서 보이도록 한다.
    }

    public void OnClickFinish() // Skip 또는 Finish 버튼을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        SceneManager.LoadScene("Level_1"); // "Level_1" 씬을 호출한다.
        SceneManager.LoadScene("Player", LoadSceneMode.Additive); // 기존의 씬(Level_1)을 삭제하지 않고 추가해서 "Player" 씬을 로드한다.
    }

    public void OnClickPause() // PauseBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        Time.timeScale = 0; // Time.timeScale은 실제 시간에 대한 게임 시간으로 0으로 두면 실제 시간이 멈추어 게임이 정지된다.

        playPanel.SetActive(false); // playPanel 비활성화하여 화면에서 보이지 않도록 한다.
        PausePanel.SetActive(true); // PausePanel 활성화하여 화면에서 보이도록 한다.
    }

    public void OnClickContinue() // ContinueBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        Time.timeScale = 1; // Time.timeScale은 실제 시간에 대한 게임 시간으로 기본값이 1이므로 1로 두면 실제 시간과 같다.

        playPanel.SetActive(true); // playPanel 활성화하여 화면에서 보이도록 한다.
        PausePanel.SetActive(false); // PausePanel 비활성화하여 화면에서 보이지 않도록 한다.
    }

    public void OnClickExit() // ExitBtn을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        SceneManager.LoadScene("Main"); // "Main" 씬으로 돌아간다.
    }

    void AudioPlay() // 버튼을 누르는 사운드를 출력하는 함수
    {
        BtnSrc.PlayOneShot(clickClip, 0.2f); // 버튼을 누를 때의 사운드(clickClip)를 0.2 볼륨으로 출력한다.
    }
}
