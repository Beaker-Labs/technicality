using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

// This is the root controller script for vehicles.
[RequireComponent(typeof(Chassis))]
[RequireComponent(typeof(Rigidbody2D))]
public class VehicleController : MonoBehaviour
{
    [Header("Placeholder Stat overrides")]
    // Serialization of these is a placeholder, they will eventually be determined by chassis and equipment
    [SerializeField] private float _rotSpeed = 200;
    [SerializeField] private float _rotAccel = 500;
    [SerializeField] private float _maxSpeed = 50;
    [SerializeField] private float _accel = 10;
    [SerializeField] private float _friction = 30;

    // [HideInInspector]public bool isPlayerControlled;
    
    private int _hitPoints; // Current HP, Max is drawn from Template
    private bool _alive = true;

    private Driver _driver;

    private Vehicle _loadout;
    private Chassis _chassis;
    private Rigidbody2D _rigidbody2D;
    private List<WeaponMount> _weapons;
    //private InputMaster _input;
    private Camera _mainCam;
    
    public enum MoveTypes
    {
        Tank,
        FrontSteer,
        RearSteer,
        Omni
    }
    
    void Start()
    {
        _driver = new Driver(this);
        _chassis = GetComponent<Chassis>();
        _hitPoints = _chassis.HitPoints;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //_input = new InputMaster();
        //_input.Vehicle.Enable();
        _weapons = GetComponentsInChildren<WeaponMount>().ToList();
        _mainCam = Camera.main;
    }

    public void Initialize(Vehicle loadout)
    {
        // delete any placeholder weapons in the prefab
        foreach (Weapon w in GetComponentsInChildren<Weapon>())
        {
            Destroy(w.gameObject);
        }

        WeaponMount[] wm = GetComponentsInChildren<WeaponMount>();
        for (int i = 0; i < wm.Length; i++)
        {
            wm[i].AddWeapon(loadout.Weapons[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float hor = 0;
        float ver = 0;

        // Old method that directly polled for player input
        // if (isPlayerControlled)
        // {
        //     hor = _input.Vehicle.Left.ReadValue<float>() - _input.Vehicle.Right.ReadValue<float>();
        //     ver = _input.Vehicle.Forward.ReadValue<float>() - _input.Vehicle.Backward.ReadValue<float>();
        //
        //     bool fire = _input.Vehicle.Fire.ReadValue<float>() > 0.5;
        //     foreach (WeaponMount weapon in _weapons)
        //     {
        //         weapon.SetTarget(_mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        //         if (fire) weapon.Fire();
        //     }
        // }
        // else
        // {
        //     foreach (WeaponMount weapon in _weapons)
        //     {
        //         weapon.UnsetTarget();
        //     }            
        // }

        _driver.Update();
        hor = _driver.Steer;
        ver = _driver.Throttle;
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



        // ---- ROTATION ----
        // Calculate desired rotation speed
        float rotDesired = hor * _rotSpeed;
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
        float velDesired = _maxSpeed * ver;
        float fwdVel = velProjFwd.magnitude;
        if (Vector3.Dot(velProjFwd.normalized, transform.up) < 0) fwdVel = -fwdVel;
        float velDelta = velDesired - fwdVel;
        velDelta = Mathf.Min(Mathf.Abs(velDelta), _accel * Time.deltaTime) * Mathf.Sign(velDelta);
        
        // Apply acceleration
        _rigidbody2D.velocity += velDelta * (Vector2)transform.up;
    }

    public void TakeDamage(int Damage)
    {
        _hitPoints -= Damage;
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

    public int GetHitPoints()
    {
        return _hitPoints;
    }
}
