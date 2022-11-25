using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMount : MonoBehaviour
{
    public float turnRate;
    public bool isFixed;
    public bool fullRotation;
    public float rotationLimitMin;
    public float rotationLimitMax;
    
    private Camera _mainCam;
    private Vector2 _mousePos;
    private float _currentAngle = 180; // 180 is center
    private Gun _weapon;

    // Start is called before the first frame update
    void Start()
    {
        _weapon = GetComponentInChildren<Gun>();
        _mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        Vector2 direction = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // I think moveTowardsAngle will cross over the back while movetowards wont?
        if (fullRotation)
        {
            _currentAngle = Mathf.MoveTowardsAngle(_currentAngle, angle, turnRate * Time.deltaTime);
        }
        else
        {
            _currentAngle = Mathf.MoveTowards(_currentAngle, angle, turnRate * Time.deltaTime);
        }

        transform.localRotation = Quaternion.AngleAxis(_currentAngle - 90, Vector3.forward);
    }

    public void Fire()
    {
        _weapon.Fire();
    }
}
