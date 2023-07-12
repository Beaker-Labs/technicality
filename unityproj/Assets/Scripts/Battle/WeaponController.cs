using UnityEngine;

// Root monobehaviour for weapon prefabs/gameobjects.
// Later, this should be made abstract.
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Properties")]
    public float fireRate; // Rate of fire in RPM
    private float _fireDelay; // time in seconds between each shot, calculated from FireRate
    
    [Header("Bullet Properties")]
    public float projectileSpeed;
    public int projectileDamage;
    public float inaccuracy;

    private GameObject _bullet;
    private float _lastTimeFired;
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _fireDelay = 60 / fireRate;
        _bullet = GameInfo.Bullet;
        _rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    public virtual void Fire()
    {
        if (Time.time > _lastTimeFired + _fireDelay)
        {
            _lastTimeFired = Time.time;
            Projectile bulletClone = Instantiate(_bullet, transform.position, transform.rotation, GameInfo.GetBattleRoot()).GetComponent<Projectile>();
            bulletClone.transform.rotation *= Quaternion.Euler(0, 0, Random.Range(-inaccuracy, inaccuracy));
            bulletClone.speed = projectileSpeed;
            bulletClone.damage = projectileDamage;
            bulletClone.origin = _rigidbody;
        }
    }
}