using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string targetTag = "Body";
    public float preferredDist = 0;
    public float moveSpeed = 0;
    public Transform rotator;
    protected Transform target;

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
        }
    }
}
