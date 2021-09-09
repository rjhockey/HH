using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb; // pull rigidbody in inspector down to fill slot

    // Start is called before the first frame update
    void Start()
    {
        //velocity is current velocity
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }    
    }

    //// hitInfo to store info about what was hit
    //private void OnTrigger2D(Collider2D hitInfo)
    //{
    //    Enemy enemy = hitInfo.GetComponent<Enemy>();
    //    if (enemy != null)
    //    {
    //        // amount of damage in (), could be saved in variable set at top
    //        enemy.TakeDamage(10);
    //    }
    //    // impactEffect hasn't actually been created
    //    // bullet explosion named impactEffect, drag that prefab onto slot
    //    //Instantiate(impactEffect, transform.position, transform.rotation)
    //    Destroy(gameObject);    
    //}
}
