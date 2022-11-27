using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMount : MonoBehaviour
{
    public float offset; // Angle (cw) from 'forward' of the turret's resting position.
    public float turnRate;
    public bool isFixed;
    public bool fullRotation;
    public float rotationLimitMin = -180;
    public float rotationLimitMax = 180;
    
    private Camera _mainCam;
    private Vector2 _target;
    private bool _active;
    private float _currentAngle; // offset is center
    private Gun _weapon;

    // Start is called before the first frame update
    void Start()
    {
        _weapon = GetComponentInChildren<Gun>();
        _mainCam = Camera.main;
        _currentAngle = offset;
    }
    
    

    void FixedUpdate()
    {
        float desiredAngle = offset + -transform.parent.rotation.eulerAngles.z;
        
        if (_active)
        {
            Vector2 targetDir = _target - (Vector2)transform.position;
            float targetAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            float targetAngleOriginal = targetAngle; // This is only for debug. remove when done.

            if (targetAngle > 180 + offset + transform.parent.rotation.eulerAngles.z)
            {
                targetAngle -= 360;
            }
            
            if (targetAngle < -180 + offset + transform.parent.rotation.eulerAngles.z)
            {
                targetAngle += 360;
            }
            
            desiredAngle += targetAngle - offset;

            if (targetAngle == targetAngleOriginal)
            {
                Debug.Log($"targetAngle: {targetAngle}, desiredAngle: {desiredAngle}");
            }
            else
            {
                Debug.Log($"targetAngle: {targetAngle}, original targetAngle: {targetAngleOriginal}, desiredAngle: {desiredAngle}");
            }
        }
        

        // moveTowardsAngle will cross over the back while moveTowards wont
        if (fullRotation)
        {
            _currentAngle = Mathf.MoveTowardsAngle(_currentAngle, desiredAngle, turnRate * Time.deltaTime);
        }
        else
        {
            _currentAngle = Mathf.MoveTowards(_currentAngle, desiredAngle, turnRate * Time.deltaTime);
            _currentAngle = Mathf.Clamp(_currentAngle, rotationLimitMin + offset, rotationLimitMax + offset);
        }

        transform.localRotation = Quaternion.AngleAxis(_currentAngle - 90, Vector3.forward);
    }

    public void SetTarget(Vector2 targetPoint)
    {
        _active = true;
        _target = targetPoint;
    }

    public void UnsetTarget()
    {
        _active = false;
    }

    public void Fire()
    {
        _weapon.Fire();
    }
}
