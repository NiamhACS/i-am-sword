using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float regen;

    void Start()
    {
        regen = 0;
        fill.color = gradient.Evaluate(1f);
    }

    void Update()
    {
        slider.value = GameController.instance.health + regen;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (GameController.instance.health < 3)
        {
            regen += .2f * Time.deltaTime;
            if (regen >= 1)
            {
                GameController.instance.health += 1;
                regen = 0;
            }
        }
    }

    public void SetMaxHealth(float f)
    {
    }

    public void SetHealth(float f)
    {

    }
}
