using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

// This is the root controller script for vehicles.
[RequireComponent(typeof(Chassis))]
[RequireComponent(typeof(Rigidbody2D))]
public class VehicleController : MonoBehaviour
{
    [Header("Object Links")]
    public List<WeaponMount> WeaponMounts;

    [Header("Placeholder Stat overrides")]
    // Serialization of these is a placeholder, they will eventually be determined by chassis and equipment
    private float _rotSpeed = 200;
    private float _rotAccel = 600;
    private float _maxSpeed = 600;
    private float _accel = 200;
    private float _friction = 400;

    // [HideInInspector]public bool isPlayerControlled;
    
    private int _hitPoints; // Current HP, Max is drawn from Template
    private bool _alive = true;
    private bool _active;

    private Driver _driver;
    
    private Vehicle _loadout;
    private Chassis _chassis;
    private Rigidbody2D _rigidbody2D;
    private List<WeaponMount> _weapons;
    private Camera _mainCam;

    public void Initialize(Vehicle loadout)
    {
        _loadout = loadout;
        _chassis = GetComponent<Chassis>();
        _hitPoints = _loadout.GetMaxHitPoints();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _weapons = GetComponentsInChildren<WeaponMount>().ToList();
        
        switch (_loadout.Driver)
        {
            case 0:
                _driver = new PlayerControlledDriver(this);
                break;
            case 1:
                _driver = new ErraticDriver(this);
                break;
            case 2:
                _driver = new AggressiveDriver(this);
                break;
            case 3:
                _driver = new RandomDriver(this);
                break;
            case 4:
                _driver = new FlankingDriver(this);
                break;
        }

        float speedFactor = (float)_loadout.Engine.power / _loadout.GetWeight();
        _rotSpeed *= speedFactor;
        _rotAccel *= speedFactor;
        _maxSpeed *= speedFactor;
        _accel *= speedFactor;
        _friction *= speedFactor;
    }

    void Start()
    {
        _mainCam = Camera.main;
    }

    // public void SetDriver(bool playerControlled)
    // {
    //     if (playerControlled)
    //     {
    //         _driver = new PlayerControlledDriver(this);
    //         return;
    //     }
    //
    //
    //     _driver = playerControlled ? new PlayerControlledDriver(this) : new RandomDriver(this);
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float steer = 0;
        float throttle = 0;

        if (_alive && _active)
        {
            _driver.Update();
            steer = Mathf.Clamp(_driver.Steer, -1, 1);
            throttle = Mathf.Clamp(_driver.Throttle, -1, 1);
        
        
            if (_driver.TargetSet)
            {
                foreach (WeaponMount weapon in _weapons)
                {
                    weapon.SetTarget(_driver.Target);
                }
            }
            else
            {
                foreach (WeaponMount weapon in _weapons)
                {
                    weapon.UnsetTarget();
                }
            }
            if (_driver.Fire)
            {
                foreach (WeaponMount weapon in _weapons)
                {
                    weapon.Fire();
                }
            }
        }


        // ---- ROTATION ----
        // Calculate desired rotation speed
        float rotDesired = steer * _rotSpeed;
        // calculate required change in rotation
        float rotDelta = rotDesired - _rigidbody2D.angularVelocity;
        // limit delta to rotational accel
        rotDelta = Mathf.Min(Mathf.Abs(rotDelta), _rotAccel * Time.deltaTime) * Mathf.Sign(rotDelta);
        // Apply rotation force in attempt to achieve desired rotspeed
        _rigidbody2D.angularVelocity += rotDelta;


        // ---- TRANSLATION ----
        // Apply friction perpendicularly to facing to counter sideslip
        Vector3 velProjRight = Vector3.Project(_rigidbody2D.velocity, transform.right);
        float sideVel = velProjRight.magnitude;
        if (Vector3.Dot(velProjRight.normalized, transform.right) < 0) sideVel = -sideVel;
        float frictionForce = Mathf.Min(Mathf.Abs(sideVel), _friction * Time.deltaTime) * Mathf.Sign(sideVel);
        
        // Apply friction
        _rigidbody2D.velocity += -frictionForce * (Vector2)transform.right;
        

        // Calculate desired velocity (vector2) based on input and facing
        Vector3 velProjFwd = Vector3.Project(_rigidbody2D.velocity, transform.up);
        float velDesired = _maxSpeed * throttle;
        float fwdVel = velProjFwd.magnitude;
        if (Vector3.Dot(velProjFwd.normalized, transform.up) < 0) fwdVel = -fwdVel;
        float velDelta = velDesired - fwdVel;
        velDelta = Mathf.Min(Mathf.Abs(velDelta), _accel * Time.deltaTime) * Mathf.Sign(velDelta);
        
        // Apply acceleration
        _rigidbody2D.velocity += velDelta * (Vector2)transform.up;
    }

    public void TakeDamage(int damage)
    {
        if (_hitPoints <= 0) return;
        
        _hitPoints -= math.max(1, damage - _loadout.Armor.Armor);

        if(_hitPoints <= 0)
        {
            Debug.Log($"{name} has died :(");
            _alive = false;
            foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
        }
    }

    public bool IsAlive()
    {
        return _alive;
    }

    // Call to activate the vehicle so it can move and shoot
    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }
    
    public void ActivateEditMode()
    {
        
    }

    public int GetHitPoints()
    {
        return _hitPoints;
    }

    [ContextMenu("Detect Weapon Mounts")]
    private void DetectWeaponMounts()
    {
        WeaponMounts = GetComponentsInChildren<WeaponMount>().ToList();
    }

    public int GetMaxHitPoints()
    {
        return _loadout.GetMaxHitPoints();
    }

    public Vehicle GetLoadout()
    {
        return _loadout;
    }
}
