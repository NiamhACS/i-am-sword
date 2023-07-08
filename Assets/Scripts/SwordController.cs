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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = GetMousePos();
            Vector2 newPos = Vector2.Lerp(transform.position, (Vector2)transform.position + mousePos, Mathf.Min(Time.deltaTime * speed, maxSpeed));
            transform.position = newPos;
            Vector2 newTargetDir = mousePos;
            transform.up = Vector2.MoveTowards(transform.up, newTargetDir, Time.deltaTime * rotationSpeed);
        }
    }

    Vector2 GetMousePos()
    {
        return Vector2.ClampMagnitude(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, maxSpeed);
    }
}
