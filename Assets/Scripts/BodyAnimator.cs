using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] frames;
    public bool moving;
    public int currentFrame;
    private float timer;
    public float timeBetweenFrames;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        currentFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFrames)
            {
                currentFrame = 1 - currentFrame;
                spriteRenderer.sprite = frames[currentFrame];
                timer = 0;
            }
        }
    }
}
