using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI 빌보드 스크립트
public class BillBoard : MonoBehaviour
{
    public Transform camTr; // AR 카메라의 Transform 변수

    void Start()
    {
        camTr = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>(); // AR 카메라의 Transform을 얻어온다.
    }

    private void LateUpdate() // 모둔 업데이트가 끝난 다음에 가장 최종적으로 실행된다.
    {
        transform.LookAt(camTr.position); // 오브젝트가 카메라의 위치를 바라보도록 한다.
    }
}
