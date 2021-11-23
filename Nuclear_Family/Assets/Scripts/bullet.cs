using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    public float speed = 20f;
    public int damage = 40;
    public float JumpForce = 30;
    public Rigidbody2D rb;
    // private Rigidbody2D rig;
    public GameObject impactEnemyEffect;
    public GameObject impactPlatEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Platform") {
            Instantiate(impactPlatEffect, transform.position, transform.rotation);
        } else {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
                //Instantiate(impactEnemyEffect, transform.position, transform.rotation);
            }
        }
        Destroy(gameObject);
    }
}
