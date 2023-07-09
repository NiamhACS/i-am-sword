using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallFaceSpriteController : MonoBehaviour
{
    public Sprite Happy;
    public Sprite Mild;
    public Sprite Sad;
    public Image image; 
    public HumanHealth human;
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteCheck();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteCheck();
    }

    void SpriteCheck(){
        if (human.current_health >= 2){
            image.sprite = Happy;
        }
        else if (human.current_health >= 1){
            image.sprite = Mild;
        }
        else if (human.current_health >= 0){
            image.sprite = Sad;
        }
        

    }
}
