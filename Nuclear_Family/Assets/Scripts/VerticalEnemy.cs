using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemy : MonoBehaviour {
    
	public int maxHealth = 100;
    public int current_health;
    public HealthBar healthBar;
    public float min;
    public float max;
    public float speed;
    // public GameObject deathEffect;
    
    void Start() {
        current_health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        min=transform.position.y-2;
        max=transform.position.y+2;
    }
    
    void Update() {
        transform.position =new Vector3(transform.position.x, Mathf.PingPong(Time.time*speed,max-min)+min, transform.position.z);
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