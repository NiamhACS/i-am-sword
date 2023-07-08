using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    public Transform swordAnchor, bodyAnchor;
    public Transform body, head, arm;

    // Start is called before the first frame update
    void Start()
    {
        swordAnchor = GameObject.FindGameObjectWithTag("SwordAnchor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        body.right = swordAnchor.position - body.position;
        arm.position = (bodyAnchor.position + swordAnchor.position) / 2;
        arm.up = swordAnchor.position - bodyAnchor.position;
        /*
        Vector2 oldArmAnchor1 = armAnchor1.position;
        Debug.Log("old arm anchor pos:" + oldArmAnchor1);
        armAnchor1.position = swordAnchor.position;
        Debug.Log("arm anchor pos:" + armAnchor1.position);
        Debug.Log("clamped vector:" + Vector2.ClampMagnitude(oldArmAnchor1 - (Vector2)armAnchor1.position, 1));
        arm.position = Vector2.ClampMagnitude(oldArmAnchor1 - (Vector2)armAnchor1.position, 1) + (Vector2)armAnchor1.position;
        arm.up = armAnchor1.position - arm.position;
        */
    }
}
