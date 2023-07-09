using System;
using System.Collections;
using System.Collections.Generic;
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
        leftArm.rotation = Quaternion.Euler(0, 0, minLeftArmAngle);
    }

    // Update is called once per frame
    void Update()
    {
        body.right = swordAnchor.position - body.position;
        rightArm.position = (rightArmAnchor.position + swordAnchor.position) / 2;
        rightArm.up = swordAnchor.position - rightArmAnchor.position;
        leftArm.position = leftArmAnchor.position;
        if (Input.GetMouseButton(0))
        {
            leftArm.rotation = Quaternion.RotateTowards(leftArm.rotation, Quaternion.Euler(0, 0, body.rotation.eulerAngles.z + maxLeftArmAngle), armRotationSpeed);
        }
        else
        {
            leftArm.rotation = Quaternion.RotateTowards(leftArm.rotation, Quaternion.Euler(0, 0, body.rotation.eulerAngles.z + minLeftArmAngle), armRotationSpeed);
        }
        head.up = -(swordAnchor.position - body.position);
    }
}
