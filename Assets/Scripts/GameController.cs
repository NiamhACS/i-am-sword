using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform corpseParent;
    public GameObject corpsePrefab;
    public Queue<GameObject> corpses;
    public int score = 0;
    public float[] timeThresholds;
    public int currentEnemies = 0;
    public float nextInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        corpses = new();
        for (int i = 0; i < 50; i++)
        {
            corpses.Enqueue(Instantiate(corpsePrefab, corpseParent));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies < timeThresholds.Length)
        {
            if (Time.time > timeThresholds[currentEnemies])
            {
                currentEnemies++;
            }
        }
        if (Time.time > nextInterval)
        {
            SpawnData enemy = EnemySpawner.instance.enemies[Random.Range(0, currentEnemies + 1)];
            nextInterval += EnemySpawner.instance.Spawn(enemy);
        }
    }

    public void SpawnCorpse(Enemy enemy)
    {
        Corpse newCorpse = corpses.Dequeue().GetComponent<Corpse>();
        newCorpse.sprites = enemy.corpseSprites;
        newCorpse.transform.position = enemy.transform.position;
        newCorpse.lifeSpan = 4;
        newCorpse.gameObject.SetActive(true);
    }

    public void GainScore(int score)
    {
        this.score += score;
    }
}
