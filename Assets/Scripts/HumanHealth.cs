using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHealth : MonoBehaviour
{
    public float max_health = 3;
    public float current_health;
    public HealthBar healthBar;

    public float health_regen_rate = .08f;

    void Start()
    {
        current_health = max_health;
        healthBar.SetMaxHealth(max_health);
    }

    // Update is called once per frame
    void Update()
    {

        //regen
        if (current_health < max_health)
        {
            current_health += health_regen_rate * Time.deltaTime;
            healthBar.SetHealth(current_health);
        }

        //update health bar
        if (current_health < max_health)
        {
            current_health += health_regen_rate * Time.deltaTime;
            healthBar.SetHealth(current_health);
        }
        
        //die
        if (current_health < 0)
        {
            Time.timeScale = 0;
        }
    }

    void TakeDamage(int damage)
    {
        current_health -= damage;

        healthBar.SetHealth(current_health);
    }
}
