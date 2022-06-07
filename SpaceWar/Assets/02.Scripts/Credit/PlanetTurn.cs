using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 행성 회전 스크립트

public class PlanetTurn : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, (-10 * Time.deltaTime), 0, Space.World); // 월드 좌표계로 y축을 기준으로 -10 * Time.deltaTime 만큼 회전한다.
    }
}
