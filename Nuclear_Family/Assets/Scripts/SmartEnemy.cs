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
    private Rigidbody2D rig;
    
    void Start() {
        current_health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerscript = GameObject.Find("Rick").GetComponent<Player>();
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 dir = (playerscript._Blade.transform.position - transform.position).normalized;
        dir.z = 0f;
        if (!omnidirectional) {
            dir.y = 0f;
        }
        rig.MovePosition(transform.position + dir * speed * Time.deltaTime);
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
		Destroy(gameObject);
	}
}