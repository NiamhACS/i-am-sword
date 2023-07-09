using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControl : MonoBehaviour
{
    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite SideSprite;

    public SpriteRenderer spriteRenderer;

    public GameObject Rotator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Rotator.transform.rotation.eulerAngles.z);
        if ((Rotator.transform.rotation.eulerAngles.z <= 45) || (Rotator.transform.rotation.eulerAngles.z > 315))
        {
            spriteRenderer.sprite = SideSprite;
            spriteRenderer.flipX = false;
        }
        else if (Rotator.transform.rotation.eulerAngles.z <= 135)
        {
            spriteRenderer.sprite = UpSprite;
            spriteRenderer.flipX = false;
        }
        else if (Rotator.transform.rotation.eulerAngles.z <= 225)
        {
            spriteRenderer.sprite = SideSprite;
            spriteRenderer.flipX = true;
        }
        else if (Rotator.transform.rotation.eulerAngles.z <= 315)
        {
            spriteRenderer.sprite = DownSprite;
            spriteRenderer.flipX = false;

        }
        else
        {
            Debug.Log("wtf is my rotation");
        }

    }
}
