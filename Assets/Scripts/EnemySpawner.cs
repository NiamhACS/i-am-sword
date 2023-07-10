
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public struct SpawnData
{
    public int enemyIndex;
    public int scoreGain;
    public Transform parent;
    public Vector2 spawnIntervalRange;
    public GameObject prefab;
    public Queue<GameObject> pool;
}

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public SpawnData[] enemies;
    public RectTransform spawnBounds;
    public float spawnRateScalar;


    public void Start()
    {
        instance = this;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].enemyIndex = i;
            enemies[i].pool = GeneratePool(enemies[i], 10);
        }
    }

    void Update()
    {
        spawnRateScalar = Mathf.Min(1f, 24f / Mathf.Min(120f, Time.timeSinceLevelLoad));
    }

    public float Spawn(SpawnData data)
    {
        Vector2 spawnPoint = RandomPointOnRect(spawnBounds.rect);
        if (data.pool.Count == 0)
        {
            data.pool.Enqueue(Instantiate(data.prefab, data.parent));
        }
        GameObject newEnemy = data.pool.Dequeue();
        newEnemy.transform.position = spawnPoint;
        newEnemy.SetActive(true);
        return Random.Range(data.spawnIntervalRange.x * spawnRateScalar, data.spawnIntervalRange.y * spawnRateScalar);
    }

    public Queue<GameObject> GeneratePool(SpawnData spawnData, int quantity)
    {
        Queue<GameObject> pool = new();
        for (int i = 0; i < quantity; i++)
        {
            GameObject newEnemy = Instantiate(spawnData.prefab, spawnData.parent);
            Debug.Log(newEnemy.GetComponent<Enemy>());
            newEnemy.SetActive(false);
            newEnemy.GetComponent<Enemy>().enemyIndex = spawnData.enemyIndex;
            pool.Enqueue(newEnemy);
        }
        return pool;
    }

    public Vector2 RandomPointOnRect(Rect rect)
    {
        Vector2 point = new();
        float perimeter = rect.height * 2 + rect.width * 2;
        float random = Random.Range(0, perimeter);
        if (random < rect.width)
        {
            point.x = rect.xMin + random;
            point.y = rect.yMax;
        }
        else if (random < rect.width + rect.height)
        {
            point.x = rect.xMax;
            point.y = rect.yMax - (random - rect.width);
        }
        else if (random < rect.width * 2 + rect.height)
        {
            point.x = rect.xMax - (random - rect.height - rect.width);
            point.y = rect.yMin;
        }
        else
        {
            point.x = rect.xMin;
            point.y = rect.yMin + (random - rect.width * 2 - rect.height);
        }
        return point;
    }
}

