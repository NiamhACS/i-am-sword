using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float maxSpeed;
    public float blockSlowDown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = GetMousePos();
        Vector2 targetDir = transform.up;
        if (Input.GetMouseButton(0))
        {
            Vector2 newPos = Vector2.Lerp(transform.position, (Vector2)transform.position + mousePos, Mathf.Min(Time.deltaTime * speed, maxSpeed));
            transform.position = newPos;
            targetDir = mousePos;
        }
        if (Input.GetMouseButtonDown(1))
        {
            maxSpeed *= blockSlowDown;
        }
        if (Input.GetMouseButton(1))
        {
            targetDir = mousePos;
            targetDir = new(-targetDir.y, targetDir.x);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            targetDir = new(targetDir.y, -targetDir.x);
            maxSpeed /= blockSlowDown;
        }
        transform.up = Vector2.MoveTowards(transform.up, targetDir, Time.deltaTime * rotationSpeed);
    }

    Vector2 GetMousePos()
    {
        return Vector2.ClampMagnitude(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, maxSpeed);
    }
}
