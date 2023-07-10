using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform corpseParent;
    public GameObject corpsePrefab;
    public Queue<GameObject> corpses;
    public AudioSource source;
    public AudioClip kill;
    public AudioClip hurt;
    public int score = 0;
    public float health = 3;
    public bool end;
    public float[] timeThresholds;
    public int currentEnemies = 0;
    public float nextInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
        corpses = new();
        end = false;
        for (int i = 0; i < 50; i++)
        {
            corpses.Enqueue(Instantiate(corpsePrefab, corpseParent));
        }
        score = 0;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (currentEnemies < timeThresholds.Length)
            {
                if (Time.timeSinceLevelLoad > timeThresholds[currentEnemies])
                {
                    currentEnemies++;
                }
            }
            if (Time.timeSinceLevelLoad > nextInterval)
            {
                SpawnData enemy = EnemySpawner.instance.enemies[Random.Range(0, currentEnemies + 1)];
                nextInterval += EnemySpawner.instance.Spawn(enemy);
            }
            if (health <= 0)
            {
                end = true;
                SceneManager.LoadScene(2);
            }
        }
    }

    public void SpawnCorpse(Enemy enemy)
    {
        source.PlayOneShot(kill);
        Corpse newCorpse = corpses.Count > 0 ? corpses.Dequeue().GetComponent<Corpse>() : Instantiate(corpsePrefab, corpseParent).GetComponent<Corpse>();
        newCorpse.sprites = enemy.corpseSprites;
        newCorpse.transform.position = enemy.transform.position;
        newCorpse.lifeSpan = 4;
        newCorpse.gameObject.SetActive(true);
    }

    public void GainScore(int score)
    {
        this.score += score;
    }

    public void TakeDamage()
    {
        source.PlayOneShot(hurt);
        health -= 1;
    }
}
