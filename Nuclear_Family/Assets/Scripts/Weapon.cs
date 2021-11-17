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
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
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
