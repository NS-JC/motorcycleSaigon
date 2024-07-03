using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BCMove : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        
        // 화면을 벗어나면 파괴
        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 최고 점수 갱신
            if (Score.score > Score.bestScore)
            {
                Score.bestScore = Score.score;
            }

            // 게임 오버 씬 로드
            SceneManager.LoadScene("GameOver");
        }
    }
}
