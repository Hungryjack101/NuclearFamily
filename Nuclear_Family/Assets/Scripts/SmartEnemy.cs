using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MonoBehaviour {
    
	public int maxHealth = 100;
    public int current_health;
    public HealthBar healthBar;
    public float speed;
    public bool omnidirectional;
    private GameObject rick;
    private Player playerscript;
    private bool go = true;
    // public Animator animator = GetComponent<Animator>();
    // public GameObject deathEffect;
    
    void Start() {
        current_health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerscript = GameObject.Find("Rick").GetComponent<Player>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform") {
            go = false;
        }
    }
    
    void Update() {
        if (go == true) {
            float X = playerscript._Blade.transform.position.x;
            float Y = 0f;
            if (omnidirectional == true) {
                Y = playerscript._Blade.transform.position.x;
            }
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(X,Y), speed * Time.deltaTime);
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