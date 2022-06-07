using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main씬 UI 스크립트
public class MainUIMng : MonoBehaviour
{
    public AudioClip clickClip; // 버튼을 누를 때의 사운드. 오디오 소스를 넣을 수 있는 공간 마련. 음원 소스를 넣을 수 있도록 public으로 설정한다.
    AudioSource BtnSrc; // 실제로 음원을 출력할 수 있는 오디오 소스 변수

    void Start()
    {
        BtnSrc = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 얻어 playerSrc에 넣는다.
    }

    public void OnClickStart() // Start 버튼을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        SceneManager.LoadScene("Tutorial"); // "Level_1" 씬을 호출한다.

    }

    public void OnClickExit() // Exit 버튼을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        Application.Quit(); // 게임을 종료한다.
    }

    public void OnClickCredit() // Credit 버튼을 눌렀을 때
    {
        AudioPlay(); // 버튼을 누르는 사운드를 출력하는 함수를 호출한다.

        SceneManager.LoadScene("Credit"); // "Credit" 씬을 호출한다.
    }

    void AudioPlay() // 버튼을 누르는 사운드를 출력하는 함수
    {
        BtnSrc.PlayOneShot(clickClip, 0.2f); // 버튼을 누를 때의 사운드(clickClip)를 0.2 볼륨으로 출력한다.
    }
}
