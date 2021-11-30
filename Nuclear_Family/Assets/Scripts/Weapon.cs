using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefab;
    public Player Rick;
    // public Rigidbody2D rig;
    public int GunForce = 30;
    
    public float coolDown = 2;
    public float current_cool;
    public CoolDownBar coolDownTimer;
    // Start is called before the first frame update
    
    private PauseMenu pauseScript;
    void Start() {
        
    }
    
    void Update()
    {
        if (current_cool > 0) {
            current_cool -= Time.deltaTime;
        } else {
            current_cool = 0;
        }
        coolDownTimer.SetCool(coolDown-current_cool);
        bool GamePaused = PauseMenu.GameisPaused;
        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
             && !GamePaused && current_cool == 0) {
            coolDownTimer.SetMaxBar(coolDown);
            current_cool = coolDown;
            Shoot();
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rick.dotheJump();
    }
}
