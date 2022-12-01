using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : EquippableItem
{
    [Header("Weapon Properties")]
    public float FireRate; // Rate of fire in RPM
    private float _fireDelay; // time in seconds between each shot, calculated from FireRate
    
    [Header("Bullet Properties")]
    public float projectileSpeed;
    public int projectileDamage;

    private GameObject _bullet;
    private float _lastTimeFired;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _fireDelay = 60 / FireRate;
        _bullet = GameInfo.Bullet;
        _rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    public void Fire()
    {
        if (Time.time > _lastTimeFired + _fireDelay)
        {
            _lastTimeFired = Time.time;
            Projectile bulletClone = Instantiate(_bullet, transform.position, transform.rotation, GameInfo.GetBattleRoot()).GetComponent<Projectile>();
            bulletClone.speed = projectileSpeed;
            bulletClone.damage = projectileDamage;
            bulletClone.origin = _rigidbody;
        }
    }
}
