
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public struct SpawnData
{
    public Vector2 spawnIntervalRange;
    public GameObject prefab;
    public Queue<GameObject> pool;
}

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public SpawnData[] enemies;
    public RectTransform spawnBounds;



    public void Start()
    {
        instance = this;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].pool = GeneratePool(enemies[i].prefab, 10);
            Debug.Log(enemies[i].pool);
        }
    }

    public float Spawn(SpawnData data)
    {
        Debug.Log(data.pool);
        Vector2 spawnPoint = RandomPointOnRect(spawnBounds.rect);
        GameObject newEnemy = data.pool.Dequeue();
        newEnemy.transform.position = spawnPoint;
        newEnemy.SetActive(true);
        return Random.Range(data.spawnIntervalRange.x, data.spawnIntervalRange.y);
    }

    public Queue<GameObject> GeneratePool(GameObject prefab, int quantity)
    {
        Queue<GameObject> pool = new();
        for (int i = 0; i < quantity; i++)
        {
            GameObject newEnemy = Instantiate(prefab);
            newEnemy.SetActive(false);
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

