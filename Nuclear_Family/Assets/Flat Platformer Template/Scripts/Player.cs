using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public float WalkSpeed;
    public float JumpForce;
    public AnimationClip _walk, _jump;
    public Animation _Legs;
    public Transform _Blade, _GroundCast, _FirePoint;
    public Camera cam;
    public bool mirror;


    private bool _canJump, _canWalk;
    private bool _isWalk, _isJump;
    private float rot, _startScale;
    private Rigidbody2D rig;
    private Vector2 _inputAxis;
    private RaycastHit2D _hit;
    
    public int maxHealth = 200;
    public int current_health;
    public HealthBar healthBar;
    
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public bool gunjump = false;
    
    public bool nextLevel = false;
    private GameHandler gamehandler;

	void Start ()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
        current_health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gamehandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
	}

    void Update()
    {
        if(_Blade.position.y < -20) {
            Die();
        }
        if (nextLevel) {
            nextLevel=false;
            gamehandler.GoToNextLevel();
            
        }
        if (_hit = Physics2D.Linecast(new Vector2(_GroundCast.position.x, _GroundCast.position.y + 0.2f), _GroundCast.position))
        {
            if (!_hit.transform.CompareTag("Player"))
            {
                _canJump = true;
                _canWalk = true;
            }
        }
        else _canJump = false;

        _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_inputAxis.y > 0 && _canJump)
        {
            _canWalk = false;
            _isJump = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - _Blade.transform.position;
        dir.Normalize();

        if (cam.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + 0.2f)
            mirror = false;
        if (cam.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - 0.2f)
            mirror = true;

        if (!mirror)
        {
            rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(_startScale, _startScale, 1);
            _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
            _FirePoint.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
        if (mirror)
        {
            rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(-_startScale, _startScale, 1);
            _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
            _FirePoint.transform.rotation = Quaternion.AngleAxis(rot - 180, Vector3.forward);
        }
        
        if(knockbackCount <= 0) {
            if (_inputAxis.x != 0)
            {
                rig.velocity = new Vector2(_inputAxis.x * WalkSpeed * Time.deltaTime, rig.velocity.y);
    
                if (_canWalk)
                {
                    _Legs.clip = _walk;
                    _Legs.Play();
                }
            }
    
            else
            {
                rig.velocity = new Vector2(0, rig.velocity.y);
            }
            
            if (_isJump)
            {
                rig.AddForce(new Vector2(0, JumpForce));
                _Legs.clip = _jump;
                _Legs.Play();
                _canJump = false;
                _isJump = false;
            }
        } else {
            if (gunjump) {
                float X = cam.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
                float Y = cam.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
                float norm_X = X/Mathf.Sqrt(X*X+Y*Y);
                float norm_Y = Y/Mathf.Sqrt(X*X+Y*Y);
                rig.velocity = new Vector2(-18*norm_X,-18*norm_Y);
            } else if (knockFromRight) {
                rig.velocity = new Vector2(-knockback, knockback);
            } else if (!knockFromRight) {
                rig.velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }
    }

    public bool IsMirror()
    {
        return mirror;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _GroundCast.position);
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
        gamehandler.RickIsDead();
		Destroy(gameObject);
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") {
            knockbackCount = knockbackLength * 2;
            gunjump = false;
            if (other.transform.position.x > transform.position.x) {
                knockFromRight = true;
            } else {
                knockFromRight = false;
            }
            TakeDamage(8);
        }
        if(other.gameObject.tag == "Trophy") {
            nextLevel = true;
        }
    }
    
    public void dotheJump() {
        gunjump = true;
        knockbackCount = knockbackLength * 2;
    }
}