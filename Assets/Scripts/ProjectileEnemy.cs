using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileEnemy : Enemy
{
    public GameObject projectilePrefab;
    public GameObject[] projectilePool;
    bool shooting = false;
    float timeUntilNextShot;
    public float missileSpeed;
    public float missileLifeSpan = 10;
    public float minTimeUntilNextShot;
    public float maxTimeUntilNextShot;

    protected override void Start()
    {
        base.Start();
        projectilePool = new GameObject[5];
        for (int i = 0; i < projectilePool.Length; i++)
        {
            projectilePool[i] = Instantiate(projectilePrefab);
            projectilePool[i].SetActive(false);
        }
        shooting = false;
    }

    protected override void Update()
    {
        base.Update();
        if (shooting)
        {
            if (timeUntilNextShot <= 0)
            {
                Shoot();
                timeUntilNextShot = Random.Range(minTimeUntilNextShot, maxTimeUntilNextShot);
            }
            else
            {
                timeUntilNextShot -= Time.deltaTime;
            }
        }
    }

    protected override void Move()
    {
        base.Move();
        if (Vector2.Distance(target.position, transform.position) <= preferredDist)
        {
            shooting = true;
        }
        else
        {
            shooting = false;
        }
    }

    protected virtual void Shoot()
    {
        for (int i = 0; i < projectilePool.Length; i++)
        {
            if (!projectilePool[i].activeSelf)
            {
                projectilePool[i].transform.position = transform.position;
                projectilePool[i].transform.up = rotator.right;
                projectilePool[i].GetComponent<Missile>().speed = missileSpeed;
                projectilePool[i].GetComponent<Missile>().lifeSpan = missileLifeSpan;
                projectilePool[i].SetActive(true);
                return;
            }
        }
    }
}
