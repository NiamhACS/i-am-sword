using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : Enemy
{
    public Transform top, bottom, middle;
    public SlimeAnimator middleAnim;
    public SlimeAnimator topAnim;

    public bool moving = false;
    public float maxTimeBetweenMoves, minTimeBetweenMoves;
    public float jumpDist;
    public Vector2 start;
    public Vector2 landing;

    private float timeTillMove = 0;

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Vector2.right);
            middleAnim.AddAngle(Vector2.right);
            topAnim.AddAngle(Vector2.left);
        }
        Move();
    }

    protected override void Move()
    {
        if (!moving)
        {
            if (timeTillMove > 0)
            {
                timeTillMove -= Time.deltaTime;
            }
            else
            {
                moving = true;
                start = transform.position;
                landing = rotator.right;
                landing = (Vector2)transform.position + landing * jumpDist;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, landing, moveSpeed * Time.deltaTime);
            if (((Vector2)transform.position).Equals(landing))
            {
                moving = false;
                timeTillMove = Random.Range(minTimeBetweenMoves, maxTimeBetweenMoves);
                Vector2 moveVector = (landing - start).normalized;
                middleAnim.AddAngle(moveVector);
                topAnim.AddAngle(-moveVector);
            }
        }
    }
}
