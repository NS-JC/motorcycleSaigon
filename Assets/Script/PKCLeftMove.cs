using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PKCLeftMove : MonoBehaviour
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
    
    /*이거 참고해서 지갑에 돈 없으면 죽도록 수정해서 넣을거임
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(Score.score > Score.bestScore)
                {
                Score.bestScore = Score.score;
                }
        SceneManager.LoadScene("GameOver");
        }
    }*/

}

