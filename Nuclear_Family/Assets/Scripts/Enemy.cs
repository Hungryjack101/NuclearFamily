using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
	public int maxHealth = 100;
    public int current_health;
    public HealthBar healthBar;
    // public GameObject deathEffect;
    
    void Start() {
        current_health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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