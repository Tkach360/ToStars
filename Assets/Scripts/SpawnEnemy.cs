using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject[] objects;
    public GameObject player;
    public GameObject wallUp;
    public GameObject wallDown;
    public int numberOfObstacles;
    private Vector2 spawnArea;

    void Start()
    {
        spawnArea.x = wallDown.transform.position.y + wallDown.transform.localScale.y * 2;
        spawnArea.y = wallUp.transform.position.y - wallUp.transform.localScale.y * 2;
        SpawnObstacles();
    }

    void Update()
    {
        if (timer > maxTime)
        {
            SpawnObstacles();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    

    private void SpawnObstacles()
    {
        List<float> spawnPoints = new List<float>();

        // Генерируем несколько случайных точек спавна препятствий
        for (int i = 0; i < numberOfObstacles; i++)
        {
            float obstacleY = Random.Range(spawnArea.x, spawnArea.y);
            spawnPoints.Add(obstacleY);
        }
        // Сортируем полученные точки спавна по возрастанию
        spawnPoints.Sort();

        // Спавним препятствия на полученных точках, проверяя, чтобы они не пересекались
        for (int i = 0; i < numberOfObstacles; i++)
        {
            GameObject obstacle = objects[Random.Range(0, objects.Length)];
            if ((i < numberOfObstacles - 1) && (spawnPoints[i + 1] - spawnPoints[i] <= obstacle.transform.localScale.y))
            {
                continue;
            }
            Vector3 spawnPosition = new Vector3(player.transform.position.x + 10f, spawnPoints[i], 0f);
            GameObject obj = Instantiate(obstacle, spawnPosition, Quaternion.identity);
            Destroy(obj, 10);
            if (obj.GetComponent<BoxCollider2D>().CompareTag("Vertical"))
            {
                break;
            }
        }
    }
}
