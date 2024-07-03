using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [System.Serializable]
    public class ObstacleData
    {
        public GameObject prefab; // 장애물 Prefab
        public float respawnTime; // 재생산 시간 (0이면 기본 시간 사용)
    }
    public ObstacleData[] obstacles; // 장애물 데이터 배열
    public Transform[] spawnPoints; // 3개의 장애물 생성 위치 배열
    public float defaultMaxSpawnInterval = 3f; // 기본 최대 생성 간격

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // 장애물을 생성할 위치와 종류를 랜덤으로 선택
            int numObstacles = Random.Range(1, 3); // 생성할 장애물의 수 (1개 또는 2개)
            int[] chosenIndices = GetUniqueRandomIndices(numObstacles, spawnPoints.Length);

            for (int i = 0; i < numObstacles; i++)
            {
                int spawnIndex = chosenIndices[i];
                int obstacleIndex = Random.Range(0, obstacles.Length);
                GameObject obstacleInstance = Instantiate(obstacles[obstacleIndex].prefab, spawnPoints[spawnIndex].position, Quaternion.identity);

                // 장애물에 Obstacle 스크립트를 추가하여 이동 속도 설정
                Obstacle obstacleScript = obstacleInstance.GetComponent<Obstacle>();
                if (obstacleScript == null)
                {
                    obstacleScript = obstacleInstance.AddComponent<Obstacle>();
                }
                obstacleScript.speed = 5.8f; // 필요에 따라 속도 설정
            }

            // 각 장애물의 재생산 시간을 고려하여 다음 생성까지의 대기 시간 설정
            float waitTime = defaultMaxSpawnInterval;

            foreach (var obstacle in obstacles)
            {
                if (obstacle.respawnTime > 0)
                {
                    waitTime = Mathf.Min(waitTime, obstacle.respawnTime);
                }
            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    private int[] GetUniqueRandomIndices(int numIndices, int maxIndex)
    {
        int[] indices = new int[maxIndex];
        for (int i = 0; i < maxIndex; i++)
        {
            indices[i] = i;
        }

        for (int i = 0; i < maxIndex; i++)
        {
            int swapIndex = Random.Range(0, maxIndex);
            int temp = indices[i];
            indices[i] = indices[swapIndex];
            indices[swapIndex] = temp;
        }

        int[] result = new int[numIndices];
        for (int i = 0; i < numIndices; i++)
        {
            result[i] = indices[i];
        }

        return result;
    }
}