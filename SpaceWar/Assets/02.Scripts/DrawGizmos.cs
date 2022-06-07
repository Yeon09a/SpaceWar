using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 기즈모 스크립트
public class DrawGizmos : MonoBehaviour
{
    public Color color = Color.red; // 기즈모 색상(붉은 색으로 초기화)
    public float radius = 0.3f; // 기즈모 반지름 길이(0.3으로 초기화)

    // 기즈모 생성
    private void OnDrawGizmos() // 기즈모 그리는 함수
    {
        Gizmos.color = color; // 기즈모 색상 설정
        Gizmos.DrawSphere(transform.position, radius); // 오브젝트의 위치에 구 모양의 기즈모를 그린다.
    }
}
