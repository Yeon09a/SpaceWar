using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 회전 함수
public class ObjectTurn : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)); // 아이템의 기울기를 랜덤으로 하여 생성되도록 한다.
    }

    void Update()
    {
        transform.Rotate((100 * Time.deltaTime), 0, 0, Space.World); // 아이템이 제자리에서 x축을 기준으로 회전, 모든 기기에서 동일한 속도로 이동하도록 Time.deltaTime을 곱한다.
    }
}
