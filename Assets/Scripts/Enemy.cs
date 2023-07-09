using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyIndex;
    public string targetTag = "Body";
    public float preferredDist = 0;
    public float moveSpeed = 0;
    public Transform rotator;
    protected Transform target;
    public BodyAnimator bodyAnimator;
    public Sprite[] corpseSprites;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (Vector2.Distance(transform.position, target.position) > preferredDist)
        {
            Vector2 velocity = rotator.right * Time.deltaTime * moveSpeed;
            transform.position = (Vector2)transform.position + velocity;
            if (bodyAnimator != null)
            {
                bodyAnimator.moving = true;
            }
        }
        else if (bodyAnimator != null)
        {
            bodyAnimator.moving = false;
        }
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag.Equals("Player"))
        {
            GameController.instance.SpawnCorpse(this);
            GameController.instance.GainScore(EnemySpawner.instance.enemies[enemyIndex].scoreGain);
            EnemySpawner.instance.enemies[enemyIndex].pool.Enqueue(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
