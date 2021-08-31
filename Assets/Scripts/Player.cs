using UnityEngine;

public class Player : MonoBehaviour
{
    //attach this script to player

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar; // unity drag health bar into slot

    void Start()
    {
        currentHealth = maxHealth; // set max health at startup
        healthBar.SetMaxHealth(maxHealth);
    }

    //update and take damage below in place only to test healthbar by pressing spacebar
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
