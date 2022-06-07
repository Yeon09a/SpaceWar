using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 매니저 스크립트
public class GameMng : MonoBehaviour
{
    static public GameMng instance; // 싱글톤. 자기 자신을 변수로 받는다

    public int level = 0; // 현재 진행되고 있는 게임 레벨 변수. 처음 레벨 1부터 시작하므로 0으로 초기화한다.

    private string[] levels = { "Level_1", "Level_2", "Level_3", "Credit" }; // level 배열
    
    private void Start()
    {
        if(instance == null) // instance가 null일 경우에
        {
            instance = this; // instance에 자기 자신을 할당한다. 이는 GameMng가 전체 게임 코드에서 유일하게 하나만 존재할 수 있기 때문이다.
        }
        else if(instance != this) // instance에 할당된 클래스와 this가 다르다는 것은 새로 생성된 클래스를 의미하므로 이전 클래스의 level을 계속 갖고 가야 하기 때문에 새로운 GameManager를 삭제한다.
        {
            Destroy(this.gameObject); // 새로 생성된 GameManager를 삭제한다.
        }

        DontDestroyOnLoad(this.gameObject);// 다른 씬으로 넘어가도 삭제하기 않고 유지하기 위해 DontDestroyLoad를 한다.
    }

    public void StartText(GameObject activeFalse, GameObject activeTrue) // Start 텍스트를 보여주는 함수, 매개변수로 각각 비활성화할 UI Panel과 활성화할 UI Panel을 받는다.
    {
        activeFalse.SetActive(false); // activeTrue 비활성화하여 화면에서 보이지 않도록 한다.
        activeTrue.SetActive(true); // PausePanel 활성화하여 화면에서 보이도록 한다.
    }

    public void Pause(GameObject activeFalse, GameObject activeTrue) // PauseBtn을 눌렀을 때, 매개변수로 각각 비활성화할 UI Panel과 활성화할 UI Panel을 받는다.
    {
        Time.timeScale = 0; // Time.timeScale은 실제 시간에 대한 게임 시간으로 0으로 두면 실제 시간이 멈추어 게임이 정지된다.

        activeFalse.SetActive(false); // activeTrue 비활성화하여 화면에서 보이지 않도록 한다.
        activeTrue.SetActive(true); // PausePanel 활성화하여 화면에서 보이도록 한다.
    }

    public void Continue(GameObject activeFalse, GameObject activeTrue) // ContinueBtn을 눌렀을 때, 매개변수로 각각 비활성화할 UI Panel과 활성화할 UI Panel을 받는다.
    {
        Time.timeScale = 1; // Time.timeScale은 실제 시간에 대한 게임 시간으로 기본값이 1이므로 1로 두면 실제 시간과 같다.

        activeTrue.SetActive(true); // activeTrue 활성화하여 화면에서 보이도록 한다.
        activeFalse.SetActive(false); // activeFalse 비활성화하여 화면에서 보이지 않도록 한다.
    }

    public void Retry() // RetryBtn을 눌렀을 때
    {
        // 씬을 다시 새로 불러와 처음부터 진행하도록 한다.
        SceneManager.LoadScene(levels[level]); // levels[level] 씬을 호출한다.
        SceneManager.LoadScene("Player", LoadSceneMode.Additive); // 기존의 씬(Level_1)을 삭제하지 않고 추가해서 "Player" 씬을 로드한다.
    }

    public void Exit() // ExitBtn을 눌렀을 때
    {
        SceneManager.LoadScene("Main"); // "Main" 씬으로 돌아간다.
    }

    public void Clear(GameObject activeFalse, GameObject activeTrue) // 해당 레벨을 클리어했을 때, 매개변수로 각각 비활성화할 UI Panel과 활성화할 UI Panel을 받는다. 
    {
        if (level == 2) // 마지막 레벨(2)을 클리어했다면 
        {
            level += 1; // level을 올려 크레딧을 가리키도록 한다.
            // 다음 level 씬을 불러온다.
            SceneManager.LoadScene(levels[level]); // levels[level] 씬을 호출한다.

        }
        else // 1, 2 레벨 클리어 시
        {
            activeFalse.SetActive(false); // activeFalse 비활성화하여 화면에서 보이지 않도록 한다.
            activeTrue.SetActive(true); // activeTrue 활성화하여 화면에서 보이도록 한다.
        }
    }

    public void Over(GameObject activeFalse, GameObject activeTrue) // 게임 오버했을 때, 매개변수로 각각 비활성화할 UI Panel과 활성화할 UI Panel을 받는다. 
    {
        activeFalse.SetActive(false); // activeFalse 비활성화하여 화면에서 보이지 않도록 한다.
        activeTrue.SetActive(true); // activeTrue 활성화하여 화면에서 보이도록 한다.
    }

    public void NextLevel() // NextBtn을 눌렀을 때
    {
        level += 1; // level을 올려 다음 레벨을 가리키도록 한다.

        // 다음 level 씬을 불러온다.
        SceneManager.LoadScene(levels[level]); // levels[level] 씬을 호출한다.
        SceneManager.LoadScene("Player", LoadSceneMode.Additive); // 기존의 씬(levels[level)을 삭제하지 않고 추가해서 "Player" 씬을 로드한다.
    }
}
