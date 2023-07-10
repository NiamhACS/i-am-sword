using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public float lifeSpan;
    public float timer;
    public float animTimer;
    public float frameInterval;
    public float flashTimer;
    private int currentSprite = 0;
    // Start is called before the first frame update
    private void OnEnable()
    {
        timer = lifeSpan;
        animTimer = 0;
        flashTimer = .1f;
        currentSprite = 0;
        spriteRenderer.enabled = true;
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[currentSprite];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (sprites.Length > 1)
            {
                animTimer += Time.deltaTime;
                if (animTimer > frameInterval)
                {
                    animTimer = 0;
                    currentSprite = 1 - currentSprite;
                    spriteRenderer.sprite = sprites[currentSprite];
                }
            }
            if (timer < 1)
            {
                if (flashTimer > 0)
                {
                    flashTimer -= Time.deltaTime;
                }
                else
                {
                    flashTimer = .1f;
                    spriteRenderer.enabled = !spriteRenderer.enabled;
                }
            }
        }
        else
        {
            GameController.instance.corpses.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
    }
}
