using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //bullet properties
    public GameObject bullet;
    public float delay;
    public float projectileSpeed;
    public int projectileDamage;

    private float previousTime = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > previousTime )
        {
            previousTime = Time.time + delay;
            shootBullet();
        }
    }

    void shootBullet()
    {
        var bulletClone = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Projectile>();
        bulletClone.speed = projectileSpeed;
        bulletClone.damage = projectileDamage;
    }
}
