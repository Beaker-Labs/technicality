using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Weapon Properties")]
    public float FireRate; // Rate of fire in RPM
    private float _fireDelay; // time in seconds between each shot, calculated from FireRate
    
    [Header("Bullet Properties")]
    public float projectileSpeed;
    public int projectileDamage;

    private GameObject bullet;
    private float lastTimeFired;

    void Start()
    {
        _fireDelay = 60 / FireRate;
        bullet = GameInfo.Bullet;
    }

    public void Fire()
    {
        if (Time.time > lastTimeFired + _fireDelay)
        {
            lastTimeFired = Time.time;
            Projectile bulletClone = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Projectile>();
            bulletClone.speed = projectileSpeed;
            bulletClone.damage = projectileDamage;
        }
    }
}
