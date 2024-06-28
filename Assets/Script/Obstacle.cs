using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int type; // 장애물의 종류 (6, 7, 8, 9 등)
    public float speed = 5f; // 이동 속도

    private void Update()
    {
        // 장애물을 일정한 속도로 아래로 이동
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 화면을 벗어나면 파괴
        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }
}
