using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileEnemy : Enemy
{
    bool shooting = false;
    float timeUntilNextShot;
    float minTimeUntilNextShot;
    float maxTimeUntilNextShot;

    protected override void Start()
    {
        base.Start();
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

    }
}
