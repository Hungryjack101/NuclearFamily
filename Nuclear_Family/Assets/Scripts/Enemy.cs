using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
	public int maxHealth = 100;
    public int current_health;
    public HealthBar healthBar;
    public float min=2f;
    public float max=3f;
    public float speed;
    public bool updown;
    // public Animator animator = GetComponent<Animator>();
    // public GameObject deathEffect;
    
    void Start() {
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
        if (updown) {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time*speed,max-min)+min);
        } else {    
            transform.position = new Vector2(Mathf.PingPong(Time.time*speed,max-min)+min, transform.position.y);
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