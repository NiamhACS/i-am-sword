using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int score = 0;
    public float[] timeThresholds;
    public int currentEnemies = 0;
    public float nextInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextInterval)
        {
            SpawnData enemy = EnemySpawner.instance.enemies[Random.Range(0, currentEnemies + 1)];
            nextInterval += EnemySpawner.instance.Spawn(enemy);
        }
    }
}
