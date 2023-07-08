using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Vector2 mousePos = GetMousePos();
            Vector2 newPos = Vector2.Lerp(transform.position, mousePos, Time.deltaTime * speed);
            transform.position = newPos;
            Vector2 newTargetDir = mousePos - new Vector2(transform.position.x, transform.position.y);
            transform.up = Vector2.MoveTowards(transform.up, newTargetDir, Time.deltaTime * rotationSpeed);
            
        }
    }

    Vector2 GetMousePos(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
