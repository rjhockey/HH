using UnityEngine;

public class Player : MonoBehaviour
{
    //attach this script to player

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar; // unity drag health bar into slot

    void Start()
    {
        // set max health at startup
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);
    }

    //update and take damage below in place only to test healthbar by pressing spacebar
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        // decrease life 10%. could make this a variable to have control in unity inspector
    //        TakeDamage(10); 
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Life"))
        {
            Destroy(collision.gameObject);
            // increase life 10% of healthbar
            GainLife(10); 
        }

        else if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            // increase life 10% of healthbar
            TakeDamage(10);
        }
    }

    // decreases life on healthbar
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    // adds life on healthbar
    void GainLife(int life)
    {
        currentHealth += life;

        healthBar.SetHealth(currentHealth);
    }
}
