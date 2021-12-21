using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    private float dirX;
    public float speed;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private Vector2 localScale;
    
    public int maxHealth = 100;
    public int current_health;
    public HealthBar healthBar;
    public float min;
    public float max;
    public bool updown;
    
    public float coolDown = 1;
    public float current_cool;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        current_health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        if (updown) {
            min=transform.position.y-min;
            max=transform.position.y+max;
        } else {
            min=transform.position.x-min;
            max=transform.position.x+max;
        }
    }
    
    void Update() {
        if (current_cool > 0) {
            current_cool -= Time.deltaTime;
        } else {
            current_cool = 0;
        }
        if (updown && current_cool == 0) {
            if (transform.position.y > max || transform.position.y < min) {
                dirX *= -1f;
                current_cool = coolDown;
            }
        } else if (!updown && current_cool == 0){
            if (transform.position.x > max || transform.position.x < min) {
                dirX *= -1f;
                current_cool = coolDown;
            }
        }
    }

    void FixedUpdate()
    {
        if (updown) {
            rb.velocity = new Vector2(rb.velocity.x, dirX * speed);
        } else {
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        }
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (!updown) {
            if (dirX > 0)
                facingRight = true;
            else if (dirX < 0)
                facingRight = false;

            if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
                localScale.x *= -1;

            transform.localScale = localScale;
        }
    }
    
    public void TakeDamage (int damage) 
    { 
        current_health -= damage;
        healthBar.SetHealth(current_health);
		if (current_health <= 0)
        {
            Die();
		}
	}

	void Die() 
    { 
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
// 
// public int maxHealth = 100;
//     public int current_health;
//     public HealthBar healthBar;
//     public float min;
//     public float max;
//     public float speed;
//     public bool updown;
// 
//     void Start() {
//         current_health = maxHealth;
//         healthBar.SetMaxHealth(maxHealth);
//         if (updown) {
//             min=transform.position.y-min;
//             max=transform.position.y+max;
//         } else {
//             min=transform.position.x-min;
//             max=transform.position.x+max;
//         }
//     }
// 
//     void Update() {
//         if (updown) {
//             transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time*speed,max-min)+min);
//         } else {    
//             transform.position = new Vector2(Mathf.PingPong(Time.time*speed,max-min)+min, transform.position.y);
//         }
//     }
// 	public void TakeDamage (int damage) 
//     { 
//         current_health -= damage;
//         healthBar.SetHealth(current_health);
// 		if (current_health <= 0)
//         {
//             Die();
// 		}
// 	}
// 
// 	void Die() 
//     { 
//         // Instantiate(deathEffect, transform.position, Quaternion.identity);
// 		Destroy(gameObject);
// 	}
// }