using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    public Transform swordAnchor, rightArmAnchor, leftArmAnchor;
    public Transform body, head, rightArm, leftArm;
    public float minLeftArmAngle, maxLeftArmAngle;
    public float armRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        swordAnchor = GameObject.FindGameObjectWithTag("SwordAnchor").transform;
        Update();
        leftArm.localRotation = Quaternion.Euler(0, 0, minLeftArmAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(-(swordAnchor.position - body.position));
        body.up = -(swordAnchor.position - body.position).normalized;
        rightArm.position = (rightArmAnchor.position + swordAnchor.position) / 2;
        rightArm.up = rightArmAnchor.position - swordAnchor.position;
        leftArm.position = leftArmAnchor.position;
        if (Input.GetMouseButton(0))
        {
            leftArm.localRotation = Quaternion.RotateTowards(leftArm.localRotation, Quaternion.Euler(0, 0, maxLeftArmAngle), armRotationSpeed);
        }
        else
        {
            leftArm.localRotation = Quaternion.RotateTowards(leftArm.localRotation, Quaternion.Euler(0, 0, minLeftArmAngle), armRotationSpeed);
        }
        head.up = -(swordAnchor.position - body.position);
    }
}
