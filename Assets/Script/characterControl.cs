using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterControl : MonoBehaviour
{      

    public float moveSpeed = 10f; // 이동 속도
    private Vector3[] positions = new Vector3[3]; // 이동 위치를 저장할 배열
    private int currentPositionIndex = 1; // 현재 위치를 추적하는 변수 (중앙이 초기 위치)
    private Vector3 targetPosition; // 이동할 목표 위치

    void Start()
    {
        // 특정 지점으로 이동 위치 설정
        positions[0] = new Vector3(-1.45f, transform.position.y, 0f); // 좌측 지점
        positions[1] = new Vector3(0f, transform.position.y, 0f);     // 중앙 지점
        positions[2] = new Vector3(1.45f, transform.position.y, 0f);  // 우측 지점

        transform.position = positions[1]; // 초기 위치를 중앙으로 설정
        targetPosition = transform.position; // 초기 목표 위치를 현재 위치로 설정
    }
    void Update()
    {
        // 터치 입력 처리
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPosition.x < 0)
            {
                // 화면의 좌측 50% 부분을 터치했을 때
                if (currentPositionIndex > 0) // 좌측으로 이동 가능할 때
                {
                    currentPositionIndex--;
                    StartCoroutine(MoveToPositionSmooth(positions[currentPositionIndex]));
                }
            }
            else
            {
                // 화면의 우측 50% 부분을 터치했을 때
                if (currentPositionIndex < positions.Length - 1) // 우측으로 이동 가능할 때
                {
                    currentPositionIndex++;
                    StartCoroutine(MoveToPositionSmooth(positions[currentPositionIndex]));
                }
            }
        }
    }

        IEnumerator MoveToPositionSmooth(Vector3 targetPos)
    {
        float startTime = Time.time;
        Vector3 startingPos = transform.position;
        float journeyLength = Vector3.Distance(startingPos, targetPos);
        float duration = journeyLength / moveSpeed;

        while (Time.time < startTime + duration)
        {
            float fractionOfJourney = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(startingPos, targetPos, fractionOfJourney);
            yield return null;
        }

        transform.position = targetPos; // 정확한 위치로 보정
        targetPosition = targetPos; // 목표 위치 업데이트
    }
        /*private void OnCollisionEnter2D(Collision2D other) {
            if(Score.score > Score.bestScore){
            Score.bestScore = Score.score;
        }
        SceneManager.LoadScene("GameOver");
    }*/

}