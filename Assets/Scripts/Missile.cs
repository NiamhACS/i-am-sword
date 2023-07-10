using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Android;

public class Missile : MonoBehaviour
{
    public float speed = 1;
    public float flipInterval;
    private float flipTimer = 0;
    public SpriteRenderer spriteRenderer;
    public float lifeSpan = 10; //-1 will never despawn
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        if (flipInterval > 0)
        {
            flipTimer -= Time.deltaTime;
            if (flipTimer < 0)
            {
                flipTimer = flipInterval;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
        if (Mathf.Abs(transform.position.x) > 20 || Mathf.Abs(transform.position.y) > 12 || lifeSpan < 0)
        {
            gameObject.SetActive(false);
        }
        lifeSpan -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Body"))
        {
            GameController.instance.TakeDamage();
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag.Equals("Player") && Input.GetMouseButton(1))
        {
            gameObject.SetActive(false);
        }
    }
}
